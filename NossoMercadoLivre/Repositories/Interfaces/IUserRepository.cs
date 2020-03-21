using NossoMercadoLivre.Models.Entities;

namespace NossoMercadoLivre.Repositories
{
    public interface IUserRepository
    {
        void CreateUser(User user);
    }
}
