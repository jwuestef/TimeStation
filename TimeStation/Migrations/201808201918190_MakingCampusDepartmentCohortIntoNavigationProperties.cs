namespace TimeStation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakingCampusDepartmentCohortIntoNavigationProperties : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "CohortId", c => c.String(maxLength: 255));
            CreateIndex("dbo.AspNetUsers", "CampusId");
            CreateIndex("dbo.AspNetUsers", "DepartmentId");
            CreateIndex("dbo.AspNetUsers", "CohortId");
            AddForeignKey("dbo.AspNetUsers", "CampusId", "dbo.Campuses", "CampusId", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "CohortId", "dbo.Cohorts", "CohortId");
            AddForeignKey("dbo.AspNetUsers", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.AspNetUsers", "CohortId", "dbo.Cohorts");
            DropForeignKey("dbo.AspNetUsers", "CampusId", "dbo.Campuses");
            DropIndex("dbo.AspNetUsers", new[] { "CohortId" });
            DropIndex("dbo.AspNetUsers", new[] { "DepartmentId" });
            DropIndex("dbo.AspNetUsers", new[] { "CampusId" });
            AlterColumn("dbo.AspNetUsers", "CohortId", c => c.String());
        }
    }
}
