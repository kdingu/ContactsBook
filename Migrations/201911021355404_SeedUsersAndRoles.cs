namespace ContactsBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsersAndRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'568e06d2-e6e7-4123-a770-88a8394000f0', N'manager@cb.com', 0, N'AAONTleyu3EafSuqUFFw4CxH86aDYmycj9GOmPOAv/d7YqSZyvnbk39IqK2A3WfMJw==', N'd0234791-fd67-4dbb-918e-ac464680de0d', NULL, 0, 0, NULL, 1, 0, N'manager@cb.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9c1d0d9c-59b7-4ac9-b34c-9bc3cebcdb4b', N'standard@cb.com', 0, N'ABN/ymENUW5uiFQ5izTTO2pk2gGV6gIKouBcSzYgXrocmSJ3PFA8QEoF72zXw5BBBQ==', N'b552bedf-7a04-4b0c-a246-ab41c1a5f417', NULL, 0, 0, NULL, 1, 0, N'standard@cb.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e9be5ea2-0bb9-456c-a4e8-5fadf02fc3e8', N'admin@cb.com', 0, N'ACCRp8vtEJox+ijy6iokWcdiILy36x8slDZ8c6IX34OM+5mPxBvYy9GueJ806QkrAg==', N'9545fde7-b301-4b41-b3e7-ef2e06f671d8', NULL, 0, 0, NULL, 1, 0, N'admin@cb.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'91831d7f-b2b3-4823-bceb-f935bd68b9cb', N'Administrator')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c3f6939d-41bf-4e76-8a55-a2cadc83da6f', N'Manager')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'fef7e04d-4043-40db-b6eb-6758fbadb8ea', N'Standard')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e9be5ea2-0bb9-456c-a4e8-5fadf02fc3e8', N'91831d7f-b2b3-4823-bceb-f935bd68b9cb')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'568e06d2-e6e7-4123-a770-88a8394000f0', N'c3f6939d-41bf-4e76-8a55-a2cadc83da6f')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9c1d0d9c-59b7-4ac9-b34c-9bc3cebcdb4b', N'fef7e04d-4043-40db-b6eb-6758fbadb8ea')
");
        }
        
        public override void Down()
        {
        }
    }
}
