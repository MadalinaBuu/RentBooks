namespace RentBooks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRecordsToBookGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO BookGenres (Name) VALUES ('Fiction')");
            Sql("INSERT INTO BookGenres (Name) VALUES ('Biography')");
            Sql("INSERT INTO BookGenres (Name) VALUES ('Horror')");
            Sql("INSERT INTO BookGenres (Name) VALUES ('Thriller')");
            Sql("INSERT INTO BookGenres (Name) VALUES ('Romance')");
            Sql("INSERT INTO BookGenres (Name) VALUES ('Children')");
        }
        
        public override void Down()
        {
        }
    }
}
