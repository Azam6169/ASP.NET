namespace VidPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMediaType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MediaTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Media", "MediaTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.Media", "MediaType_ID", c => c.Int());
            CreateIndex("dbo.Media", "MediaType_ID");
            AddForeignKey("dbo.Media", "MediaType_ID", "dbo.MediaTypes", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Media", "MediaType_ID", "dbo.MediaTypes");
            DropIndex("dbo.Media", new[] { "MediaType_ID" });
            DropColumn("dbo.Media", "MediaType_ID");
            DropColumn("dbo.Media", "MediaTypeId");
            DropTable("dbo.MediaTypes");
        }
    }
}
