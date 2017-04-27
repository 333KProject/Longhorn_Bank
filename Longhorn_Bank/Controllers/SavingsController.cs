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
    public class SavingsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Savings
        public ActionResult Index()
        {
            return View(db.SavingsDbSet.ToList());
        }

        // GET: Savings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Saving @saving = db.SavingsDbSet.Find(id);
            if (@saving == null)
            {
                return HttpNotFound();
            }
            return View(@saving);
        }

        // GET: Savings/Create
        public ActionResult Create()
        {
            ViewBag.AllUsers = GetAllUsers();
            return View();
        }

        // POST: Savings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //TO DO: create customer ID to add into if loop
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SavingID,SavingsName,SavingsBalance,TransactionType")] Saving @saving, string Id)
        {
            AppUser SelectedUser = db.Users.Find(Id);
            @saving.User = SelectedUser;
            if (ModelState.IsValid)
            {
                db.SavingsDbSet.Add(@saving);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AllUsers = GetAllUsers(@saving);
            return View(@saving);
        }

        // GET: Savings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Saving @saving = db.SavingsDbSet.Find(id);
            if (@saving == null)
            {
                return HttpNotFound();
            }
            ViewBag.AllUsers = GetAllUsers(@saving);
            return View(@saving);
        }

        // POST: Savings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SavingID,SavingsName,SavingsBalance,TransactionType")] Saving @saving, string Id, string[] SelectedUsers)
        {
            if (ModelState.IsValid)
            {
                //find associated user
                Saving savingToChange = db.SavingsDbSet.Find(@saving.SavingID);

                if (savingToChange.User.Id != Id)
                {
                    //find user
                    AppUser SelectedUser = db.Users.Find(Id);

                    //update user
                    savingToChange.User = SelectedUser;
                }

                savingToChange.SavingsName = @saving.SavingsName;

                db.Entry(savingToChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AllUsers = GetAllUsers(@saving);
            return View(@saving);
        }

        // GET: Savings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Saving @saving = db.SavingsDbSet.Find(id);
            if (@saving == null)
            {
                return HttpNotFound();
            }
            return View(@saving);
        }

        // POST: Savings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Saving @saving = db.SavingsDbSet.Find(id);
            db.SavingsDbSet.Remove(@saving);
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

        public SelectList GetAllUsers()
        {
            var query = from u in db.Users
                        orderby u.FirstName
                        select u;
            List<AppUser> allUsers = query.ToList();
            SelectList allUsersList = new SelectList(allUsers, "Id", "FirstName");
            return allUsersList;
        }

        public MultiSelectList GetAllUsers(Saving @saving)
        {
            var query = from u in db.Users
                        orderby u.FirstName
                        select u;
            List<AppUser> allUsers = query.ToList();
            SelectList list = new SelectList(allUsers, "Id", "FirstName", @saving.User.Id);
            return list;
        }
    }
}
