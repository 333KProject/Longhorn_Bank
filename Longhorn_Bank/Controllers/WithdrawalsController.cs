using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Longhorn_Bank.Controllers
{
    public class WithdrawalsController : Controller
    {

        // GET: Withdrawals
        public ActionResult Index()
        {
            //TO DO: uncomment when done
            //ViewBag.AllWithdrawalAccounts = GetAllDepositAccounts();
            return View();
        }

        //figure out how to populate with three different types of accounts

        public ActionResult WithdrawalResults(string WithdrawalAmount)
        {
            // TO DO:
            //    //Selected month is the selected value from the dropdown
            //    if (SelectedWithdrawalAccount == 0) //they choose no deposit account
            //    {
            //        ViewBag.SelectedWithdrawalAccounts = "No account was selected";
            //    }
            //    else //depoosit account was selected
            //    {
            //        List<Month> AllMonths = MonthUtilities.GetMonths();
            //        Month MonthToDisplay = AllDepositAccount.Find(m => m.ID == SelectedDepositAccount);
            //        ViewBag.SelectedMonth = "The selected month is " + MonthToDisplay.MonthName;
            //    }

            //code for textbox entry where user entires deposit amount
            if (WithdrawalAmount != null && WithdrawalAmount != "")
            {
                //make sure string is a valid number
                Decimal decWithdrawalAmount;

                try
                {
                    decWithdrawalAmount = Convert.ToDecimal(WithdrawalAmount);
                }
                catch //this code will display when something is wrong
                {
                    //add a message for the viewbag
                    ViewBag.Message = WithdrawalAmount + "is not valid amount. Please try again.";

                    //re-populate dropdown
                    //ViewBag.AllWithdrawalAccounts = GetAllWithdrawalAccounts();

                    //send user back to home page
                    return View("Index");
                }

                //if deposit amount entered is negative or zero
                if (decWithdrawalAmount < 0 || decWithdrawalAmount == 0)
                {
                    //add a message for the viewbag
                    ViewBag.Message = WithdrawalAmount + "is not a valid amount. Please try again.";

                    //re-populate dropdown
                    //ViewBag.AllWithdrawalAccounts = GetAllWithdrawalAccounts();

                    //send user back to home page
                    return View("Index");
                }

                //TO DO: withdrawals of over $5000 should be treated the same as when opening the account, meaning they must be approved by a manager before being added to the account balance
                //? same as deposits??


            }
            return View();
        }
    }
}
