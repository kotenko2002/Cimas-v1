using Cimas.Service.Halls.Descriptors;
using System.Threading.Tasks;

namespace Cimas.Service.Halls
{
    public interface IHallService
    {
        Task AddHallAsync(AddHallDescriptor descriptor);
    }
}
