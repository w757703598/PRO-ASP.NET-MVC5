using SportStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportStore.Domain.Entities;

namespace SportStore.Domain.Concreate
{
    public class EFProductRepository : IProductsRepository
    {
        private EFDbContext db = new EFDbContext();
        public IEnumerable<Product> Products
        {
            get
            {
               return db.Products;
            }
        }
    }
}
