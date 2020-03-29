using NossoMercadoLivre.Models.Entities;
using System.Threading.Tasks;

namespace NossoMercadoLivre.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        bool AnyUserByUsername(string? username);
        User? GetUserByUsername(string? username);
        Task<User> FindById(string userId);
    }
}
