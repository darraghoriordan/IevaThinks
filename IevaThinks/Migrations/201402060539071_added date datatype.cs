namespace IsmsWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddatedatatype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.IsmConfigurations", "BaseImageUrl", c => c.String(nullable: false));
            AlterColumn("dbo.IsmConfigurations", "BubbleTextInputTop", c => c.String(nullable: false));
            AlterColumn("dbo.IsmConfigurations", "BubbleTextInputLeft", c => c.String(nullable: false));
            AlterColumn("dbo.IsmConfigurations", "BubbleTextInputWidth", c => c.String(nullable: false));
            AlterColumn("dbo.IsmConfigurations", "BubbleTextInputHeight", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.IsmConfigurations", "BubbleTextInputHeight", c => c.String());
            AlterColumn("dbo.IsmConfigurations", "BubbleTextInputWidth", c => c.String());
            AlterColumn("dbo.IsmConfigurations", "BubbleTextInputLeft", c => c.String());
            AlterColumn("dbo.IsmConfigurations", "BubbleTextInputTop", c => c.String());
            AlterColumn("dbo.IsmConfigurations", "BaseImageUrl", c => c.String());
        }
    }
}
