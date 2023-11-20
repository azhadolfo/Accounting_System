using System.ComponentModel.DataAnnotations;

namespace Accounting_System.Models
{
    public class JournalBook : BaseEntity
    {
        public string Date { get; set; }
        public string Reference { get; set; }

        [Display(Name = "Account Title")]
        public string AccountTitle { get; set; }

        public decimal Debit { get; set; }

        public decimal Credit { get; set; }
    }
}