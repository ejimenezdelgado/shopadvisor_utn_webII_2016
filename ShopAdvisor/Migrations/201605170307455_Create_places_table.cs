namespace ShopAdvisor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_places_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        latitud = c.Double(nullable: false),
                        longitud = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Places");
        }
    }
}
