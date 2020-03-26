using Microsoft.AspNetCore.Mvc;

namespace NossoMercadoLivre.Controllers
{
    public class HomeController : Base
    {
        public IActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}
