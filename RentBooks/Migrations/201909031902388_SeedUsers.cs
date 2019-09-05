namespace RentBooks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'03c67976-e0b6-4865-9c75-763d86eb0890', N'admin@gmail.com', 0, N'AOzNp4E5R3zKr7xzUXybuYaOeaoZn4GTQQJBAzqxuW5Xd7Cl1SgCsEKzSeHx/wxLCw==', N'cfdde136-7eae-4f38-8b13-a3dd2d5c8d9f', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4ebdcc7d-88e8-4940-9c3b-b399b3434228', N'guest@gmail.com', 0, N'ADvbDK2zJRoD8SBu6J6hkS99TI4Q8FB+sZBE75A+noWgfrrI9BvfL+PEJ+QQsizyEw==', N'8b0641a7-75b7-4b68-a283-bc8581508119', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b2038c69-21e0-4f04-b7b9-3efa9984630b', N'CanManageBooks')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'03c67976-e0b6-4865-9c75-763d86eb0890', N'b2038c69-21e0-4f04-b7b9-3efa9984630b')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
