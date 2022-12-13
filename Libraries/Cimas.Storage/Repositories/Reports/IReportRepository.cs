using Cimas.Entities.Reports;
using Cimas.Storage.Configuration.BaseRepository;
using Cimas.Storage.Repositories.Reports.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimas.Storage.Repositories.Reports
{
    public interface IReportRepository : IBaseRepository<Report>
    {
        Task<IEnumerable<FullReportView>> GetReportsListByCompanyIdAsync(int cinemaId);
    }
}
