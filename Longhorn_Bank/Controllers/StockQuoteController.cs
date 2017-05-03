using Longhorn_Bank.Models;
using Longhorn_Bank.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Longhorn_Bank.Controllers
{
    public class StockQuoteController : Controller
    {
        // GET: LiveStock
        public ActionResult Index(AvailableStocks Stocks)
        {
            List<StockQuote> Quotes = new List<StockQuote>();

            foreach (StockQuote q in Quotes)
                {
                    StockQuote sq1 = GetQuote.GetStock(Stocks.TickerSymbol);
                }   

            return View(Quotes);
        }
    }
}
