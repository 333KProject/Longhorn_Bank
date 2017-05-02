namespace Longhorn_Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stockquote : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StockQuotes",
                c => new
                    {
                        StockQuoteId = c.Int(nullable: false, identity: true),
                        Symbol = c.String(),
                        Name = c.String(),
                        PreviousClose = c.Double(nullable: false),
                        LastTradePrice = c.Double(nullable: false),
                        Volume = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.StockQuoteId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StockQuotes");
        }
    }
}
