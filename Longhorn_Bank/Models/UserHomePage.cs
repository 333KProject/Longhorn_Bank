using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Longhorn_Bank.Models
{
    public class UserHomePage
    {
        public List<Checking> Checkings;
        public List<Saving> Savings;
        public IRA IRA;
        public StockPortfolio Stockportfolio;
    }
}