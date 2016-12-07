using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPCore.CityApi.Entities
{
    public  class PointOfInterest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // primary key
        public int Id { get; set; }

        [Required] // avoid null input
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; } // navigation prop
        public int CityId { get; set; }//Foreign Key 
    }
}