using Cimas.Entities.Halls;
using Cimas.Service.Halls.Descriptors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimas.Service.Halls
{
    public interface IHallService
    {
        Task<int> AddHallAsync(AddHallDescriptor descriptor);
        Task DeleteHallAsync(int hallId);
        Task<IEnumerable<Hall>> GetHallsByCinemaIdAsync(int cinemaId);

    }
}
