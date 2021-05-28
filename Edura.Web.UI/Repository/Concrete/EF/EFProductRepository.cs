using Edura.Web.UI.Entity;
using Edura.Web.UI.Models;
using Edura.Web.UI.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Edura.Web.UI.Repository.Concrete.EF
{
    public class EFProductRepository : EfGenericRepository<Product>, IProductRepository
    {
        public EduraContext eduraContext
        {
            get
            {
                return context as EduraContext;
            }
        }

        public EFProductRepository(EduraContext context) : base(context)
        {

        }


        public List<Product> GetTop5Products()
        {
            return eduraContext.Products.OrderByDescending(k => k.ProductId).Take(5).ToList();
        }

        public List<Product> GetHomePageProducts()
        {
            return eduraContext.Products.Where(k => k.IsHome && k.IsApproved).ToList();
        }

        public List<Product> GetFeaturedProducts()
        {
            return eduraContext.Products.Where(k => k.IsFeatured && k.IsApproved).ToList();
        }

        public ProductListModel GetProductsWithPaging(string categoryName, int page, int pageSize)
        {
            var products = eduraContext.Products.Where(k => k.IsApproved);
            if (!string.IsNullOrEmpty(categoryName))
            {
                products = products.Include(k => k.ProductCategories).ThenInclude(k => k.Category)
                                   .Where(k => k.ProductCategories.Any(x => x.Category.CategoryName.Equals(categoryName)));
            }

            int _count = products.Count();

            products = products.Skip((page - 1) * pageSize).Take(pageSize);

            return new ProductListModel
            {
                Products = products,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = _count
                }
            };
        }

        public ProductDetailsModel GetProductDetailsModel(int productId)
        {
            return eduraContext.Products
                .Where(k => k.ProductId == productId)
                .Include(k => k.Images)
                .Include(k => k.ProductAttributes)
                .Include(k => k.ProductCategories)
                .ThenInclude(k => k.Category)
                .Select(k => new ProductDetailsModel
                {
                    Product = k,
                    Categories = k.ProductCategories.Select(x => x.Category).ToList(),
                    ProductImages = k.Images,
                    ProductAttributes = k.ProductAttributes
                })
                .FirstOrDefault();
        }
    }
}
