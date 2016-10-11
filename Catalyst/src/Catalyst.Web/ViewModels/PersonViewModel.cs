using Catalyst.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyst.Web.ViewModels
{
    public class PersonViewModel
    {

        public int Id { get; set; }
        public ICollection<Interests> Interests { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return (this.FirstName != null && this.LastName != null) ? (this.FirstName + ' ' + this.LastName): "Name is Missing";
            }
        }

        public Address Address { get; set; }
        
        public int Age { get; set; }
       
        public Image Image { get; set; }
    }
}
