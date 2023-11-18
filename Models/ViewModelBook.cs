using System.ComponentModel.DataAnnotations;

namespace Accounting_System.Models
{
    public class ViewModelBook
    {
        [Required]
        [Display(Name = "Date From")]
        public string DateFrom { get; set; }

        [Required]
        [Display(Name = "Date To")]
        public string DateTo { get; set; }
    }
}