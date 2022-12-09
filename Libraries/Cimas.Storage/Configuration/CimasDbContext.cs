using Cimas.Entities.Cinemas;
using Cimas.Entities.Companies;
using Cimas.Entities.Films;
using Cimas.Entities.Halls;
using Cimas.Entities.Products;
using Cimas.Entities.Reports;
using Cimas.Entities.Sessions;
using Cimas.Entities.Users;
using Cimas.Entities.WorkDays;
using Microsoft.EntityFrameworkCore;

namespace Cimas.Storage.Configuration
{
    public class CimasDbContext : DbContext
    {
        public DbSet<Company> Company { get; set; }
        public DbSet<Cinema> Cinema { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<WorkDay> WorkDay { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Report> Report { get; set; }
        public DbSet<Film> Film { get; set; }
        public DbSet<Hall> Hall { get; set; }
        public DbSet<HallSeat> HallSeat { get; set; }
        public DbSet<SessionSeat> SessionSeat { get; set; }
        public DbSet<Session> Session { get; set; }
        public CimasDbContext(DbContextOptions<CimasDbContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>(builder =>
            {
                builder.Property(c => c.Name).IsRequired();
            });

            modelBuilder.Entity<Cinema>(builder =>
            {
                builder
                    .HasOne(c => c.Company)
                    .WithMany(c => c.Cinemas)
                    .HasForeignKey(c => c.CompanyId);

                builder.Property(c => c.Name).IsRequired();
                builder.Property(c => c.Adress).IsRequired();
            });

            modelBuilder.Entity<User>(builder =>
            {
                builder
                    .HasOne(c => c.Company)
                    .WithMany(u => u.Users)
                    .HasForeignKey(c => c.CompanyId);

                builder.HasIndex(u => u.Login).IsUnique();

                builder.Property(u => u.Login).IsRequired();
                builder.Property(u => u.PasswordHash).IsRequired();
                builder.Property(u => u.PasswordSalt).IsRequired();
                builder.Property(u => u.Name).IsRequired();
            });

            modelBuilder.Entity<WorkDay>(builder =>
            {
                builder
                    .HasOne(wd => wd.Cinema)
                    .WithMany(c => c.WorkDays)
                    .HasForeignKey(wd => wd.CinemaId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder
                    .HasOne(wd => wd.User)
                    .WithMany(u => u.WorkDays)
                    .HasForeignKey(wd => wd.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.Property(wd => wd.StartDateTime).IsRequired();
            });

            modelBuilder.Entity<Product>(builder =>
            {
                builder
                    .HasOne(p => p.WorkDay)
                    .WithMany(wk => wk.Products)
                    .HasForeignKey(p => p.WorkDayId);

                builder.Property(p => p.Name).IsRequired();
                builder.Property(p => p.Price).HasPrecision(18, 2).IsRequired();
                builder.Property(p => p.Amount).IsRequired();
                builder.Property(p => p.SoldAmount).IsRequired();
                builder.Property(p => p.Incoming).IsRequired();
            });

            modelBuilder.Entity<Report>(builder =>
            {
                builder
                    .HasOne(r => r.WorkDay)
                    .WithMany(wk => wk.Reports)
                    .HasForeignKey(r => r.WorkDayId);

                builder.Property(r => r.Status).IsRequired();
            });

            modelBuilder.Entity<Film>(builder =>
            {
                builder
                    .HasOne(f => f.Company)
                    .WithMany(c => c.Films)
                    .HasForeignKey(c => c.CompanyId);

                builder.Property(f => f.Name).IsRequired();
                builder.Property(f => f.Duration).IsRequired();
            });

            modelBuilder.Entity<Hall>(builder =>
            {
                builder
                    .HasOne(h => h.Cinema)
                    .WithMany(c => c.Halls)
                    .HasForeignKey(h => h.CinemaId);

                builder.Property(h => h.Name).IsRequired();
            });

            modelBuilder.Entity<Session>(builder =>
            {
                builder
                    .HasOne(s => s.Film)
                    .WithMany(f => f.Sessions)
                    .HasForeignKey(s => s.FilmId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder
                    .HasOne(s => s.Hall)
                    .WithMany(h => h.Sessions)
                    .HasForeignKey(s => s.HallId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.Property(s => s.TicketPrice).HasPrecision(18, 2).IsRequired();
                builder.Property(s => s.StartDateTime).IsRequired();
                builder.Property(s => s.EndDateTime).IsRequired();
            });

            modelBuilder.Entity<HallSeat>(builder =>
            {
                builder
                    .HasOne(hs => hs.Hall)
                    .WithMany(h => h.HallSeats)
                    .HasForeignKey(hs => hs.HallId);

                builder.Property(hs => hs.Row).IsRequired();
                builder.Property(hs => hs.Column).IsRequired();
            });

            modelBuilder.Entity<SessionSeat>(builder =>
            {
                builder
                    .HasOne(ss => ss.Session)
                    .WithMany(s => s.SessionSeats)
                    .HasForeignKey(ss => ss.SessionId);

                builder.Property(ss => ss.Row).IsRequired();
                builder.Property(ss => ss.Column).IsRequired();
                builder.Property(ss => ss.Status).IsRequired();
            });
        }
    }
}
