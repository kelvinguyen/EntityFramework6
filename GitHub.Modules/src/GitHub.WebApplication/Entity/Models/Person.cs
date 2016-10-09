using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitHub.WebApplication.Entity.Models;

namespace GitHub.WebApplication.Entity.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Address> AddressList { get; set; }
        public List<Interest> InterestList { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }

    }
}
