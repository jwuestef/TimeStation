namespace TimeStation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCohortsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cohorts",
                c => new
                    {
                        CohortId = c.String(nullable: false, maxLength: 255),
                        CohortName = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.CohortId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cohorts");
        }
    }
}
