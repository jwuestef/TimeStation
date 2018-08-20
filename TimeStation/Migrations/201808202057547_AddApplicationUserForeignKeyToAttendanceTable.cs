namespace TimeStation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApplicationUserForeignKeyToAttendanceTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendances", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Attendances", "ApplicationUserId");
            AddForeignKey("dbo.Attendances", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Attendances", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attendances", "UserId", c => c.String());
            DropForeignKey("dbo.Attendances", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Attendances", new[] { "ApplicationUserId" });
            DropColumn("dbo.Attendances", "ApplicationUserId");
        }
    }
}
