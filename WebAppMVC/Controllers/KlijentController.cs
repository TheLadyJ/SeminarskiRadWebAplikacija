using Microsoft.AspNetCore.Mvc;

namespace WebAppMVC.Controllers
{
    public class KlijentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
