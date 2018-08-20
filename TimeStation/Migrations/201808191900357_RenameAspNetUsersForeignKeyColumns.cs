namespace TimeStation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameAspNetUsersForeignKeyColumns : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Campus_CampusId", "dbo.Campuses");
            DropForeignKey("dbo.AspNetUsers", "Department_DepartmentId", "dbo.Departments");
            DropIndex("dbo.AspNetUsers", new[] { "Campus_CampusId" });
            DropIndex("dbo.AspNetUsers", new[] { "Department_DepartmentId" });
            RenameColumn(table: "dbo.AspNetUsers", name: "Campus_CampusId", newName: "CampusId");
            RenameColumn(table: "dbo.AspNetUsers", name: "Cohort_CohortId", newName: "CohortId");
            RenameColumn(table: "dbo.AspNetUsers", name: "Department_DepartmentId", newName: "DepartmentId");
            AlterColumn("dbo.AspNetUsers", "Barcode", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.AspNetUsers", "CampusId", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "CampusId");
            CreateIndex("dbo.AspNetUsers", "DepartmentId");
            AddForeignKey("dbo.AspNetUsers", "CampusId", "dbo.Campuses", "CampusId", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.AspNetUsers", "CampusId", "dbo.Campuses");
            DropIndex("dbo.AspNetUsers", new[] { "DepartmentId" });
            DropIndex("dbo.AspNetUsers", new[] { "CampusId" });
            AlterColumn("dbo.AspNetUsers", "DepartmentId", c => c.Int());
            AlterColumn("dbo.AspNetUsers", "CampusId", c => c.Int());
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_CohortId", newName: "IX_Cohort_CohortId");
            RenameColumn(table: "dbo.AspNetUsers", name: "DepartmentId", newName: "Department_DepartmentId");
            RenameColumn(table: "dbo.AspNetUsers", name: "CohortId", newName: "Cohort_CohortId");
            RenameColumn(table: "dbo.AspNetUsers", name: "CampusId", newName: "Campus_CampusId");
            CreateIndex("dbo.AspNetUsers", "Department_DepartmentId");
            CreateIndex("dbo.AspNetUsers", "Campus_CampusId");
            AddForeignKey("dbo.AspNetUsers", "Department_DepartmentId", "dbo.Departments", "DepartmentId");
            AddForeignKey("dbo.AspNetUsers", "Campus_CampusId", "dbo.Campuses", "CampusId");
        }
    }
}
