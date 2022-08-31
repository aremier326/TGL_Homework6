using Microsoft.EntityFrameworkCore;
using Puppies.Dal.RepoInterface;
using Puppies.Dal.Repos.EFRepo.Base;
using Puppies.Dal.Repos.EFRepo.Data;
using Puppies.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puppies.Dal.Repos.EFRepo
{
    public  class BreedEFRepo : BaseEFRepo<Breed>, IBreedRepo
    {
        public BreedEFRepo(PuppyContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Breed>> GetAllAsync()
        {
            return await Table
                .ToListAsync();
        }
    }
}
