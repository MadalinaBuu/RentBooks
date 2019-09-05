namespace RentBooks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeIntToByte : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Books");
            AlterColumn("dbo.Books", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Books", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Books");
            AlterColumn("dbo.Books", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Books", "Id");
        }
    }
}
