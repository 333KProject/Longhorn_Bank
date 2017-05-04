namespace Longhorn_Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tryingstock : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StockQuotes", "AvailableStocks_AvailableStocksID", "dbo.AvailableStocks");
            DropPrimaryKey("dbo.AvailableStocks");
            AlterColumn("dbo.AvailableStocks", "AvailableStocksID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.AvailableStocks", "AvailableStocksID");
            AddForeignKey("dbo.StockQuotes", "AvailableStocks_AvailableStocksID", "dbo.AvailableStocks", "AvailableStocksID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StockQuotes", "AvailableStocks_AvailableStocksID", "dbo.AvailableStocks");
            DropPrimaryKey("dbo.AvailableStocks");
            AlterColumn("dbo.AvailableStocks", "AvailableStocksID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.AvailableStocks", "AvailableStocksID");
            AddForeignKey("dbo.StockQuotes", "AvailableStocks_AvailableStocksID", "dbo.AvailableStocks", "AvailableStocksID");
        }
    }
}
