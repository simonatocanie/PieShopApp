using Microsoft.AspNetCore.Mvc;
using PieShopApp.Models.Repositories.Repositories;
using PieShopApp.ViewModels;

namespace PieShopApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository pieRepository;

        public HomeController(IPieRepository pieRepository )
        {
            this.pieRepository = pieRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel(pieRepository.PiesOfTheWeek);
            return View(homeViewModel);
        }
    }
}
