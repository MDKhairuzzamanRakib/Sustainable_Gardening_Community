using Microsoft.AspNetCore.Mvc;

namespace Sustainable_Gardening_Community.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
