using Puppies.Model.Base;

namespace Homework6.Services.Base
{
    public interface IService<T> where T : BaseItem
    {
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> RemoveAsync(T entity);
        Task<T> FindAsync(int? id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
