namespace WebApplication4.Migrations.Context
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingEmailToPerson : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Email");
        }
    }
}
