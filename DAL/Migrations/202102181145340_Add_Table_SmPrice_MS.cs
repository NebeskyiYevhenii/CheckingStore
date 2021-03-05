namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Table_SmPrice_MS : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SmPrice_MS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreLoc = c.Int(nullable: false),
                        Article = c.String(),
                        Price = c.Double(nullable: false),
                        ShowLevel = c.Single(nullable: false),
                        ShortName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SmPrice_MS");
        }
    }
}
