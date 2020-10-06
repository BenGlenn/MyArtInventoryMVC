namespace MyArt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImgForeignKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Image", "ArtID", c => c.Int(nullable: false));
            AlterColumn("dbo.Image", "ImageTitle", c => c.String());
            CreateIndex("dbo.Image", "ArtID");
            AddForeignKey("dbo.Image", "ArtID", "dbo.Art", "ArtID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Image", "ArtID", "dbo.Art");
            DropIndex("dbo.Image", new[] { "ArtID" });
            AlterColumn("dbo.Image", "ImageTitle", c => c.String(nullable: false));
            DropColumn("dbo.Image", "ArtID");
        }
    }
}
