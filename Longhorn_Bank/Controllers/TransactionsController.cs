using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Longhorn_Bank.Models;


public enum AmountRange { A, B, C, D, customrange}
public enum DateRange { last15days, last30days, last60days, customrange }

namespace Longhorn_Bank.Controllers
{

    public class TransactionsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Transactions
        public ActionResult Index(string SearchString)
        {

            //Create instance of Transaction list
            List<Transaction> SelectedTransactions = new List<Transaction>();

            //If nothing entered
            if (SearchString == null || SearchString == "")
            {
                //Return list of all customers
                SelectedTransactions = db.TransactionsDbSet.ToList();
            }
            //If something entered
            else
            {

                //Search database for customers with search string in their name
                SelectedTransactions = db.TransactionsDbSet.Where(t => t.Description.Contains(SearchString)).ToList();
                //Sort the list of customers
                SelectedTransactions = SelectedTransactions.OrderBy(c => c.TransactionNumber).ThenBy(c => c.TransactionType).ThenBy(c => c.Description).ThenBy(c => c.Amount).ToList();
            }


            //ViewBag for total customer count
            ViewBag.All = db.TransactionsDbSet.ToList().Count;
            //ViewBag for SelectedCustomers count
            ViewBag.Returned = SelectedTransactions.Count;
            
            return View(SelectedTransactions);

            
        }

        // GET: Transactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.TransactionsDbSet.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        //Get: Transactions/Withdrawals
        public ActionResult Withdrawals()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Withdrawals([Bind(Include = "TransactionID, TransactionNumber, Date, Description, TransactionType, EmployeeComment, Status, Amount")] Transaction transaction)
        {
            return View();
        }





        // GET: Transactions/Create
        public ActionResult Deposits()
        {
            ViewBag.AllCheckingDeposits = GetAllCheckingDepositAccounts();
            ViewBag.AllSavingsDeposits = GetAllSavingsDepositAccounts();
            ViewBag.AllIRADeposits = GetIRADepositAccount();
            ViewBag.AllStockPortfolioDeposits = GetStockPortfolioDepositAccount();
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deposits([Bind(Include = "TransactionID,TransactionNumber,Date,Description,TransactionType,EmployeeComment,Status,Amount")] Transaction transaction)
        {
            string Id4 = User.Identity.GetUserId();
            AppUser UserAccounts = db.Users.Find(Id4);
            AppUser SelectedUser = db.Users.Find(Id4);
            UserAccounts.Checkings = UserAccounts.Checkings;
            //Int32 AccNum = Utilities.BankAccountNumber.AccountNumberList(db);

            transaction.TransactionNumber = 1000;
            Int32 NewTransactionNumber = transaction.TransactionNumber += 1;

            
            transaction.User = SelectedUser;
           

            if (ModelState.IsValid)
            {
                
                db.TransactionsDbSet.Add(transaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AllCheckingDeposits = GetAllCheckingDepositAccounts();
            return View();
        }

        //// GET: Transactions/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Transaction transaction = db.TransactionsDbSet.Find(id);
        //    if (transaction == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(transaction);
        //}

        //// POST: Transactions/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "TransactionID,TransactionNumber,Date,Description,TransactionType,EmployeeComment,Status,Amount")] Transaction transaction)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(transaction).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(transaction);
        //}

        // GET: Transactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.TransactionsDbSet.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaction transaction = db.TransactionsDbSet.Find(id);
            db.TransactionsDbSet.Remove(transaction);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        ////detailed search method for transaction type
        //public ActionResult DetailedSearch ()
        //{
        //    //create list for transaction type
        //    List<Transaction> Transactions = db.TransactionsDbSet.ToList();
        //    Transaction SelectNoTransactions = new Models.Transaction() { TransactionID = 0, TransactionName = "All Transactions" };
        //    Transactions.Add(SelectNoTransactions);

        //    //select list
        //    SelectList ALLTransactions = new SelectList(Transactions.OrderBy(t => t.TransactionID), "TransactionID", "TransactionType");
        //    ViewBag.Transactions = ALLTransactions;
        //    return View("DetailedSearch");
        //}

        ////detailed search method for date
        //public ActionResult DateSearch()
        //{
        //    //create list for date
        //    List<Transaction> Transactions = db.TransactionsDbSet.ToList();
        //    Transaction SelectNoDates = new Models.Transaction() { TransactionID = 0, TransactionName = "All Dates" };
        //    Transactions.Add(SelectNoDates);

        //    //select list
        //    SelectList ALLDates = new SelectList(Transactions.OrderBy(t => t.TransactionID), "TransactionID", "Date");
        //    ViewBag.Transactions = ALLDates;
        //    return View("DetailedSearch");
        //}

        ////search method for description of transaction
        //public ActionResult SearchResults (string SearchString, int? SelectedTransaction, string Description, decimal? Amount, decimal? Amount1, decimal? Amount2, int? TransactionNumber, DateTime? Date, DateTime? CustomDateRange1, DateTime? CustomDateRange2, AmountRange? SelectedAmountRange, DateRange? SelectedDateRange)
        //{
        //    //create variable
        //    var query = from t in db.TransactionsDbSet select t;

        //    //code for searching descriiption
        //    if (SearchString == null || SearchString == "")
        //    {

        //    }
        //    else
        //    {
        //        ViewBag.SearchString = "Search string is " + SearchString;
        //        query = query.Where(t => t.Description.Contains(SearchString));
        //    }

        //    //transaction type search criteria
        //    if (SelectedTransaction != 0)
        //    {
        //        query = query.Where(t => t.TransactionID == SelectedTransaction);
        //    }
        //    else
        //    {

        //    }

        //    //amount search criteria
        //    if ((Amount == null || Amount.ToString() == ""))
        //    {
        //    }
        //    else if (SelectedAmountRange == AmountRange.A)
        //    {
        //        query = query.Where(t => t.Amount >= 0 && t.Amount <= 100);
        //    }
        //    else if (SelectedAmountRange == AmountRange.B)
        //    {
        //        query = query.Where(t => t.Amount > 100 && t.Amount <=200);
        //    }
        //    else if (SelectedAmountRange == AmountRange.C)
        //    {
        //        query = query.Where(t => t.Amount > 200 && t.Amount <= 300);
        //    }
        //    else if (SelectedAmountRange == AmountRange.D)
        //    {
        //        query = query.Where(t => t.Amount > 300);
        //    }
        //    else
        //    {
        //        query = query.Where(t => t.AmountStart >= Amount1);
        //        query = query.Where(t => t.AmountEnd <= Amount2);
        //    }
        //    //TO DO: connect enum and custom amount entry 
        //    query = query.OrderBy(t => t.TransactionNumber).ThenBy(t => t.Amount);

        //    //date search criteria
        //    if ((Date == null || Date.ToString() == ""))
        //    {
        //    }
        //    else if (SelectedDateRange == DateRange.last15days)
        //    {
        //        query = query.Where(t => t.TimeStamp <= t.DateForPast15);
        //    }
        //    else if (SelectedDateRange == DateRange.last30days)
        //    {
        //        query = query.Where(t => t.TimeStamp <= t.DateForPast30);
        //    }
        //    else if (SelectedDateRange == DateRange.last60days)
        //    {
        //        query = query.Where(t => t.TimeStamp <= t.DateForPast60);
        //    }
        //    else
        //    {
        //        query = query.Where(t => t.CustomDateRangeStart >= CustomDateRange1);
        //        query = query.Where(t => t.CustomDateRangeEnd <= CustomDateRange2);
        //    }
 
        //    query = query.OrderBy(t => t.TransactionNumber).ThenBy(t => t.Amount);

        //    List<Transaction> SelectedTransactions = query.ToList();
        //    ViewBag.All = db.TransactionsDbSet.ToList().Count;
        //    ViewBag.Returned = SelectedTransactions.Count;

        //    return View("Index", SelectedTransactions);
        //}

        public ActionResult DepositResults(int SelectedCheckingDepositAccount, int SelectedSavingsDepositAccount, int SelectedIRADepositAccount, int SelectedStockPortfolioDepositAccount, DateTime Date, string DepositAmount, string DepositDescription)
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

            //textbox for date of transaction that is entered in by user
            if (Date == null) //if date is not entered
            {
    
                ViewBag.Date = "Date is null";
            }
            else //they entered in a date
            {
                ViewBag.Date = "The date is " + Date;
            }

            //textbox for deposit amount
            if (DepositAmount != null && DepositAmount != "")
            {
                Decimal decDepositAmount;
                try
                {
                    decDepositAmount = Convert.ToDecimal(DepositAmount);
                }
                catch
                {
                    ViewBag.Message = DepositAmount + "is not a valid input. Please try again.";

                    //re-populate drop-downs
                    ViewBag.AllCheckingDeposits = GetAllCheckingDepositAccounts();
                    ViewBag.AllSavingsDeposits = GetAllSavingsDepositAccounts();
                    ViewBag.AllIRADeposits = GetIRADepositAccount();
                    ViewBag.AllStockPortfolioDeposits = GetStockPortfolioDepositAccount();

                    //send user back to home page
                    return View("Index");
                }

                //add value to view bag
                ViewBag.UpdatedDepositAmount = "The updated deposit amount is " + decDepositAmount.ToString("n2");
            }
            else //they didn't enter in a deposit amount
            {
                ViewBag.UpdatedDepositAmount = "No deposit amount was entered.";
            }

            //textbox for description of deposit transaction
            if (DepositDescription == null || DepositDescription == "") //if date is not entered
            {
                ViewBag.DepositDescription = "Description is null";
            }
            else //they entered in a date
            {
                ViewBag.DepositDescription = "Description " + DepositDescription;
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

        

        //public SelectList GetAllUsers()
        //{
        //    var query = from u in db.Users
        //                orderby u.FirstName
        //                select u;
        //    List<AppUser> allUsers = query.ToList();
        //    SelectList allUsersList = new SelectList(allUsers, "Id", "FirstName");
        //    return allUsersList;
        //}

        //public MultiSelectList GetAllUsers(Transaction transaction)
        //{
        //    var query = from u in db.Users
        //                orderby u.FirstName
        //                select u;
        //    List<AppUser> allUsers = query.ToList();
        //    SelectList list = new SelectList(allUsers, "Id", "FirstName");
        //    return list;
        //}
    }
}
