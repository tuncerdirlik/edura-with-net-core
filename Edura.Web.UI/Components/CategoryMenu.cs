using Edura.Web.UI.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.Web.UI.Components
{
    public class CategoryMenu: ViewComponent
    {
        private IUnitOfWork uow;

        public CategoryMenu(IUnitOfWork _uow)
        {
            this.uow = _uow;
        }

        public IViewComponentResult Invoke()
        {
            var lst = uow.Categories.GetAllWithProductCount();
            return View(lst);
        }
    }
}
