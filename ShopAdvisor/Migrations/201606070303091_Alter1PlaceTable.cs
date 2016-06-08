namespace ShopAdvisor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter1PlaceTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Places", "image_path", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Places", "image_path");
        }
    }
}
