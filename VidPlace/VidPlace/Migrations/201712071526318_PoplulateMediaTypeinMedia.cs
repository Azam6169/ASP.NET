namespace VidPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PoplulateMediaTypeinMedia : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MediaTypes (Id, Name) VALUES (1,'Movie')");
            Sql("INSERT INTO MediaTypes (Id, Name) VALUES (2,'TV Show')");
            Sql("INSERT INTO MediaTypes (Id, Name) VALUES (3,'Tutorial')");
        }
        
        public override void Down()
        {
        }
    }
}
