namespace Longhorn_Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finishseed : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.StockPortfolios", "StockPortfolioActive");
            DropColumn("dbo.IRAs", "IRAAccountActive");
            DropColumn("dbo.Savings", "SavingAccountActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Savings", "SavingAccountActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.IRAs", "IRAAccountActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.StockPortfolios", "StockPortfolioActive", c => c.Boolean(nullable: false));
        }
    }
}
