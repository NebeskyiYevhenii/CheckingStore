namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_userid_to_inspection : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inspections", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Inspections", "UserId");
            AddForeignKey("dbo.Inspections", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inspections", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Inspections", new[] { "UserId" });
            DropColumn("dbo.Inspections", "UserId");
        }
    }
}
