using Cimas.Entities.WorkDays;
using Cimas.Storage.Configuration;
using Cimas.Storage.Configuration.BaseRepository;
using Microsoft.EntityFrameworkCore;
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
    }
}
