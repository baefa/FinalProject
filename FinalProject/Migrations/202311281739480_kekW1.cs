namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kekW1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductReceives", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.ProductReceives", "Supplier_Id", "dbo.Suppliers");
            DropForeignKey("dbo.ProductReceives", "Warehouse_Id", "dbo.Warehouses");
            DropIndex("dbo.ProductReceives", new[] { "Product_Id" });
            DropIndex("dbo.ProductReceives", new[] { "Supplier_Id" });
            DropIndex("dbo.ProductReceives", new[] { "Warehouse_Id" });
            AddColumn("dbo.ProductReceives", "Product_Id1", c => c.Int());
            AddColumn("dbo.ProductReceives", "Supplier_Id1", c => c.Int());
            AddColumn("dbo.ProductReceives", "Warehouse_Id1", c => c.Int());
            AlterColumn("dbo.ProductReceives", "Product_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductReceives", "Supplier_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductReceives", "Warehouse_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductReceives", "Product_Id1");
            CreateIndex("dbo.ProductReceives", "Supplier_Id1");
            CreateIndex("dbo.ProductReceives", "Warehouse_Id1");
            AddForeignKey("dbo.ProductReceives", "Product_Id1", "dbo.Products", "Id");
            AddForeignKey("dbo.ProductReceives", "Supplier_Id1", "dbo.Suppliers", "Id");
            AddForeignKey("dbo.ProductReceives", "Warehouse_Id1", "dbo.Warehouses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductReceives", "Warehouse_Id1", "dbo.Warehouses");
            DropForeignKey("dbo.ProductReceives", "Supplier_Id1", "dbo.Suppliers");
            DropForeignKey("dbo.ProductReceives", "Product_Id1", "dbo.Products");
            DropIndex("dbo.ProductReceives", new[] { "Warehouse_Id1" });
            DropIndex("dbo.ProductReceives", new[] { "Supplier_Id1" });
            DropIndex("dbo.ProductReceives", new[] { "Product_Id1" });
            AlterColumn("dbo.ProductReceives", "Warehouse_Id", c => c.Int());
            AlterColumn("dbo.ProductReceives", "Supplier_Id", c => c.Int());
            AlterColumn("dbo.ProductReceives", "Product_Id", c => c.Int());
            DropColumn("dbo.ProductReceives", "Warehouse_Id1");
            DropColumn("dbo.ProductReceives", "Supplier_Id1");
            DropColumn("dbo.ProductReceives", "Product_Id1");
            CreateIndex("dbo.ProductReceives", "Warehouse_Id");
            CreateIndex("dbo.ProductReceives", "Supplier_Id");
            CreateIndex("dbo.ProductReceives", "Product_Id");
            AddForeignKey("dbo.ProductReceives", "Warehouse_Id", "dbo.Warehouses", "Id");
            AddForeignKey("dbo.ProductReceives", "Supplier_Id", "dbo.Suppliers", "Id");
            AddForeignKey("dbo.ProductReceives", "Product_Id", "dbo.Products", "Id");
        }
    }
}
