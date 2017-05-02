using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Longhorn_Bank.Models
{
    public class UserHomePage
    {
        public virtual List<Checking> Checkings { get; set; }
        public virtual List<Saving> Savings { get; set; }
        public virtual IRA IRA { get; set; }
        public virtual StockPortfolio StockPortfolio { get; set; }
    }
}