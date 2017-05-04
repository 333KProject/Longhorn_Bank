using Longhorn_Bank.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Longhorn_Bank.Migrations
{
    public class SeedPayees
    {
        AppDbContext db = new AppDbContext();
        public static void AddPayees (AppDbContext db)
        {
            Payee p1 = new Payee(); p1.PayeeName = "City of Austin Water"; p1.PayType = PayeeType.Utilities; p1.PayeeAddress = "113 South Congress Ave."; p1.PayeeCity = "Austin"; p1.State = StateAbrv.TX; p1.ZipCode = "78710"; p1.PhoneNumber = "5126645558"; db.PayeeDbSet.AddOrUpdate(p => p.PayeeName, p1);
            Payee p2 = new Payee(); p2.PayeeName = "Reliant Energy"; p2.PayType = PayeeType.Utilities; p2.PayeeAddress = "3500 E. Interstate 10"; p2.PayeeCity = "Houston"; p2.State = StateAbrv.TX; p2.ZipCode = "77099"; p2.PhoneNumber = "7135546697"; db.PayeeDbSet.AddOrUpdate(p => p.PayeeName, p2);
            Payee p3 = new Payee(); p3.PayeeName = "Lee Properties"; p3.PayType = PayeeType.Rent; p3.PayeeAddress = "2500 Salado"; p3.PayeeCity = "Austin"; p3.State = StateAbrv.TX; p3.ZipCode = "78705"; p3.PhoneNumber = "5124453312"; db.PayeeDbSet.AddOrUpdate(p => p.PayeeName, p3);
            Payee p4 = new Payee(); p4.PayeeName = "Capital One"; p4.PayType = PayeeType.CreditCard; p4.PayeeAddress = "1299 Fargo Blvd."; p4.PayeeCity = "Cheyenne"; p4.State = StateAbrv.WY; p4.ZipCode = "82001"; p4.PhoneNumber = "5302215542"; db.PayeeDbSet.AddOrUpdate(p => p.PayeeName, p4);
            Payee p5 = new Payee(); p5.PayeeName = "Vanguard Title"; p5.PayType = PayeeType.Mortgage; p5.PayeeAddress = "10976 Interstate 35 South"; p5.PayeeCity = "Austin"; p5.State = StateAbrv.TX; p5.ZipCode = "78745"; p5.PhoneNumber = "5128654951"; db.PayeeDbSet.AddOrUpdate(p => p.PayeeName, p5);
            Payee p6 = new Payee(); p6.PayeeName = "Lawn Care of Texas"; p6.PayType = PayeeType.Other; p6.PayeeAddress = "4473 W. 3rd Street"; p6.PayeeCity = "Austin"; p6.State = StateAbrv.TX; p6.ZipCode = "78712"; p6.PhoneNumber = "5123365247"; db.PayeeDbSet.AddOrUpdate(p => p.PayeeName, p6);

            db.SaveChanges();

        }
    }
}