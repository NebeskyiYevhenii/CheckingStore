namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateInspection_TypeInspection : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ResultInspections", "Id", "dbo.Inspection_TypeInspection");
            DropIndex("dbo.ResultInspections", new[] { "Id" });
            DropPrimaryKey("dbo.ResultInspections");
            AddColumn("dbo.ResultInspections", "Inspection_TypeInspection_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ResultInspections", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ResultInspections", "Id");
            CreateIndex("dbo.ResultInspections", "Inspection_TypeInspection_Id");
            AddForeignKey("dbo.ResultInspections", "Inspection_TypeInspection_Id", "dbo.Inspection_TypeInspection", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResultInspections", "Inspection_TypeInspection_Id", "dbo.Inspection_TypeInspection");
            DropIndex("dbo.ResultInspections", new[] { "Inspection_TypeInspection_Id" });
            DropPrimaryKey("dbo.ResultInspections");
            AlterColumn("dbo.ResultInspections", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.ResultInspections", "Inspection_TypeInspection_Id");
            AddPrimaryKey("dbo.ResultInspections", "Id");
            CreateIndex("dbo.ResultInspections", "Id");
            AddForeignKey("dbo.ResultInspections", "Id", "dbo.Inspection_TypeInspection", "Id");
        }
    }
}
