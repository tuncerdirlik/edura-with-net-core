using Edura.Web.UI.Entity;
using Edura.Web.UI.Models;
using Edura.Web.UI.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Edura.Web.UI.Repository.Concrete.EF
{
    public class EFCategoryRepository : EfGenericRepository<Category>, ICategoryRepository
    {
        public EduraContext eduraContext
        {
            get
            {
                return context as EduraContext;
            }
        }

        public EFCategoryRepository(EduraContext context): base(context)
        {

        }

        public Category GetByName(string name)
        {
            return eduraContext.Categories.FirstOrDefault(k => k.CategoryName.Equals(name));
        }

        public IEnumerable<CategoryViewModel> GetAllWithProductCount()
        {
            return eduraContext.Categories.Select(k => new CategoryViewModel
            {
                CategoryId = k.CategoryId,
                CategoryName = k.CategoryName,
                ProductCount = k.ProductCategories.Count()
            });
        }
    }
}
