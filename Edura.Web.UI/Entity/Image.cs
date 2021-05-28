using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.Web.UI.Entity
{
    public class Image
    {
        public int ImageId { get; set; }
        public int ProductId { get; set; }
        public string ImageName { get; set; }

        public Product Product { get; set; }
    }
}
