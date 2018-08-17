namespace TimeStation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCampusNavigationPropertyToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Campus_CampusId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Campus_CampusId");
            AddForeignKey("dbo.AspNetUsers", "Campus_CampusId", "dbo.Campuses", "CampusId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Campus_CampusId", "dbo.Campuses");
            DropIndex("dbo.AspNetUsers", new[] { "Campus_CampusId" });
            DropColumn("dbo.AspNetUsers", "Campus_CampusId");
        }
    }
}
