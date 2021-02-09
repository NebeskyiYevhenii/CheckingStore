namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateInspection_TypeInspection3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ResultInspections", "Id");
            RenameColumn(table: "dbo.ResultInspections", name: "Inspection_TypeInspectionsId", newName: "Id");
            RenameIndex(table: "dbo.ResultInspections", name: "IX_Inspection_TypeInspectionsId", newName: "IX_Id");
            AddColumn("dbo.ResultInspections", "Inspection_TypeInspections_Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ResultInspections", "Inspection_TypeInspections_Id");
            RenameIndex(table: "dbo.ResultInspections", name: "IX_Id", newName: "IX_Inspection_TypeInspectionsId");
            RenameColumn(table: "dbo.ResultInspections", name: "Id", newName: "Inspection_TypeInspectionsId");
            AddColumn("dbo.ResultInspections", "Id", c => c.Int(nullable: false));
        }
    }
}
