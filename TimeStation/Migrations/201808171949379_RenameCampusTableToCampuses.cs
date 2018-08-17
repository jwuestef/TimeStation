namespace TimeStation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameCampusTableToCampuses : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Campus", newName: "Campuses");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Campuses", newName: "Campus");
        }
    }
}
