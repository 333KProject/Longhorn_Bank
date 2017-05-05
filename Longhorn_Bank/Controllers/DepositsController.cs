using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Longhorn_Bank.Models;

namespace Longhorn_Bank.Controllers
{
    public class DepositsController : Controller

    {
        private AppDbContext db = new AppDbContext();

        // GET: Deposits
        public ActionResult Index()
        {
            //TO DO: uncomment when done
            //ViewBag.AllDepositAccounts = GetAllDepositAccounts();
            return View();
        }

        //figure out how to populate with three different types of accounts

        public ActionResult DepositResults(string DepositAmount, int SelectedDepositAccount)
        {
            //TO DO:
            //    
            //they choose no deposit account
            //var query = from a in GetAllAccounts select a;

            //if (SelectedDepositAccount == 0)
            //{
            //    ViewBag.SelectedDepositAccounts = "No account was selected";
            //}
            ////they pick a deposit 
            //else
            //{
            //    ViewBag.SelectedDepositAccount = "Account selected was " + SelectedDepositAccount;
            //    query = query.Where(a => a.);


            //}


            //code for textbox entry where user entires deposit amount
            if (DepositAmount != null && DepositAmount != "")
            {
                //make sure string is a valid number
                Decimal decDepositAmount;

                try
                {
                    decDepositAmount = Convert.ToDecimal(DepositAmount);
                }
                catch //this code will display when something is wrong
                {
                    //add a message for the viewbag
                    ViewBag.Message = DepositAmount + "is not valid amount. Please try again.";

                    //re-populate dropdown
                    //ViewBag.AllDepositAccounts = GetAllDepositAccounts();

                    //send user back to home page
                    return View("Index");
                }

                //if deposit amount entered is negative or zero
                if (decDepositAmount < 0 || decDepositAmount == 0)
                {
                    //add a message for the viewbag
                    ViewBag.Message = DepositAmount + "is not a valid amount. Please try again.";

                    //re-populate dropdown
                    //ViewBag.AllDepositAccounts = GetAllDepositAccounts();

                    //send user back to home page
                    return View("Index");
                }

                //TO DO: deposits of over $5000 should be treated the same as when opening the account, meaning they must be approved by a manager before being added to the account balance
                if (decDepositAmount >5000)
                {
                    //manager has to approve the transaction - route to manager approval 
                }


            }
            return View();
        }

        //method to populate drop down list of all accounts that the user has and can deposit to

        //public SelectList GetAllAccounts()
        //{

        //    //var queryCheckings = (from a in db.CheckingsDbSet select a.CheckingsName).ToList();
        //    //var querySavings = (from a in db.SavingsDbSet select a.SavingsName);
        //    //var queryIRAs = (from a in db.IRAsDbSet select a.IRAName);
        //    //var queryStock = (from a in db.StockPortfoliosDbSet select a.Name);


        //    //SelectList allAccountsList = new SelectList(queryCheckings, "CheckingId", "CheckingsName");

        //    //allAccountsList.Add(queryCheckings);
        //    //allAccountsList.Add(querySavings);
        //    //allAccountsList.Add(queryIRAs);
            

        //    //return allAccountsList;

        //}{



    }
}   