using Edura.Web.UI.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.Web.UI.Components
{
    public class FeaturedProducts: ViewComponent
    {
        private IUnitOfWork uow;

        public FeaturedProducts(IUnitOfWork _uow)
        {
            this.uow = _uow;
        }

        public IViewComponentResult Invoke()
        {
            var lst = uow.Products.GetFeaturedProducts();
            return View(lst);
        }
    }
}
