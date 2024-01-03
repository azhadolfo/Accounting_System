using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting_System.Models
{
    public class CreditMemo : BaseEntity
    {
        [Display(Name = "CM No")]
        public string? CMNo { get; set; }

        public long SeriesNumber { get; set; }
        public DateTime Date { get; set; }

        [Display(Name = "SI No")]
        public int? SIId { get; set; }

        [ForeignKey("SIId")]
        public SalesInvoice? SalesInvoice { get; set; }

        [NotMapped]
        public List<SelectListItem>? Invoices { get; set; }

        [Display(Name = "SI No")]
        public string? SINo { get; set; }

        [Display(Name = "SOA No")]
        public int? SOAId { get; set; }

        [ForeignKey("SOAId")]
        public StatementOfAccount? StatementOfAccount { get; set; }

        [NotMapped]
        public List<SelectListItem>? Soa { get; set; }

        [Display(Name = "SOA No")]
        public string? SOANo { get; set; }

        public string Description { get; set; }

        [Display(Name = "Adjusted Price")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal AdjustedPrice { get; set; }

        [Display(Name = "Credit Amount")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal CreditAmount { get; set; }

        [Display(Name = "Vatable Sales")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal VatableSales { get; set; }

        [Display(Name = "Vat Amount")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal VatAmount { get; set; }

        [Display(Name = "Total Sales")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal TotalSales { get; set; }

        [Required]
        public string Source { get; set; }

        public bool IsPrinted { get; set; }

        public string? Remarks { get; set; }
    }
}