using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第六章.Models
{
    public class ShoopingCart
    {
        private IValueCalculator calc;
        public ShoopingCart(IValueCalculator calcParam )
        {
            calc = calcParam;
        }
        public IEnumerable<Products> Products { get; set; }
        public decimal CalculateProductTotal()
        {
            return calc.ValueProducts(Products);
        }
    }
}