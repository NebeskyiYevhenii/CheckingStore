namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Deleted_Users : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Inspections", "Userid", "dbo.Users");
            DropForeignKey("dbo.Users", "UserRoleId", "dbo.UserRoles");
            DropIndex("dbo.Inspections", new[] { "Userid" });
            DropIndex("dbo.Users", new[] { "UserRoleId" });
            DropColumn("dbo.Inspections", "Userid");
            DropTable("dbo.Users");
            DropTable("dbo.UserRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        UserRoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Inspections", "Userid", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "UserRoleId");
            CreateIndex("dbo.Inspections", "Userid");
            AddForeignKey("dbo.Users", "UserRoleId", "dbo.UserRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Inspections", "Userid", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
