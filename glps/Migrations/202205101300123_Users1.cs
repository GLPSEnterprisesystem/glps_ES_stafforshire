namespace glps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Users1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "CurrentPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "CurrentPassword", c => c.String());
        }
    }
}
