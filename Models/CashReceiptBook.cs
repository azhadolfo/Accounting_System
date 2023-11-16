using System.ComponentModel.DataAnnotations;

namespace Accounting_System.Models
{
    public class CashReceiptBook : BaseEntity
    {
        [Display(Name = "OR Date")]
        public string ORDate { get; set; }

        [Display(Name = "OR No")]
        public string ORNo { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        public string Bank { get; set; }

        [Display(Name = "Check No.")]
        public string CheckNo { get; set; }

        [Display(Name = "Chart of Account")]
        public string COA { get; set; }

        public string Particulars { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Debit { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Credit { get; set; }
    }
}