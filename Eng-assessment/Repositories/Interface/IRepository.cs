using Models.Entities.Base;

namespace Eng_assessment.Repositories.Interface
{
    public interface IRepository<T> where T : DatabaseEntity
    {
        Task<T> GetAsync(long id, bool includeInactive = false);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveChangesAsync();
    }
}
