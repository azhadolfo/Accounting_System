using System.ComponentModel.DataAnnotations;

namespace Accounting_System.Models
{
    public class Services : BaseEntity
    {
        [Display(Name = "Service No")]
        public int Number { get; set; }

        [Display(Name = "Service Name")]
        public string Name { get; set; }

        [Display(Name = "Service Percentage")]
        public int Percent { get; set; }
    }
}