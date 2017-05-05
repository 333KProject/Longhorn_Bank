using Longhorn_Bank.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Longhorn_Bank.Controllers
{
    
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            return View();
            
        }
        public ActionResult Manage()
        {
            User.Identity.GetUserId();
            if (User.IsInRole("Employee"))
            {
                return RedirectToAction("EmployeeHomePage", "EmployeePage");
            }
            if (User.IsInRole("Manager"))
            {
                return RedirectToAction("ManagerHomePage", "EmployeePage");
            }
            if (User.IsInRole("User"))
            {
                return RedirectToAction("UserHomePage", "EmployeePage");
            }
            return View();
        }
    }
}