﻿using Cimas.Entities.Reports;
using Cimas.Storage.Configuration;
using Cimas.Storage.Configuration.BaseRepository;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Cimas.Storage.Repositories.Reports.Views;
using Cimas.Storage.Uow;

namespace Cimas.Storage.Repositories.Reports
{
    public class ReportRepository : BaseRepository<Report>, IReportRepository
    {
        public ReportRepository(CimasDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<FullReportView>> GetReportsListByCompanyIdAsync(int companyId)
        {
            var temp = await Sourse
                .Include(report => report.WorkDay)
                    .ThenInclude(workDay => workDay.Cinema)
                .Where(report => report.WorkDay.Cinema.CompanyId == companyId)
                .Include(report => report.WorkDay)
                    .ThenInclude(workDay => workDay.User)
                .Select(report => new FullReportView()
                {
                    Id = report.Id,
                    WorkDayId = report.WorkDayId,
                    WorkerName = report.WorkDay.User.Name,
                    WorkerRole = report.WorkDay.User.Role,
                    StartDateTime = report.WorkDay.StartDateTime,
                    EndDateTime = (System.DateTime)report.WorkDay.EndDateTime,
                    Status = report.Status,
                }).ToListAsync();

            return temp;
        }
    }
}