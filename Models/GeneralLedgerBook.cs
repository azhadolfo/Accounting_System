﻿using System.ComponentModel.DataAnnotations;

namespace Accounting_System.Models
{
    public class GeneralLedgerBook : BaseEntity
    {
        public string Date { get; set; }
        public string Reference { get; set; }

        [Display(Name = "Account Title")]
        public string AccountTitle { get; set; }

        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Debit { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Credit { get; set; }
    }
}