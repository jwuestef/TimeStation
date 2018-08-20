namespace TimeStation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyConstraintsToAttendanceTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Attendances", "CohortId", c => c.String(maxLength: 255));
            CreateIndex("dbo.Attendances", "CampusId");
            CreateIndex("dbo.Attendances", "DepartmentId");
            CreateIndex("dbo.Attendances", "CohortId");
            AddForeignKey("dbo.Attendances", "CampusId", "dbo.Campuses", "CampusId", cascadeDelete: true);
            AddForeignKey("dbo.Attendances", "CohortId", "dbo.Cohorts", "CohortId");
            AddForeignKey("dbo.Attendances", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Attendances", "CohortId", "dbo.Cohorts");
            DropForeignKey("dbo.Attendances", "CampusId", "dbo.Campuses");
            DropIndex("dbo.Attendances", new[] { "CohortId" });
            DropIndex("dbo.Attendances", new[] { "DepartmentId" });
            DropIndex("dbo.Attendances", new[] { "CampusId" });
            AlterColumn("dbo.Attendances", "CohortId", c => c.String());
        }
    }
}
