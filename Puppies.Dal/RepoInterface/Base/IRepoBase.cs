using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puppies.Dal.RepoInterface.Base
{
    public interface IRepoBase<T>
    {
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> RemoveAsync(T entity);
        Task<T> FindAsync(int? id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
