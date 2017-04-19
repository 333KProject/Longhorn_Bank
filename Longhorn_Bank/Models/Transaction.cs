using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Longhorn_Bank.Models
{
    public class Transaction
    {
        [Required]
        public Int32 TransactionID { get; set; }

        public Int32 TransactionNumber { get; set; }

        [Required(ErrorMessage = "Please enter a valid date")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Please enter a description")]
        public String Description { get; set; }

        public String TransactionType { get; set; }

        public String EmployeeComment { get; set; }

        public String Status { get; set; }

        [Required]
        public Decimal Amount { get; set; }

        //navigational properties
        /*public virtual CheckingAccount CheckingAccount { get; set; }
        public virtual SavingsAccount SavingsAccount { get; set; }*/
        
        //transactions model (which has a 1:1 relationship with IRA Accounts - below)
        /*public virtual IRAAccount IRAAccount { get; set; }
        public virtual StockAccount StockAccount { get; set; }*/
    }
}