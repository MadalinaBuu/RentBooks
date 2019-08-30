namespace RentBooks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationPopulateBookGenre : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookGenres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Books", "GenreId", c => c.Byte(nullable: false));
            AddColumn("dbo.Books", "Genre_Id", c => c.Int());
            CreateIndex("dbo.Books", "Genre_Id");
            AddForeignKey("dbo.Books", "Genre_Id", "dbo.BookGenres", "Id");
            DropColumn("dbo.Books", "Genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Genre", c => c.String());
            DropForeignKey("dbo.Books", "Genre_Id", "dbo.BookGenres");
            DropIndex("dbo.Books", new[] { "Genre_Id" });
            DropColumn("dbo.Books", "Genre_Id");
            DropColumn("dbo.Books", "GenreId");
            DropTable("dbo.BookGenres");
        }
    }
}
