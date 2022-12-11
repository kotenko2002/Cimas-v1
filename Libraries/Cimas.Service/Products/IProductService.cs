using Cimas.Entities.Products;
using Cimas.Service.Products.Descriptors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimas.Service.Products
{
    public interface IProductService
    {
        Task<int> AddProductAsync(AddProductDescriptor descriptor);
        Task EditProductsAsync(int workDayId, IEnumerable<EditProductDescriptor> descriptors);
        Task DeleteProductAsync(int productId);
        Task<IEnumerable<Product>> GetProductsByWorkDayIdAsync(int workDayId);
    }
}
