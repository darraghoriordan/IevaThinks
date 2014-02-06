namespace IsmsWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ism",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsmText = c.String(nullable: false),
                        Username = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        SharedOn = c.DateTime(nullable: false),
                        ViewCount = c.Int(nullable: false),
                        Configuration_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IsmConfigurations", t => t.Configuration_Id)
                .Index(t => t.Configuration_Id);
            
            CreateTable(
                "dbo.IsmConfigurations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TargetName = c.String(nullable: false),
                        Username = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        BaseImageUrl = c.String(),
                        BubbleTextInputTop = c.String(),
                        BubbleTextInputLeft = c.String(),
                        BubbleTextInputWidth = c.String(),
                        BubbleTextInputHeight = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Ism", new[] { "Configuration_Id" });
            DropForeignKey("dbo.Ism", "Configuration_Id", "dbo.IsmConfigurations");
            DropTable("dbo.IsmConfigurations");
            DropTable("dbo.Ism");
        }
    }
}
