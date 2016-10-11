using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSearch.Classes.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Address> Address{ get; set; }
        public string ImgUrl { get; set; }
        public List<Interest> Interests { get; set; }

        public int Age { get; set; }

    }
}
