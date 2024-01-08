using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting_System.Models
{
    public class SalesInvoice : BaseEntity
    {
        [Display(Name = "SI No")]
        [Column(TypeName = "varchar(12)")]
        public string? SINo { get; set; }

        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }

        public long SeriesNumber { get; set; }

        [Required]
        [Display(Name = "Customer No")]
        public int CustomerId { get; set; }

        [Display(Name = "Customer Type")]
        [Column(TypeName = "varchar(10)")]
        public string CustomerType { get; set; }

        [NotMapped]
        public List<SelectListItem>? Customers { get; set; }

        [NotMapped]
        public List<SelectListItem>? Products { get; set; }

        [NotMapped]
        public List<SelectListItem>? COSNo { get; set; }

        public int CustomerNo { get; set; }

        [Display(Name = "Sold To")]
        [Column(TypeName = "varchar(100)")]
        public string SoldTo { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Address { get; set; }

        [Display(Name = "Tin#")]
        [Column(TypeName = "varchar(20)")]
        public string TinNo { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Business Style")]
        public string BusinessStyle { get; set; }

        [Column(TypeName = "varchar(5)")]
        public string Terms { get; set; }

        [Column(TypeName = "varchar(20)")]
        [Required]
        [Display(Name = "Other Ref No")]
        public string OtherRefNo { get; set; }

        [Required]
        [Display(Name = "P.O No")]
        [Column(TypeName = "varchar(20)")]
        public string PoNo { get; set; }

        [Required]
        [Display(Name = "Product No")]
        [Column(TypeName = "varchar(20)")]
        public string ProductNo { get; set; }

        [Display(Name = "Product Name")]
        [Column(TypeName = "varchar(50)")]
        public string ProductName { get; set; }

        [Display(Name = "Unit")]
        [Column(TypeName = "varchar(5)")]
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
        [Column(TypeName = "varchar(100)")]
        public string Remarks { get; set; }

        [Display(Name = "Vatable Sales")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal VatableSales { get; set; }

        [Display(Name = "VAT Amount")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal VatAmount { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Status { get; set; } = "Pending";

        [Required]
        [Display(Name = "Transaction Date")]
        public DateTime TransactionDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Discount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal NetDiscount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal VatExempt { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal ZeroRated { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal WithHoldingVatAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal WithHoldingTaxAmount { get; set; }

        public decimal AmountPaid { get; set; }

        public decimal Balance { get; set; }

        public bool IsPaid { get; set; }

        public bool IsTaxAndVatPaid { get; set; }
    }
}