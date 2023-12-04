using System.ComponentModel.DataAnnotations;

namespace Accounting_System.Models
{
    public class SalesBook : BaseEntity
    {
        [Display(Name = "Tran. Date")]
        public string TransactionDate { get; set; }

        [Display(Name = "Serial Number")]
        public string SerialNo { get; set; }

        [Display(Name = "Customer Name")]
        public string SoldTo { get; set; }

        [Display(Name = "Tin#")]
        public string TinNo { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Amount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Vat Amount")]
        public decimal VatAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Vatable Sales")]
        public decimal VatableSales { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Vat-Exempt Sales")]
        public decimal VatExemptSales { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Zero-Rated Sales")]
        public decimal ZeroRated { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Discount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Net Sales")]
        public decimal NetSales { get; set; }
    }
}