using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Longhorn_Bank.Models;

namespace Longhorn_Bank.Utilities
{
    public class BankAccountNumber
    {
        private AppDbContext db = new AppDbContext();

        public SelectList AccountNumberList(int? AccountNumber)
        {
            var queryCheckings = (from a in db.CheckingsDbSet select a.CheckingsAccountNumber).Max() == AccountNumber;
            var querySavings = (from a in db.SavingsDbSet select a.SavingsAccountNumber).Max();
            var queryIRAs = (from a in db.IRAsDbSet select a.IRAAccountNumber).Max();
            var queryStocks = (from a in db.StockPortfoliosDbSet select a.StockAccountNumber).Max();

            List<Checking> allCheckingsAccountNumbers = queryCheckings.ToList();
            List<Saving> SelectedMaxSavings = querySavings.ToList();
            List<IRA> SelectedMaxIRA = queryIRAs.ToList();
            List<StockPortfolio> SelectedMaxStock = queryStocks.ToList();

            List<BankAccountNumber> allAccountNumbersList = SelectedMaxCheckings.Concat(SelectedMaxSavings).Concat(SelectedMaxIRA).Concat(SelectedMaxStock).ToList();
            return allAccountNumbersList;
        }

        public SelectList CreateAccountNumberList(int? AccountNumber)
        {
            var queryCheckings = (from a in db.CheckingsDbSet
                                 orderby a.CheckingsAccountNumber == AccountNumber
                                 select a.CheckingsAccountNumber).Max();
            var querySavings = (from a in db.SavingsDbSet
                                orderby a.SavingsAccountNumber == AccountNumber
                                select a.SavingsAccountNumber).Max();
            var queryIRAs = (from a in db.IRAsDbSet
                             orderby a.IRAAccountNumber == AccountNumber
                             select a.IRAAccountNumber).Max();
            var queryStocks = from a in db.StockPortfoliosDbSet
                              where a.StockAccountNumber == AccountNumber
                              select a;

            List<Checking> allCheckingsAccountNumbers = queryCheckings.ToList();
            List<Saving> allSavingsAccountNumbers = querySavings.ToList();
            List<IRA> allIRAsAccountNumbers = queryIRAs.ToList();
            List<StockPortfolio> allStockAccountNumbers = queryStocks.ToList();

            SelectList allAccountNumbersList = new SelectList(allCheckingsAccountNumbers, "CheckingID", "CheckingsAccountNumber", allSavingsAccountNumbers, "SavingsID", "SavingsAccountNumber", allIRAsAccountNumbers, "IRAID", "IRAAccountNumber", allStockAccountNumbers, "StockPortfolioID", "StockAccountNumber");
            return allAccountNumbersList;



        }*/

    }
}
