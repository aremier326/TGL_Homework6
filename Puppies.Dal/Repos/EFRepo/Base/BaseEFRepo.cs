using Puppies.Model.Base;
using Microsoft.EntityFrameworkCore;
using Puppies.Dal.RepoInterface.Base;
using Puppies.Dal.Repos.EFRepo.Data;

namespace Puppies.Dal.Repos.EFRepo.Base
{
    public abstract class BaseEFRepo<T> : IRepoBase<T> where T : BaseItem
    {
        public DbSet<T> Table { get; }

        public PuppyContext Context { get; }

        public BaseEFRepo(PuppyContext context)
        {
            Context = context;
            Table = Context.Set<T>();
        }

        public virtual async Task<int> AddAsync(T entity)
        {
            await Table.AddAsync(entity);
            return await Context.SaveChangesAsync();
        }

        public virtual async Task<int> RemoveAsync(T entity)
        {
            Table.Remove(entity);
            return await Context.SaveChangesAsync();
        }

        public virtual async Task<T> FindAsync(int? id)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
        }
        
        public virtual async Task<int> UpdateAsync(T entity)
        {
            Table.Update(entity);
            return await Context.SaveChangesAsync();
        }

        public abstract Task<IEnumerable<T>> GetAllAsync();
    }
}
