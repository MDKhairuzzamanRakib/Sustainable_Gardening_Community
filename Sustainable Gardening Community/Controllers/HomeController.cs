using Microsoft.AspNetCore.Mvc;

namespace Sustainable_Gardening_Community.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
