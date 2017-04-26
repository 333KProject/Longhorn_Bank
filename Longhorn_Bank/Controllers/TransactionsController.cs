using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Longhorn_Bank.Models;


public enum Limit {  $0-$100, }
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
            Transaction SelectNone = new Models.Transaction() { TransactionID = 0, TransactionType = "All Transactions" };
            Transactions.Add(SelectNone);

            //select list
            SelectList ALLTransactions = new SelectList(Transactions.OrderBy(t => t.TransactionID), "TransactionID", "TransactionType");
            ViewBag.Transactions = ALLTransactions;
            return View();
        }

        //search method for description of transaction
        public ActionResult TransactionSearchResults (string SearchString, int? SelectedTransaction, string Description, decimal? Amount, Int32 TransactionNumber, DateTime Date, Limit SelectedLimit)
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
                query = query.Where(t => t.Transactions.TransactionID == SelectedTransaction);
            }
            else
            {

            }

            //amount search criteria
            if ((Amount == null || Amount.ToString() == "") && (SelectedLimit == Limit.GreaterThan || SelectedLimit == Limit.LessThan))
            {
              
            }
            else if (SelectedLimit == Limit.GreaterThan)
            {
                query = query.Where
            }
        }
    }
}
