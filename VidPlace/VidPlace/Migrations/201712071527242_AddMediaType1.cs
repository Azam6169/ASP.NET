namespace VidPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMediaType1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MediaTypes" + "(Name)" + "VALUES('Movies')");
            Sql("INSERT INTO MediaTypes" + "(Name)" + "VALUES('TvShows')");
            Sql("INSERT INTO MediaTypes" + "(Name)" + "VALUES('Tutorial')");
        }
        
        public override void Down()
        {
        }
    }
}
