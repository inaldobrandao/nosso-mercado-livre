using NossoMercadoLivre.Models.Entities;

namespace NossoMercadoLivre.Repositories
{
    public interface IProductRepository
    {
        void Create(Product product);
    }
}
