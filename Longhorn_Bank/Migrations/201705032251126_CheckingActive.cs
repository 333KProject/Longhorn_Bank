namespace Longhorn_Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckingActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Checkings", "CheckingAccountActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Checkings", "CheckingAccountActive");
        }
    }
}
