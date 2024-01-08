using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting_System.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Customer No")]
        public int Number { get; set; }

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
        [Display(Name = "Customer Type")]
        public string CustomerType { get; set; }

        [Required]
        [Display(Name = "Creditable Withholding VAT 2306 ")]
        public bool WithHoldingVat { get; set; }

        [Required]
        [Display(Name = "Creditable Withholding Tax 2307")]
        public bool WithHoldingTax { get; set; }

        [Display(Name = "Created By")]
        [Column(TypeName = "varchar(50)")]
        public string? CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}