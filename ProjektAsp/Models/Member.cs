using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektAsp.Models
{
    [Table("Members")]
    public class Member
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Imię")]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nazwisko")]
        public string? LastName { get; set; }

        [Display(Name = "Zajęcia grupowe")]
        public virtual ICollection<GroupClass>? GroupClasses { get; set; }

        [Display(Name = "Sesje z trenerem")]
        public virtual ICollection<TrainingSession>? TrainingSessions { get; set; }

        [Display(Name = "Wystawione opinie")]
        public virtual ICollection<Review>? Reviews { get; set; }
    }
}
