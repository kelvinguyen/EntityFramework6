using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHub.WebApplication.Entity.Models
{
    public class Interest
    {
        public int Id { get; set; }
        public string InterestContent { get; set; }
        public Person Person { get; set; }
    }
}
