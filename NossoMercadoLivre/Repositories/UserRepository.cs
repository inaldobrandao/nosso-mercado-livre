using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using NossoMercadoLivre.Models.Entities;
using System.Data.SqlClient;
using System.Linq;

namespace NossoMercadoLivre.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void CreateUser(User user)
        {
            using(SqlConnection connection = new SqlConnection(_configuration.GetConnectionString(Constants.DEFAULT_CONNECTION)))
            {
                try
                {
                    connection.Insert(user);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                }
            }
        }

        public bool AnyUserByUsername(string username)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString(Constants.DEFAULT_CONNECTION)))
            {
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
        }
    }
}
