namespace VidPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipValuesToMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Memberships SET Name = 'Pay as you go' WHERE Id =1");
            Sql("UPDATE Memberships SET Name = 'Monthly' WHERE Id =2");
            Sql("UPDATE Memberships SET Name = 'Quarterly' WHERE Id =3");
            Sql("UPDATE Memberships SET Name = 'Yearly' WHERE Id =4");
        }
        
        public override void Down()
        {
        }
    }
}
