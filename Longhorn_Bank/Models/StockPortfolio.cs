using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Longhorn_Bank.Models
{
    public class StockPortfolio
    {
        [Required]
        public Int32 StockAccountID { get; set; }

        //[Range(10, 10)]
        public Int32 AccountNumber { get; set; }

        [Required]
        public Decimal CashBalance { get; set; }

        public String Name { get; set; }

        //navigational properties
        /*[Required]
        public virtual AppUser Profile { get; set; }
        public virtual List<Transaction> Transactions { get; set; }
        public virtual List<Bill> Bills { get; set; }*/
    }
}