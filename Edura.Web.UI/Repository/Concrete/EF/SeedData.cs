using Edura.Web.UI.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.Web.UI.Repository.Concrete.EF
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetRequiredService<EduraContext>();

            context.Database.Migrate();

            if (!context.Products.Any())
            {
                var products = new List<Product>
                {
                    new Product(){ProductName = "Photo Camera", Price = 10, Image = "product1_thumb.jpg"},
                    new Product(){ProductName = "Webcam Camera", Price = 15, Image = "product2_thumb.jpg"},
                    new Product(){ProductName = "Handbag", Price = 20, Image = "product3_thumb.jpg"},
                    new Product(){ProductName = "Sofa", Price = 30, Image = "product4_thumb.jpg"}
                };

                context.Products.AddRange(products);

                var categories = new List<Category>
                {
                    new Category(){CategoryName = "Electronics"},
                    new Category(){CategoryName = "Accessories"},
                    new Category(){CategoryName = "Furniture"}
                };

                context.Categories.AddRange(categories);

                var productCatgories = new List<ProductCategory>
                {
                    new ProductCategory(){Product = products[0], Category = categories[0]}
                };

                context.AddRange(productCatgories);

                context.SaveChanges();
            }
        }
    }
}
