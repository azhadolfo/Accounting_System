using System.ComponentModel.DataAnnotations;

namespace Accounting_System.Models
{
    public class DisbursementBook : BaseEntity
    {
        public string Date { get; set; }

        [Display(Name = "CV No")]
        public string CVNo { get; set; }

        public string Payee { get; set; }

        public decimal Amount { get; set; }

        public string Particulars { get; set; }

        public string Bank { get; set; }

        [Display(Name = "Check No")]
        public string CheckNo { get; set; }

        [Display(Name = "Check Date")]
        public string CheckDate { get; set; }

        [Display(Name = "Date Cleared")]
        public string DateCleared { get; set; }

        [Display(Name = "Chart Of Account")]
        public string ChartOfAccount { get; set; }

        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
    }
}