namespace Longhorn_Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
                        DOB = c.String(),
                        MiddleInitial = c.String(),
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
                "dbo.TransactionCheckings",
                c => new
                    {
                        Transaction_TransactionID = c.Int(nullable: false),
                        Checking_CheckingID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Transaction_TransactionID, t.Checking_CheckingID })
                .ForeignKey("dbo.Transactions", t => t.Transaction_TransactionID, cascadeDelete: true)
                .ForeignKey("dbo.Checkings", t => t.Checking_CheckingID, cascadeDelete: true)
                .Index(t => t.Transaction_TransactionID)
                .Index(t => t.Checking_CheckingID);
            
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
                "dbo.StockPortfolioTransactions",
                c => new
                    {
                        StockPortfolio_StockPortfolioID = c.Int(nullable: false),
                        Transaction_TransactionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StockPortfolio_StockPortfolioID, t.Transaction_TransactionID })
                .ForeignKey("dbo.StockPortfolios", t => t.StockPortfolio_StockPortfolioID, cascadeDelete: true)
                .ForeignKey("dbo.Transactions", t => t.Transaction_TransactionID, cascadeDelete: true)
                .Index(t => t.StockPortfolio_StockPortfolioID)
                .Index(t => t.Transaction_TransactionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Transactions", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.StockPortfolios", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.StockPortfolioTransactions", "Transaction_TransactionID", "dbo.Transactions");
            DropForeignKey("dbo.StockPortfolioTransactions", "StockPortfolio_StockPortfolioID", "dbo.StockPortfolios");
            DropForeignKey("dbo.Savings", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SavingTransactions", "Transaction_TransactionID", "dbo.Transactions");
            DropForeignKey("dbo.SavingTransactions", "Saving_SavingID", "dbo.Savings");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.IRAs", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Checkings", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.IRATransactions", "Transaction_TransactionID", "dbo.Transactions");
            DropForeignKey("dbo.IRATransactions", "IRA_IRAID", "dbo.IRAs");
            DropForeignKey("dbo.TransactionCheckings", "Checking_CheckingID", "dbo.Checkings");
            DropForeignKey("dbo.TransactionCheckings", "Transaction_TransactionID", "dbo.Transactions");
            DropIndex("dbo.StockPortfolioTransactions", new[] { "Transaction_TransactionID" });
            DropIndex("dbo.StockPortfolioTransactions", new[] { "StockPortfolio_StockPortfolioID" });
            DropIndex("dbo.SavingTransactions", new[] { "Transaction_TransactionID" });
            DropIndex("dbo.SavingTransactions", new[] { "Saving_SavingID" });
            DropIndex("dbo.IRATransactions", new[] { "Transaction_TransactionID" });
            DropIndex("dbo.IRATransactions", new[] { "IRA_IRAID" });
            DropIndex("dbo.TransactionCheckings", new[] { "Checking_CheckingID" });
            DropIndex("dbo.TransactionCheckings", new[] { "Transaction_TransactionID" });
            DropIndex("dbo.StockPortfolios", new[] { "User_Id" });
            DropIndex("dbo.Savings", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.IRAs", new[] { "User_Id" });
            DropIndex("dbo.Transactions", new[] { "User_Id" });
            DropIndex("dbo.Checkings", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.StockPortfolioTransactions");
            DropTable("dbo.SavingTransactions");
            DropTable("dbo.IRATransactions");
            DropTable("dbo.TransactionCheckings");
            DropTable("dbo.StockPortfolios");
            DropTable("dbo.Savings");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.IRAs");
            DropTable("dbo.Transactions");
            DropTable("dbo.Checkings");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
