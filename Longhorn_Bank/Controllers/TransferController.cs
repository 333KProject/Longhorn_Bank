using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Longhorn_Bank.Models;

namespace Longhorn_Bank.Controllers
{
    public class TransferController : Controller
    {
        private AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
            //ViewBad.AllTransferAccounts = GetAllTransferAccounts();
            return View();
        }


        //GET Transfer
        //public ActionResult Transfer(int TransferAmount, int AccountBalanceFrom, int AccountBalanceTo, string SelectedTransferFrom, string SelectedTransferTo)
        //{
        //    if(TransferAmount > AccountBalanceFrom)
        //    {
        //        return View("Error", new string[] { "This account does not have enough money to transfer" });
        //    }
        //    else
        //    {
        //        int NewAccountBalanceTo = TransferAmount + AccountBalanceTo;
        //        int NewAccountBalanceFrom = TransferAmount - AccountBalanceFrom;
        //    }

        //}



          

    }
}