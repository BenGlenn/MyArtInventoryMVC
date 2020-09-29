namespace MyArt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedToClientDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Client", "PhoneNumber", c => c.String(nullable: false));
            AddColumn("dbo.Client", "Address", c => c.String());
            AlterColumn("dbo.Art", "DateOfCreation", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Art", "DateOfCreation", c => c.String(nullable: false));
            DropColumn("dbo.Client", "Address");
            DropColumn("dbo.Client", "PhoneNumber");
            DropColumn("dbo.Client", "Email");
        }
    }
}
