using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Longhorn_Bank.Models
{
    //Checking model
    public class Checking
    {
        //primary key property
        public Int32 CheckingID { get; set; }

        private string _checkingsName;
        public String CheckingsName
        {
            get { return _checkingsName; }
            set { _checkingsName = value ?? "Longhorn Checking"; }
        }

        public Int32 CheckingsAccountNumber { get; set; }

        public Decimal CheckingsBalance { get; set; }

        [DefaultValue(true)]
        public bool CheckingAccountActive { get; set; }


        //navigation properties 
        public virtual AppUser User { get; set; }
        public virtual List<Transaction> Transactions { get; set; }

    }

    
}