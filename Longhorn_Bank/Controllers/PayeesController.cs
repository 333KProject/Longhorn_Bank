using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Longhorn_Bank.Models;
using Longhorn_Bank.Migrations;
using Microsoft.AspNet.Identity;

namespace Longhorn_Bank.Controllers
{
    public class PayeesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Payees
        public ActionResult Index()
        {
            return View(db.PayeeDbSet.ToList());
        }

        // GET: Payees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payee payee = db.PayeeDbSet.Find(id);
            if (payee == null)
            {
                return HttpNotFound();
            }
            return View(payee);
        }

        // GET: Payees/Create
        public ActionResult Create()

        {
            //Show Existing Payees 
            ViewBag.AllPayees = GetAllPayees();

            return View();
        }

        // POST: Payees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PayeeID,PayeeName,PayeeAddress,PayeeCity,State,ZipCode,PayType")]  string Id, Payee @payee, AppUser UserAccount, AppDbContext db)
        {
            string Id3 = User.Identity.GetUserId();
            AppUser UserAccounts = db.Users.Find(Id3);
            AppUser SelectedUser = db.Users.Find(Id3);
            //@payee.AppUsers = SelectedUser;
            if (ModelState.IsValid)
            {
                db.PayeeDbSet.Add(@payee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AllPayees = GetAllPayees();
            return View(@payee);
        }

        // GET: Payees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payee payee = db.PayeeDbSet.Find(id);
            if (payee == null)
            {
                return HttpNotFound();
            }
            return View(payee);
        }

        // POST: Payees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PayeeID,PayeeName,PayeeStreet,PayeeCity,State,ZipCode,PayType")] Payee payee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(payee);
        }

        // GET: Payees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payee payee = db.PayeeDbSet.Find(id);
            if (payee == null)
            {
                return HttpNotFound();
            }
            return View(payee);
        }

        // POST: Payees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Payee payee = db.PayeeDbSet.Find(id);
            db.PayeeDbSet.Remove(payee);
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

        //Create Select list to gather all payee names from all customer
        public SelectList GetAllPayees()
        {
            var query = from c in db.PayeeDbSet
                        orderby c.PayeeName
                        select c;
            List<Payee> allPayees = query.ToList();

            SelectList allPayeeslist = new SelectList(allPayees, "PayeeID", "PayeeName");

            return allPayeeslist;

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

        ////GET: Make a Payment 
        public ActionResult MakeAPayment(string Id)

        {
            ViewBag.AllCheckingDeposits = GetAllCheckingDepositAccounts();
            ViewBag.AllSavingsDeposits = GetAllSavingsDepositAccounts();

            return View();
        }

        //POST: Make a Payment
        public ActionResult PaymentConfirmed([Bind(Include = "PayeeID, PayeeName, PayeeAddress, PayeeCity, State, ZipCode, PayType")] int SelectedCheckingDepositAccount, int SelectedSavingsDepositAccount)
        {
            string Id = User.Identity.GetUserId();
            AppUser UserAccounts = db.Users.Find(Id);
            UserAccounts.Checkings = UserAccounts.Checkings;
            UserAccounts.Savings = UserAccounts.Savings;


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

            ViewData["AllCheckingDeposits"] = SelectedCheckingDepositAccount;
            ViewData["AllSavingsDeposits"] = SelectedSavingsDepositAccount;

            return View();

           
        }

        //GET: Add an Existing Account
        public ActionResult ExistingPayee()
        {
            ViewBag.AllPayees = GetAllPayees();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //POST: Add an Existing Account 
        public ActionResult ExistingPayee([Bind(Include = "PayeeID,PayeeName,PayeeAddress,PayeeCity,State,ZipCode,PayType")] Payee @payee, AppUser User, int[] SelectedPayee, string Id, AppDbContext db)
        {

            AppUser Usertochange = db.Users.Find(User.Id);
    
            if (ModelState.IsValid)
            {
                if (SelectedPayee != null)
                {
                    foreach (int PayeeId in SelectedPayee)
                    {
                        Payee payeetoadd = db.PayeeDbSet.Find(SelectedPayee);
                       //Payee payeetoadd = db.PayeeDbSet.Find(PayeeId);
                        Usertochange.Payees.Add(payeetoadd);
                    }
                }
                db.Entry(Usertochange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AllPayees = GetAllPayees();
            return View(@payee);
        }

        

    }
}
