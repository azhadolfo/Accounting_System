using System.ComponentModel.DataAnnotations;

namespace Accounting_System.Models
{
    public class AuditTrail
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public DateTime Date { get; set; }

        [Display(Name = "Machine Name")]
        public string MachineName { get; set; }
        public string Activity { get; set; }

        [Display(Name = "Document Type")]
        public string DocumentType { get; set; }

        public AuditTrail(string username, string activity, string documentType)
        {
            Username = username;
            Date = DateTime.Now;
            MachineName = Environment.MachineName;
            Activity = activity;
            DocumentType = documentType;
        }
    }
}