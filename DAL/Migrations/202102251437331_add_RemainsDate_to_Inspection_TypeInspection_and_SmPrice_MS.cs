namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_RemainsDate_to_Inspection_TypeInspection_and_SmPrice_MS : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inspection_TypeInspection", "RemainsDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.SmPrice_MS", "RemainsDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SmPrice_MS", "RemainsDate");
            DropColumn("dbo.Inspection_TypeInspection", "RemainsDate");
        }
    }
}
