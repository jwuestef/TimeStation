namespace TimeStation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDepartmentNavigationPropertyToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Department_DepartmentId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Department_DepartmentId");
            AddForeignKey("dbo.AspNetUsers", "Department_DepartmentId", "dbo.Departments", "DepartmentId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Department_DepartmentId", "dbo.Departments");
            DropIndex("dbo.AspNetUsers", new[] { "Department_DepartmentId" });
            DropColumn("dbo.AspNetUsers", "Department_DepartmentId");
        }
    }
}
