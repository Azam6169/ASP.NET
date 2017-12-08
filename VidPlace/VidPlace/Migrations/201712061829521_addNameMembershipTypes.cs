namespace VidPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNameMembershipTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Memberships", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Memberships", "Name");
        }
    }
}
