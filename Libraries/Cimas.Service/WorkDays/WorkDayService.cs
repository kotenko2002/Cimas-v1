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
            WorkDay workDay = new WorkDay()
            {
                UserId = descriptor.UserId,
                CinemaId = descriptor.CinemaId,
                StartDateTime = DateTime.Now
            };

            _uow.WorkDayRepository.Add(workDay);
            await _uow.CompleteAsync();

            return workDay.Id;
        }

        public async Task<bool> UserHasNotFinishedWorkDayAsync(int userId)
        {
            return await _uow.WorkDayRepository.GetNotFinishedWorkDayOfUserAsync(userId) != null;
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

        public async Task<IEnumerable<FullReportView>> GetReportsListByCompanyIdAsync(int cinemaId)
        {
            var views = await _uow.ReportRepository.GetReportsListByCompanyIdAsync(cinemaId);

            foreach (var view in views)
            {
                view.Profit = await _uow.ProductRepository.GetProfitByWorkDayId(view.WorkDayId);
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
