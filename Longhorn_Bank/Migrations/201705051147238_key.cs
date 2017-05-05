namespace Longhorn_Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class key : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Transactions", "CustomDateRangeStart");
            DropColumn("dbo.Transactions", "CustomDateRangeEnd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "CustomDateRangeEnd", c => c.DateTime(nullable: false));
            AddColumn("dbo.Transactions", "CustomDateRangeStart", c => c.DateTime(nullable: false));
        }
    }
}
