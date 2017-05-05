namespace Longhorn_Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Disputes", "Transaction_TransactionID", "dbo.Transactions");
            DropIndex("dbo.Disputes", new[] { "Transaction_TransactionID" });
            DropTable("dbo.Disputes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Disputes",
                c => new
                    {
                        DisputeID = c.String(nullable: false, maxLength: 128),
                        DisputeComments = c.String(),
                        DisputeAmount = c.Int(nullable: false),
                        Delete = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Transaction_TransactionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DisputeID);
            
            CreateIndex("dbo.Disputes", "Transaction_TransactionID");
            AddForeignKey("dbo.Disputes", "Transaction_TransactionID", "dbo.Transactions", "TransactionID");
        }
    }
}
