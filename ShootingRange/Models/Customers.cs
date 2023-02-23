using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ShootingRange.Models
{
    public class Customers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nazwisko")]
        public string? Surname { get; set; }
        [Required]
        [Display(Name = "Imię")]
        public string? Name { get; set; }
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Adres e-mail")]
        public string Email { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Numer telefonu")]
        public string TelephoneNumber { get; set; } = string.Empty;
    }
}
