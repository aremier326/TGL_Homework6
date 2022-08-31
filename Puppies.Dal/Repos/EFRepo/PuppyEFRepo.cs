using Microsoft.EntityFrameworkCore;
using Puppies.Dal.RepoInterface;
using Puppies.Dal.Repos.EFRepo.Base;
using Puppies.Dal.Repos.EFRepo.Data;
using Puppies.Model;

namespace Puppies.Dal.Repos.EFRepo
{
    public class PuppyEFRepo : BaseEFRepo<Puppy>, IPuppyRepo
    {
        public PuppyEFRepo(PuppyContext context) : base(context)
        {
        }

        public override async Task<Puppy> FindAsync(int? id)
        {
            return await Table
                .Include(x => x.Breed)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<IEnumerable<Puppy>> GetAllAsync()
        {
            return await Table
                .Include(x => x.Breed)
                .ToListAsync();
        }

        public override async Task<int> UpdateAsync(Puppy entity)
        {
            var puppy = await Table.FindAsync(entity.Id);

            if (puppy == null) return 0;

            puppy.Name = entity.Name;
            puppy.Gender = entity.Gender;
            puppy.Age = entity.Age;
            puppy.Weight = entity.Weight;
            puppy.Height = entity.Height;
            puppy.FurColor = entity.FurColor;
            puppy.BreedId = entity.BreedId;
            puppy.Breed = entity.Breed;

            return await Context.SaveChangesAsync();
        }
    }
}
