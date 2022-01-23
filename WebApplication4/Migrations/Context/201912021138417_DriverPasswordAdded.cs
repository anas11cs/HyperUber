namespace WebApplication4.Migrations.Context
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DriverPasswordAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drivers", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Drivers", "Password");
        }
    }
}
