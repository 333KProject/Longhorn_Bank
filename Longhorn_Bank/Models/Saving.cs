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

        private string _savingsName;
        public String SavingsName
        {
            get { return _savingsName; }
            set { _savingsName = value ?? "Longhorn Savings"; }
        }

        public Decimal SavingsBalance { get; set; }

        public bool SavingAccountActive { get; set; }

        public Saving()
        {
            SavingAccountActive = true;
        }


        //navigation properties 
        public virtual AppUser User { get; set; }
        public virtual List<Transaction> Transactions { get; set; }
    }
}
