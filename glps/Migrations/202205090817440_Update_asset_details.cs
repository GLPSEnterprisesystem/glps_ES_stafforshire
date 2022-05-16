namespace glps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_asset_details : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.asset_details", "Flight", c => c.String());
            AddColumn("dbo.asset_details", "Departure", c => c.String());
            AddColumn("dbo.asset_details", "Arrival", c => c.String());
            AddColumn("dbo.asset_details", "Terminal", c => c.String());
            AddColumn("dbo.asset_details", "Aircraft", c => c.String());
            AddColumn("dbo.asset_details", "Capacity", c => c.String());
            AddColumn("dbo.asset_details", "Crew", c => c.String());
            DropColumn("dbo.asset_details", "Company_name");
            DropColumn("dbo.asset_details", "Letter_code");
            DropColumn("dbo.asset_details", "Country");
        }
        
        public override void Down()
        {
            AddColumn("dbo.asset_details", "Country", c => c.String());
            AddColumn("dbo.asset_details", "Letter_code", c => c.String());
            AddColumn("dbo.asset_details", "Company_name", c => c.String());
            DropColumn("dbo.asset_details", "Crew");
            DropColumn("dbo.asset_details", "Capacity");
            DropColumn("dbo.asset_details", "Aircraft");
            DropColumn("dbo.asset_details", "Terminal");
            DropColumn("dbo.asset_details", "Arrival");
            DropColumn("dbo.asset_details", "Departure");
            DropColumn("dbo.asset_details", "Flight");
        }
    }
}
