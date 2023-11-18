using System;
using System.ComponentModel.DataAnnotations;

namespace Accounting_System.Models
{
    public class Customer : BaseEntity
    {
        [Required]
        [Display(Name = "Customer Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Customer Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "TIN No")]
        public string TinNo { get; set; }

        [Required]
        [Display(Name = "Business Style")]
        public string BusinessStyle { get; set; }

        [Required]
        [Display(Name = "Payment Terms")]
        public string Terms { get; set; }

        [Required]
        public string CustomerType { get; set; }

        [Required]
        [Display(Name = "Creditable Withholding VAT 2306 ")]
        public bool WithHoldingVat { get; set; }

        [Required]
        [Display(Name = "Creditable Withholding Tax 2307")]
        public bool WithHoldingTax { get; set; }
    }
}