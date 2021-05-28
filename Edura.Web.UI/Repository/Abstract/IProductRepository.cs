using Edura.Web.UI.Entity;
using Edura.Web.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Edura.Web.UI.Repository.Abstract
{
    public interface IProductRepository: IGenericRepository<Product>
    {
        List<Product> GetTop5Products();

        List<Product> GetHomePageProducts();

        List<Product> GetFeaturedProducts();

        ProductListModel GetProductsWithPaging(string categoryName, int page, int pageSize);

        ProductDetailsModel GetProductDetailsModel(int productId);
    }
}
