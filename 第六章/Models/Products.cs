﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第六章.Models
{
    public class Products
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}