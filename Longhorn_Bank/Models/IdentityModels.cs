using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System;

namespace Longhorn_Bank.Models
{
    public enum EmpType { Employee, Manager }
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public enum StateAbrv { AL, AK, AZ, AR, CA, CO, CT, DE, FL, GA, HI, ID, IL, IN, IA, KS, KY, LA, ME, MD, MA, MI, MN, MS, MO, MT, NE, NV, NH, NJ, NM, NY, NC, ND, OH, OK, OR, PA, RI, SC, SD, TN, TX, UT, VA, VT, WA, WV, WI, WY }
    public class AppUser : IdentityUser
    {
        //TODO: Put any additional fields that you need for your user here
        //For instance
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public StateAbrv State { get; set; }
        public string ZipCode { get; set; }
        public DateTime DOB { get; set; }
        public string MiddleInitial { get; set; }
        public string SSN { get; set; }
        public EmpType EmpType { get; set; }

        public virtual List<Checking> Checkings { get; set; }
        public virtual List<Saving> Savings { get; set; }
        public virtual IRA IRA { get; set; }
        public virtual StockPortfolio StockPortfolio { get; set; }

        public virtual List<Payee> Payees { get; set; }
        public virtual List<Transaction> Transactions { get; set; }


        //This method allows you to create a new user
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    
    //TODO: Here's your db context for the project.  All of your db sets should go in here
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        //TODO:  Add dbsets here, for instance there's one for books
        //Remember, Identity adds a db set for users, so you shouldn't add that one - you will get an error
        //public DbSet<Book> Books { get; set; }
        public DbSet<Checking> CheckingsDbSet { get; set; }
        public DbSet<Saving> SavingsDbSet { get; set; }
        public DbSet<IRA> IRAsDbSet { get; set; }
        public DbSet<StockPortfolio> StockPortfoliosDbSet { get; set; }
        public DbSet<Transaction> TransactionsDbSet { get; set;  }
        public DbSet<AvailableStocks> AvailableStocks { get; set; }
        public DbSet<Payee> PayeeDbSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //it will automatically create something like base(**) if you let intelisense auto-create, keep that in there.
            modelBuilder.Entity<AppUser>()
                    .HasOptional(f => f.IRA)
                    .WithRequired(s => s.User);
            modelBuilder.Entity<AppUser>()
                    .HasOptional(f => f.StockPortfolio)
                    .WithRequired(s => s.User);
           
        }

        //TODO: Make sure that your connection string name is correct here.
        public AppDbContext()
            : base("MyDBConnection", throwIfV1Schema: false)
        {
        }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }

        public DbSet<AppRole> AppRoles { get; set; }

        public System.Data.Entity.DbSet<Longhorn_Bank.Models.StockQuote> StockQuotes { get; set; }

        public System.Data.Entity.DbSet<Longhorn_Bank.Models.AppUser> AppUsers { get; set; }
    }

   
}