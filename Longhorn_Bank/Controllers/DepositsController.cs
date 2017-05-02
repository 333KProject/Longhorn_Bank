using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Longhorn_Bank.Models;

namespace Longhorn_Bank.Controllers
{
    public class DepositsController : Controller
    {
        // GET: Deposits
        public ActionResult Index()
        {
            //TO DO: uncomment when done
            //ViewBag.AllDepositAccounts = GetAllDepositAccounts();
            return View();
        }

        //figure out how to populate with three different types of accounts

        public ActionResult DepositResults (string DepositAmount)
        {
            // TO DO:
            //    //Selected month is the selected value from the dropdown
            //    if (SelectedDepositAccount == 0) //they choose no deposit account
            //    {
            //        ViewBag.SelectedDepositAccounts = "No account was selected";
            //    }
            //    else //depoosit account was selected
            //    {
            //        List<Month> AllMonths = MonthUtilities.GetMonths();
            //        Month MonthToDisplay = AllDepositAccount.Find(m => m.ID == SelectedDepositAccount);
            //        ViewBag.SelectedMonth = "The selected month is " + MonthToDisplay.MonthName;
            //    }

            //code for textbox entry where user entires deposit amount
            if (DepositAmount != null && DepositAmount != "")
            {
                //make sure string is a valid number
                Decimal decDepositAmount;

                try
                {
                    decDepositAmount = Convert.ToDecimal(DepositAmount);
                }
                catch //this code will display when something is wrong
                {
                    //add a message for the viewbag
                    ViewBag.Message = DepositAmount + "is not valid amount. Please try again.";

                    //re-populate dropdown
                    //ViewBag.AllDepositAccounts = GetAllDepositAccounts();

                    //send user back to home page
                    return View("Index");
                }

                //if deposit amount entered is negative or zero
                if (decDepositAmount < 0 || decDepositAmount == 0)
                {
                    //add a message for the viewbag
                    ViewBag.Message = DepositAmount + "is not a valid amount. Please try again.";

                    //re-populate dropdown
                    //ViewBag.AllDepositAccounts = GetAllDepositAccounts();

                    //send user back to home page
                    return View("Index");
                }

                //TO DO: deposits of over $5000 should be treated the same as when opening the account, meaning they must be approved by a manager before being added to the account balance



            }
            return View();
        }

        //TO DO: method to populate drop down list of all accounts that the user has and can deposit to
        //these can only be checkings, savings, and IRA
        //public SelectList GetAllDepositAccounts()
        //{
        //    var query = from a in db.CheckingsDbSet
        //                orderby u.FirstName
        //                select u;
        //    List<AppUser> allUsers = query.ToList();
        //    SelectList allUsersList = new SelectList(allUsers, "Id", "FirstName");
        //    return allUsersList;
        //}

        

    }
}