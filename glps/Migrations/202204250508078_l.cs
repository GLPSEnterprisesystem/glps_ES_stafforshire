namespace glps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class l : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.airline_details",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Company_name = c.String(),
                        letter_code = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.airport_data",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IATA_code = c.Int(nullable: false),
                        ISO_Alpha_Code = c.String(),
                        Long_Name = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.appin_data",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Flight = c.String(),
                        Seat_Number = c.String(),
                        Fore_Name = c.String(),
                        Family_Name = c.String(),
                        Passport_Number = c.String(),
                        Country_of_Issue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.asset_details",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Company_name = c.String(),
                        Letter_code = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.bchn_data",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fore_Nane = c.Int(nullable: false),
                        Family_Name = c.String(),
                        Gender = c.String(),
                        DOB = c.String(),
                        Nationality = c.String(),
                        Passport_number = c.String(),
                        Terrorism = c.String(),
                        Narcotics = c.String(),
                        Smuggling = c.String(),
                        Illegal = c.String(),
                        Immigration = c.String(),
                        Revenue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.bchn_data");
            DropTable("dbo.asset_details");
            DropTable("dbo.appin_data");
            DropTable("dbo.airport_data");
            DropTable("dbo.airline_details");
        }
    }
}
