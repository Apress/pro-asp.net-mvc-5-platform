namespace Users.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CityProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "City", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "City");
        }
    }
}
