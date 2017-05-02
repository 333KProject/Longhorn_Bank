using Longhorn_Bank.Models;
using Longhorn_Bank.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Longhorn_Bank.Controllers
{
    public class LiveStockController : Controller
    {
        // GET: LiveStock
        public ActionResult Index()
        {
            List<StockQuote> Quotes = new List<StockQuote>();
            StockQuote sq1 = GetQuote.GetStock("AAPL");
            Quotes.Add(sq1);

            StockQuote sq2 = GetQuote.GetStock("GOOG");
            Quotes.Add(sq2);

            StockQuote sq3 = GetQuote.GetStock("LUV");
            Quotes.Add(sq3);

            return View(Quotes);
        }
    }
}
