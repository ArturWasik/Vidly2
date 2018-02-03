namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
			Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'da5209df-acc1-4955-a67d-e2375c220523', N'guest@vidly.com', 0, N'ANQraucVZ6UQRYN0QYGhwKVCfNzp61o6WqikXSBdSmdEN+MKpiqpWO1MuqT3DLniIw==', N'8248ea99-a541-4e26-9e74-55f4ec9afc08', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e7120044-55b4-4dc7-9ff9-484fd1bde0d1', N'admin@vidly.com', 0, N'ABbTe+/gM/WvEuHRLqgdmeXkyBhHyAELYIYEzkBmDeoQj7CSUPanH5mAYuvaAigWrw==', N'16fa36b7-1115-4fe1-a007-8bf0b37cb3f5', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'162fd892-0b20-4604-bd98-37e691c9d586', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e7120044-55b4-4dc7-9ff9-484fd1bde0d1', N'162fd892-0b20-4604-bd98-37e691c9d586')

");
        }
        
        public override void Down()
        {
        }
    }
}
