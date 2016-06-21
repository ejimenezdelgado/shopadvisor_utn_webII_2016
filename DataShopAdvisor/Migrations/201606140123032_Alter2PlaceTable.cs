namespace DataShopAdvisor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter2PlaceTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Places", "image_path", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Places", "image_path", c => c.String(nullable: false));
        }
    }
}
