namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addingrelationshipsbetweentables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ResultInspections", "Inspection_TypeInspectionsId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ResultInspections", "Inspection_TypeInspectionsId");
        }
    }
}
