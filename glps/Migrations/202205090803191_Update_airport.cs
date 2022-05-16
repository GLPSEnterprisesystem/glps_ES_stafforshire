namespace glps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_airport : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.airport_data", "IATA_code", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.airport_data", "IATA_code", c => c.Int(nullable: false));
        }
    }
}
