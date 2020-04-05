using NossoMercadoLivre.Models.Entities;
using System.Threading.Tasks;

namespace NossoMercadoLivre.Repositories
{
    public interface IProductRepository
    {
        void Create(Product product);
        Task<Product?> FindById(int productId);
    }
}
