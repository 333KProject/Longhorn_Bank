using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Longhorn_Bank.Models
{
    public class UserHomePage
    {
        public IEnumerable<Checking> Checkings;
        public Saving saving;
        public IRA ira;
        public StockPortfolio stockportfolio;
    }
}