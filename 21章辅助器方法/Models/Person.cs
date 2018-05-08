using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _21章辅助器方法.Models
{
    public class Person
    {
        [ScaffoldColumn(false)]//完全禁止
        [HiddenInput(DisplayValue =false)]
        public int PersonID { get; set; }
        [DisplayName("姓名")]
        public string FirstName { get; set; }
        [UIHint("MultilineText")]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public Address HomeAddress { get; set; }
        public Role Role { get; set; }
    }
    public class Address {


        public string Name { get; set; }
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string line3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
    }
    public enum Role
    {
        Admin,
        User,
        Guest
    }
}