using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting_System.Models
{
    public class CollectionReceipt : BaseEntity
    {
        public int SalesInvoiceId { get; set; }

        [ForeignKey("SalesInvoiceId")]
        public SalesInvoice? SalesInvoice { get; set; }

        public string? CRNo { get; set; }

        public string Date { get; set; }

        [Display(Name = "Reference No")]
        public string ReferenceNo { get; set; }

        [Display(Name = "Form Of Payment")]
        public string FormOfPayment { get; set; }

        [Display(Name = "Check Date")]
        public string CheckDate { get; set; }

        [Display(Name = "Check No")]
        public int CheckNo { get; set; }

        public string Bank { get; set; }

        public string Branch { get; set; }

        public decimal Amount { get; set; }

        public decimal EWT { get; set; }

        public decimal Total { get; set; }

        public bool IsPrint { get; set; }

        [NotMapped]
        public List<SelectListItem>? Customers { get; set; }
    }
}