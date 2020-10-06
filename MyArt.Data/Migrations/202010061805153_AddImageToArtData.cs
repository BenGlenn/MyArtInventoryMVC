namespace MyArt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageToArtData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Art", "ImageContent", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Art", "ImageContent");
        }
    }
}
