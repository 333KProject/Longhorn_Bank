using Longhorn_Bank.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Longhorn_Bank.Controllers
{
    public class UserHomePageController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: UserHomePage
        public ActionResult Index()
        {
            string Id = User.Identity.GetUserId();

            AppUser UserAccounts = db.Users.Find(Id);

            UserAccounts.Checkings = UserAccounts.Checkings;
            UserAccounts.Savings = UserAccounts.Savings;
            UserAccounts.IRA = UserAccounts.IRA;
            UserAccounts.StockPortfolio = UserAccounts.StockPortfolio;

            return View(UserAccounts);
        }



    }
}


