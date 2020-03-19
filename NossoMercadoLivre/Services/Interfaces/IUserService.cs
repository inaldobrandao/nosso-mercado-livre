using NossoMercadoLivre.Models.ViewModels;

namespace NossoMercadoLivre.Services
{
    public interface IUserService
    {
        void Create(CreateUserViewModel user);
    }
}
