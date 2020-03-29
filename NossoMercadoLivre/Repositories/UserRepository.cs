using Dapper;
using Microsoft.Extensions.Configuration;
using NossoMercadoLivre.Models.Entities;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NossoMercadoLivre.Repositories
{
    public class UserRepository : AbstractRepository<User>, IUserRepository
    {
        public UserRepository(IConfiguration configuration)
            :base (configuration)
        {
            
        }

        public bool AnyUserByUsername(string? username)
        {
            using SqlConnection connection = new SqlConnection(
                _configuration.GetConnectionString(Constants.DEFAULT_CONNECTION));
            try
            {
                return connection.Query<int>(
                    "SELECT 1 WHERE EXISTS " +
                    " (SELECT 1 FROM dbo.Users U " +
                    "WHERE U.Username = @Username) ",
                new
                {
                    Username = username
                }).Any();
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        public User? GetUserByUsername(string? username)
        {
            using SqlConnection connection = new SqlConnection(
                _configuration.GetConnectionString(Constants.DEFAULT_CONNECTION));
            try
            {
                return connection.QueryFirstOrDefault<User?>(
                "SELECT * " +
                "FROM dbo.Users U " +
                "WHERE U.Username = @Username ",
                new { Username = username });
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        public async Task<User> FindById(string userId)
        {
            using SqlConnection connection = new SqlConnection(
                _configuration.GetConnectionString(Constants.DEFAULT_CONNECTION));
            try
            {
                return await connection.QueryFirstOrDefaultAsync<User>(
                    "SELECT * " +
                    "FROM dbo.Users U " +
                    "WHERE U.Id = @Id",
                    new { Id = userId }
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
