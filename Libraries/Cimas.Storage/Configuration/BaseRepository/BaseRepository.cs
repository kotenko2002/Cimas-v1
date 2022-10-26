using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimas.Storage.Configuration.BaseRepository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected CimasDbContext _context;
        protected DbSet<TEntity> Sourse;

        public BaseRepository(CimasDbContext context)
        {
            _context = context;
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
