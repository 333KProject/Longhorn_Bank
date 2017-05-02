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
    public class CheckingsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Checkings
        public ActionResult Index()
        {
            
            return View(db.CheckingsDbSet.ToList());
        }

        // GET: Checkings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Checking @checking = db.CheckingsDbSet.Find(id);
            if (@checking == null)
            {
                return HttpNotFound();
            }
            return View(@checking);
        }

        // GET: Checkings/Create
        public ActionResult Create()
        {
            ViewBag.AllUsers = GetAllUsers();
            return View();
        }

        // POST: Checkings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //TO DO: create customer ID to add into if loop
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CheckingID,CheckingsName,CheckingsBalance")] Checking @checking, string Id)
        {
            AppUser SelectedUser = db.Users.Find(Id);
            @checking.User = SelectedUser;
            if (ModelState.IsValid)
            {
                db.CheckingsDbSet.Add(@checking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AllUsers = GetAllUsers(@checking);
            return View(@checking);
        }

        // GET: Checkings/Edit/5
        //changed Id to id
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Checking @checking = db.CheckingsDbSet.Find(id);
            if (@checking == null)
            {
                return HttpNotFound();
            }
            ViewBag.AllUsers = GetAllUsers(@checking);
            return View(@checking);
        }

        // POST: Checkings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CheckingID,CheckingsName,CheckingsBalance")] Checking @checking, string Id, string[] SelectedUsers)
        {
            if (ModelState.IsValid)
            {
                //find associated user
                Checking checkingToChange = db.CheckingsDbSet.Find(@checking.CheckingID);

                //edit error is there becauase there's no users in the database: check this after seeding to see if edit works
                if (checkingToChange.User.Id != Id)
                {
                    //find user
                    AppUser SelectedUser = db.Users.Find(Id);

                    //update user
                    checkingToChange.User = SelectedUser;
                }

                checkingToChange.CheckingsName = @checking.CheckingsName;
                
                db.Entry(checkingToChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AllUsers = GetAllUsers(@checking);
            return View(@checking);
        }

        //user can't delete an account but can disable so use this to figure out code for that
    
        //// GET: Checkings/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Checking @checking = db.CheckingsDbSet.Find(id);
        //    if (@checking == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(@checking);
        //}

        //// POST: Checkings/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Checking @checking = db.CheckingsDbSet.Find(id);
        //    db.CheckingsDbSet.Remove(@checking);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public SelectList GetAllUsers()
        {
            var query = from u in db.Users
                        orderby u.FirstName
                        select u;
            List<AppUser> allUsers = query.ToList();
            SelectList allUsersList = new SelectList(allUsers, "Id", "FirstName");
            return allUsersList;
        }

        public MultiSelectList GetAllUsers(Checking @checking)
        {
            var query = from u in db.Users
                        orderby u.FirstName
                        select u;
            List<AppUser> allUsers = query.ToList();
            SelectList list = new SelectList(allUsers, "Id", "FirstName");
            return list;
        }

       public SelectList CreateAccountNumberList(int? AccountNumber)
       {
            var queryCheckings = from a in db.CheckingsDbSet
                                where a.CheckingsAccountNumber == AccountNumber
                                select AccountNumber.Max();
            var querySavings = from a in db.SavingsDbSet
                               where a.SavingsAccountNumber == AccountNumber
                                select a;
            var queryIRAs = from a in db.IRAsDbSet
                            where a.IRAAccountsNumber == AccountNumber
                            select a;
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
