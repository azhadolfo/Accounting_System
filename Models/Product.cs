namespace Accounting_System.Models
{
    public class Product : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
    }
}