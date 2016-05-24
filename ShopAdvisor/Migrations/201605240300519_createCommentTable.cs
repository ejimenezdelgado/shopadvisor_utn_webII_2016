namespace ShopAdvisor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createCommentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        comment = c.String(),
                        place_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Places", t => t.place_id)
                .Index(t => t.place_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "place_id", "dbo.Places");
            DropIndex("dbo.Comments", new[] { "place_id" });
            DropTable("dbo.Comments");
        }
    }
}
