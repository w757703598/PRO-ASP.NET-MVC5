using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore.Domain.Entities
{
    //送货详情
    public  class ShippingDetails
    {
        [Required(ErrorMessage ="Please enter a name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please enter the first address line")]
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string line3 { get; set; }
        [Required(ErrorMessage ="Please enter a city name")]
        public string City { get; set; }
        [Required(ErrorMessage ="Please enter a state name")]
        [Display(Name ="州")]
        public string State { get; set; }
        [Display(Name ="邮编")]
        public string Zip { get; set; }
        [Required(ErrorMessage ="Please enter a country name")]
        public string Country { get; set; }
        public bool GiftWrap { get; set; }

    }
}
