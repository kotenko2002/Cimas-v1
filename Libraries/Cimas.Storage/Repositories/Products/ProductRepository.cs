using Cimas.Entities.Products;
using Cimas.Storage.Configuration;
using Cimas.Storage.Configuration.BaseRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cimas.Storage.Repositories.Products
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(CimasDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Product>> GetProductsByWorkDayIdAsync(int workDayId)
        {
            return await Sourse.Where(item => item.WorkDayId == workDayId).ToListAsync();
        }
    }
}
