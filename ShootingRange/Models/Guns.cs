using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ShootingRange.Models
{
    public class Guns
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Typ")]
        public string Type { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Nazwa")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Opis")]
        public string Description { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Data produkcji")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ProductionDate { get; set; }
        [Required]
        [Display(Name = "Numer seryjny")]
        public string SerialNumber { get; set; } = string.Empty;
        [Required]
        public int ManufacturerId { get; set; }
        public Manufacturers? Manufacturer { get; set; }
    }
}
