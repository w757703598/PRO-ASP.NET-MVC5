using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第六章.Models
{
    //条件绑定
    public class FlexibleDiscountHelper : IDiscountHelper
    {
        public decimal ApplyDiscount( decimal totalParam )
        {
            decimal discount = totalParam > 100 ? 70 : 25;
            return (totalParam - (discount / 100 * totalParam));
        }
    }
}