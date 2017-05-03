using Longhorn_Bank.Models;
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
        public ActionResult Index(UserHomePage model)
        {
            
            return View();
        }

    }
}