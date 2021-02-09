namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateInspection_TypeInspection2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ResultInspections", "Inspection_TypeInspection_Id", "dbo.Inspection_TypeInspection");
            DropColumn("dbo.ResultInspections", "Inspection_TypeInspectionsId");
            RenameColumn(table: "dbo.ResultInspections", name: "Inspection_TypeInspection_Id", newName: "Inspection_TypeInspectionsId");
            RenameIndex(table: "dbo.ResultInspections", name: "IX_Inspection_TypeInspection_Id", newName: "IX_Inspection_TypeInspectionsId");
            DropPrimaryKey("dbo.ResultInspections");
            AlterColumn("dbo.ResultInspections", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ResultInspections", "Inspection_TypeInspectionsId");
            AddForeignKey("dbo.ResultInspections", "Inspection_TypeInspectionsId", "dbo.Inspection_TypeInspection", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResultInspections", "Inspection_TypeInspectionsId", "dbo.Inspection_TypeInspection");
            DropPrimaryKey("dbo.ResultInspections");
            AlterColumn("dbo.ResultInspections", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ResultInspections", "Id");
            RenameIndex(table: "dbo.ResultInspections", name: "IX_Inspection_TypeInspectionsId", newName: "IX_Inspection_TypeInspection_Id");
            RenameColumn(table: "dbo.ResultInspections", name: "Inspection_TypeInspectionsId", newName: "Inspection_TypeInspection_Id");
            AddColumn("dbo.ResultInspections", "Inspection_TypeInspectionsId", c => c.Int(nullable: false));
            AddForeignKey("dbo.ResultInspections", "Inspection_TypeInspection_Id", "dbo.Inspection_TypeInspection", "Id", cascadeDelete: true);
        }
    }
}
