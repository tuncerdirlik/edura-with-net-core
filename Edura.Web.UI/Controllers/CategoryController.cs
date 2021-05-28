using Edura.Web.UI.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.Web.UI.Controllers
{
    public class CategoryController : Controller
    {
        private IUnitOfWork uow;

        public CategoryController(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        public IActionResult Index()
        {
            var item = uow.Categories.GetByName("Electronics");

            return View(item);
        }
    }
}
