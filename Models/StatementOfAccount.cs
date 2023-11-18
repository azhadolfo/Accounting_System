using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting_System.Models
{
    public class StatementOfAccount : BaseEntity
    {
        public int Number { get; set; }

        [NotMapped]
        [Display(Name = "SOA No.")]
        public string FormmatedNumber
        {
            get
            {
                return "SOA" + Number.ToString("D10");
            }
        }

        [Required]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }

        [NotMapped]
        public List<SelectListItem>? Customers { get; set; }

        [Required]
        [Display(Name = "Particulars")]
        public int ServicesId { get; set; }

        [ForeignKey("ServicesId")]
        public Services? Service { get; set; }

        [NotMapped]
        public List<SelectListItem>? Services { get; set; }

        [Required]
        public string Period { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        [Display(Name = "Account Name")]
        public string AccountName { get; set; }

        [Required]
        public string Bank { get; set; }

        [Required]
        [Display(Name = "Bank Account No.")]
        public string BankAccountNo { get; set; }

        [Required]
        [Display(Name = "Bank Branch")]
        public string BankBranch { get; set; }
    }
}