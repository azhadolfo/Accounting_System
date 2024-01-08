using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting_System.Models
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Created By")]
        [Column(TypeName = "varchar(50)")]
        public string? CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public bool IsPrinted { get; set; }

        public bool IsCanceled { get; set; }

        public bool IsVoided { get; set; }

        public bool IsPosted { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? CanceledBy { get; set; }

        public DateTime? CanceledDate { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? VoidedBy { get; set; }

        public DateTime? VoidedDate { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? PostedBy { get; set; }

        public DateTime? PostedDate { get; set; }
    }
}