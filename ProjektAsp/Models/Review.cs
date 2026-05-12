using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektAsp.Models
{
    [Table("Reviews")]
    public class Review
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("MemberId")]
        [Display(Name = "Klubowicz")]
        public int MemberId { get; set; }
        public virtual Member? Member { get; set; }

        [Required]
        [ForeignKey("TrainerId")]
        [Display(Name = "Trener")]
        public int TrainerId { get; set; }
        public virtual Trainer? Trainer { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Ocena musi być w przedziale 1-5")]
        [Display(Name = "Ocena (1-5)")]
        public int Rating { get; set; }

        [StringLength(500)]
        [Display(Name = "Komentarz")]
        public string? Comment { get; set; }

        [Display(Name = "Data Wystawienia")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
