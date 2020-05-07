namespace SmartCom.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelRefactoring : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Order", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Product", "OrderElementModel_OrderElementId", "dbo.OrderElement");
            RenameColumn(table: "dbo.Product", name: "OrderElementModel_OrderElementId", newName: "OrderElementModel_Id");
            RenameIndex(table: "dbo.Product", name: "IX_OrderElementModel_OrderElementId", newName: "IX_OrderElementModel_Id");
            DropPrimaryKey("dbo.Customer");
            DropPrimaryKey("dbo.OrderElement");
            AddColumn("dbo.Customer", "CustomerAddress", c => c.String());
            AddColumn("dbo.OrderElement", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Customer", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Customer", "Id");
            AddPrimaryKey("dbo.OrderElement", "Id");
            AddForeignKey("dbo.Order", "CustomerId", "dbo.Customer", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Product", "OrderElementModel_Id", "dbo.OrderElement", "Id");
            DropColumn("dbo.Customer", "CustomerId");
            DropColumn("dbo.Customer", "CustomerAdress");
            DropColumn("dbo.Customer", "Name");
            DropColumn("dbo.OrderElement", "OrderElementId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderElement", "OrderElementId", c => c.Guid(nullable: false));
            AddColumn("dbo.Customer", "Name", c => c.String());
            AddColumn("dbo.Customer", "CustomerAdress", c => c.String());
            AddColumn("dbo.Customer", "CustomerId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Product", "OrderElementModel_Id", "dbo.OrderElement");
            DropForeignKey("dbo.Order", "CustomerId", "dbo.Customer");
            DropPrimaryKey("dbo.OrderElement");
            DropPrimaryKey("dbo.Customer");
            AlterColumn("dbo.Customer", "Id", c => c.Guid(nullable: false));
            DropColumn("dbo.OrderElement", "Id");
            DropColumn("dbo.Customer", "CustomerAddress");
            AddPrimaryKey("dbo.OrderElement", "OrderElementId");
            AddPrimaryKey("dbo.Customer", "CustomerId");
            RenameIndex(table: "dbo.Product", name: "IX_OrderElementModel_Id", newName: "IX_OrderElementModel_OrderElementId");
            RenameColumn(table: "dbo.Product", name: "OrderElementModel_Id", newName: "OrderElementModel_OrderElementId");
            AddForeignKey("dbo.Product", "OrderElementModel_OrderElementId", "dbo.OrderElement", "OrderElementId");
            AddForeignKey("dbo.Order", "CustomerId", "dbo.Customer", "CustomerId", cascadeDelete: true);
        }
    }
}
