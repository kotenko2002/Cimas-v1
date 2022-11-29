using Cimas.Service.Companies.Descriptors;
using System.Threading.Tasks;

namespace Cimas.Service.Areas
{
    public interface IAreaService
    {
        Task<int> AddAreaAsync(AreaAddDescriptor descriptor);
    }
}
