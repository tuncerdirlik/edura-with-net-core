using Edura.Web.UI.Models;
using Edura.Web.UI.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.Web.UI.Controllers
{
    public class ProductController : Controller
    {
        public int PageSize = 2;

        private IUnitOfWork uow;

        public ProductController(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List(string category, int page = 1)
        {
            var model = uow.Products.GetProductsWithPaging(category, page, PageSize);
            return View(model);
        }

        public IActionResult Details(int id)
        {
            ProductDetailsModel output = uow.Products.GetProductDetailsModel(id);

            return View(output);
        }
    }
}
