using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Website.TheWorldMap.ViewModels
{
    public class TripViewModel
    {
        [Required]
        [StringLength(100,MinimumLength =10)]
        public string Name { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

    }
}
