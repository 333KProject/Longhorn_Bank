namespace Longhorn_Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updated : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Checkings", "CheckingAccountActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Checkings", "CheckingAccountActive", c => c.Boolean(nullable: false));
        }
    }
}
