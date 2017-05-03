namespace Longhorn_Bank.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Longhorn_Bank.Models.AppDbContext>
    {C:\Users\CNT-Cedar Park-XPS\Documents\Longhorn_Bank\Longhorn_Bank\Longhorn_Bank\Longhorn_Bank\Migrations\Configuration.cs
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        //Migrations
        protected override void Seed(Longhorn_Bank.Models.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            SeedIdentity.SeedUsers(context);
            SeedAccounts.AddAccounts(context);
            SeedStocks.AddStocks(context);
            context.SaveChanges();

        }
    }
}
