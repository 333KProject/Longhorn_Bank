namespace Longhorn_Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yeet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "CustomDateRangeStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.Transactions", "CustomDateRangeEnd", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "CustomDateRangeEnd");
            DropColumn("dbo.Transactions", "CustomDateRangeStart");
        }
    }
}
