using System.ComponentModel.DataAnnotations;

namespace NameSearch.Classes.Models
{
    public class Interest
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int PersonId { get; set; }
        [Required]
        public Person Person { get; set; }
    }
}