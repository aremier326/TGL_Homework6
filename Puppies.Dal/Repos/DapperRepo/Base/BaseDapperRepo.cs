using Puppies.Model.Base;
using Dapper;
using Microsoft.Data.SqlClient;
using Puppies.Dal.RepoInterface.Base;

namespace Puppies.Dal.Repos.DapperRepo.Base
{
    public abstract class BaseDapperRepo<T> : IRepoBase<T> where T : BaseItem
    {
        protected string ConnectionString { get; }

        public BaseDapperRepo(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public abstract Task<int> AddAsync(T entity);

        public abstract Task<T> FindAsync(int? id);

        public abstract Task<IEnumerable<T>> GetAllAsync();

        public abstract Task<int> RemoveAsync(T entity);

        public abstract Task<int> UpdateAsync(T entity);
    }
}
