namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kekW : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Producers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Telephone = c.String(),
                        BankDetails = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductReceives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Product_Id = c.Int(),
                        Supplier_Id = c.Int(),
                        Warehouse_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_Id)
                .ForeignKey("dbo.Warehouses", t => t.Warehouse_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.Supplier_Id)
                .Index(t => t.Warehouse_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Article = c.Int(nullable: false),
                        Category = c.String(),
                        Cost = c.Double(nullable: false),
                        Producer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Producers", t => t.Producer_Id)
                .Index(t => t.Producer_Id);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Telephone = c.String(),
                        BankDetails = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductReceives", "Warehouse_Id", "dbo.Warehouses");
            DropForeignKey("dbo.ProductReceives", "Supplier_Id", "dbo.Suppliers");
            DropForeignKey("dbo.ProductReceives", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Products", "Producer_Id", "dbo.Producers");
            DropIndex("dbo.Products", new[] { "Producer_Id" });
            DropIndex("dbo.ProductReceives", new[] { "Warehouse_Id" });
            DropIndex("dbo.ProductReceives", new[] { "Supplier_Id" });
            DropIndex("dbo.ProductReceives", new[] { "Product_Id" });
            DropTable("dbo.Warehouses");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Products");
            DropTable("dbo.ProductReceives");
            DropTable("dbo.Producers");
        }
    }
}
