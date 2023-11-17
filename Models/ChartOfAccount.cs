namespace Accounting_System.Models
{
    public class ChartOfAccount : BaseEntity
    {
        public bool IsMain { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public string Level { get; set; } = string.Empty;
    }
}