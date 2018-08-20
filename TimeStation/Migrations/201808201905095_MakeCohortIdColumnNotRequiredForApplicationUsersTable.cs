namespace TimeStation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeCohortIdColumnNotRequiredForApplicationUsersTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "CohortId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "CohortId", c => c.String(nullable: false));
        }
    }
}
