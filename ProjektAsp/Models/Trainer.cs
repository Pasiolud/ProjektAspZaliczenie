using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektAsp.Models
{
    [Table("Trainers")]
    public class Trainer
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

        [Required]
        [StringLength(100)]
        [Display(Name = "Główna specjalizacja")]
        public string? Specialization { get; set; }

        [Display(Name = "Sesje Treningowe")]
        public virtual ICollection<TrainingSession>? TrainingSessions { get; set; }
    }
}
