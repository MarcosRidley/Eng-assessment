using Eng_assessment.Configuration;
using Eng_assessment.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Models.Entities.Base;

namespace Eng_assessment.Repositories.Base
{
    public abstract class RootRepository<TEntity> : IRepository<TEntity>
        where TEntity : DatabaseEntity
    {
        private readonly MyDbContext _context;

        protected RootRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> GetAsync(long id, bool includeInactive = false)
        {
            return await _context.Set<TEntity>().Where(entity => entity.Id == id && (includeInactive || entity.Active)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().Where(entity => entity.Active).ToListAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Update(entity);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
