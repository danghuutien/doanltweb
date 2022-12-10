namespace GioithieuCongTy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class loc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Backgrounds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CatId = c.Int(nullable: false),
                        Thumbnail = c.String(),
                        Created_at = c.DateTime(nullable: false),
                        Update_at = c.DateTime(nullable: false),
                        Backgrounds_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Backgrounds", t => t.Backgrounds_Id)
                .Index(t => t.Backgrounds_Id);
            
            CreateTable(
                "dbo.Categorys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.String(),
                        Typecategory_id = c.String(),
                        Name = c.String(),
                        Slug = c.String(),
                        Created_at = c.DateTime(),
                        Created_by = c.DateTime(),
                        Updated_by = c.DateTime(),
                        Updated_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Created_by = c.String(),
                        Thumbnail = c.String(),
                        Content = c.String(),
                        Status = c.Boolean(nullable: false),
                        Created_at = c.DateTime(nullable: false),
                        Update_at = c.DateTime(nullable: false),
                        Comments_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comments", t => t.Comments_Id)
                .Index(t => t.Comments_Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Address = c.String(),
                        Phone = c.Double(nullable: false),
                        Gmail = c.String(),
                        Created_at = c.DateTime(nullable: false),
                        Update_at = c.DateTime(nullable: false),
                        Contacts_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.Contacts_Id)
                .Index(t => t.Contacts_Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CatId = c.String(),
                        Title = c.String(),
                        Slug = c.String(),
                        Thumbnail = c.String(),
                        Excerpt = c.String(),
                        Content = c.String(),
                        IsHighlight = c.Boolean(nullable: false),
                        Created_at = c.DateTime(nullable: false),
                        Updated_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Slug = c.String(),
                        Answer = c.String(),
                        Content = c.String(),
                        Status = c.Boolean(nullable: false),
                        Created_at = c.DateTime(nullable: false),
                        Created_by = c.DateTime(nullable: false),
                        Updated_by = c.DateTime(nullable: false),
                        Updated_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Typecategorys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Slug = c.String(),
                        Created_at = c.DateTime(),
                        Update_at = c.DateTime(),
                        Typecategorys_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Typecategorys", t => t.Typecategorys_Id)
                .Index(t => t.Typecategorys_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(),
                        Gmail = c.String(),
                        Phone = c.Double(nullable: false),
                        Password = c.String(),
                        Created_at = c.DateTime(),
                        Update_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Typecategorys", "Typecategorys_Id", "dbo.Typecategorys");
            DropForeignKey("dbo.Contacts", "Contacts_Id", "dbo.Contacts");
            DropForeignKey("dbo.Comments", "Comments_Id", "dbo.Comments");
            DropForeignKey("dbo.Backgrounds", "Backgrounds_Id", "dbo.Backgrounds");
            DropIndex("dbo.Typecategorys", new[] { "Typecategorys_Id" });
            DropIndex("dbo.Contacts", new[] { "Contacts_Id" });
            DropIndex("dbo.Comments", new[] { "Comments_Id" });
            DropIndex("dbo.Backgrounds", new[] { "Backgrounds_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Typecategorys");
            DropTable("dbo.Questions");
            DropTable("dbo.Posts");
            DropTable("dbo.Contacts");
            DropTable("dbo.Comments");
            DropTable("dbo.Categorys");
            DropTable("dbo.Backgrounds");
        }
    }
}
