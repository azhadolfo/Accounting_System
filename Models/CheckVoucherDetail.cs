using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting_System.Models
{
    public class CheckVoucherDetail : BaseEntity
    {
        [Display(Name = "COA No")]
        public int COAId { get; set; }

        [ForeignKey("COAId")]
        public ChartOfAccount? ChartOfAccount { get; set; }

        [NotMapped]
        public List<SelectListItem>? COA { get; set; }

        public string AccountNo { get; set; }
        public string AccountName { get; set; }

        public string TransactionNo { get; set; }

        public string Category { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Amount { get; set; }
    }
}