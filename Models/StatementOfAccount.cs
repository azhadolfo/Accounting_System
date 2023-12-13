using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting_System.Models
{
    public class StatementOfAccount : BaseEntity
    {
        public string? SOANo { get; set; }
        public long SeriesNumber { get; set; }

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
        public DateTime Period { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Amount { get; set; }

        public bool IsPrinted { get; set; }
    }
}