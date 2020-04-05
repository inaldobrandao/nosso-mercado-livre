using Microsoft.AspNetCore.Mvc;

namespace NossoMercadoLivre.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}
