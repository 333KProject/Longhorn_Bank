using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

//yo yo yo

namespace Longhorn_Bank.Models
{
    //Account model
    public class Account
    {
        //primary key property
        public Int32 AccountID { get; set; }

        public string AccountName { get; set; }

        //navigation properties 
        public virtual AppUser AppUser { get; set; }
        public virtual List<Checking> Checkings { get; set; }
        public virtual List<Saving> Savings { get; set; }
        public virtual IRA IRA { get; set; }
        public virtual StockPortfolio StockPortfolio { get; set; }
    }
}