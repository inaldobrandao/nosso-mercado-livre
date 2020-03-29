using Microsoft.AspNetCore.Mvc;
using NossoMercadoLivre.Models.Entities;
using NossoMercadoLivre.Repositories;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NossoMercadoLivre.Controllers
{
    public abstract class Base : Controller
    {
        protected string GetUserId()
        {
            return User.FindFirstValue("id");
        }

        protected async Task<User> GetLoggedUser(IUserRepository userRepository)
        {
            return await userRepository.FindById(GetUserId());
        }
    }
}
