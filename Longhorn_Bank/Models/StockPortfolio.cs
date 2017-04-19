using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Longhorn_Bank.Models
{
    public class StockPortfolio
    {
       
        public Int32 StockPortfolioID { get; set; }

        //[Range(10, 10)]
        public Int32 AccountNumber { get; set; }

        [Required]
        public Decimal CashBalance { get; set; }

        public String Name { get; set; }

        //navigational properties
     
     
        public virtual List<Transaction> Transactions { get; set; }
        public virtual Account Account { get; set; }
        //public virtual List<Bill> Bills { get; set; }
    }
}