using Cimas.Entities.Reports;
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

        public async Task<Report> GetFullReportByReportId(int reportId)
        {
            return await Sourse
                .Include(report => report.WorkDay)
                    .ThenInclude(workDay => workDay.Cinema)
                .Include(report => report.WorkDay)
                    .ThenInclude(workDay => workDay.User)
                .FirstOrDefaultAsync(item => item.Id == reportId);
        }

        public async Task<IEnumerable<ShortReportForReviewerView>> GetShortReportsByCinemaId(int cinemaId)
        {
            var temp = await Sourse
                .Include(report => report.WorkDay)
                .Where(report => report.WorkDay.CinemaId == cinemaId)
                .Select(report => new ShortReportForReviewerView()
                {
                    Id = report.Id,
                    StartDateTime = report.WorkDay.StartDateTime,
                    EndDateTime = (System.DateTime)report.WorkDay.EndDateTime,
                    Status = report.Status
                })
                .OrderByDescending(report => report.StartDateTime)
                .ToListAsync();

            return temp;
        }
    }
}
