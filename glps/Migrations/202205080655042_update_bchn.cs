namespace glps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_bchn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.bchn_data", "Fore_Nane", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.bchn_data", "Fore_Nane", c => c.Int(nullable: false));
        }
    }
}
