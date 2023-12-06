namespace MyClass.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SliderRow : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Users");
            //AddColumn("dbo.Products", "Image", c => c.String());
            AddColumn("dbo.Sliders", "MetaDesc", c => c.String(nullable: false));
            AddColumn("dbo.Sliders", "MetaKey", c => c.String(nullable: false));
            //AddColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            //AlterColumn("dbo.Users", "Username", c => c.String(nullable: false));
            //AddPrimaryKey("dbo.Users", "Id");
            //DropColumn("dbo.Products", "Img");
        }
        
        //public override void Down()
        //{
        //    AddColumn("dbo.Products", "Img", c => c.String());
        //    DropPrimaryKey("dbo.Users");
        //    AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 128));
        //    DropColumn("dbo.Users", "Id");
        //    DropColumn("dbo.Sliders", "MetaKey");
        //    DropColumn("dbo.Sliders", "MetaDesc");
        //    DropColumn("dbo.Products", "Image");
        //    AddPrimaryKey("dbo.Users", "Username");
        //}
    }
}
