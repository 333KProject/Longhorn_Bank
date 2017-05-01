using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Longhorn_Bank.Models;


public enum AmountRange { A, B, C, D }
public enum DateRange { last15days, last30days, last60days }

namespace Longhorn_Bank.Controllers
{

    public class TransactionsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Transactions
        public ActionResult Index()
        {
            return View(db.TransactionsDbSet.ToList());
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

        // GET: Transactions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransactionID,TransactionNumber,Date,Description,TransactionType,EmployeeComment,Status,Amount")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.TransactionsDbSet.Add(transaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransactionID,TransactionNumber,Date,Description,TransactionType,EmployeeComment,Status,Amount")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transaction);
        }

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

        //detailed search method for transaction type
        public ActionResult TransactionTypeSearch()
        {
            //create list for transaction type
            List<Transaction> Transactions = db.TransactionsDbSet.ToList();
            Transaction SelectNoTransactions = new Models.Transaction() { TransactionID = 0, TransactionName = "All Transactions" };
            Transactions.Add(SelectNoTransactions);

            //select list
            SelectList ALLTransactions = new SelectList(Transactions.OrderBy(t => t.TransactionID), "TransactionID", "TransactionType");
            ViewBag.Transactions = ALLTransactions;
            return View("DetailedSearch");
        }

        //detailed search method for date
        public ActionResult DateSearch()
        {
            //create list for date
            List<Transaction> Transactions = db.TransactionsDbSet.ToList();
            Transaction SelectNoDates = new Models.Transaction() { TransactionID = 0, TransactionName = "All Dates" };
            Transactions.Add(SelectNoDates);

            //select list
            SelectList ALLDates = new SelectList(Transactions.OrderBy(t => t.TransactionID), "TransactionID", "Date");
            ViewBag.Transactions = ALLDates;
            return View("DetailedSEarch");
        }

        //search method for description of transaction
        public ActionResult TransactionSearchResults (string SearchString, int? SelectedTransaction, string Description, decimal? Amount, decimal? Amount1, decimal? Amount2, Int32 TransactionNumber, DateTime Date, DateTime CustomDateRange1, DateTime CustomDateRange2, AmountRange SelectedAmountRange, DateRange SelectedDateRange)
        {
            //create variable
            var query = from t in db.TransactionsDbSet select t;

            //code for searching descriiption
            if (SearchString == null || SearchString == "")
            {

            }
            else
            {
                ViewBag.SearchString = "Search string is " + SearchString;
                query = query.Where(t => t.Description.Contains(SearchString));
            }

            //transaction type search criteria
            if (SelectedTransaction != 0)
            {
                query = query.Where(t => t.TransactionID == SelectedTransaction);
            }
            else
            {

            }

            //amount search criteria
            if ((Amount == null || Amount.ToString() == ""))
            {
            }
            else if (SelectedAmountRange == AmountRange.A)
            {
                query = query.Where(t => t.Amount >= 0 && t.Amount <= 100);
            }
            else if (SelectedAmountRange == AmountRange.B)
            {
                query = query.Where(t => t.Amount > 100 && t.Amount <=200);
            }
            else if (SelectedAmountRange == AmountRange.C)
            {
                query = query.Where(t => t.Amount > 200 && t.Amount <= 300);
            }
            else if (SelectedAmountRange == AmountRange.D)
            {
                query = query.Where(t => t.Amount > 300);
            }
            else
            {
                query = query.Where(t => t.AmountStart >= Amount1);
                query = query.Where(t => t.AmountEnd <= Amount2);
            }
            //TO DO: connect enum and custom amount entry 
            query = query.OrderBy(t => t.TransactionNumber).ThenBy(t => t.Amount);

            //date search criteria
            if ((Date == null || Date.ToString() == ""))
            {
            }
            else if (SelectedDateRange == DateRange.last15days)
            {
                query = query.Where(t => t.TimeStamp <= t.DateForPast15);
            }
            else if (SelectedDateRange == DateRange.last30days)
            {
                query = query.Where(t => t.TimeStamp <= t.DateForPast30);
            }
            else if (SelectedDateRange == DateRange.last60days)
            {
                query = query.Where(t => t.TimeStamp <= t.DateForPast60);
            }
            else
            {
                query = query.Where(t => t.CustomDateRangeStart >= CustomDateRange1);
                query = query.Where(t => t.CustomDateRangeEnd <= CustomDateRange2);
            }
 
            query = query.OrderBy(t => t.TransactionNumber).ThenBy(t => t.Amount);

            List<Transaction> SelectedTransactions = query.ToList();
            ViewBag.All = db.TransactionsDbSet.ToList().Count;
            ViewBag.Returned = SelectedTransactions.Count;

            return View("Index", SelectedTransactions);
        }
    }
}
