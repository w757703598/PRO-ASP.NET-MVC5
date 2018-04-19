using SportStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportStore.WebUI.Models
{
    public class PruductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PageingInfo { get; set; }
        public string CurrentCategory { get; set; }

    }
}