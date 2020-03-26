using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace NossoMercadoLivre.Repositories
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : class
    {
        protected readonly IConfiguration _configuration;

        public AbstractRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Create(T entity)
        {
            using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString(Constants.DEFAULT_CONNECTION));
            try
            {
                connection.Insert(entity);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }
    }
}
