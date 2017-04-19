using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace Longhorn_Bank.Models
{

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public enum StateAbrv { AL, AK, AZ, AR, CA, CO, CT, DE, FL, GA, HI, ID, IL, IN, IA, KS, KY, LA, ME, MD, MA, MI, MN, MS, MO, MT, NE, NV, NH, NJ, NM, NY, NC, ND, OH, OK, OR, PA, RI, SC, SD, TN, TX, UT, VA, VT, WA, WV, WI, WY }
    public class AppUser : IdentityUser
    {

        //TODO: Put any additional fields that you need for your user here
        //For instance
        public string FName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public StateAbrv State { get; set; }
        public string Zip { get; set; }
        public string Birthday { get; set; }
        public string MiddleInitial { get; set; }


        public virtual List<Checking> CheckingAccounts { get; set; }
        public virtual List<Saving> SavingAccounts { get; set; }
        public virtual List<IRA> IRAAccounts { get; set; }
        public virtual List<StockPortfolio> StockPortfolios { get; set; }


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
        public DbSet<Checking> CheckingAccounts { get; set; }
        public DbSet<Saving> SavingAcocunts { get; set; }
        public DbSet<IRA> IRAAccounts { get; set; }
        public DbSet<StockPortfolio> StockPortfolios { get; set; }


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
    }
}