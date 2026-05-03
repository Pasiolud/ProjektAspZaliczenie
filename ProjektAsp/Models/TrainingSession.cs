using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektAsp.Models
{
    [Table("TrainingSessions")]
    public class TrainingSession
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("MemberId")]
        public int? MemberId { get; set; }

        [Display(Name = "Klubowicz")]
        public Member? Member { get; set; }

        [ForeignKey("TrainerId")]
        public int? TrainerId { get; set; }

        [Display(Name = "Trener")]
        public Trainer? Trainer { get; set; }

        [Required]
        [Display(Name = "Data Spotkania")]
        [DataType(DataType.Date)]
        public DateTime ScheduledDate { get; set; }

        [Required]
        [Display(Name = "Należność (PLN)")]
        [Column(TypeName = "decimal(18, 2)")]
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public decimal Price { get; set; }
    }
}
