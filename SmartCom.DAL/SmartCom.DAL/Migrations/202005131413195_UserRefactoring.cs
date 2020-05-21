namespace SmartCom.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRefactoring : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Code", c => c.String());
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Customers_Id", c => c.Guid());
            CreateIndex("dbo.AspNetUsers", "Customers_Id");
            AddForeignKey("dbo.AspNetUsers", "Customers_Id", "dbo.Customer", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Customers_Id", "dbo.Customer");
            DropIndex("dbo.AspNetUsers", new[] { "Customers_Id" });
            DropColumn("dbo.AspNetUsers", "Customers_Id");
            DropColumn("dbo.AspNetUsers", "Discriminator");
            DropColumn("dbo.AspNetUsers", "Code");
        }
    }
}
