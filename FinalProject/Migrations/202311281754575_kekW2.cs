namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kekW2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductReceives", "Product_Id1", "dbo.Products");
            DropForeignKey("dbo.ProductReceives", "Supplier_Id1", "dbo.Suppliers");
            DropForeignKey("dbo.ProductReceives", "Warehouse_Id1", "dbo.Warehouses");
            DropForeignKey("dbo.Products", "Producer_Id", "dbo.Producers");
            DropIndex("dbo.ProductReceives", new[] { "Product_Id1" });
            DropIndex("dbo.ProductReceives", new[] { "Supplier_Id1" });
            DropIndex("dbo.ProductReceives", new[] { "Warehouse_Id1" });
            DropIndex("dbo.Products", new[] { "Producer_Id" });
            RenameColumn(table: "dbo.ProductReceives", name: "Product_Id1", newName: "ProductId");
            RenameColumn(table: "dbo.ProductReceives", name: "Supplier_Id1", newName: "SupplierId");
            RenameColumn(table: "dbo.ProductReceives", name: "Warehouse_Id1", newName: "WarehouseId");
            RenameColumn(table: "dbo.Products", name: "Producer_Id", newName: "ProducerId");
            AlterColumn("dbo.ProductReceives", "ProductId", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductReceives", "SupplierId", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductReceives", "WarehouseId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "ProducerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "ProducerId");
            CreateIndex("dbo.ProductReceives", "SupplierId");
            CreateIndex("dbo.ProductReceives", "ProductId");
            CreateIndex("dbo.ProductReceives", "WarehouseId");
            AddForeignKey("dbo.ProductReceives", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductReceives", "SupplierId", "dbo.Suppliers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductReceives", "WarehouseId", "dbo.Warehouses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "ProducerId", "dbo.Producers", "Id", cascadeDelete: true);
            DropColumn("dbo.ProductReceives", "Supplier_Id");
            DropColumn("dbo.ProductReceives", "Product_Id");
            DropColumn("dbo.ProductReceives", "Warehouse_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductReceives", "Warehouse_Id", c => c.Int(nullable: false));
            AddColumn("dbo.ProductReceives", "Product_Id", c => c.Int(nullable: false));
            AddColumn("dbo.ProductReceives", "Supplier_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Products", "ProducerId", "dbo.Producers");
            DropForeignKey("dbo.ProductReceives", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.ProductReceives", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.ProductReceives", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductReceives", new[] { "WarehouseId" });
            DropIndex("dbo.ProductReceives", new[] { "ProductId" });
            DropIndex("dbo.ProductReceives", new[] { "SupplierId" });
            DropIndex("dbo.Products", new[] { "ProducerId" });
            AlterColumn("dbo.Products", "ProducerId", c => c.Int());
            AlterColumn("dbo.ProductReceives", "WarehouseId", c => c.Int());
            AlterColumn("dbo.ProductReceives", "SupplierId", c => c.Int());
            AlterColumn("dbo.ProductReceives", "ProductId", c => c.Int());
            RenameColumn(table: "dbo.Products", name: "ProducerId", newName: "Producer_Id");
            RenameColumn(table: "dbo.ProductReceives", name: "WarehouseId", newName: "Warehouse_Id1");
            RenameColumn(table: "dbo.ProductReceives", name: "SupplierId", newName: "Supplier_Id1");
            RenameColumn(table: "dbo.ProductReceives", name: "ProductId", newName: "Product_Id1");
            CreateIndex("dbo.Products", "Producer_Id");
            CreateIndex("dbo.ProductReceives", "Warehouse_Id1");
            CreateIndex("dbo.ProductReceives", "Supplier_Id1");
            CreateIndex("dbo.ProductReceives", "Product_Id1");
            AddForeignKey("dbo.Products", "Producer_Id", "dbo.Producers", "Id");
            AddForeignKey("dbo.ProductReceives", "Warehouse_Id1", "dbo.Warehouses", "Id");
            AddForeignKey("dbo.ProductReceives", "Supplier_Id1", "dbo.Suppliers", "Id");
            AddForeignKey("dbo.ProductReceives", "Product_Id1", "dbo.Products", "Id");
        }
    }
}
