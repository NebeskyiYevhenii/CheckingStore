namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adding_SMLocId_and_ShelfLocId_Fields_to_the_Location_Model : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "SMLocId", c => c.Int(nullable: false));
            AddColumn("dbo.Locations", "ShelfLocId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Locations", "ShelfLocId");
            DropColumn("dbo.Locations", "SMLocId");
        }
    }
}
