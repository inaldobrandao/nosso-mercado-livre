using Dapper;
using Microsoft.Extensions.Configuration;
using NossoMercadoLivre.Models.Entities;
using System.Data.SqlClient;
using System.Linq;

namespace NossoMercadoLivre.Repositories
{
    public class CategoryRepository : AbstractRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IConfiguration configuration)
            : base (configuration)
        {
            
        }

        public bool AnyCategoryByName(string name)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString(Constants.DEFAULT_CONNECTION)))
            {
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
        }
    }
}
