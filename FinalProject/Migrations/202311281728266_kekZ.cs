namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kekZ : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ProductReceives", new[] { "Supplier_Id1" });
            DropColumn("dbo.ProductReceives", "Supplier_Id");
            RenameColumn(table: "dbo.ProductReceives", name: "Supplier_Id1", newName: "Supplier_Id");
            AlterColumn("dbo.ProductReceives", "Supplier_Id", c => c.Int());
            CreateIndex("dbo.ProductReceives", "Supplier_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ProductReceives", new[] { "Supplier_Id" });
            AlterColumn("dbo.ProductReceives", "Supplier_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.ProductReceives", name: "Supplier_Id", newName: "Supplier_Id1");
            AddColumn("dbo.ProductReceives", "Supplier_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductReceives", "Supplier_Id1");
        }
    }
}
