using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cimas.Storage.Configuration.BaseRepository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected CimasDbContext _context;
        protected DbSet<TEntity> Sourse;
        protected readonly ILogger _logger;

        public BaseRepository(CimasDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            Sourse = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            Sourse.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Sourse.AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Sourse.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Sourse.RemoveRange(entities);
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync()
        {
            return await Sourse.ToListAsync();
        }

        public async Task<TEntity> FindAsync(int id)
        {
            return await Sourse.FindAsync(id);
        }
    }
}
