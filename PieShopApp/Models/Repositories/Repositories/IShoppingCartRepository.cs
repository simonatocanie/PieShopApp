namespace PieShopApp.Models.Repositories.Repositories
{
    public interface IShoppingCartRepository
    {
        void AddToCart(Pie pie);
        int RemoveFromCart(Pie pie);  
        List<ShoppingCartItem> GetShoppingCartItems();
        void ClearCart();
        decimal GetShoppingCartTotal();
        List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
