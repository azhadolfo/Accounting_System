using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting_System.Models
{
    public class Inventory : BaseEntity
    {
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public Product Product { get; }

        public string PO { get; set; }
        public decimal Quantity { get; set; }
        public decimal QuantityServe { get; set; }
        public decimal QuantityBalance { get; set; }
    }
}