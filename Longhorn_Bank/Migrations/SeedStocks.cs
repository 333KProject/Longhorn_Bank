using Longhorn_Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Longhorn_Bank.Migrations
{
    public class SeedStocks
    {
        AppDbContext db = new AppDbContext();
        public static void AddStocks(AppDbContext db)
        {
            //AvailableStocks q1 = new AvailableStocks(); q1.TickerSymbol = "GOOG"; q1.StockType = StockType.Ordinary; q1.StockName = "Alphabet Inc."; q1.StockFee = 25; db.AvailableStocks.AddOrUpdate(q => q.TickerSymbol, q1);
            //AvailableStocks q2 = new AvailableStocks(); q2.TickerSymbol = "AAPL"; q2.StockType = StockType.Ordinary; q2.StockName = "Apple Inc."; q2.StockFee = 40; db.AvailableStocks.AddOrUpdate(q => q.TickerSymbol, q2);
            //AvailableStocks q3 = new AvailableStocks(); q3.TickerSymbol = "AMZN"; q3.StockType = StockType.Ordinary; q3.StockName = "Amazon.com Inc."; q3.StockFee = 15; db.AvailableStocks.AddOrUpdate(q => q.TickerSymbol, q3);
            //AvailableStocks q4 = new AvailableStocks(); q4.TickerSymbol = "LUV"; q4.StockType = StockType.Ordinary; q4.StockName = "Southwest Airlines"; q4.StockFee = 35; db.AvailableStocks.AddOrUpdate(q => q.TickerSymbol, q4);
            //AvailableStocks q5 = new AvailableStocks(); q5.TickerSymbol = "TXN"; q5.StockType = StockType.Ordinary; q5.StockName = "Texas Instruments"; q5.StockFee = 15; db.AvailableStocks.AddOrUpdate(q => q.TickerSymbol, q5);
            //AvailableStocks q6 = new AvailableStocks(); q6.TickerSymbol = "HSY"; q6.StockType = StockType.Ordinary; q6.StockName = "The Hershey Company"; q6.StockFee = 25; db.AvailableStocks.AddOrUpdate(q => q.TickerSymbol, q6);
            //AvailableStocks q7 = new AvailableStocks(); q7.TickerSymbol = "V"; q7.StockType = StockType.Ordinary; q7.StockName = "Visa Inc."; q7.StockFee = 10; db.AvailableStocks.AddOrUpdate(q => q.TickerSymbol, q7);
            //AvailableStocks q8 = new AvailableStocks(); q8.TickerSymbol = "NKE"; q8.StockType = StockType.Ordinary; q8.StockName = "Nike"; q8.StockFee = 30; db.AvailableStocks.AddOrUpdate(q => q.TickerSymbol, q8);
            //AvailableStocks q9 = new AvailableStocks(); q9.TickerSymbol = "VWO"; q9.StockType = StockType.ETF; q9.StockName = "Vanguard Emerging Markets ETF"; q9.StockFee = 20; db.AvailableStocks.AddOrUpdate(q => q.TickerSymbol, q9);
            //AvailableStocks q10 = new AvailableStocks(); q10.TickerSymbol = "CORN"; q10.StockType = StockType.Futures; q10.StockName = "Corn"; q10.StockFee = 10; db.AvailableStocks.AddOrUpdate(q => q.TickerSymbol, q10);
            //AvailableStocks q11 = new AvailableStocks(); q11.TickerSymbol = "F"; q11.StockType = StockType.Ordinary; q11.StockName = "Ford Motor Company"; q11.StockFee = 10; db.AvailableStocks.AddOrUpdate(q => q.TickerSymbol, q11);
            //AvailableStocks q12 = new AvailableStocks(); q12.TickerSymbol = "BAC"; q12.StockType = StockType.Ordinary; q12.StockName = "Bank of America Corporation"; q12.StockFee = 10; db.AvailableStocks.AddOrUpdate(q => q.TickerSymbol, q12);
            //AvailableStocks q13 = new AvailableStocks(); q13.TickerSymbol = "VNQ"; q13.StockType = StockType.ETF; q13.StockName = "Vanguard REIT ETF"; q13.StockFee = 15; db.AvailableStocks.AddOrUpdate(q => q.TickerSymbol, q13);
            //AvailableStocks q14 = new AvailableStocks(); q14.TickerSymbol = "KMX"; q14.StockType = StockType.Ordinary; q14.StockName = "CarMax, Inc."; q14.StockFee = 15; db.AvailableStocks.AddOrUpdate(q => q.TickerSymbol, q14);
            //AvailableStocks q15 = new AvailableStocks(); q15.TickerSymbol = "DIA"; q15.StockType = StockType.IndexFund; q15.StockName = "Dow Jones Industrial Average Index Fund"; q15.StockFee = 25; db.AvailableStocks.AddOrUpdate(q => q.TickerSymbol, q15);
            //AvailableStocks q16 = new AvailableStocks(); q16.TickerSymbol = "SPY"; q16.StockType = StockType.IndexFund; q16.StockName = "S&P 500 Index Fund"; q16.StockFee = 25; db.AvailableStocks.AddOrUpdate(q => q.TickerSymbol, q16);
            //AvailableStocks q17 = new AvailableStocks(); q17.TickerSymbol = "BEN"; q17.StockType = StockType.Ordinary; q17.StockName = "Franklin Resources, Inc."; q17.StockFee = 25; db.AvailableStocks.AddOrUpdate(q => q.TickerSymbol, q17);
            //AvailableStocks q18 = new AvailableStocks(); q18.TickerSymbol = "PGSCX"; q18.StockType = StockType.MutualFund; q18.StockName = "Pacific Advisors Small Cap Value Fund"; q18.StockFee = 15; db.AvailableStocks.AddOrUpdate(q => q.TickerSymbol, q18);

        }
    }

}
