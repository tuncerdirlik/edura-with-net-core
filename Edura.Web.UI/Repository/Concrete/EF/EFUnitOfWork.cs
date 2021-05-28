using Edura.Web.UI.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.Web.UI.Repository.Concrete.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly EduraContext dbContext;
        public EFUnitOfWork(EduraContext _dbContext)
        {
            dbContext = _dbContext ?? throw new ArgumentNullException("dbContext can not be null");
        }

        private IProductRepository _products;
        private IOrderRepository _orders;
        private ICategoryRepository _categories;

        public IProductRepository Products
        {
            get
            {
                return _products ?? (_products = new EFProductRepository(dbContext));
            }
        }

        public IOrderRepository Orders
        {
            get
            {
                return _orders ?? (_orders = new EFOrderRepository(dbContext));
            }
        }

        public ICategoryRepository Categories
        {
            get
            {
                return _categories ?? (_categories = new EFCategoryRepository(dbContext));
            }
        }

        public int SaveChanges()
        {
            try
            {
                return dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        
    }
}
