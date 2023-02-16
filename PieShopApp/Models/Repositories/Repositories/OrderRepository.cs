using PieShopApp.Models.Context;

namespace PieShopApp.Models.Repositories.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PieShopDbContext dbContext;
        private readonly IShoppingCartRepository shoppingCartRepository;

        public OrderRepository(PieShopDbContext dbContext, IShoppingCartRepository shoppingCartRepository)
        {
            this.dbContext = dbContext;
            this.shoppingCartRepository = shoppingCartRepository;
        }
        public void CreateOrder(Order order)
        {
            order.CreatedDate = DateTime.Now;
            order.OrderTotal = shoppingCartRepository.GetShoppingCartTotal();
            order.OrderItems = new List<OrderItem>();

            foreach (var item in shoppingCartRepository.ShoppingCartItems)
            {
                var orderItem = new OrderItem
                {
                    Quantity= item.Quantity,
                    PieId= item.Pie.PieId,
                    Price = item.Pie.Price
                };

                order.OrderItems.Add(orderItem);
            }

            dbContext.Orders.Add(order);
            dbContext.SaveChanges();
        }
    }
}
