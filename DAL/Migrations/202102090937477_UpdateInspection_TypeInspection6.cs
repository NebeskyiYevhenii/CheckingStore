namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateInspection_TypeInspection6 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ResultInspections", new[] { "Id" });
            DropPrimaryKey("dbo.ResultInspections");
            AlterColumn("dbo.ResultInspections", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ResultInspections", "Id");
            CreateIndex("dbo.ResultInspections", "Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ResultInspections", new[] { "Id" });
            DropPrimaryKey("dbo.ResultInspections");
            AlterColumn("dbo.ResultInspections", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ResultInspections", "Id");
            CreateIndex("dbo.ResultInspections", "Id");
        }
    }
}
