using Cimas.Entities.Cinemas;
using Cimas.Service.Cinemas.Descriptors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimas.Service.Cinemas
{
    public interface ICinemaService
    {
        Task<int> AddCinemaAsync(AddCinemaDescriptor descriptor);
        Task DeleteCinemaAsync(int cinemaId);
        Task<IEnumerable<Cinema>> GetCinemasByComnapyIdAsync(int companyId);
    }
}
