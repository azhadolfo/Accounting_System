using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting_System.Models
{
    public class CollectionReceipt : BaseEntity
    {
        [Display(Name = "Collection Receipt No.")]
        [Column(TypeName = "varchar(12)")]
        public string? CRNo { get; set; }

        //Invoice Property

        [Required(ErrorMessage = "Invoice is required.")]
        public int SalesInvoiceId { get; set; }

        [Display(Name = "Sales Invoice No.")]
        [Column(TypeName = "varchar(12)")]
        public string? SINo { get; set; }

        [ForeignKey("SalesInvoiceId")]
        public SalesInvoice? SalesInvoice { get; set; }

        [NotMapped]
        public List<SelectListItem>? Invoices { get; set; }

        //Customer Property

        [NotMapped]
        public List<SelectListItem>? Customers { get; set; }

        [Required(ErrorMessage = "Customer is required.")]
        public int CustomerNo { get; set; }

        //COA Property

        [NotMapped]
        public List<SelectListItem>? ChartOfAccounts { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public long SeriesNumber { get; set; }

        [Display(Name = "Reference No")]
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string ReferenceNo { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? Remarks { get; set; }

        //Cash
        public decimal CashAmount { get; set; }

        //Check
        public DateTime? CheckDate { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? CheckNo { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? CheckBank { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? CheckBranch { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal CheckAmount { get; set; }

        //Manager's Check
        public DateTime? ManagerCheckDate { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? ManagerCheckNo { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? ManagerCheckBank { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? ManagerCheckBranch { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal ManagerCheckAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal EWT { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal WVAT { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Total { get; set; }
    }
}