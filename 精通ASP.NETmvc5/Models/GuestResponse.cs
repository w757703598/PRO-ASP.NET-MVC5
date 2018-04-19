using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace 精通ASP.NETmvc5.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage ="Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please enter you email")]
        [RegularExpression(".+\\@.+\\..+",ErrorMessage ="Please enter a valid email address")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool ? WillAttend { get; set; }
    }
}