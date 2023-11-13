using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting_System.Models
{
    public class SalesOrder : BaseEntity
    {
        public int CustomerId { get; set; }

        [Display(Name = "COS No.")]
        public string COSNo { get; set; } = "";

        [Display(Name = "PO No.")]
        public string PO { get; set; }

        [Display(Name = "Date")]
        public string TransactionDate { get; set; }

        [Display(Name = "Date Expiration")]
        public string DateExpiration { get; set; } = "";

        public decimal Quantity { get; set; }

        [Display(Name = "Quantity Serve")]
        public decimal QuantityServe { get; set; }

        public decimal Balance { get; set; }

        [Display(Name = "Delivery Date")]
        public string DeliveryDate { get; set; }

        [Display(Name = "Order Amount")]
        public decimal OrderAmount { get; set; }

        public string Remarks { get; set; }

        public string Status { get; set; } = "";

        [Display(Name = "Approved By")]
        public string ApprovedBy { get; set; } = "";

        [Display(Name = "Approved Date")]
        public DateTime ApprovedDate { get; set; }

        [NotMapped]
        public List<SelectListItem>? Customers { get; set; }
    }
}
