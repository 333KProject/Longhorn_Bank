using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

public enum TransactionType { Deposit, Withdrawal, Transfer }

namespace Longhorn_Bank.Models
{
    //Saving model
    public class Saving
    {
        //primary key property
        public Int32 SavingID { get; set; }


        public Int32 SavingsAccountNumber { get; set; }

        public Saving()
        {
            SavingsName = "Longhorn Savings";
        }

        public string SavingsName { get; set; }

        public Decimal SavingsBalance { get; set; }

        //navigation properties 
        public virtual AppUser User { get; set; }
        public virtual List<Transaction> Transactions { get; set; }

    }
}
