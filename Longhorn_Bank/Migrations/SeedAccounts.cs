using Longhorn_Bank.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Longhorn_Bank.Migrations
{
    public class SeedAccounts
    {
        AppDbContext db = new AppDbContext();
        public static void AddAccounts(AppDbContext db)
        {
            Saving s1 = new Saving();
            s1.SavingsAccountNumber = 1000000001;
            s1.User = db.Users.FirstOrDefault(u=>u.UserName== "willsheff@email.com");
            s1.SavingsName = "William's Savings";
            s1.SavingsBalance = 40035.5m;
            db.SavingsDbSet.AddOrUpdate(s => s.SavingsAccountNumber, s1);


        }
    }
}