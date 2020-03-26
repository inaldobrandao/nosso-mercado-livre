using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace NossoMercadoLivre.Controllers
{
    public abstract class Base : Controller
    {
        protected string GetUserId()
        {
            return User.FindFirstValue("id");
        }
    }
}
