namespace TimeStation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCohortNavigationPropertyToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Cohort_CohortId", c => c.String(maxLength: 255));
            CreateIndex("dbo.AspNetUsers", "Cohort_CohortId");
            AddForeignKey("dbo.AspNetUsers", "Cohort_CohortId", "dbo.Cohorts", "CohortId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Cohort_CohortId", "dbo.Cohorts");
            DropIndex("dbo.AspNetUsers", new[] { "Cohort_CohortId" });
            DropColumn("dbo.AspNetUsers", "Cohort_CohortId");
        }
    }
}
