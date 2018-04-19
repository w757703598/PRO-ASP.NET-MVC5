using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第六章.Models
{
    public interface IValueCalculator
    {
        decimal ValueProducts( IEnumerable<Products> products );
    }
}