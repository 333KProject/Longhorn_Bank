using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Longhorn_Bank.Models;
using System.Net;
using System.Data.Entity;

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


        // GET: Account/Edit/5
        public ActionResult Edit()
        {
            string Id = User.Identity.GetUserId();

            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AppUser user = db.Users.Find(Id);
            if (user == null)
            {
                return HttpNotFound();
            }
            if (user.Id != User.Identity.GetUserId())
            {
                return RedirectToAction("Login", "Account");
            }

            return View(user);
        }

        //POST: Account/Edit/5
        //To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,MiddleInitial,Address,City,State,ZipCode,Email,PhoneNumber")] AppUser user)
        {
            if (ModelState.IsValid)
            {
                AppUser userToChange = db.Users.Find(user.Id);

                userToChange.FirstName = @user.FirstName;
                userToChange.LastName = @user.LastName;
                userToChange.MiddleInitial = @user.MiddleInitial;
                userToChange.Address = @user.Address;
                userToChange.City = @user.City;
                userToChange.State = @user.State;
                userToChange.ZipCode = @user.ZipCode;
                userToChange.Email = @user.Email;
                userToChange.UserName = @user.UserName;
                userToChange.PhoneNumber = @user.PhoneNumber;

                db.Entry(userToChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

    }
}


