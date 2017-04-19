using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Longhorn_Bank.Models
{
    //Checking model
    public class Checking
    {
        //primary key property
        public Int32 CheckingID { get; set; }

        public string CheckingsName { get; set; }

        public Decimal CheckingsBalance { get; set; }

        public TransactionType TransactionType { get; set; }

        //navigation properties 
        public virtual Account Account { get; set; }
        public virtual List<Transaction> Transactions { get; set; }

    }
}