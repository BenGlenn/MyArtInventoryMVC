namespace MyArt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImgData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Image",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        ImageTitle = c.String(nullable: false),
                        ImageData = c.Binary(nullable: false),
                    })
                .PrimaryKey(t => t.ImageID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Image");
        }
    }
}
