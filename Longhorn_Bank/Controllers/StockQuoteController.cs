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
        AppDbContext db = new AppDbContext();
        // GET: LiveStock
        public ActionResult Index(AvailableStocks Stocks)
        {
            List<StockQuote> Quotes = new List<StockQuote>();

            //string Symbol = db.AvailableStocks;
            var symbolquery = from c in db.AvailableStocks select c.TickerSymbol;

            foreach (var q in symbolquery)
                {
                    
                    StockQuote sq = GetQuote.GetStock(q);
                    Quotes.Add(sq);
                }

            return View(Quotes.ToList());
        }
    }
}
