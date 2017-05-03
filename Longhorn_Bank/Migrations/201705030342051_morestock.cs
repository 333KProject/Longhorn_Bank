namespace Longhorn_Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class morestock : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AvailableStocks", "AvailableStocksID", "dbo.StockQuotes");
            DropIndex("dbo.AvailableStocks", new[] { "AvailableStocksID" });
            DropPrimaryKey("dbo.AvailableStocks");
            AddColumn("dbo.StockQuotes", "AvailableStocks_AvailableStocksID", c => c.Int());
            AlterColumn("dbo.AvailableStocks", "AvailableStocksID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.AvailableStocks", "AvailableStocksID");
            CreateIndex("dbo.StockQuotes", "AvailableStocks_AvailableStocksID");
            AddForeignKey("dbo.StockQuotes", "AvailableStocks_AvailableStocksID", "dbo.AvailableStocks", "AvailableStocksID");
            DropColumn("dbo.StockQuotes", "LastTradePrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StockQuotes", "LastTradePrice", c => c.Double(nullable: false));
            DropForeignKey("dbo.StockQuotes", "AvailableStocks_AvailableStocksID", "dbo.AvailableStocks");
            DropIndex("dbo.StockQuotes", new[] { "AvailableStocks_AvailableStocksID" });
            DropPrimaryKey("dbo.AvailableStocks");
            AlterColumn("dbo.AvailableStocks", "AvailableStocksID", c => c.Int(nullable: false));
            DropColumn("dbo.StockQuotes", "AvailableStocks_AvailableStocksID");
            AddPrimaryKey("dbo.AvailableStocks", "AvailableStocksID");
            CreateIndex("dbo.AvailableStocks", "AvailableStocksID");
            AddForeignKey("dbo.AvailableStocks", "AvailableStocksID", "dbo.StockQuotes", "StockQuoteId");
        }
    }
}
