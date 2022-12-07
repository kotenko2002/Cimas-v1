using Cimas.Storage.Configuration;
using Cimas.Storage.Repositories.Cinemas;
using Cimas.Storage.Repositories.Companies;
using Cimas.Storage.Repositories.Films;
using Cimas.Storage.Repositories.Halls;
using Cimas.Storage.Repositories.Sessions;
using Cimas.Storage.Repositories.Users;
using System;
using System.Threading.Tasks;

namespace Cimas.Storage.Uow
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CimasDbContext _context;

        public ICompanyRepository CompanyRepository { get; }
        public IUserRepository UserRepository { get; }
        public ICinemaRepository CinemaRepository { get; }
        public IFilmRepository FilmRepository { get; }
        public IHallRepository HallRepository { get; }
        public ISessionRepository SessionRepository { get; }

        public UnitOfWork(CimasDbContext context)
        {
            _context = context;

            CompanyRepository = new CompanyRepository(_context);
            UserRepository = new UserRepository(_context);
            CinemaRepository = new CinemaRepository(_context);
            FilmRepository = new FilmRepository(_context);
            HallRepository = new HallRepository(_context);
            SessionRepository = new SessionRepository(_context);
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
