﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Longhorn_Bank.Controllers
{
    public class EmployeeHomePageController : Controller
    {
        // GET: EmployeeHomePage
        public ActionResult Index()
        {
            return View();
        }
    }
}