namespace RentBooks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NumberAvBooks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "NumberAvailable", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "NumberAvailable");
        }
    }
}
