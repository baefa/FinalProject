namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kekW : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductReceives", "Supplier_Id", "dbo.Suppliers");
            DropIndex("dbo.ProductReceives", new[] { "Supplier_Id" });
            AddColumn("dbo.ProductReceives", "Supplier_Id1", c => c.Int());
            AlterColumn("dbo.ProductReceives", "Supplier_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductReceives", "Supplier_Id1");
            AddForeignKey("dbo.ProductReceives", "Supplier_Id1", "dbo.Suppliers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductReceives", "Supplier_Id1", "dbo.Suppliers");
            DropIndex("dbo.ProductReceives", new[] { "Supplier_Id1" });
            AlterColumn("dbo.ProductReceives", "Supplier_Id", c => c.Int());
            DropColumn("dbo.ProductReceives", "Supplier_Id1");
            CreateIndex("dbo.ProductReceives", "Supplier_Id");
            AddForeignKey("dbo.ProductReceives", "Supplier_Id", "dbo.Suppliers", "Id");
        }
    }
}
