using Cimas.Entities.Companies;
using Microsoft.EntityFrameworkCore;

namespace Cimas.Storage.Configuration
{
    public class CimasDbContext : DbContext
    {
        public CimasDbContext(DbContextOptions<CimasDbContext> opt) : base(opt)
        {

        }
        
        public DbSet<Company> Companies { get; set; }
    }
}
