using NossoMercadoLivre.Models.Entities;
using System.Threading.Tasks;

namespace NossoMercadoLivre.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        bool AnyCategoryByName(string? name);
        Task<Category?> FindById(int id);
    }
}
