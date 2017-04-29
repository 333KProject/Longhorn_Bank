namespace Longhorn_Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Checkings", "CheckingsAccountNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Transactions", "TransactionName", c => c.String());
            AddColumn("dbo.Transactions", "CustomDateRangeStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.Transactions", "CustomDateRangeEnd", c => c.DateTime(nullable: false));
            AddColumn("dbo.Transactions", "AmountStart", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Transactions", "AmountEnd", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Transactions", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.IRAs", "IRAAccountsNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Savings", "SavingsAccountNumber", c => c.Int(nullable: false));
            AddColumn("dbo.StockPortfolios", "StockAccountNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Transactions", "TransactionType", c => c.Int(nullable: false));
            CreateIndex("dbo.Transactions", "User_Id");
            AddForeignKey("dbo.Transactions", "User_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.StockPortfolios", "AccountNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StockPortfolios", "AccountNumber", c => c.Int(nullable: false));
            DropForeignKey("dbo.Transactions", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Transactions", new[] { "User_Id" });
            AlterColumn("dbo.Transactions", "TransactionType", c => c.String());
            DropColumn("dbo.StockPortfolios", "StockAccountNumber");
            DropColumn("dbo.Savings", "SavingsAccountNumber");
            DropColumn("dbo.IRAs", "IRAAccountsNumber");
            DropColumn("dbo.Transactions", "User_Id");
            DropColumn("dbo.Transactions", "AmountEnd");
            DropColumn("dbo.Transactions", "AmountStart");
            DropColumn("dbo.Transactions", "CustomDateRangeEnd");
            DropColumn("dbo.Transactions", "CustomDateRangeStart");
            DropColumn("dbo.Transactions", "TransactionName");
            DropColumn("dbo.Checkings", "CheckingsAccountNumber");
        }
    }
}
