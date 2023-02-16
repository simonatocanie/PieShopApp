using Microsoft.EntityFrameworkCore;

namespace PieShopApp.Models.Context
{
    public class PieShopDbContext : DbContext
    {
        public PieShopDbContext(DbContextOptions<PieShopDbContext> options) : base(options) { }

        public DbSet<Pie> Pies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
