using Microsoft.AspNetCore.Mvc;

namespace PieShopApp.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
