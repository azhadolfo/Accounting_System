using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting_System.Models
{
    public class CashReceiptBook
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "OR Date")]
        public string Date { get; set; }

        [Display(Name = "Ref No")]
        public string RefNo { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        public string? Bank { get; set; }

        [Display(Name = "Check No.")]
        public string? CheckNo { get; set; }

        [Display(Name = "Chart of Account")]
        public string COA { get; set; }

        public string Particulars { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Debit { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Credit { get; set; }

        [Display(Name = "Created By")]
        [Column(TypeName = "varchar(50)")]
        public string? CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}