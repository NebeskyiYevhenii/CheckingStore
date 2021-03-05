namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Table_SmPrice_MS_v2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SmPrice_MS", "ShowLevel", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SmPrice_MS", "ShowLevel", c => c.Single(nullable: false));
        }
    }
}
