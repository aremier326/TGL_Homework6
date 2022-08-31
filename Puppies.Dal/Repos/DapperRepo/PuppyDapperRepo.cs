using Dapper;
using Microsoft.Data.SqlClient;
using Puppies.Dal.RepoInterface;
using Puppies.Dal.Repos.DapperRepo.Base;
using Puppies.Model;

namespace Puppies.Dal.Repos.DapperRepo
{
    public class PuppyDapperRepo : BaseDapperRepo<Puppy>, IPuppyRepo
    {
        public PuppyDapperRepo(string connectionString) : base(connectionString)
        {
        }

        public override async Task<int> AddAsync(Puppy entity)
        {
            var sql = @"INSERT INTO [dbo].[Puppies] (Name, Gender, Age, Weight, Height, FurColor, BreedId)
                        VALUES (@Name, @Gender, @Age, @Weight, @Height, @FurColor, @BreedId)";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public override async Task<Puppy> FindAsync(int? id)
        {
            var sql = @"SELECT * FROM [dbo].[Puppies] p
                        INNER JOIN Breeds b ON b.Id = p.BreedId";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<Puppy, Breed, Puppy>(sql, (puppy, breed) =>
                {
                    puppy.Breed = breed;
                    return puppy;
                });
                return result.SingleOrDefault(x => x.Id == id);
            }
        }

        public override async Task<IEnumerable<Puppy>> GetAllAsync()
        {
            var sql = @"SELECT * FROM [dbo].[Puppies] p
                        INNER JOIN Breeds b ON b.Id = p.BreedId";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<Puppy, Breed, Puppy>(sql, 
                    (puppy, breed) =>
                {
                    puppy.Breed = breed;
                    return puppy;
                });
                return result;
            }
        }

        public override async Task<int> RemoveAsync(Puppy entity)
        {
            var sql = @"DELETE FROM [dbo].[Puppies] WHERE Id = @Id";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public override async Task<int> UpdateAsync(Puppy entity)
        {
            var sql = @"UPDATE [dbo].[Puppies] SET
                        Name = @Name,
                        Gender = @Gender,
                        Age = @Age,
                        Weight = @Weight,
                        Height = @Height,
                        FurColor = @FurColor,
                        BreedId = @BreedId
                        WHERE Id = @Id";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
