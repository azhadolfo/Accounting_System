using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting_System.Models
{
    public class DebitMemo : BaseEntity
    {
        [Display(Name = "SI No")]
        public int? SalesInvoiceId { get; set; }

        [ForeignKey("SalesInvoiceId")]
        public SalesInvoice? SalesInvoice { get; set; }

        [NotMapped]
        public List<SelectListItem>? SalesInvoices { get; set; }

        [Display(Name = "SOA No")]
        public int? SOAId { get; set; }

        [ForeignKey("SOAId")]
        public StatementOfAccount? SOA { get; set; }

        [NotMapped]
        public List<SelectListItem>? StatementOfAccounts { get; set; }

        public string? DMNo { get; set; }
        public long SeriesNumber { get; set; }
        public DateTime Date { get; set; }

        [Display(Name = "Debit Amount")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal DebitAmount { get; set; }

        public string Description { get; set; }

        [Display(Name = "Vatable Sales")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal VatableSales { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal VatAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal TotalSales { get; set; }

        [Display(Name = "Adjusted Price")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal AdjustedPrice { get; set; }

        public string Source { get; set; }

        public string? Remarks { get; set; }
    }
}