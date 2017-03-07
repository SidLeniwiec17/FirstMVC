using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTask.Models
{
    public class Customer
    {
        public String Name { get; set; }
        public String Surname { get; set; }
        public int Number { get; set; }
        public string Email { get; set; }
    }
}