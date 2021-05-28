using Edura.Web.UI.Entity;
using Edura.Web.UI.Infrastructure;
using Edura.Web.UI.Models;
using Edura.Web.UI.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.Web.UI.Controllers
{
    public class CartController : Controller
    {
        IUnitOfWork uow;

        public CartController(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        public IActionResult Index()
        {

            return View(GetCart());
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            var product = uow.Products.Get(productId);
            if (product != null)
            {
                var cart = GetCart();
                cart.AddProduct(product, quantity);

                SaveCart(cart);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            var product = uow.Products.Get(productId);
            if (product != null)
            {
                var cart = GetCart();
                cart.RemoveProduct(product);

                SaveCart(cart);
            }

            return RedirectToAction("Index");
        }

        private Cart GetCart()
        {
            return HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }

        public IActionResult Checkout()
        {
            var cart = GetCart();
            if (!cart.Products.Any())
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Checkout(OrderDetails model)
        {
            var cart = GetCart();
            if (!cart.Products.Any())
            {
                ModelState.AddModelError("", "Sepetinizde ürün bulunmamaktadır.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                SaveOrder(cart, model);
                cart.ClearAll();
                SaveCart(cart);

                return View("Completed");
            }

            return View(model);
        }

        public IActionResult Completed()
        {
            return View();
        }

        private void SaveOrder(Cart cart, OrderDetails orderDetails)
        {
            var order = new Order();
            order.OrderNumber = "A" + (new Random().Next(1111, 9999)).ToString();
            order.Total = cart.TotalPrice();
            order.OrderDate = DateTime.Now;
            order.OrderState = EnumOrderState.Waiting;
            order.Username = User.Identity.Name;

            order.AdresTanimi = orderDetails.AdresTanimi;
            order.Adres = orderDetails.Adres;
            order.Sehir = orderDetails.Sehir;
            order.Semt = orderDetails.Semt;
            order.Telefon = orderDetails.Telefon;

            foreach (var product in cart.Products)
            {
                var orderLine = new OrderLine();
                orderLine.Quantity = product.Quantity;
                orderLine.Price = product.Product.Price;
                orderLine.ProductId = product.Product.ProductId;

                order.OrderLines.Add(orderLine);
            }

            uow.Orders.Add(order);
            uow.SaveChanges();
        }
    }
}
