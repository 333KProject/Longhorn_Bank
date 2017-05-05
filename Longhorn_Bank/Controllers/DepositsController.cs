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

        public ActionResult DepositResults(int SelectedCheckingDepositAccount, int SelectedSavingsDepositAccount, int SelectedIRADepositAccount, int SelectedStockPortfolioDepositAccount, string Date, string DepositAmount, string DepositDescription)
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
            if(Date == null || Date == "") //if date is not entered
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
    }
}   