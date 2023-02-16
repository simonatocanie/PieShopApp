using Microsoft.AspNetCore.Mvc;
using PieShopApp.Models.Repositories.Repositories;
using PieShopApp.ViewModels;

namespace PieShopApp.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly IShoppingCartRepository shoppingCartRepository;

        public ShoppingCartSummary(IShoppingCartRepository shoppingCartRepository)
        {
            this.shoppingCartRepository = shoppingCartRepository;
        }

        public IViewComponentResult Invoke()
        {
            var items = shoppingCartRepository.GetShoppingCartItems();
            shoppingCartRepository.ShoppingCartItems = items;

            return View(new ShoppingCartViewModel(shoppingCartRepository, shoppingCartRepository.GetShoppingCartTotal()));
        }
    }
}
