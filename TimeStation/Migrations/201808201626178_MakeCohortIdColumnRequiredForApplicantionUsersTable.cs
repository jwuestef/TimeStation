namespace TimeStation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeCohortIdColumnRequiredForApplicantionUsersTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "CohortId", "dbo.Cohorts");
            DropIndex("dbo.AspNetUsers", new[] { "CohortId" });
            AlterColumn("dbo.AspNetUsers", "CohortId", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.AspNetUsers", "CohortId");
            AddForeignKey("dbo.AspNetUsers", "CohortId", "dbo.Cohorts", "CohortId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "CohortId", "dbo.Cohorts");
            DropIndex("dbo.AspNetUsers", new[] { "CohortId" });
            AlterColumn("dbo.AspNetUsers", "CohortId", c => c.String(maxLength: 255));
            CreateIndex("dbo.AspNetUsers", "CohortId");
            AddForeignKey("dbo.AspNetUsers", "CohortId", "dbo.Cohorts", "CohortId");
        }
    }
}
