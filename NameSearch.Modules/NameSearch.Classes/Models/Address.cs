using System.ComponentModel.DataAnnotations;

namespace NameSearch.Classes.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }
        public int Zipcode { get; set; }
        public int PersonId { get; set; }
        [Required]
        public Person Person { get; set; }
    }
}