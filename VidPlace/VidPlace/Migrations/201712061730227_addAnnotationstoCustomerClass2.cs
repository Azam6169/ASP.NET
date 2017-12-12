namespace VidPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAnnotationstoCustomerClass2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String());
            AlterColumn("dbo.Customers", "Address", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Address", c => c.String(maxLength: 255));
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
