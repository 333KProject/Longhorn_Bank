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

        public Int32 StockAccountNumber { get; set; }

        [Required]
        public Decimal PortfolioCashBalance { get; set; }

        public String Name { get; set; }

        //navigational properties
     
     
        public virtual List<Transaction> Transactions { get; set; }
        public virtual AppUser User { get; set; }
        //public virtual List<Bill> Bills { get; set; }
        public virtual List<AvailableStocks> AvaliableStocks { get; set; }
    }
}