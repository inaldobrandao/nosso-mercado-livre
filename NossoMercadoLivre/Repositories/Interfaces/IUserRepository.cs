using NossoMercadoLivre.Models.Entities;

namespace NossoMercadoLivre.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        bool AnyUserByUsername(string username);
    }
}
