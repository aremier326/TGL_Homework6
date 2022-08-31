using Dapper;
using Microsoft.Data.SqlClient;
using Puppies.Dal.RepoInterface.Base;
using Puppies.Dal.RepoInterface;
using Puppies.Dal.Repos.DapperRepo.Base;
using Puppies.Model;

namespace Puppies.Dal.Repos.DapperRepo
{
    public class BreedDapperRepo : BaseDapperRepo<Breed>, IBreedRepo
    {
        public BreedDapperRepo(string connectionString) : base(connectionString)
        {
        }

        public override async Task<int> AddAsync(Breed entity)
        {
            var sql = @"INSERT INTO [dbo].[Breeds] (Name)
                        VALUES (@Name)";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public override async Task<Breed> FindAsync(int? id)
        {
            var sql = @"SELECT * FROM [dbo].[Breeds]
                        WHERE Id = @Id";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Breed>(sql, new { Id = id });
                return result;
            }
        }

        public override async Task<IEnumerable<Breed>> GetAllAsync()
        {
            var sql = @"SELECT * FROM [dbo].[Breeds]";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<Breed>(sql);
                return result;
            }
        }

        public override async Task<int> RemoveAsync(Breed entity)
        {
            var sql = @"DELETE FROM [dbo].[Breeds] WHERE Id = @Id";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public override async Task<int> UpdateAsync(Breed entity)
        {
            var sql = @"UPDATE [dbo].[Breeds] SET
                        Name = @Name,
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
