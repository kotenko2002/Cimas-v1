using Cimas.Entities.Halls;
using Cimas.Service.Halls.Descriptors;
using Cimas.Storage.Repositories.Halls.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimas.Service.Halls
{
    public interface IHallService
    {
        Task<int> AddHallAsync(AddHallDescriptor descriptor);
        Task DeleteHallAsync(int hallId);
        Task<IEnumerable<HallView>> GetHallsByCinemaIdAsync(int cinemaId);

    }
}
