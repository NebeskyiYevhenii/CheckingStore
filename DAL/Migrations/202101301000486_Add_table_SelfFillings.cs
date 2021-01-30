namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_table_SelfFillings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShelfFillings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HardwareId = c.String(),
                        EquipmentName = c.String(),
                        ShelfId = c.String(),
                        ShelfNumber = c.String(),
                        Article = c.String(),
                        ProductId = c.String(),
                        NumberOnTheShelf = c.Int(nullable: false),
                        NumberInWidth = c.Int(nullable: false),
                        NumberInHeight = c.Int(nullable: false),
                        NumberInDepth = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShelfFillings", "LocationId", "dbo.Locations");
            DropIndex("dbo.ShelfFillings", new[] { "LocationId" });
            DropTable("dbo.ShelfFillings");
        }
    }
}
