using Longhorn_Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Longhorn_Bank.Controllers
{
    public class DisputesController : Controller
    {
        AppDbContext db = new AppDbContext();

        [Authorize(Roles = "Employee")]
        // GET: Disputes
        public ActionResult ViewCustomerDisputes()
        {
            return View(db.Disputes.ToList());
        }

        //POST: Disputes
        public ActionResult ViewCustomerDisputes(AppUser Id)
        {

            return View(Id);
        }

       
    }
}