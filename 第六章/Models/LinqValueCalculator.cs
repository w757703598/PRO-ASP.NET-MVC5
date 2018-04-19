using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第六章.Models
{
    public class LinqValueCalculator:IValueCalculator
    {
        private IDiscountHelper discounter;//新的依赖项
        private static int counter = 0;//演示是否重新创建一个实例
        public LinqValueCalculator(IDiscountHelper discountParam )
        {
            discounter = discountParam;
            System.Diagnostics.Debug.WriteLine(string.Format("Instance{0}Created", ++counter));
        }
        public decimal ValueProducts(IEnumerable<Products> products )
        {
            return discounter.ApplyDiscount(products.Sum(p=>p.Price));
        }
    }
}