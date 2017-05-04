using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Longhorn_Bank.Models
{
    public enum PayeeType { CreditCard, Utilities, Rent, Mortgage, Other }

    public class Payee

    {

        [Key]
        public Int32 PayeeID { get; set; }

        [Required(ErrorMessage = "Payee Name Required.")]
        [Display(Name = "Payee Name")]
        public string PayeeName { get; set; }

        [Required(ErrorMessage = "Address Required.")]
        [Display(Name = "Address Name")]
        public string PayeeAddress { get; set; }

        [Required(ErrorMessage = "City Required.")]
        [Display(Name = "City")]
        public string PayeeCity { get; set;}

        [Required(ErrorMessage = "State Required.")]
        [Display(Name = "State")]
        public StateAbrv State { get; set; }

        [Required(ErrorMessage = "Zip Code Required.")]
        [Display(Name = "ZipCode")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Payee Type Required.")]
        [Display(Name = "Pay Type")]
        public PayeeType PayType { get; set; }

        [Required(ErrorMessage = "Phone Number Required.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

       
        //TO DO: ADD Navigational Properties to connect payees to user 
        public virtual List<AppUser> AppUsers { get; set; }
        
    }
}