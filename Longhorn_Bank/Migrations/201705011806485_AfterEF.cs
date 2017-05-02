namespace Longhorn_Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AfterEF : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "DOB", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "DOB", c => c.String());
        }
    }
}
