namespace RentBooks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropToIdInBook : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE Rentals DROP CONSTRAINT [FK_dbo.Rentals_dbo.Books_Books_Id]");
            DropForeignKey("dbo.Rentals", "BookId", "dbo.Books");
            DropPrimaryKey("dbo.Books");
            AlterColumn("dbo.Books", "Id", c => c.Byte(nullable: false, identity: true));
            AddPrimaryKey("dbo.Books", "Id");
            AddForeignKey("dbo.Rentals", "BookId", "dbo.Books", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "BookId", "dbo.Books");
            DropPrimaryKey("dbo.Books");
            AlterColumn("dbo.Books", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Books", "Id");
            AddForeignKey("dbo.Rentals", "BookId", "dbo.Books", "Id", cascadeDelete: true);
        }
    }
}
