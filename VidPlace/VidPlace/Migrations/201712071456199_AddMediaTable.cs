namespace VidPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMediaTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Media", "NumberInStock", c => c.Int(nullable: false));
            AlterColumn("dbo.Media", "Name", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Media", "NumberIsStock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Media", "NumberIsStock", c => c.Int(nullable: false));
            AlterColumn("dbo.Media", "Name", c => c.String());
            DropColumn("dbo.Media", "NumberInStock");
        }
    }
}
