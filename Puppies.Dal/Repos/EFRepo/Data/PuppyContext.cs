using Microsoft.EntityFrameworkCore;
using Puppies.Model;

namespace Puppies.Dal.Repos.EFRepo.Data
{
    public class PuppyContext : DbContext
    {
        public PuppyContext()
        {
        }

        public PuppyContext(DbContextOptions<PuppyContext> options)
            : base(options)
        {

        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(),
                connectionString).Options;
        }

        public DbSet<Puppy> Puppies { get; set; }
        public DbSet<Breed> Breeds { get; set; }
    }
}
