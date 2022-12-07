using Cimas.Storage.Configuration;
using Cimas.Storage.Repositories.Cinemas;
using Cimas.Storage.Repositories.Companies;
using Cimas.Storage.Repositories.Users;
using System;
using System.Threading.Tasks;

namespace Cimas.Storage.Uow
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CimasDbContext _context;

        public ICompanyRepository Companies { get; }
        public IUserRepository Users { get; }
        public ICinemaRepository Cinemas { get; }//+

        public UnitOfWork(CimasDbContext context)
        {
            _context = context;

            Companies = new CompanyRepository(_context);
            Users = new UserRepository(_context);
            Cinemas = new CinemaRepository(_context);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
