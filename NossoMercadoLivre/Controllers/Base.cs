using Microsoft.AspNetCore.Mvc;
using NossoMercadoLivre.Helpers;
using NossoMercadoLivre.Models.Entities;
using System.Threading.Tasks;

namespace NossoMercadoLivre.Controllers
{
    public abstract class Base : Controller
    {
        private readonly ILoggedHelper _logged;

        public Base(ILoggedHelper logged)
        {
            _logged = logged;
        }

        protected async Task<User> UserLogged()
        {
            return await _logged.GetUser();
        }
    }
}
