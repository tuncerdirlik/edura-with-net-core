using Edura.Web.UI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.Web.UI.Models
{
    public class Cart
    {
        private List<CartLine> products = new List<CartLine>();
        public List<CartLine> Products => products;

        public void AddProduct(Product product, int quantity)
        {
            var _product = products.Where(k => k.Product.ProductId == product.ProductId).FirstOrDefault();
            if (_product != null)
            {
                _product.Quantity += quantity;
            }
            else
            {
                products.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
        }

        public void RemoveProduct(Product product)
        {
            products.RemoveAll(k => k.Product.ProductId == product.ProductId);
        }

        public void ClearAll()
        {
            products.Clear();
        }

        public double TotalPrice()
        {
            return products.Sum(k => k.Product.Price * k.Quantity);
        }



    }

    public class CartLine
    {
        public int CartLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
