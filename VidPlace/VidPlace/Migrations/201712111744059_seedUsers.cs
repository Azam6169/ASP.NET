namespace VidPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'412af3c4-bfb2-4269-8bc5-a4a498bd5b1d', N'admin@vidplace.com', 0, N'ALGsnTvkQtCowjuETpK6Gfl+k4KqWDnUL8XJFUdG0yRkdWnaxZoUujLcxfvf/jlLaQ==', N'09b5e2bc-3c77-43b2-bcdf-c995bcacd747', NULL, 0, 0, NULL, 1, 0, N'admin@vidplace.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c96a9183-ef98-48e0-a69e-57ee708aa94c', N'staff@vidplace.com', 0, N'AKIgRL1OYVB5kq13oIjamZ7p92lD+EUmQ+6EPJtwjtjUzHbEBmtPWImlQj9rdDiQwA==', N'49709b68-b380-46cf-aebd-2231200c4ad9', NULL, 0, 0, NULL, 1, 0, N'staff@vidplace.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'168a41e1-3908-4e80-80e0-99ca50609aa6', N'CanManageMedia')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'412af3c4-bfb2-4269-8bc5-a4a498bd5b1d', N'168a41e1-3908-4e80-80e0-99ca50609aa6')

");
        }
        
        public override void Down()
        {
        }
    }
}
