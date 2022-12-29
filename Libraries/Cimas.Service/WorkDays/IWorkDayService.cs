using Cimas.Entities.Reports;
using Cimas.Entities.WorkDays;
using Cimas.Service.WorkDays.Descriptors;
using Cimas.Service.WorkDays.Views;
using Cimas.Storage.Repositories.Reports.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimas.Service.WorkDays
{
    public interface IWorkDayService
    {
        Task<int> StartWorkDayAsync(StartWorkDayDescriptor descriptor);
        Task<bool> UserHasNotFinishedWorkDayAsync(int userId);
        Task<WorkDay> GetNotFinishedWorkDayOfUserAsync(int userId);
        Task EndWorkDayAsync(int workDayId);
        Task<FullReportView> GetFullReportByReportId(int cinemaId);
        Task EditReportAsync(EditReportDescriptor descriptor);
        Task<IEnumerable<ShortReportForReviewerView>> GetShortReportsByCinemaId(int cinemaId);
    }
}
