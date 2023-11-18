using System.ComponentModel.DataAnnotations;

namespace Accounting_System.Models
{
    public class InventoryBook : BaseEntity
    {
        public string Date { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        public string Unit { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Quantity { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Price Per Unit")]
        public decimal Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Amount { get; set; }
    }
}