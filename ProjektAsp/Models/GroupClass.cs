using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektAsp.Models
{
    [Table("GroupClasses")]
    public class GroupClass
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nazwa zajęć")]
        public string? Name { get; set; }

        [Display(Name = "Pojemność")]
        public int Capacity { get; set; }

        [Display(Name = "Uczestnicy")]
        public virtual ICollection<Member>? Members { get; set; }
    }
}
