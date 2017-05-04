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

        public Int32 IRAAccountNumber { get; set; }

        [Required]
        public Decimal IRACashBalance { get; set; }

        public String IRAName { get; set; }

        public bool IRAAccountActive { get; set; }

        public IRA()
        {
            IRAAccountActive = true;
        }


        //navigational properties


        public virtual List<Transaction> Transactions { get; set; }
        public virtual AppUser User { get; set; }
    }
}