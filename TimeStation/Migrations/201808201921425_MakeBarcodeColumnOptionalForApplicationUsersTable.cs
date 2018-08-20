namespace TimeStation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeBarcodeColumnOptionalForApplicationUsersTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Barcode", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Barcode", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
