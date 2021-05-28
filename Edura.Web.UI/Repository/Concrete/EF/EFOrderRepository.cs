using Edura.Web.UI.Entity;
using Edura.Web.UI.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Edura.Web.UI.Repository.Concrete.EF
{
    public class EFOrderRepository : EfGenericRepository<Order>, IOrderRepository
    {
        public EduraContext eduraContext
        {
            get
            {
                return context as EduraContext;
            }
        }

        public EFOrderRepository(EduraContext context) : base(context)
        {

        }
    }
}
