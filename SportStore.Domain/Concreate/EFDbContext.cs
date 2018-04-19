using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SportStore.Domain.Entities;

namespace SportStore.Domain.Concreate
{
    public  class EFDbContext:DbContext
    {
        //public EFDbContext():base("EFDbContext")
        //{
            
        //}
        public DbSet<Product> Products { get; set; }
    }
}
