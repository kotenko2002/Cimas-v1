using Cimas.Entities.Areas;
using Cimas.Entities.Companies;
using Cimas.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Cimas.Storage.Configuration
{
    public class CimasDbContext : DbContext
    {
        public CimasDbContext(DbContextOptions<CimasDbContext> opt) : base(opt)
        {

        }
        
        public DbSet<Company> Companies { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasIndex(u => u.Login).IsUnique();
        }
    }
}
