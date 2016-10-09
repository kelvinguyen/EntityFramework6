using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GitHub.WebApplication.ViewModels
{
    public class PersonViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public List<string> Address { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public List<string> Interests { get; set; }
    }
}
