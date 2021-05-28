using Edura.Web.UI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.Web.UI.Models
{
    public class ProductDetailsModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
        public List<Image> ProductImages { get; set; }
        public List<ProductAttribute> ProductAttributes { get; set; }
    }
}
