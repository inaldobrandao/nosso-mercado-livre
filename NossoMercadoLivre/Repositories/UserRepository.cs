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
            using(SqlConnection connection = new SqlConnection(_configuration.GetConnectionString(Constantes.DEFAULT_CONNECTION)))
            {
                try
                {
                    connection.Insert(user);
                }
                catch (SqlException ex)
                {
                    if (ex != null)
                    {
                        //2601
                        if (ex.Number == 2627)
                        {
                            // Duplicate Key Exception
                            throw new BaseException("Duplicate User", (int)EnumExceptionResponseCode.Auth.DUPLICATADE_USER);
                        }
                        
                        throw new BaseException("Create User Failure", (int)EnumExceptionResponseCode.Auth.CREATE_USER_FAILURE);
                    }
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
