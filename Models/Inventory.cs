using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting_System.Models
{
    public class Inventory : BaseEntity
    {
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public string PO { get; set; }
        public decimal Quantity { get; set; }
        public decimal QuantityServe { get; set; }
        public decimal QuantityBalance { get; set; }
    }
}