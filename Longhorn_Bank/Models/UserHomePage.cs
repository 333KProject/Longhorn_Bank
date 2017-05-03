using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Longhorn_Bank.Models
{
    public class UserHomePage
    {
        public List<Checking> Checkings { get; set; }
        public List<Saving> Savings { get; set; }
        public IRA IRA { get; set; }
        public StockPortfolio Stockportfolio { get; set; }
    }
}