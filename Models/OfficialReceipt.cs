using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting_System.Models
{
    public class OfficialReceipt : BaseEntity
    {
        public int SOAId { get; set; }

        [ForeignKey("SOAId")]
        public StatementOfAccount? StatementOfAccount { get; set; }

        public string? ORNo { get; set; }
        public long SeriesNumber { get; set; }

        public DateTime Date { get; set; }

        public string ReferenceNo { get; set; }

        public string FormOfPayment { get; set; }

        public int CheckNo { get; set; }

        public DateTime CheckDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Amount { get; set; }

        [NotMapped]
        public List<SelectListItem>? SOANo { get; set; }

        public string? Remarks { get; set; }
    }
}