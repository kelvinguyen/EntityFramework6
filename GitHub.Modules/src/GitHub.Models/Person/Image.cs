using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHub.Models.Person
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public Person Person { get; set; }
    }
}
