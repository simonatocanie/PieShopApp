using Microsoft.AspNetCore.Mvc;
using PieShopApp.Models;
using PieShopApp.Models.Repositories.Repositories;

namespace PieShopApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly IShoppingCartRepository shoppingCartRepository;

        public OrderController(IOrderRepository orderRepository, IShoppingCartRepository shoppingCartRepository)
        {
            this.orderRepository = orderRepository;
            this.shoppingCartRepository = shoppingCartRepository;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {

            if (!ModelState.IsValid)
            {
                return View(order);
            }

            var items = shoppingCartRepository.GetShoppingCartItems();
            shoppingCartRepository.ShoppingCartItems = items;

            if (items.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some pies first");
            }

            orderRepository.CreateOrder(order);
            shoppingCartRepository.ClearCart();
            return RedirectToAction("CheckoutComplete");
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order. You'll receive soon your order.";
            return View();
        }
    }
}
