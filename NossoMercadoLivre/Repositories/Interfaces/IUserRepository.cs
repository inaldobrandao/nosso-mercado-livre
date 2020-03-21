using NossoMercadoLivre.Models.Entities;

namespace NossoMercadoLivre.Repositories
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        bool AnyUserByUsername(string username);
    }
}
