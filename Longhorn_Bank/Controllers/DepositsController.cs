using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
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
            ViewBag.AllCheckingDeposits = GetAllCheckingDepositAccounts();
            ViewBag.AllSavingsDeposits = GetAllSavingsDepositAccounts();
            ViewBag.AllIRADeposits = GetIRADepositAccount();
            ViewBag.AllStockPortfolioDeposits = GetStockPortfolioDepositAccount();
            return View();
        }

        public ActionResult DepositResults(int SelectedCheckingDepositAccount, int SelectedSavingsDepositAccount, int SelectedIRADepositAccount, int SelectedStockPortfolioDepositAccount)
        {
            string Id = User.Identity.GetUserId();
            AppUser UserAccounts = db.Users.Find(Id);
            UserAccounts.Checkings = UserAccounts.Checkings;
            UserAccounts.Savings = UserAccounts.Savings;
            UserAccounts.IRA = UserAccounts.IRA;
            UserAccounts.StockPortfolio = UserAccounts.StockPortfolio;

            //checkings
            if (UserAccounts.Checkings == null)
            {
                ViewBag.SelectedCheckingDepositAccount = "No deposit account selected";
            }
            else
            {
                List<Checking> AllCheckingDeposits = UserAccounts.Checkings;
                Checking CheckingToDisplay = AllCheckingDeposits.Find(a => a.CheckingID == SelectedCheckingDepositAccount);
                ViewBag.SelectedCheckingDepositAccount = CheckingToDisplay.CheckingsName;
            }

            //savings
            if (UserAccounts.Savings == null)
            {
                ViewBag.SelectedSavingsDepositAccount = "No deposit account selected";
            }
            else
            {
                List<Saving> AllSavingsDeposits = UserAccounts.Savings;
                Saving SavingsToDisplay = AllSavingsDeposits.Find(a => a.SavingID == SelectedSavingsDepositAccount);
                ViewBag.SelectedSavingsDepositAccount = SavingsToDisplay.SavingsName;
            }

            //ira
            if (UserAccounts.IRA == null)
            {
                ViewBag.SelectedIRADepositAccount = "No deposit account selected";
            }
            else
            {
                IRA AllIRADeposits = UserAccounts.IRA;
                IRA IRAToDisplay = AllIRADeposits;
                ViewBag.SelectedIRADepositAccount = IRAToDisplay.IRAName;
            }

            //stock portfolio
            if (UserAccounts.StockPortfolio == null)
            {
                ViewBag.SelectedStockPortfolioDepositAccount = "No deposit account selected";
            }
            else
            {
                StockPortfolio AllStockPortfolioDeposits = UserAccounts.StockPortfolio;
                StockPortfolio StockPortfolioToDisplay = AllStockPortfolioDeposits;
                ViewBag.SelectedStockPortfolioDepositAccount = StockPortfolioToDisplay.Name;
            }


            ViewData["AllCheckingDeposits"] = SelectedCheckingDepositAccount;
            ViewData["AllSavingsDeposits"] = SelectedSavingsDepositAccount;
            ViewData["AllIRADeposits"] = SelectedIRADepositAccount;
            ViewData["AllStockPortfolioDeposits"] = SelectedStockPortfolioDepositAccount;
            return View();
        }

        //select list checkings
        public SelectList GetAllCheckingDepositAccounts()
        {
            string strId = User.Identity.GetUserId();
            var query = from a in db.CheckingsDbSet
                        //where strId == User.Identity.GetUserId()
                        select a;
            query = query.Where(a => a.User.Id == strId);
            List<Checking> CheckingDeposits = query.ToList();

            //Checking SelectNone = new Models.Checking() { CheckingID = 0, CheckingsName = "All Checkings" };
            //CheckingDeposits.Add(SelectNone);
        
            SelectList AllCheckingDeposits = new SelectList(CheckingDeposits.OrderBy(a => a.CheckingID), "CheckingID", "CheckingsName");
            return AllCheckingDeposits;
        }

        //select list savings
        public SelectList GetAllSavingsDepositAccounts()
        {
            string strId = User.Identity.GetUserId();
            var query = from a in db.SavingsDbSet
                            //where strId == User.Identity.GetUserId()
                        select a;
            query = query.Where(a => a.User.Id == strId);
            List<Saving> SavingsDeposits = query.ToList();

            //Checking SelectNone = new Models.Checking() { CheckingID = 0, CheckingsName = "All Checkings" };
            //CheckingDeposits.Add(SelectNone);

            SelectList AllSavingsDeposits = new SelectList(SavingsDeposits.OrderBy(a => a.SavingID), "SavingID", "SavingsName");
            return AllSavingsDeposits;
        }

        //select list ira
        public SelectList GetIRADepositAccount()
        {
            string strId = User.Identity.GetUserId();
            var query = from a in db.IRAsDbSet
                            //where strId == User.Identity.GetUserId()
                        select a;
            query = query.Where(a => a.User.Id == strId);
            List<IRA> IRADeposits = query.ToList();

            //Checking SelectNone = new Models.Checking() { CheckingID = 0, CheckingsName = "All Checkings" };
            //CheckingDeposits.Add(SelectNone);

            SelectList AllIRADeposits = new SelectList(IRADeposits.OrderBy(a => a.IRAID), "IRAID", "IRAName");
            return AllIRADeposits;
        }

        //select list stock portfolio
        public SelectList GetStockPortfolioDepositAccount()
        {
            string strId = User.Identity.GetUserId();
            var query = from a in db.StockPortfoliosDbSet
                            //where strId == User.Identity.GetUserId()
                        select a;
            query = query.Where(a => a.User.Id == strId);
            List<StockPortfolio> StockPortfolioDeposits = query.ToList();

            //Checking SelectNone = new Models.Checking() { CheckingID = 0, CheckingsName = "All Checkings" };
            //CheckingDeposits.Add(SelectNone);

            SelectList AllStockPortfolioDeposits = new SelectList(StockPortfolioDeposits.OrderBy(a => a.StockPortfolioID), "StockPortfolioID", "Name");
            return AllStockPortfolioDeposits;
        }

        ////code for checking deposit accounts drop-down list
        ////selected checking deposit account is the selected value from the drop-down list
        //string Id = User.Identity.GetUserId();

        //AppUser UserAccounts = db.Users.Find(Id);


        ////UserAccounts.Checkings = UserAccounts.Checkings;

        ////var query = from a in db.CheckingsDbSet
        ////            where Id == User.Identity.GetUserId()
        ////            select a.CheckingsName;

        //if (SelectedCheckingDepositAccount == null)
        //{
        //    ViewBag.SelectedCheckingDepositAccount = "No deposit account selected";
        //}
        //else
        //{
        //    List<Checking> CheckingsList = UserAccounts.Checkings;
        //    SelectList AllCheckings = new SelectList(CheckingsList.OrderBy(c => c.CheckingID), "CheckingID", "CheckingsName");
        //    //IEnumerable<Checking> AllCheckingDepositAccounts = UserAccounts.Checkings;
        //    //IEnumerable<Checking> CheckingsDisplay = AllCheckingDepositAccounts.OrderBy(c => c.CheckingsName);
        //    ViewBag.AllCheckingsAccounts = AllCheckings;
        //    Checking CheckingDepositAccountToDisplay = CheckingsList.Find(c => c.CheckingsName == SelectedCheckingDepositAccount);
        //    ViewBag.SelectedCheckingDepositAccount = "The selected deposit account is " + CheckingDepositAccountToDisplay.CheckingsName;
        //}
        //return View();

        //ViewBag.AllCheckingDepositAccounts = GetAllCheckingDepositAccounts();
        //ViewBag.AllSavingsDepositAccounts = GetAllSavingsDepositAccounts();
        //ViewBag.IRADepositAccount = GetIRADepositAccount();
        //ViewBag.StockPortfolioDepositAccount = GetStockPortfolioDepositAccount();
        //return View();


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "CheckingID,CheckingsName,CheckingsBalance")] Checking @checking, AppUser UserAccount, string Id, AppDbContext db)
        //{

        //    string Id2 = User.Identity.GetUserId();
        //    AppUser UserAccounts = db.Users.Find(Id2);
        //    AppUser SelectedUser = db.Users.Find(Id2);
        //    UserAccounts.Checkings = UserAccounts.Checkings;
        //    Int32 AccNum = Utilities.BankAccountNumber.AccountNumberList(db);


        //    @checking.CheckingsAccountNumber = AccNum;

        //    @checking.User = SelectedUser;
        //    if (ModelState.IsValid)
        //    {
        //        db.CheckingsDbSet.Add(@checking);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.AllUsers = GetAllCheckingDepositAccounts();
        //    return View(@checking);
        //}





        //figure out how to populate with three different types of accounts

        //public ActionResult DepositResults(string DepositAmount, int SelectedCheckingDepositAccount)
        //{
        //    //code for checking deposit accounts drop-down list
        //    //selected checking deposit account is the selected value from the drop-down list
        //    string Id = User.Identity.GetUserId();

        //    AppUser UserAccounts = db.Users.Find(Id);

        //    UserAccounts.Checkings = UserAccounts.Checkings;

        //    ////var query = from a in db.CheckingsDbSet
        //    ////            select a.User.Id;

        //    List<Checking> AllCheckingDepositAccounts = UserAccounts.Checkings;

        //    Checking CheckingDepositAccountToDisplay = AllCheckingDepositAccounts.Find(a => a.CheckingID == SelectedCheckingDepositAccount);
        //    ViewBag.SelectedCheckingDepositAccount = "The selected deposit account is " + CheckingDepositAccountToDisplay.CheckingsName;
        //    return View(AllCheckingDepositAccounts);
        //}

        //public SelectList GetAllCheckingDepositAccounts()
        //{
        //    List<Checking> Checkings = db.CheckingsDbSet.ToList();

        //    //convert list to select list
        //    SelectList AllCheckingDepositAccounts = new SelectList(Checkings.OrderBy(a => a.CheckingID), "CheckingID", "CheckingsName");

        //    //return the select list
        //    return AllCheckingDepositAccounts;
        //}






        ////TO DO:

        ////they choose no deposit account
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
        //    if (DepositAmount != null && DepositAmount != "")
        //    {
        //        //make sure string is a valid number
        //        Decimal decDepositAmount;

        //        try
        //        {
        //            decDepositAmount = Convert.ToDecimal(DepositAmount);
        //        }
        //        catch //this code will display when something is wrong
        //        {
        //            //add a message for the viewbag
        //            ViewBag.Message = DepositAmount + "is not valid amount. Please try again.";

        //            //re-populate dropdown
        //            //ViewBag.AllDepositAccounts = GetAllDepositAccounts();

        //            //send user back to home page
        //            return View("Index");
        //        }

        //        //if deposit amount entered is negative or zero
        //        if (decDepositAmount < 0 || decDepositAmount == 0)
        //        {
        //            //add a message for the viewbag
        //            ViewBag.Message = DepositAmount + "is not a valid amount. Please try again.";

        //            //re-populate dropdown
        //            //ViewBag.AllDepositAccounts = GetAllDepositAccounts();

        //            //send user back to home page
        //            return View("Index");
        //        }

        //        //TO DO: deposits of over $5000 should be treated the same as when opening the account, meaning they must be approved by a manager before being added to the account balance
        //        if (decDepositAmount >5000)
        //        {
        //            //manager has to approve the transaction - route to manager approval 
        //        }


        //    }
        //    return View();
        //}

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

        //}



    }
}   