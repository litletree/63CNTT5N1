namespace MyClass.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Slug = c.String(),
                        ParentID = c.Int(),
                        Order = c.Int(),
                        MetaDesc = c.String(nullable: false),
                        MetaKey = c.String(nullable: false),
                        CreateBy = c.Int(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                        UpdateBy = c.Int(nullable: false),
                        UpdateAt = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        FullName = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Title = c.String(nullable: false),
                        Detail = c.String(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                        UpdateBy = c.Int(nullable: false),
                        UpdateAt = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Links",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Slug = c.String(),
                        TableId = c.Int(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        TableID = c.Int(),
                        TypeMenu = c.String(),
                        Position = c.String(),
                        Link = c.String(),
                        ParentID = c.Int(),
                        Order = c.Int(),
                        CreateBy = c.Int(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                        UpdateBy = c.Int(nullable: false),
                        UpdateAt = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ReceiverAdress = c.String(nullable: false),
                        ReceiverEmail = c.String(nullable: false),
                        ReceiverPhone = c.String(nullable: false),
                        Note = c.String(),
                        CreateAt = c.DateTime(nullable: false),
                        UpdateBy = c.Int(nullable: false),
                        UpdateAt = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TopId = c.Int(),
                        Title = c.String(nullable: false),
                        Slug = c.String(),
                        Detail = c.String(),
                        Img = c.String(),
                        PostType = c.String(),
                        MetaDesc = c.String(nullable: false),
                        MetaKey = c.String(nullable: false),
                        CreateBy = c.Int(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                        UpdateBy = c.Int(nullable: false),
                        UpdateAt = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CatId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Supplier = c.String(),
                        Slug = c.String(),
                        Detail = c.String(nullable: false),
                        Img = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty = c.Int(nullable: false),
                        MetaDesc = c.String(nullable: false),
                        MetaKey = c.String(nullable: false),
                        CreateBy = c.Int(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                        UpdateBy = c.Int(nullable: false),
                        UpdateAt = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        URL = c.String(),
                        Img = c.String(),
                        Order = c.Int(),
                        Position = c.String(),
                        CreateBy = c.Int(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                        UpdateBy = c.Int(),
                        UpdateAt = c.DateTime(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Img = c.String(),
                        Slug = c.String(),
                        Order = c.Int(),
                        FullName = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        UrlSite = c.String(),
                        MetaDesc = c.String(nullable: false),
                        MetaKey = c.String(nullable: false),
                        CreateBy = c.Int(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                        UpdateBy = c.Int(nullable: false),
                        UpdateAt = c.DateTime(nullable: false),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Slug = c.String(),
                        ParentID = c.Int(),
                        Order = c.Int(),
                        MetaDesc = c.String(nullable: false),
                        MetaKey = c.String(nullable: false),
                        CreateBy = c.Int(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                        UpdateBy = c.Int(nullable: false),
                        UpdateAt = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        FullName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Img = c.String(),
                        Role = c.String(nullable: false),
                        Gender = c.Int(nullable: false),
                        Address = c.String(),
                        CreateBy = c.Int(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                        UpdateBy = c.Int(nullable: false),
                        UpdateAt = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Topics");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Sliders");
            DropTable("dbo.Products");
            DropTable("dbo.Posts");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Menus");
            DropTable("dbo.Links");
            DropTable("dbo.Contacts");
            DropTable("dbo.Categories");
        }
    }
}
