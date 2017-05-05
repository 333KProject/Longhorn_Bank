using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Security;
using System.Web;
using System.Web.Mvc;
using Longhorn_Bank.Models;
using Microsoft.AspNet.Identity.Owin;

namespace Longhorn_Bank.Controllers
{
    public class EmployeePageController : Controller
    {
        public AppDbContext db = new AppDbContext();

        // GET: EmployeePage
        public ActionResult Index()
        {
            //List<AppUser> user = db.Users.ToList();
            //var query = from c in user select c;
            //query = query.Where(c => c.UserRole = "Manager");

            return View();
        }

        // GET: EmployeePage/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUser appUser = db.Users.Find(id);
            if (appUser == null)
            {
                return HttpNotFound();
            }
            return View(appUser);
        }

        // GET: EmployeePage/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: EmployeePage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Address,City,State,ZipCode,DOB,MiddleInitial,SSN,EmpType,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] AppUser appUser)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(appUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(appUser);
        }

        // GET: EmployeePage/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUser appUser = db.Users.Find(id);
            if (appUser == null)
            {
                return HttpNotFound();
            }
            
            return View(appUser);
        }

        // POST: EmployeePage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditManagers([Bind(Include = "Id,FirstName,LastName,Address,City,State,ZipCode,DOB,MiddleInitial,SSN,EmpType,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] AppUser appUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(appUser);
        }
        [Authorize(Roles = "Employee")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmployees([Bind(Include = "Address,City,State,ZipCode,PhoneNumber")] AppUser appUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(appUser);
        }

        // GET: EmployeePage/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUser appUser = db.Users.Find(id);
            if (appUser == null)
            {
                return HttpNotFound();
            }
            return View(appUser);
        }

        // POST: EmployeePage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AppUser appUser = db.Users.Find(id);
            db.Users.Remove(appUser);
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

        public ActionResult ViewAvailableStocks()
        {
            return View(db.AvailableStocks.ToList());
        }
        [Authorize(Roles = "Manager")]
        public ActionResult AddNewStock()
        {

            return View();
        }
        [Authorize(Roles = "Manager")]
        public ActionResult ManagerHomePage()
        {
            return View();
        }

        [Authorize(Roles="Manager, Employee")]
        public ActionResult EditRoles()
        {
            return RedirectToAction("Index", "RoleAdmin");
        }
       
        [Authorize(Roles = "Manager, Employee")]
        public ActionResult EmployeeHomePage()
        {
            return View();
        }

   
        public ActionResult Disputes()
        {
            return View();
        }
    }
}
