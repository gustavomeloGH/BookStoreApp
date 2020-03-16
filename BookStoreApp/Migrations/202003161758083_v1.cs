namespace BookStoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                        ISBN = c.String(nullable: false, maxLength: 32),
                        ReleaseDate = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookActor",
                c => new
                    {
                        Actor_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Actor_Id, t.Book_Id })
                .ForeignKey("dbo.Actor", t => t.Actor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Book", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.Actor_Id)
                .Index(t => t.Book_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookActor", "Book_Id", "dbo.Book");
            DropForeignKey("dbo.BookActor", "Actor_Id", "dbo.Actor");
            DropForeignKey("dbo.Book", "CategoryId", "dbo.Category");
            DropIndex("dbo.BookActor", new[] { "Book_Id" });
            DropIndex("dbo.BookActor", new[] { "Actor_Id" });
            DropIndex("dbo.Book", new[] { "CategoryId" });
            DropTable("dbo.BookActor");
            DropTable("dbo.Category");
            DropTable("dbo.Book");
            DropTable("dbo.Actor");
        }
    }
}
