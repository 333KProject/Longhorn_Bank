namespace Longhorn_Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StockPortfolios", "StockPortfolioActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.IRAs", "IRAAccountActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Savings", "SavingAccountActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Savings", "SavingAccountActive");
            DropColumn("dbo.IRAs", "IRAAccountActive");
            DropColumn("dbo.StockPortfolios", "StockPortfolioActive");
        }
    }
}
