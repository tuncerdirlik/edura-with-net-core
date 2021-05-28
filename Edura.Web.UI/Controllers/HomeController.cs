using Edura.Web.UI.Entity;
using Edura.Web.UI.Models;
using Edura.Web.UI.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork uow;

        public HomeController(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        public IActionResult Index()
        {
            var products = uow.Products.GetHomePageProducts();

            return View(products);
        }

        public IActionResult Details(int id)
        {
            var item = uow.Products.Get(id);
            return View(item);
        }

        public IActionResult Create()
        {
            var prd = new Product();
            prd.ProductName = "Yeni Ürün " + DateTime.Now.Ticks.ToString();
            prd.Price = 1000;

            uow.Products.Add(prd);
            uow.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
