using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using NossoMercadoLivre.Models.Entities;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NossoMercadoLivre.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration _configuration;

        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Create(Product product)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString(Constants.DEFAULT_CONNECTION));
            connection.Insert(product);
            foreach (var photo in product.Photos)
            {
                photo.GetRelationId();
            }
            connection.Insert(product.Photos);
            foreach (var characteristic in product.Characteristics)
            {
                characteristic.GetRelationId();
            }
            connection.Insert(product.Characteristics);            
        }

        public async Task<Product?> FindById(int productId)
        {
            using SqlConnection connection = new SqlConnection(
                _configuration.GetConnectionString(Constants.DEFAULT_CONNECTION));            
            var result = await connection.QueryAsync<Product, User, Product>(
                "SELECT TOP 1 * " +
                "FROM dbo.Products P " +
                "INNER JOIN Users u on u.Id = P.UserId " +
                "WHERE P.Id = @ProductId ",
                (product, user) =>
                {
                    product.User = user;
                    return product;
                },
                new { ProductId = productId },
                splitOn: "Id"
            );
            return result.Distinct().FirstOrDefault();             
        }
    }
}
