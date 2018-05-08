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

        public void SaveProduct( Product product )
        {
            if (product.ProductID == 0)
            {
                db.Products.Add(product);
            }
            else
            {
                Product dbentry = db.Products.Find(product.ProductID);
                if (dbentry != null)
                {
                    dbentry.Name = product.Name;
                    dbentry.Description = product.Description;
                    dbentry.Price = product.Price;
                    dbentry.Category = product.Category;
                    dbentry.ImageData = product.ImageData;
                    dbentry.ImageMineType = product.ImageMineType;
                }
            }
            db.SaveChanges();
        }
        public Product DeleteProduct(int productID )
        {
            Product dbEntry = db.Products.Find(productID);
            if (dbEntry != null)
            {
                db.Products.Remove(dbEntry);
                db.SaveChanges();
            }
            return dbEntry;

        }
    }
}
