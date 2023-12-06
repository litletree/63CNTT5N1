namespace MyClass.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editUsersRow : DbMigration
    {
        public override void Up()
        {
            //DropPrimaryKey("dbo.Users");
            //AddColumn("dbo.Products", "SupplierId", c => c.Int(nullable: false));
            //AddColumn("dbo.Suppliers", "Image", c => c.String());
            AddColumn("dbo.Users", "ConfrimPassword", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Mobile", c => c.String());
            AddColumn("dbo.Users", "DateOfBirth", c => c.DateTime());
            AddColumn("dbo.Users", "City", c => c.String());
            //AlterColumn("dbo.Products", "Status", c => c.Int());
            //AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 128));
            //AddPrimaryKey("dbo.Users", "Username");
            //DropColumn("dbo.Products", "Supplier");
            //DropColumn("dbo.Products", "Detail");
            //DropColumn("dbo.Suppliers", "Img");
            //DropColumn("dbo.Users", "Id");
            DropColumn("dbo.Users", "FullName");
            DropColumn("dbo.Users", "Phone");
            DropColumn("dbo.Users", "Img");
            DropColumn("dbo.Users", "Role");
            DropColumn("dbo.Users", "Gender");
            DropColumn("dbo.Users", "CreateBy");
            DropColumn("dbo.Users", "CreateAt");
            DropColumn("dbo.Users", "UpdateBy");
            DropColumn("dbo.Users", "UpdateAt");
            DropColumn("dbo.Users", "Status");
        }
        
        //public override void Down()
        //{
        //    AddColumn("dbo.Users", "Status", c => c.Int(nullable: false));
        //    AddColumn("dbo.Users", "UpdateAt", c => c.DateTime(nullable: false));
        //    AddColumn("dbo.Users", "UpdateBy", c => c.Int(nullable: false));
        //    AddColumn("dbo.Users", "CreateAt", c => c.DateTime(nullable: false));
        //    AddColumn("dbo.Users", "CreateBy", c => c.Int(nullable: false));
        //    AddColumn("dbo.Users", "Gender", c => c.Int(nullable: false));
        //    AddColumn("dbo.Users", "Role", c => c.String(nullable: false));
        //    AddColumn("dbo.Users", "Img", c => c.String());
        //    AddColumn("dbo.Users", "Phone", c => c.String(nullable: false));
        //    AddColumn("dbo.Users", "FullName", c => c.String(nullable: false));
        //    AddColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
        //    AddColumn("dbo.Suppliers", "Img", c => c.String());
        //    AddColumn("dbo.Products", "Detail", c => c.String(nullable: false));
        //    AddColumn("dbo.Products", "Supplier", c => c.String());
        //    DropPrimaryKey("dbo.Users");
        //    AlterColumn("dbo.Users", "Username", c => c.String(nullable: false));
        //    AlterColumn("dbo.Products", "Status", c => c.Int(nullable: false));
        //    DropColumn("dbo.Users", "City");
        //    DropColumn("dbo.Users", "DateOfBirth");
        //    DropColumn("dbo.Users", "Mobile");
        //    DropColumn("dbo.Users", "ConfrimPassword");
        //    DropColumn("dbo.Suppliers", "Image");
        //    DropColumn("dbo.Products", "SupplierId");
        //    AddPrimaryKey("dbo.Users", "Id");
        //}
    }
}
