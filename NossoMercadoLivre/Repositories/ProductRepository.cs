using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using NossoMercadoLivre.Models.Entities;
using System.Data.SqlClient;

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
                photo.SetProductRelationship(product.Id);
            }
            connection.Insert(product.Photos);
            foreach (var characteristic in product.Characteristics)
            {
                characteristic.SetProductRelationship(product.Id);
            }
            connection.Insert(product.Characteristics);
        }
    }
}
