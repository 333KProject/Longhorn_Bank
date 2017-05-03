using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Longhorn_Bank.Models
{
    public class UserHomePage
    {
        public string CheckingsName { get; set; }
        public Int32 CheckingsAccountNumber { get; set; }
        public Decimal CheckingsBalance { get; set; }
        public string SavingsName { get; set; }
        public string IRAName { get; set; }
        public string StockPortfolio { get; set; }
    }
}