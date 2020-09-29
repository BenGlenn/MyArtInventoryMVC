namespace MyArt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStateZip : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client", "City", c => c.String());
            AddColumn("dbo.Client", "State", c => c.Int(nullable: false));
            AddColumn("dbo.Client", "ZipCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Client", "ZipCode");
            DropColumn("dbo.Client", "State");
            DropColumn("dbo.Client", "City");
        }
    }
}
