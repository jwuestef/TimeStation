namespace TimeStation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveApplicationUsersNavigationProperties : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "CampusId", "dbo.Campuses");
            DropForeignKey("dbo.AspNetUsers", "CohortId", "dbo.Cohorts");
            DropForeignKey("dbo.AspNetUsers", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.AspNetUsers", new[] { "CampusId" });
            DropIndex("dbo.AspNetUsers", new[] { "DepartmentId" });
            DropIndex("dbo.AspNetUsers", new[] { "CohortId" });
            AlterColumn("dbo.AspNetUsers", "CohortId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "CohortId", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.AspNetUsers", "CohortId");
            CreateIndex("dbo.AspNetUsers", "DepartmentId");
            CreateIndex("dbo.AspNetUsers", "CampusId");
            AddForeignKey("dbo.AspNetUsers", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "CohortId", "dbo.Cohorts", "CohortId", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "CampusId", "dbo.Campuses", "CampusId", cascadeDelete: true);
        }
    }
}
