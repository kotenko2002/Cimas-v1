using Cimas.Entities.WorkDays;
using Cimas.Storage.Configuration;
using Cimas.Storage.Configuration.BaseRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Cimas.Storage.Repositories.WorkDays
{
    public class WorkDayRepository : BaseRepository<WorkDay>, IWorkDayRepository 
    {
        public WorkDayRepository(CimasDbContext context) : base(context)
        {

        }
        public async Task<WorkDay> GetNotFinishedWorkDayOfUserAsync(int userId)
        {
            return await Sourse
                .FirstOrDefaultAsync(item => item.UserId == userId && item.EndDateTime == null);
        }

        public async Task<WorkDay> GetNotFinishedWorkDayOfCinemaAsync(int cinemaId)
        {
            return await Sourse
                .FirstOrDefaultAsync(item => item.CinemaId == cinemaId && item.EndDateTime == null);
        }

        public async Task<WorkDay> GetClosestWorkdayInCinemaByDataTimeAsync(int cinemaId, DateTime dateTime)
        {
            var workdays = await Sourse
                .Where(item => item.CinemaId == cinemaId && item.EndDateTime != null)
                .ToListAsync();

            var response = workdays
                .OrderBy(item => Math.Abs(((DateTime)item.EndDateTime - DateTime.Now).Ticks))
                .FirstOrDefault();

            return response;
        }
    }
}
