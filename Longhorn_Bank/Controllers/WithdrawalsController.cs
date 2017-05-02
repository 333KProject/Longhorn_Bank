using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Longhorn_Bank.Controllers
{
    public class WithdrawalsController : Controller
    {
        // GET: Withdrawals
        public ActionResult Index()
        {
            return View();
        }
    }
}