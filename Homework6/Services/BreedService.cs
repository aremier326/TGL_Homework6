using Homework6.Services.Base;
using Homework6.Services.Interface;
using Puppies.Dal.Interface.RepoInterface;
using Puppies.Model;

namespace Homework6.Services
{
    public class BreedService : IBreedService
    {
        private IBreedRepo BreedRepo { get; }

        public BreedService(IBreedRepo breedRepo)
        {
            BreedRepo = breedRepo;
        }

        public async Task<int> AddAsync(Breed entity)
        {
            return await BreedRepo.AddAsync(entity);
        }

        public async Task<int> UpdateAsync(Breed entity)
        {
            return await BreedRepo.UpdateAsync(entity);
        }

        public async Task<int> RemoveAsync(Breed entity)
        {
            return await BreedRepo.RemoveAsync(entity);
        }

        public async Task<Breed> FindAsync(int? id)
        {
            return await BreedRepo.FindAsync(id);
        }

        public async Task<IEnumerable<Breed>> GetAllAsync()
        {
            return await BreedRepo.GetAllAsync();
        }
    }
}
