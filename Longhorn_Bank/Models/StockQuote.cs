using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Longhorn_Bank.Models
{
    public class StockQuote
    {
        public Int32 StockId { get; set; }
        public String Symbol { get; set; }
        public String Name { get; set; }
        public Double PreviousClose { get; set; }
        public Double LastTradePrice { get; set; }
        public Double Volume { get; set; }
    }
}