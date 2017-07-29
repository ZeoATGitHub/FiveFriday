namespace CustomersApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Main_Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        Description = c.String(),
                        Address = c.String(),
                        Lat = c.String(),
                        Long = c.String(),
                        ContactPersonName = c.String(),
                        ContactPersonNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sub_Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubCustomerName = c.String(),
                        SubCustomerEmail = c.String(),
                        SubCustomerContactNumber = c.String(),
                        Main_CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Main_Customer", t => t.Main_CustomerID, cascadeDelete: true)
                .Index(t => t.Main_CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sub_Customer", "Main_CustomerID", "dbo.Main_Customer");
            DropIndex("dbo.Sub_Customer", new[] { "Main_CustomerID" });
            DropTable("dbo.Sub_Customer");
            DropTable("dbo.Main_Customer");
        }
    }
}
