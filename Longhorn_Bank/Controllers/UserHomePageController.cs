using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Longhorn_Bank.Controllers
{
    public class UserHomePageController : Controller
    {
        // GET: UserHomePage
        public ActionResult Index()
        {
            //if (Age >= DateTime.Now.AddYears(-70) || UserIRA.IRA == null)
            //{
            //    return View();
            //}
            //else
            {
                return View("Error", new string[] { "You must apply for a banking product to continue using the site." });
            }
        }
    }
}