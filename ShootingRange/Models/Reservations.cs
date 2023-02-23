using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;

namespace ShootingRange.Models
{
    public class Reservations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Data rezerwacji")]
        public DateTime ReservationDate { get; set; } = DateTime.Now;
        [Required]
        [Display(Name = "Ilość użytkowników")]
        public int UsersNumber { get; set; }
        [Required]
        [Display(Name = "Numer toru")]
        public int TrackNumber { get; set; }
        [Required]
        [Display(Name = "Ilość amunicji")]
        public int AmmunitionNumber { get; set; }
        [Required]
        public int InstructorsId { get; set; }
        public Instructors? Instructors { get; set; }
        [Required]
        public int GunsId { get; set; }
        public Guns? Guns { get; set; }
        public string? UserId { get; set; }
        public IdentityUser? User { get; set; }
    }
}
