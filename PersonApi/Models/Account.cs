using System;
using System.Collections.Generic;

#nullable disable

namespace PersonApi.Models
{
    public partial class Account
    {
        public Account()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int Code { get; set; }
        public int PersonCode { get; set; }
        public string AccountNumber { get; set; }
        public decimal OutstandingBalance { get; set; }

        public virtual Person PersonCodeNavigation { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
