using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第六章.Models
{
    public interface IDiscountHelper {
        decimal ApplyDiscount( decimal totalParam );
    }
    public class DefaultDiscountHelper : IDiscountHelper
    {
        public DefaultDiscountHelper( decimal discountPara )
        {
            DiscountSize = discountPara;
        }
        public decimal DiscountSize { get; set; }
        public decimal ApplyDiscount( decimal totalParam )
        {
            return totalParam - (DiscountSize / 100m * totalParam);
        }
    }
    public class Discount
    {
    }
}