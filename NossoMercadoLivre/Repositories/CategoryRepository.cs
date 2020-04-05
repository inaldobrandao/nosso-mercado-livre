using Dapper;
using Microsoft.Extensions.Configuration;
using NossoMercadoLivre.Models.Entities;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NossoMercadoLivre.Repositories
{
    public class CategoryRepository : AbstractRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IConfiguration configuration)
            : base (configuration)
        {
            
        }

        public bool AnyCategoryByName(string? name)
        {
            using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString(Constants.DEFAULT_CONNECTION));
            try
            {
                return connection.Query<int>(
                    "SELECT 1 WHERE EXISTS " +
                    " (SELECT 1 FROM dbo.Categories C " +
                    "WHERE C.Name = @Name) ",
                new
                {
                    Name = name
                }).Any();
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        public async Task<Category?> FindById(int id)
        {
            using SqlConnection connection = new SqlConnection(
                _configuration.GetConnectionString(Constants.DEFAULT_CONNECTION));
            try
            {
                return await connection.QueryFirstOrDefaultAsync<Category?>(
                    "SELECT * " +
                    "FROM dbo.Categories C " +
                    "WHERE C.Id = @Id",
                    new { Id = id }
                );
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }
    }
}
