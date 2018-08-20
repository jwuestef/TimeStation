namespace TimeStation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAttendanceTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        AttendanceId = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        TimeIn = c.DateTime(nullable: false),
                        TimeOut = c.DateTime(),
                        Duration = c.Time(precision: 6),
                        CampusId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        CohortId = c.String(),
                    })
                .PrimaryKey(t => t.AttendanceId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Attendances");
        }
    }
}
