namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateInspection_TypeInspection7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inspection_TypeInspection", "IsValid", c => c.Boolean(nullable: false));
            AddColumn("dbo.Inspection_TypeInspection", "CreatDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inspection_TypeInspection", "CreatDate");
            DropColumn("dbo.Inspection_TypeInspection", "IsValid");
        }
    }
}
