namespace TimeStation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCampusesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Campus",
                c => new
                    {
                        CampusId = c.Int(nullable: false, identity: true),
                        CampusName = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.CampusId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Campus");
        }
    }
}
