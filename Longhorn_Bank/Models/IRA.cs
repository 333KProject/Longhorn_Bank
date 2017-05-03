using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Longhorn_Bank.Models
{
    public class IRA
    {
      
        public Int32 IRAID { get; set; }

        public Int32 IRAAccountNumber { get; set; }

        [Required]
        public Decimal IRACashBalance { get; set; }

        public String IRAName { get; set; }

        [DefaultValue(true)]
        public bool IRAActive { get; set; }

        //navigational properties


        public virtual List<Transaction> Transactions { get; set; }
        public virtual AppUser User { get; set; }
    }
}