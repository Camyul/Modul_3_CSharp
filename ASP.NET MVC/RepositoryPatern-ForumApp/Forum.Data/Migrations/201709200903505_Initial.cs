namespace Forum.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        AnsweredOn = c.DateTime(nullable: false),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        PostType = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.ParentCategoryId)
                .Index(t => t.ParentCategoryId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.TagPosts",
                c => new
                    {
                        Tag_TagId = c.Int(nullable: false),
                        Post_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_TagId, t.Post_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_TagId, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.Post_Id, cascadeDelete: true)
                .Index(t => t.Tag_TagId)
                .Index(t => t.Post_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagPosts", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.TagPosts", "Tag_TagId", "dbo.Tags");
            DropForeignKey("dbo.Posts", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "ParentCategoryId", "dbo.Categories");
            DropForeignKey("dbo.PostAnswers", "PostId", "dbo.Posts");
            DropIndex("dbo.TagPosts", new[] { "Post_Id" });
            DropIndex("dbo.TagPosts", new[] { "Tag_TagId" });
            DropIndex("dbo.Categories", new[] { "ParentCategoryId" });
            DropIndex("dbo.Posts", new[] { "CategoryId" });
            DropIndex("dbo.PostAnswers", new[] { "PostId" });
            DropTable("dbo.TagPosts");
            DropTable("dbo.Tags");
            DropTable("dbo.Categories");
            DropTable("dbo.Posts");
            DropTable("dbo.PostAnswers");
        }
    }
}
