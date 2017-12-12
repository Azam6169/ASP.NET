namespace VidPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMediaTypeToMedia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MediaTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Media", "MediaTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Media", "MediaTypeId");
            AddForeignKey("dbo.Media", "MediaTypeId", "dbo.MediaTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Media", "MediaTypeId", "dbo.MediaTypes");
            DropIndex("dbo.Media", new[] { "MediaTypeId" });
            DropColumn("dbo.Media", "MediaTypeId");
            DropTable("dbo.MediaTypes");
        }
    }
}
