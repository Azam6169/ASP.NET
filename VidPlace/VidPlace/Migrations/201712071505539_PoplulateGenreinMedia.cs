namespace VidPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PoplulateGenreinMedia : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1,'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2,'Thriller')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3,'Science Fiction')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4,'Family')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5,'Comedy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6,'Romance')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (7,'Horror')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (8,'Documentary')");

        }
        
        public override void Down()
        {
        }
    }
}
