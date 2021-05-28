using Edura.Web.UI.Entity;
using Edura.Web.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Edura.Web.UI.Repository.Abstract
{
    public interface ICategoryRepository: IGenericRepository<Category>
    {
        Category GetByName(string name);
        IEnumerable<CategoryViewModel> GetAllWithProductCount();
    }
}
