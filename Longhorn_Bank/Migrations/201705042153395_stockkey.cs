namespace Longhorn_Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stockkey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StockQuotes", "AvailableStocks_AvailableStocksID", "dbo.AvailableStocks");
            DropIndex("dbo.StockQuotes", new[] { "AvailableStocks_AvailableStocksID" });
            RenameColumn(table: "dbo.StockQuotes", name: "AvailableStocks_AvailableStocksID", newName: "AvailableStocks_TickerSymbol");
            DropPrimaryKey("dbo.AvailableStocks");
            AlterColumn("dbo.AvailableStocks", "AvailableStocksID", c => c.Int(nullable: false));
            AlterColumn("dbo.AvailableStocks", "TickerSymbol", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.StockQuotes", "AvailableStocks_TickerSymbol", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.AvailableStocks", "TickerSymbol");
            CreateIndex("dbo.StockQuotes", "AvailableStocks_TickerSymbol");
            AddForeignKey("dbo.StockQuotes", "AvailableStocks_TickerSymbol", "dbo.AvailableStocks", "TickerSymbol");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StockQuotes", "AvailableStocks_TickerSymbol", "dbo.AvailableStocks");
            DropIndex("dbo.StockQuotes", new[] { "AvailableStocks_TickerSymbol" });
            DropPrimaryKey("dbo.AvailableStocks");
            AlterColumn("dbo.StockQuotes", "AvailableStocks_TickerSymbol", c => c.Int());
            AlterColumn("dbo.AvailableStocks", "TickerSymbol", c => c.String());
            AlterColumn("dbo.AvailableStocks", "AvailableStocksID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.AvailableStocks", "AvailableStocksID");
            RenameColumn(table: "dbo.StockQuotes", name: "AvailableStocks_TickerSymbol", newName: "AvailableStocks_AvailableStocksID");
            CreateIndex("dbo.StockQuotes", "AvailableStocks_AvailableStocksID");
            AddForeignKey("dbo.StockQuotes", "AvailableStocks_AvailableStocksID", "dbo.AvailableStocks", "AvailableStocksID");
        }
    }
}
