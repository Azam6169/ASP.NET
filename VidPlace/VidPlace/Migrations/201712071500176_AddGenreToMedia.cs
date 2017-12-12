namespace VidPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreToMedia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Media", "GenreId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Media", "GenreId");
            AddForeignKey("dbo.Media", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Media", "GenreId", "dbo.Genres");
            DropIndex("dbo.Media", new[] { "GenreId" });
            DropColumn("dbo.Media", "GenreId");
            DropTable("dbo.Genres");
        }
    }
}
