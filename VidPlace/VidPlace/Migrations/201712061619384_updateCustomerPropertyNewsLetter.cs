namespace VidPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCustomerPropertyNewsLetter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSunscribedToNewsLetter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsSunscribedToNewsLetter");
        }
    }
}
