using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting_System.Models
{
    public class PurchaseOrder : BaseEntity
    {
        [Display(Name = "PO No")]
        public string? PONo { get; set; }

        public long SeriesNumber { get; set; }
        public DateTime Date { get; set; }

        [Display(Name = "Supplier Name")]
        public int SupplierId { get; set; }

        [ForeignKey("SupplierId")]
        public Supplier? Supplier { get; set; }

        [NotMapped]
        public List<SelectListItem>? Suppliers { get; set; }

        public int SupplierNo { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Quantity { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Amount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal FinalPrice { get; set; }

        public decimal QuantityReceived { get; set; }

        public bool IsReceived { get; set; }

        public DateTime ReceivedDate { get; set; }

        public string Remarks { get; set; }
    }
}