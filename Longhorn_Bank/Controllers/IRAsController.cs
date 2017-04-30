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
    public class IRAsController : Controller
    {

        AppDbContext db = new AppDbContext();

        // GET: IRAs
        public ActionResult Index()
        {
            return View(db.IRAsDbSet.ToList());
        }

        // GET: IRAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IRA iRA = db.IRAsDbSet.Find(id);
            if (iRA == null)
            {
                return HttpNotFound();
            }
            return View(iRA);
        }

        // GET: IRAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IRAs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IRAID,IRAAccountsNumber,CashBalance,Name")] IRA iRA)
        {
            if (ModelState.IsValid)
            {
                db.IRAsDbSet.Add(iRA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(iRA);
        }

        // GET: IRAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IRA iRA = db.IRAsDbSet.Find(id);
            if (iRA == null)
            {
                return HttpNotFound();
            }
            return View(iRA);
        }

        // POST: IRAs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IRAID,IRAAccountsNumber,CashBalance,Name")] IRA iRA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iRA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iRA);
        }

        // GET: IRAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IRA iRA = db.IRAsDbSet.Find(id);
            if (iRA == null)
            {
                return HttpNotFound();
            }
            return View(iRA);
        }

        // POST: IRAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IRA iRA = db.IRAsDbSet.Find(id);
            db.IRAsDbSet.Remove(iRA);
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
    }
}
