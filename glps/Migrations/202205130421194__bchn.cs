namespace glps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _bchn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.bchn_data", "Illegal_Immigration", c => c.String());
            DropColumn("dbo.bchn_data", "Illegal");
            DropColumn("dbo.bchn_data", "Immigration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.bchn_data", "Immigration", c => c.String());
            AddColumn("dbo.bchn_data", "Illegal", c => c.String());
            DropColumn("dbo.bchn_data", "Illegal_Immigration");
        }
    }
}
