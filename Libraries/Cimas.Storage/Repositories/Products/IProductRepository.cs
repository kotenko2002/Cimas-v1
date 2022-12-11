using Cimas.Entities.Products;
using Cimas.Storage.Configuration.BaseRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimas.Storage.Repositories.Products
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByWorkDayIdAsync(int workDayId);
    }
}
