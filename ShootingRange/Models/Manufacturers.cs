using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ShootingRange.Models
{
    public class Manufacturers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nazwa producenta")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Kraj pochodzenia")]
        public string Country { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Opis")]
        public string Description { get; set; } = string.Empty;

    }
}
