using Cimas.Storage.Configuration;
using Cimas.Storage.Repositories.Areas;
using Cimas.Storage.Repositories.Companies;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cimas.Storage.Uow
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CimasDbContext _context;
        private readonly ILogger _logger;

        public ICompanyRepository Companies { get; }
        public IAreaRepository Areas { get; }
        public UnitOfWork(CimasDbContext context, ILoggerFactory logger)
        {
            _context = context;
            _logger = logger.CreateLogger("logs");

            Companies = new CompanyRepository(_context, _logger);
            Areas = new AreaRepository(_context, _logger);
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
