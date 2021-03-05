namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_3_Columns_to_Inspection_TypeInspection_and_1_col_to_SmPrice_MS : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inspection_TypeInspection", "Remains", c => c.Double(nullable: false));
            AddColumn("dbo.Inspection_TypeInspection", "ShowLevel", c => c.Double(nullable: false));
            AddColumn("dbo.Inspection_TypeInspection", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.SmPrice_MS", "Remains", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SmPrice_MS", "Remains");
            DropColumn("dbo.Inspection_TypeInspection", "Price");
            DropColumn("dbo.Inspection_TypeInspection", "ShowLevel");
            DropColumn("dbo.Inspection_TypeInspection", "Remains");
        }
    }
}
