namespace Longhorn_Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
                .ForeignKey("dbo.StockPortfolios", t => t.StockPortfolio_StockPortfolioID)
                .Index(t => t.StockPortfolio_StockPortfolioID);
            
            CreateTable(
                "dbo.StockQuotes",
                c => new
                    {
                        StockQuoteId = c.Int(nullable: false, identity: true),
                        Symbol = c.String(),
                        Name = c.String(),
                        PreviousClose = c.Double(nullable: false),
                        Volume = c.Double(nullable: false),
                        AvailableStocks_AvailableStocksID = c.Int(),
                    })
                .PrimaryKey(t => t.StockQuoteId)
                .ForeignKey("dbo.AvailableStocks", t => t.AvailableStocks_AvailableStocksID)
                .Index(t => t.AvailableStocks_AvailableStocksID);
            
            CreateTable(
                "dbo.StockPortfolios",
                c => new
                    {
                        StockPortfolioID = c.Int(nullable: false, identity: true),
                        StockAccountNumber = c.Int(nullable: false),
                        PortfolioCashBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.StockPortfolioID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionID = c.Int(nullable: false, identity: true),
                        TransactionNumber = c.Int(nullable: false),
                        TransactionName = c.String(),
                        Date = c.DateTime(nullable: false),
                        CustomDateRangeStart = c.DateTime(nullable: false),
                        CustomDateRangeEnd = c.DateTime(nullable: false),
                        Description = c.String(nullable: false),
                        TransactionType = c.Int(nullable: false),
                        EmployeeComment = c.String(),
                        Status = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AmountStart = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AmountEnd = c.Decimal(nullable: false, precision: 18, scale: 2),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TransactionID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Checkings",
                c => new
                    {
                        CheckingID = c.Int(nullable: false, identity: true),
                        CheckingsName = c.String(),
                        CheckingsAccountNumber = c.Int(nullable: false),
                        CheckingsBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CheckingID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.Int(nullable: false),
                        ZipCode = c.String(),
                        DOB = c.DateTime(nullable: false),
                        MiddleInitial = c.String(),
                        SSN = c.String(),
                        EmpType = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.IRAs",
                c => new
                    {
                        IRAID = c.Int(nullable: false, identity: true),
                        IRAAccountNumber = c.Int(nullable: false),
                        IRACashBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IRAName = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.IRAID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Savings",
                c => new
                    {
                        SavingID = c.Int(nullable: false, identity: true),
                        SavingsAccountNumber = c.Int(nullable: false),
                        SavingsName = c.String(),
                        SavingsBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SavingID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.CheckingTransactions",
                c => new
                    {
                        Checking_CheckingID = c.Int(nullable: false),
                        Transaction_TransactionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Checking_CheckingID, t.Transaction_TransactionID })
                .ForeignKey("dbo.Checkings", t => t.Checking_CheckingID, cascadeDelete: true)
                .ForeignKey("dbo.Transactions", t => t.Transaction_TransactionID, cascadeDelete: true)
                .Index(t => t.Checking_CheckingID)
                .Index(t => t.Transaction_TransactionID);
            
            CreateTable(
                "dbo.IRATransactions",
                c => new
                    {
                        IRA_IRAID = c.Int(nullable: false),
                        Transaction_TransactionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IRA_IRAID, t.Transaction_TransactionID })
                .ForeignKey("dbo.IRAs", t => t.IRA_IRAID, cascadeDelete: true)
                .ForeignKey("dbo.Transactions", t => t.Transaction_TransactionID, cascadeDelete: true)
                .Index(t => t.IRA_IRAID)
                .Index(t => t.Transaction_TransactionID);
            
            CreateTable(
                "dbo.SavingTransactions",
                c => new
                    {
                        Saving_SavingID = c.Int(nullable: false),
                        Transaction_TransactionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Saving_SavingID, t.Transaction_TransactionID })
                .ForeignKey("dbo.Savings", t => t.Saving_SavingID, cascadeDelete: true)
                .ForeignKey("dbo.Transactions", t => t.Transaction_TransactionID, cascadeDelete: true)
                .Index(t => t.Saving_SavingID)
                .Index(t => t.Transaction_TransactionID);
            
            CreateTable(
                "dbo.TransactionStockPortfolios",
                c => new
                    {
                        Transaction_TransactionID = c.Int(nullable: false),
                        StockPortfolio_StockPortfolioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Transaction_TransactionID, t.StockPortfolio_StockPortfolioID })
                .ForeignKey("dbo.Transactions", t => t.Transaction_TransactionID, cascadeDelete: true)
                .ForeignKey("dbo.StockPortfolios", t => t.StockPortfolio_StockPortfolioID, cascadeDelete: true)
                .Index(t => t.Transaction_TransactionID)
                .Index(t => t.StockPortfolio_StockPortfolioID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AvailableStocks", "StockPortfolio_StockPortfolioID", "dbo.StockPortfolios");
            DropForeignKey("dbo.TransactionStockPortfolios", "StockPortfolio_StockPortfolioID", "dbo.StockPortfolios");
            DropForeignKey("dbo.TransactionStockPortfolios", "Transaction_TransactionID", "dbo.Transactions");
            DropForeignKey("dbo.Transactions", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.StockPortfolios", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Savings", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SavingTransactions", "Transaction_TransactionID", "dbo.Transactions");
            DropForeignKey("dbo.SavingTransactions", "Saving_SavingID", "dbo.Savings");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.IRAs", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.IRATransactions", "Transaction_TransactionID", "dbo.Transactions");
            DropForeignKey("dbo.IRATransactions", "IRA_IRAID", "dbo.IRAs");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Checkings", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CheckingTransactions", "Transaction_TransactionID", "dbo.Transactions");
            DropForeignKey("dbo.CheckingTransactions", "Checking_CheckingID", "dbo.Checkings");
            DropForeignKey("dbo.StockQuotes", "AvailableStocks_AvailableStocksID", "dbo.AvailableStocks");
            DropIndex("dbo.TransactionStockPortfolios", new[] { "StockPortfolio_StockPortfolioID" });
            DropIndex("dbo.TransactionStockPortfolios", new[] { "Transaction_TransactionID" });
            DropIndex("dbo.SavingTransactions", new[] { "Transaction_TransactionID" });
            DropIndex("dbo.SavingTransactions", new[] { "Saving_SavingID" });
            DropIndex("dbo.IRATransactions", new[] { "Transaction_TransactionID" });
            DropIndex("dbo.IRATransactions", new[] { "IRA_IRAID" });
            DropIndex("dbo.CheckingTransactions", new[] { "Transaction_TransactionID" });
            DropIndex("dbo.CheckingTransactions", new[] { "Checking_CheckingID" });
            DropIndex("dbo.Savings", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.IRAs", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Checkings", new[] { "User_Id" });
            DropIndex("dbo.Transactions", new[] { "User_Id" });
            DropIndex("dbo.StockPortfolios", new[] { "User_Id" });
            DropIndex("dbo.StockQuotes", new[] { "AvailableStocks_AvailableStocksID" });
            DropIndex("dbo.AvailableStocks", new[] { "StockPortfolio_StockPortfolioID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.TransactionStockPortfolios");
            DropTable("dbo.SavingTransactions");
            DropTable("dbo.IRATransactions");
            DropTable("dbo.CheckingTransactions");
            DropTable("dbo.Savings");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.IRAs");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Checkings");
            DropTable("dbo.Transactions");
            DropTable("dbo.StockPortfolios");
            DropTable("dbo.StockQuotes");
            DropTable("dbo.AvailableStocks");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
