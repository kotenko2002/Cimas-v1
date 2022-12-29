using Cimas.Entities.Reports;
using Cimas.Entities.WorkDays;
using Cimas.Service.WorkDays.Descriptors;
using Cimas.Storage.Repositories.Reports.Views;
using Cimas.Storage.Uow;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using Cimas.Сommon.Enums;
using Cimas.Сommon.Exceptions;
using Cimas.Entities.Products;
using Cimas.Storage.Repositories.SessionSeats.Filters;

namespace Cimas.Service.WorkDays
{
    public class WorkDayService : IWorkDayService
    {
        private readonly IUnitOfWork _uow;

        public WorkDayService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> StartWorkDayAsync(StartWorkDayDescriptor descriptor)
        {
            var notFinishedWorkday = await _uow.WorkDayRepository.GetNotFinishedWorkDayOfUserAsync(descriptor.UserId);
            if(notFinishedWorkday != null)
            {
                throw new BusinessLogicException("User has an unfinished workday");
            }

            var cinemaNotFinishedWorkday = await _uow.WorkDayRepository.GetNotFinishedWorkDayOfCinemaAsync(descriptor.CinemaId);
            if(cinemaNotFinishedWorkday != null)
            {
                var anotherUser = await _uow.UserRepository.FindAsync(cinemaNotFinishedWorkday.UserId);
                throw new BusinessLogicException($"{anotherUser.Name} has already started his working day in this cinema");
            }

            WorkDay newWorkDay = new WorkDay()
            {
                UserId = descriptor.UserId,
                CinemaId = descriptor.CinemaId,
                StartDateTime = DateTime.Now
            };

            var oldWorkDay = await _uow.WorkDayRepository.GetClosestWorkdayInCinemaByDataTimeAsync(
                newWorkDay.CinemaId, newWorkDay.StartDateTime);

            if(oldWorkDay != null)
            {
                var oldProducts = await _uow.ProductRepository.GetProductsByWorkDayIdAsync(oldWorkDay.Id);
                var newProducts = oldProducts.Select(item => new Product()
                {
                    WorkDay = newWorkDay,
                    Name = item.Name,
                    Price = item.Price,
                    Amount = item.Amount + item.Incoming - item.SoldAmount,
                    SoldAmount = 0,
                    Incoming = 0,
                });

                _uow.ProductRepository.AddRange(newProducts);
            }

            _uow.WorkDayRepository.Add(newWorkDay);
            await _uow.CompleteAsync();

            return newWorkDay.Id;
        }

        public async Task<bool> UserHasNotFinishedWorkDayAsync(int userId)
        {
            var workday = await _uow.WorkDayRepository.GetNotFinishedWorkDayOfUserAsync(userId);
            return workday != null;
        }

        public async Task<WorkDay> GetNotFinishedWorkDayOfUserAsync(int userId)
        {
            var workDay = await _uow.WorkDayRepository.GetNotFinishedWorkDayOfUserAsync(userId);

            if (workDay == null)
            {
                throw new Exception("User doesn't have not finished workDay.");
            }

            return workDay;
        }

        public async Task EndWorkDayAsync(int workDayId)
        {
            var workDay = await _uow.WorkDayRepository.FindAsync(workDayId);
            workDay.EndDateTime = DateTime.Now;

            var report = new Report()
            {
                WorkDayId = workDayId,
                Status = RepostStatus.NotReviewed
            };
            _uow.ReportRepository.Add(report);
            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<FullReportView>> GetReportsListByCompanyIdAsync(int companyId)
        {
            var views = await _uow.ReportRepository.GetReportsListByCompanyIdAsync(companyId);

            foreach (var view in views)
            {
                view.Profit = await _uow.ProductRepository.GetProfitByWorkDayId(view.WorkDayId);

                var filter = new CountProfitFilter()
                {
                    CinemaId = view.CinemaId,
                    StartDateTime = view.StartDateTime,
                    EndDateTime = view.EndDateTime
                };
                view.Profit += await _uow.SessionSeatRepository.GetProfit(filter);
            }

            return views;
        }

        public async Task EditReportAsync(EditReportDescriptor descriptor)
        {
            var report = await _uow.ReportRepository.FindAsync(descriptor.Id);

            report.Status = descriptor.Status;
            await _uow.CompleteAsync();
        }
    }
}
