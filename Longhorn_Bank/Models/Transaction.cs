using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Longhorn_Bank.Models
{
    public enum TransType { Deposit, Withdrawal, Transfer }
    public class Transaction
    {
        [Required]
        public Int32 TransactionID { get; set; }

        public Int32 TransactionNumber { get; set; }

        [Required(ErrorMessage = "Please enter a valid date")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Please enter a description")]
        public String Description { get; set; }

        public TransType TransactionType { get; set; }

        public String EmployeeComment { get; set; }

        public String Status { get; set; }

        [Required]
        public Decimal Amount { get; set; }

        //navigational properties
        public virtual List<Checking> Checkings { get; set; }
        public virtual List<Saving> Savings { get; set; }
        
        public virtual List<IRA> IRAs { get; set; }
        public virtual List<StockPortfolio> StockPortfolios { get; set; }
    }
}