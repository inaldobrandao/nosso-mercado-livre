using NossoMercadoLivre.Models.Entities;

namespace NossoMercadoLivre.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        bool AnyUserByName(string name);
    }
}
