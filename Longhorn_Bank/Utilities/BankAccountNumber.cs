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
        public AppDbContext db = new AppDbContext();


        public static Int32 AccountNumberList(AppDbContext db)
        {
            List<Int32> MaxList = new List<Int32>();
            var queryCheckings = (from a in db.CheckingsDbSet select a.CheckingsAccountNumber);
            var querySavings = (from a in db.SavingsDbSet select a.SavingsAccountNumber);
            var queryIRAs = (from a in db.IRAsDbSet select a.IRAAccountNumber);
            var queryStocks = (from a in db.StockPortfoliosDbSet select a.StockAccountNumber);

            MaxList.Add(queryCheckings.Max());
            MaxList.Add(querySavings.Max());
            MaxList.Add(queryIRAs.Max());
            MaxList.Add(queryStocks.Max());

            Int32 MaxNumber = MaxList.Max();

            Int32 NewAccountNumber = MaxNumber += 1;


            return NewAccountNumber;
        }

        public string HideAccountNumber(string AccountNumber)
        {


            string hiddenString = AccountNumber.Substring(AccountNumber.Length - 4,4);
            string HiddenString = hiddenString.PadLeft(AccountNumber.Length, 'X');
            string MaskedNumber = HiddenString + hiddenString;


            return MaskedNumber;



        }
    }         
}
