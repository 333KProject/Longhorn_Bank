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

        public Checking()
        {
            CheckingsName = "Longhorn Saving";
        }

        public string CheckingsName { get; set; }

        public Int32 CheckingsAccountNumber { get; set; }

        public Decimal CheckingsBalance { get; set; }

        public TransactionType TransactionType { get; set; }

        //navigation properties 
        public virtual AppUser User { get; set; }
        public virtual List<Transaction> Transactions { get; set; }

    }

    
}