using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Longhorn_Bank.Models
{
    public class IRA
    {
      
        public Int32 IRAID { get; set; }

        [Required]
        public Decimal CashBalance { get; set; }

        public String Name { get; set; }

        //navigational properties
   
        
        public virtual List<Transaction> Transactions { get; set; }
        public virtual AppUser User { get; set; }
    }
}