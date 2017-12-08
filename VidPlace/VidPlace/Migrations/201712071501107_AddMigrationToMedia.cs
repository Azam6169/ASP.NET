namespace VidPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMigrationToMedia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Media", "GenderId", c => c.Byte(nullable: false));
            AddColumn("dbo.Media", "Genre_Id", c => c.Byte(nullable: false));
            CreateIndex("dbo.Media", "Genre_Id");
            AddForeignKey("dbo.Media", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Media", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Media", new[] { "Genre_Id" });
            DropColumn("dbo.Media", "Genre_Id");
            DropColumn("dbo.Media", "GenderId");
            DropTable("dbo.Genres");
        }
    }
}
