using System;
using System.Collections.Generic;

#nullable disable

namespace PersonApi.Models
{
    public partial class Transaction
    {
        public int Code { get; set; }
        public int AccountCode { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime CaptureDate { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }

        public virtual Account AccountCodeNavigation { get; set; }
    }
}
