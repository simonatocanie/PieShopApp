using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using PieShopApp.Models.Context;

namespace PieShopApp.Models.Repositories.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly PieShopDbContext dbcontext;
        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;
        public string? ShoppingCartId { get; set; }

        public ShoppingCartRepository(PieShopDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public static ShoppingCartRepository GetShoopingCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;
            PieShopDbContext dbContext = services.GetService<PieShopDbContext>() ?? throw new Exception("Error initializing");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();
            session?.SetString("CartId", cartId);
            return new ShoppingCartRepository(dbContext) { ShoppingCartId = cartId };
        }

        public void AddToCart(Pie pie)
        {
            var shoopingCartIem = dbcontext.ShoppingCartItems.SingleOrDefault(x => x.Pie.PieId == pie.PieId && x.ShoppingCartId == ShoppingCartId);

            if (shoopingCartIem == null)
            {
                shoopingCartIem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Quantity = 1,
                    Pie = pie
                };

                dbcontext.Add(shoopingCartIem);
            }
            else
            {
                shoopingCartIem.Quantity++;
            }

            dbcontext.SaveChanges();
        }

        public int RemoveFromCart(Pie pie)
        {
            var shoppingCartItem = dbcontext.ShoppingCartItems.SingleOrDefault(x => x.Pie.PieId == pie.PieId && x.ShoppingCartId == ShoppingCartId);
            int localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Quantity > 1)
                {
                    shoppingCartItem.Quantity--;
                    localAmount = 0;
                }
                else
                {
                    dbcontext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            dbcontext.SaveChanges();
            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return  dbcontext.ShoppingCartItems.Where(x => x.ShoppingCartId == ShoppingCartId)
                  .Include(x => x.Pie).ToList();
        }

        public void ClearCart()
        {
            var cartItems = dbcontext.ShoppingCartItems.Where(x => x.ShoppingCartId == ShoppingCartId);
            dbcontext.RemoveRange(cartItems);
            dbcontext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = dbcontext.ShoppingCartItems.Where(x => x.ShoppingCartId == ShoppingCartId)
                 .Select(x => x.Pie.Price * x.Quantity).Sum();

            return total;
        }
    }
}
