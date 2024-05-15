using Microsoft.AspNetCore.Mvc;

namespace CarRent.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            //Colocando autenticação nos contatos

            //if (User.Identity.IsAuthenticated)
            //{
            //    return View();

            //}
            //return RedirectToAction("Login", "Account");

            return View();
        }
    }
}
