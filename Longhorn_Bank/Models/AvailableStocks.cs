using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Longhorn_Bank.Models
{
    public  enum StockType { ETF, Ordinary, Futures, IndexFund, MutualFund}
    public class AvailableStocks
    {
        public Int32 AvailableStocksID { get; set; }
        public string TickerSymbol { get; set; }
        public StockType StockType {get;set;}

        public string StockName { get; set; }
        public Int32 StockFee { get; set; }

        public virtual StockPortfolio StockPortfolio { get; set; }
        public virtual StockQuote Price { get; set; }
    }
}