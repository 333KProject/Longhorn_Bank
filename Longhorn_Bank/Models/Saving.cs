using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

public enum TransactionType { Deposit, Withdrawal, Transfer }

namespace Longhorn_Bank.Models
{
    //Saving model
    public class Saving
    {
        //primary key property
        public Int32 SavingID { get; set; }

        public string SavingsName { get; set; }

        public Decimal SavingsBalance { get; set; }

        public TransactionType TransactionType { get; set; }

        //navigation properties 
        public virtual AppUser User { get; set; }
        public virtual List<Transaction> Transactions { get; set; }

    }
}
