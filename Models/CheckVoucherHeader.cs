using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting_System.Models
{
    public class CheckVoucherHeader : BaseEntity
    {
        [Display(Name = "CV No")]
        public string? CVNo { get; set; }

        public long SeriesNumber { get; set; }

        public DateTime Date { get; set; }

        [Display(Name = "RR No")]
        public int RRId { get; set; }

        [ForeignKey("RRId")]
        public ReceivingReport? ReceivingReport { get; set; }

        [NotMapped]
        public List<SelectListItem>? RR { get; set; }

        [Display(Name = "RR No")]
        public string? RRNo { get; set; }

        public decimal Amount { get; set; }

        [Display(Name = "Amount in Words")]
        public string? AmountInWords { get; set; }

        public string Particulars { get; set; }

        public string Bank { get; set; }

        [Display(Name = "Check #")]
        public string CheckNo { get; set; }
    }
}