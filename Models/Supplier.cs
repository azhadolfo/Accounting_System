using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting_System.Models
{
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Supplier No")]
        public int Number { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        [Display(Name = "Tin No")]
        public string TinNo { get; set; }

        [Display(Name = "Business Style")]
        public string BusinessStyle { get; set; }

        [Display(Name = "Supplier Type")]
        public string Type { get; set; }

        [Display(Name = "Withholding Tax")]
        public bool WithholdingTax { get; set; }

        [Display(Name = "Withholding Vat")]
        public bool WithholdingVat { get; set; }

        [Display(Name = "Created By")]
        [Column(TypeName = "varchar(50)")]
        public string? CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}