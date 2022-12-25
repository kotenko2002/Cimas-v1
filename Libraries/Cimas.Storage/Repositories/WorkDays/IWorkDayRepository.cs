using Cimas.Entities.WorkDays;
using Cimas.Storage.Configuration.BaseRepository;
using System;
using System.Threading.Tasks;

namespace Cimas.Storage.Repositories.WorkDays
{
    public interface IWorkDayRepository : IBaseRepository<WorkDay>
    {
        Task<WorkDay> GetNotFinishedWorkDayOfUserAsync(int userId);
        Task<WorkDay> GetClosestWorkdayInCinemaByDataTimeAsync(int cinemaId, DateTime dateTime);
    }
}
