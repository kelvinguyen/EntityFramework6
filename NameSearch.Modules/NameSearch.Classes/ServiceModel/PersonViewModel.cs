using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSearch.Classes.ServiceModel
{
    public class PersonViewModel
    {
        public string FullName { get; set; }
        public List<string> Content { get; set; }

        public List<string> Address { get; set; }
        public int Age { get; set; }
        public string Image { get; set; }
    }
}
