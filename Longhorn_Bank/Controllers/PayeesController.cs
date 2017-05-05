using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Longhorn_Bank.Models;


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
        public ActionResult Create([Bind(Include = "PayeeID,PayeeName,PayeeAddress,PayeeCity,State,ZipCode,PayType")] AppUser User, int[] SelectedPayee)
        {

            if (ModelState.IsValid)
            {

                AppUser Usertochange = db.Users.Find(@User.Id);

                if (SelectedPayee != null)
                {
                    foreach (int PayeeId in SelectedPayee)
                    {
                        Payee payeetoadd = db.PayeeDbSet.Find(PayeeId);
                        Usertochange.Payees.Add(payeetoadd);
                        db.PayeeDbSet.Add(@payeetoadd);
                    }
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AllPayees = GetAllPayees();

            return View();
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

        //Select list for user checkings and savings to choose from to make a payment
        public SelectList GetAllUserCheckingAccounts(string Id)
        {

            ////figure out how to get checkings and savings for that one user 
            AppUser UserAccounts = db.Users.Find(Id);

            var queryCheckings = (from a in db.CheckingsDbSet select a.CheckingsName).ToList();
            SelectList allCheckings = new SelectList(queryCheckings, "Id", "Name");

            return allCheckings;
        }

        public SelectList GetAllUserSavingsAccounts(string Id)
        {

            ////figure out how to get checkings and savings for that one user 
            AppUser UserAccounts = db.Users.Find(Id);

            var querySavings = (from a in db.SavingsDbSet select a.SavingsName).ToList();
            SelectList allSavings = new SelectList(querySavings, "Id", "Name");

            return allSavings;
        }

        ////GET: Make a Payment 
        public ActionResult MakeAPayment(string Id)

        {
            ViewBag.AllCheckings = GetAllUserCheckingAccounts(Id);
            ViewBag.AllSavings = GetAllUserSavingsAccounts(Id);

            return View();
        }

        //POST: Make a Payment
        public ActionResult PaymentConfirmed([Bind(Include = "PayeeID, PayeeName, PayeeAddress, PayeeCity, State, ZipCode, PayType")] AppUser  User, int[] SelectedAccount, Int32 Amount)
        {
            if (ModelState.IsValid)
            {
                //deduct amount from selected account 

            if (SelectedAccount != null)
                {

                }

                
            }
            return View();
        }

        //GET: Add an Existing Account
        public ActionResult ExistingPayee()
        {
            ViewBag.AllPayees = GetAllPayees();

            return View();
        }

        //POST: Add an Existing Account 
        public ActionResult ExistingPayeeConfirmed([Bind(Include = "PayeeID,PayeeName,PayeeAddress,PayeeCity,State,ZipCode,PayType")] Payee @payee, AppUser User, int[] SelectedPayee)
        {
            
            AppUser Usertochange = db.Users.Find(@User.Id);
    
            if (ModelState.IsValid)
            {
                if (SelectedPayee != null)
                {
                    foreach (int PayeeId in SelectedPayee)
                    {
                        Payee payeetoadd = db.PayeeDbSet.Find(PayeeId);
                        Usertochange.Payees.Add(payeetoadd);
                    }
                }
                db.Entry(Usertochange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
