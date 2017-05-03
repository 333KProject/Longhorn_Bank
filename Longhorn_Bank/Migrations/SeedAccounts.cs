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
            //Saving s1 = new Saving();
            //s1.SavingsAccountNumber = 1000000001;
            //s1.User = db.Users.FirstOrDefault(u => u.UserName == "willsheff@email.com");
            //s1.SavingsName = "William's Savings";
            //s1.SavingsBalance = 40035.5m;
            //db.SavingsDbSet.AddOrUpdate(s => s.SavingsAccountNumber, s1);

            //StockPortfolio sp1 = new StockPortfolio(); sp1.StockAccountNumber = 1000000000; sp1.User = db.Users.FirstOrDefault(u => u.UserName == "Dixon@aool.com"); sp1.Name = "Shan's Stock"; sp1.PortfolioCashBalance = 0m; db.StockPortfoliosDbSet.AddOrUpdate(sp => sp.StockAccountNumber, sp1);
            //Checking c1 = new Checking(); c1.CheckingsAccountNumber = 1000000002; c1.User = db.Users.FirstOrDefault(u => u.UserName == "smartinmartin.Martin@aool.com"); c1.CheckingsName = "Gregory's Checking"; c1.CheckingsBalance = 39779.49m; db.CheckingsDbSet.AddOrUpdate(c => c.CheckingsAccountNumber, c1);
            //Checking c2 = new Checking(); c2.CheckingsAccountNumber = 1000000003; c2.User = db.Users.FirstOrDefault(u => u.UserName == "avelasco@yaho.com"); c2.CheckingsName = "Allen's Checking"; c2.CheckingsBalance = 47277.33m; db.CheckingsDbSet.AddOrUpdate(c => c.CheckingsAccountNumber, c2);
            //Checking c3 = new Checking(); c3.CheckingsAccountNumber = 1000000004; c3.User = db.Users.FirstOrDefault(u => u.UserName == "rwood@voyager.net"); c3.CheckingsName = "Reagan's Checking"; c3.CheckingsBalance = 70812.15m; db.CheckingsDbSet.AddOrUpdate(c => c.CheckingsAccountNumber, c3);
            //Saving s2 = new Saving(); s2.SavingsAccountNumber = 1000000005; s2.User = db.Users.FirstOrDefault(u => u.UserName == "nelson.Kelly@aool.com"); s2.SavingsName = "Kelly's Savings"; s2.SavingsBalance = 21901.97m; db.SavingsDbSet.AddOrUpdate(s => s.SavingsAccountNumber, s2);
            //Checking c4 = new Checking(); c4.CheckingsAccountNumber = 1000000006; c4.User = db.Users.FirstOrDefault(u => u.UserName == "erynrice@aool.com"); c4.CheckingsName = "Eryn's Checking"; c4.CheckingsBalance = 70480.99m; db.CheckingsDbSet.AddOrUpdate(c => c.CheckingsAccountNumber, c4);
            //Saving s3 = new Saving(); s3.SavingsAccountNumber = 1000000007; s3.User = db.Users.FirstOrDefault(u => u.UserName == "westj@pioneer.net"); s3.SavingsName = "Jake's Savings"; s3.SavingsBalance = 7916.4m; db.SavingsDbSet.AddOrUpdate(s => s.SavingsAccountNumber, s3);
            //StockPortfolio sp2 = new StockPortfolio(); sp2.StockAccountNumber = 1000000008; sp2.User = db.Users.FirstOrDefault(u => u.UserName == "mb@aool.com"); sp2.Name = "Michelle's Stock"; sp2.PortfolioCashBalance = 0m; db.StockPortfoliosDbSet.AddOrUpdate(sp => sp.StockAccountNumber, sp2);
            //Saving s4 = new Saving(); s4.SavingsAccountNumber = 1000000009; s4.User = db.Users.FirstOrDefault(u => u.UserName == "jeff@ggmail.com"); s4.SavingsName = "Jeffrey's Savings"; s4.SavingsBalance = 69576.83m; db.SavingsDbSet.AddOrUpdate(s => s.SavingsAccountNumber, s4);
            //StockPortfolio sp3 = new StockPortfolio(); sp3.StockAccountNumber = 1000000010; sp3.User = db.Users.FirstOrDefault(u => u.UserName == "nelson.Kelly@aool.com"); sp3.Name = "Kelly's Stock"; sp3.PortfolioCashBalance = 0m; db.StockPortfoliosDbSet.AddOrUpdate(sp => sp.StockAccountNumber, sp3);
            //Checking c5 = new Checking(); c5.CheckingsAccountNumber = 1000000011; c5.User = db.Users.FirstOrDefault(u => u.UserName == "erynrice@aool.com"); c5.CheckingsName = "Eryn's Checking 2"; c5.CheckingsBalance = 30279.33m; db.CheckingsDbSet.AddOrUpdate(c => c.CheckingsAccountNumber, c5);
            //IRA r1 = new IRA(); r1.IRAAccountNumber = 1000000012; r1.User = db.Users.FirstOrDefault(u => u.UserName == "mackcloud@pimpdaddy.com"); r1.IRAName = "Jennifer's IRA"; r1.IRACashBalance = 5000m; db.IRAsDbSet.AddOrUpdate(r => r.IRAAccountNumber, r1);
            //Saving s5 = new Saving(); s5.SavingsAccountNumber = 1000000013; s5.User = db.Users.FirstOrDefault(u => u.UserName == "ss34@ggmail.com"); s5.SavingsName = "Sarah's Savings"; s5.SavingsBalance = 11958.08m; db.SavingsDbSet.AddOrUpdate(s => s.SavingsAccountNumber, s5);
            //Saving s6 = new Saving(); s6.SavingsAccountNumber = 1000000014; s6.User = db.Users.FirstOrDefault(u => u.UserName == "tanner@ggmail.com"); s6.SavingsName = "Jeremy's Savings"; s6.SavingsBalance = 72990.47m; db.SavingsDbSet.AddOrUpdate(s => s.SavingsAccountNumber, s6);
            //Saving s7 = new Saving(); s7.SavingsAccountNumber = 1000000015; s7.User = db.Users.FirstOrDefault(u => u.UserName == "liz@ggmail.com"); s7.SavingsName = "Elizabeth's Savings"; s7.SavingsBalance = 7417.2m; db.SavingsDbSet.AddOrUpdate(s => s.SavingsAccountNumber, s7);
            //IRA r2 = new IRA(); r2.IRAAccountNumber = 1000000016; r2.User = db.Users.FirstOrDefault(u => u.UserName == "ra@aoo.com"); r2.IRAName = "Allen's IRA"; r2.IRACashBalance = 5000m; db.IRAsDbSet.AddOrUpdate(r => r.IRAAccountNumber, r2);
            //StockPortfolio sp4 = new StockPortfolio(); sp4.StockAccountNumber = 1000000017; sp4.User = db.Users.FirstOrDefault(u => u.UserName == "johnsmith187@aool.com"); sp4.Name = "John's Stock"; sp4.PortfolioCashBalance = 0m; db.StockPortfoliosDbSet.AddOrUpdate(sp => sp.StockAccountNumber, sp4);
            //Saving s8 = new Saving(); s8.SavingsAccountNumber = 1000000018; s8.User = db.Users.FirstOrDefault(u => u.UserName == "mclarence@aool.com"); s8.SavingsName = "Clarence's Savings"; s8.SavingsBalance = 1642.82m; db.SavingsDbSet.AddOrUpdate(s => s.SavingsAccountNumber, s8);
            //Checking c6 = new Checking(); c6.CheckingsAccountNumber = 1000000019; c6.User = db.Users.FirstOrDefault(u => u.UserName == "ss34@ggmail.com"); c6.CheckingsName = "Sarah's Checking"; c6.CheckingsBalance = 84421.45m; db.CheckingsDbSet.AddOrUpdate(c => c.CheckingsAccountNumber, c6);

        }
    }

}
