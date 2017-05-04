namespace Longhorn_Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StockQuotes", "AvailableStocks_TickerSymbol", "dbo.AvailableStocks");
            DropIndex("dbo.StockQuotes", new[] { "AvailableStocks_TickerSymbol" });
            RenameColumn(table: "dbo.StockQuotes", name: "AvailableStocks_TickerSymbol", newName: "AvailableStocks_AvailableStocksID");
            DropPrimaryKey("dbo.AvailableStocks");
            AlterColumn("dbo.AvailableStocks", "TickerSymbol", c => c.String());
            AlterColumn("dbo.StockQuotes", "AvailableStocks_AvailableStocksID", c => c.Int());
            AddPrimaryKey("dbo.AvailableStocks", "AvailableStocksID");
            CreateIndex("dbo.StockQuotes", "AvailableStocks_AvailableStocksID");
            AddForeignKey("dbo.StockQuotes", "AvailableStocks_AvailableStocksID", "dbo.AvailableStocks", "AvailableStocksID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StockQuotes", "AvailableStocks_AvailableStocksID", "dbo.AvailableStocks");
            DropIndex("dbo.StockQuotes", new[] { "AvailableStocks_AvailableStocksID" });
            DropPrimaryKey("dbo.AvailableStocks");
            AlterColumn("dbo.StockQuotes", "AvailableStocks_AvailableStocksID", c => c.String(maxLength: 128));
            AlterColumn("dbo.AvailableStocks", "TickerSymbol", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.AvailableStocks", "TickerSymbol");
            RenameColumn(table: "dbo.StockQuotes", name: "AvailableStocks_AvailableStocksID", newName: "AvailableStocks_TickerSymbol");
            CreateIndex("dbo.StockQuotes", "AvailableStocks_TickerSymbol");
            AddForeignKey("dbo.StockQuotes", "AvailableStocks_TickerSymbol", "dbo.AvailableStocks", "TickerSymbol");
        }
    }
}
