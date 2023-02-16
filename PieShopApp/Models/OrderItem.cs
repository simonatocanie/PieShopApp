namespace PieShopApp.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int PieId { get; set; }
        public Pie Pie { get; set; } = default!;
        public int OrderId { get; set; }
        public Order Order { get; set; } = default!;
    }
}
 