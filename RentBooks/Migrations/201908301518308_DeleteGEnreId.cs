namespace RentBooks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteGEnreId : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Books", "Genre_Id1", "dbo.BookGenres");
            //DropIndex("dbo.Books", new[] { "Genre_Id1" });
            DropColumn("dbo.Books", "Genre_Id");
            //DropColumn("dbo.Books", "Genre_Id1");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.Books", "Genre_Id1", c => c.Int());
            AddColumn("dbo.Books", "Genre_Id", c => c.Byte(nullable: false));
            //CreateIndex("dbo.Books", "Genre_Id1");
            //AddForeignKey("dbo.Books", "Genre_Id1", "dbo.BookGenres", "Id");
        }
    }
}
