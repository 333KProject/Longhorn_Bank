﻿using System;
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
            return View(db.Payees.ToList());
        }

        // GET: Payees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payee payee = db.Payees.Find(id);
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
            //ViewBag.AllPayees = GetAllPayees();

            return View();
        }

        // POST: Payees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "PayeeID,PayeeName,PayeeAddress,PayeeCity,State,ZipCode,PayType")] Payee @payee, )
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if GetAllPayees != null{
        //            Payee SelectedPayee = db.PayeeDbSet.Find(PayeeID);
        //            //the beginning part of this after adding navigational property on app user 
        //            Payee = SelectedPayee;
        //        }

        //        db.Payees.Add(payee);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(payee);
        //}

        // GET: Payees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payee payee = db.Payees.Find(id);
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
            Payee payee = db.Payees.Find(id);
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
            Payee payee = db.Payees.Find(id);
            db.Payees.Remove(payee);
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
        //public SelectList GetAllPayees()
        //{
        //    //var query = from c in db.PayeesDbSet
        //    //            orderby c.PayeeName
        //    //            select c;
        //    //List<Payee> allPayees = query.ToList();

        //    //SelectList allPayeeslist = new SelectList(allPayees, "PayeeID", "PayeeName");

        //    return allPayeeslist;

        //}




    }
}
