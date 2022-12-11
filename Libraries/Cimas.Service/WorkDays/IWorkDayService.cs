using Cimas.Entities.WorkDays;
using Cimas.Service.WorkDays.Descriptors;
using System.Threading.Tasks;

namespace Cimas.Service.WorkDays
{
    public interface IWorkDayService
    {
        Task<int> StartWorkDayAsync(StartWorkDayDescriptor descriptor);
        Task<bool> UserHasNotFinishedWorkDayAsync(int userId);
        Task<WorkDay> GetNotFinishedWorkDayOfUserAsync(int userId);
        Task EndWorkDayAsync(int workDayId);
    }
}
