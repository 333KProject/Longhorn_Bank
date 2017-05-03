namespace Longhorn_Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class availablestock : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AvailableStocks",
                c => new
                    {
                        AvailableStocksID = c.Int(nullable: false),
                        TickerSymbol = c.String(),
                        StockType = c.Int(nullable: false),
                        StockName = c.String(),
                        StockFee = c.Int(nullable: false),
                        StockPortfolio_StockPortfolioID = c.Int(),
                    })
                .PrimaryKey(t => t.AvailableStocksID)
                .ForeignKey("dbo.StockQuotes", t => t.AvailableStocksID)
                .ForeignKey("dbo.StockPortfolios", t => t.StockPortfolio_StockPortfolioID)
                .Index(t => t.AvailableStocksID)
                .Index(t => t.StockPortfolio_StockPortfolioID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AvailableStocks", "StockPortfolio_StockPortfolioID", "dbo.StockPortfolios");
            DropForeignKey("dbo.AvailableStocks", "AvailableStocksID", "dbo.StockQuotes");
            DropIndex("dbo.AvailableStocks", new[] { "StockPortfolio_StockPortfolioID" });
            DropIndex("dbo.AvailableStocks", new[] { "AvailableStocksID" });
            DropTable("dbo.AvailableStocks");
        }
    }
}
