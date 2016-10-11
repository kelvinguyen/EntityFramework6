using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyst.Domain.Entities
{
    public class Person
    {
        public Person()
        {

        }
        public Person(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return (this.FirstName != null && this.LastName != null) ? (this.FirstName + ' ' + this.LastName) : "Name is Missing";
            }
        }
        public int Age { get; set; }
        public Address Address { get; set; }
        public List<Interests> Interests { get; set; }
        public Image Icon { get; set; }
    }
}
