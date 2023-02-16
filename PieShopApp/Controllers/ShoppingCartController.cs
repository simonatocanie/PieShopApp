using Microsoft.AspNetCore.Mvc;
using PieShopApp.Models.Repositories.Repositories;
using PieShopApp.ViewModels;

namespace PieShopApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IPieRepository pieRepository;
        private readonly IShoppingCartRepository shoppingCartRepository;

        public ShoppingCartController(IPieRepository pieRepository, IShoppingCartRepository shoppingCartRepository)
        {
            this.pieRepository = pieRepository;
            this.shoppingCartRepository = shoppingCartRepository;
        }

        public IActionResult Index()
        {
            var items = shoppingCartRepository.GetShoppingCartItems();
            shoppingCartRepository.ShoppingCartItems = items;

            return View(new ShoppingCartViewModel(shoppingCartRepository, shoppingCartRepository.GetShoppingCartTotal()));
        }

        public IActionResult AddToShoppingCart(int pieId)
        {
            var selectPie = pieRepository.AllPies.FirstOrDefault(x => x.PieId == pieId);

            if (selectPie != null)
            {
                shoppingCartRepository.AddToCart(selectPie);
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromShoppingCart(int pieId)
        {
            var selectPie = pieRepository.AllPies.FirstOrDefault(x => x.PieId == pieId);

            if (selectPie != null)
            {
                shoppingCartRepository.RemoveFromCart(selectPie);
            }

            return RedirectToAction("Index");
        }
    }
}
