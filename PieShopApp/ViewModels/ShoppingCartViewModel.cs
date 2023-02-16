using PieShopApp.Models.Repositories.Repositories;

namespace PieShopApp.ViewModels
{
    public class ShoppingCartViewModel
    {

        public ShoppingCartViewModel(IShoppingCartRepository shoppingCartRepository, decimal shoppingCartTotal)
        {
            ShoppingCart = shoppingCartRepository;
            ShoppingCartTotal = shoppingCartTotal;
        }

        public IShoppingCartRepository ShoppingCart { get; }
        public decimal ShoppingCartTotal { get; }
    }
}
