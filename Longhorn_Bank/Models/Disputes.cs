using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Longhorn_Bank.Models
{
    public enum DeleteDispute {Delete}

    public enum DisputeStatus { Submitted, Accepted, Rejected, Adjusted}

    public class Disputes
    {
        public string DisputeID { get; set; }

        public string DisputeComments { get; set; }

        public int DisputeAmount { get; set; }

        public DeleteDispute Delete { get; set; }

        public DisputeStatus Status { get; set; }

        //navigational property to transaction
        public virtual Transaction Transaction { get; set; }
        

    }


}