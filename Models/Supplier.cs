using System.ComponentModel.DataAnnotations;

namespace Accounting_System.Models
{
    public class Supplier : BaseEntity
    {
        [Display(Name = "Supplier No")]
        public int Number { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        [Display(Name = "Tin No")]
        public string TinNo { get; set; }

        [Display(Name = "Business Style")]
        public string BusinessStyle { get; set; }

        [Display(Name = "Supplier Type")]
        public string Type { get; set; }

        [Display(Name = "Withholding Tax")]
        public bool WithholdingTax { get; set; }

        [Display(Name = "Withholding Vat")]
        public bool WithholdingVat { get; set; }
    }
}