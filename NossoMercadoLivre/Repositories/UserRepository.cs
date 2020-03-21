using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using NossoMercadoLivre.Models.Entities;
using System.Data.SqlClient;

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
    }
}
