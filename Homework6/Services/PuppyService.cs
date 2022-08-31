using Homework6.Services.Base;
using Homework6.Services.Interface;
using Puppies.Dal.RepoInterface;
using Puppies.Model;

namespace Homework6.Services
{
    public class PuppyService : IPuppyService
    {
        private IPuppyRepo PuppyRepo { get; }

        public PuppyService(IPuppyRepo puppyRepo)
        {
            PuppyRepo = puppyRepo;
        }

        public async Task<int> AddAsync(Puppy entity)
        {
            return await PuppyRepo.AddAsync(entity);
        }

        public async Task<int> UpdateAsync(Puppy entity)
        {
            return await PuppyRepo.UpdateAsync(entity);
        }

        public async Task<int> RemoveAsync(Puppy entity)
        {
            return await PuppyRepo.RemoveAsync(entity);
        }

        public async Task<Puppy> FindAsync(int? id)
        {
            return await PuppyRepo.FindAsync(id);
        }

        public async Task<IEnumerable<Puppy>> GetAllAsync()
        {
            return await PuppyRepo.GetAllAsync();
        }
    }
}
