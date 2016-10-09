using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GitHub.WebApplication.Entity.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
        public Person Person { get; set; }
    }
}
