using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting_System.Models
{
    public class ReceivingReport : BaseEntity
    {
        [Display(Name = "RR No")]
        public string? RRNo { get; set; }

        public long SeriesNumber { get; set; }
        public DateTime Date { get; set; }

        [Display(Name = "PO No")]
        public int POId { get; set; }

        [ForeignKey("POId")]
        public PurchaseOrder? PurchaseOrder { get; set; }

        [NotMapped]
        public List<SelectListItem>? PurchaseOrders { get; set; }

        [Display(Name = "PO No")]
        public string? PONo { get; set; }

        [Display(Name = "Truck/Vessels")]
        public string TruckOrVessels { get; set; }

        [Display(Name = "Qty Delivered")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal QuantityDelivered { get; set; }

        [Display(Name = "Qty Received")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal QuantityReceived { get; set; }

        [Display(Name = "Gain/Loss")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal? GainOrLoss { get; set; }

        [Display(Name = "Other Reference")]
        public string OtherRef { get; set; }

        public string Remarks { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal AmountPaid { get; set; }

        public bool IsPaid { get; set; }

        public DateTime PaidDate { get; set; }
    }
}