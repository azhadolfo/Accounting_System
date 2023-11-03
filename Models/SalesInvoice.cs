using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting_System.Models
{
    public class SalesInvoice : BaseEntity
    {
        [Display(Name = "Serial No")]
        public int SerialNo { get; set; }

        [NotMapped]
        public string FormattedSerialNo
        {
            get
            {
                return SerialNo.ToString("D8"); // Formats with leading zeros, e.g., 0000021
            }
        }

        [Required]
        [Display(Name = "Customer No")]
        public int CustomerId { get; set; }

        [Display(Name = "Customer Type")]
        public string CustomerType { get; set; }

        public bool WithHoldingTax { get; set; }

        [NotMapped]
        public List<SelectListItem>? Customers { get; set; }

        [NotMapped]
        public List<SelectListItem>? Products { get; set; }

        [Display(Name = "Sold To")]
        public string SoldTo { get; set; }

        public string Address { get; set; }

        [Display(Name = "Tin#")]
        public string TinNo { get; set; }

        [Display(Name = "Business Style")]
        public string BusinessStyle { get; set; }

        [Required]
        [Display(Name = "Transaction Date")]
        public string TransactionDate { get; set; }

        public string Terms { get; set; }

        [Required]
        [Display(Name = "Other Ref No")]
        public string OtherRefNo { get; set; }

        [Required]
        [Display(Name = "P.O No")]
        public string PoNo { get; set; }

        [Required]
        [Display(Name = "Product No")]
        public string ProductNo { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Display(Name = "Unit")]
        public string ProductUnit { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Quantity { get; set; }

        [Required]
        [Display(Name = "Unit Price")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal UnitPrice { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Amount { get; set; }

        [Required]
        public string Remarks { get; set; }

        public bool IsVoid { get; set; }

        public bool IsPosted { get; set; }

        public bool OriginalCopy { get; set; } = true;

        [Display(Name = "Vatable Sales")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal VatableSales { get; set; }

        [Display(Name = "VAT Amount")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal VatAmount { get; set; }
    }
}