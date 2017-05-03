namespace Longhorn_Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employees : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "SSN", c => c.String());
            AddColumn("dbo.AspNetUsers", "EmpType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "EmpType");
            DropColumn("dbo.AspNetUsers", "SSN");
        }
    }
}
