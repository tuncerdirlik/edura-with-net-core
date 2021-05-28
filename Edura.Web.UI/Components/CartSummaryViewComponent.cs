using Edura.Web.UI.Infrastructure;
using Edura.Web.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.Web.UI.Components
{
    public class CartSummaryViewComponent: ViewComponent
    {
        public string Invoke()
        {
            return HttpContext.Session.GetJson<Cart>("Cart")?.Products.Count().ToString() ?? "0";
        }
    }
}
