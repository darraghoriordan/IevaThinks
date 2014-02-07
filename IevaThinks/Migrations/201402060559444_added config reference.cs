namespace IsmsWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedconfigreference : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ism", "Configuration_Id", "dbo.IsmConfigurations");
            DropIndex("dbo.Ism", new[] { "Configuration_Id" });
            AddColumn("dbo.Ism", "IsmConfigurationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Ism", "IsmConfigurationId");
            AddForeignKey("dbo.Ism", "IsmConfigurationId", "dbo.IsmConfigurations", "Id", cascadeDelete: true);
            DropColumn("dbo.Ism", "Configuration_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ism", "Configuration_Id", c => c.Int());
            DropForeignKey("dbo.Ism", "IsmConfigurationId", "dbo.IsmConfigurations");
            DropIndex("dbo.Ism", new[] { "IsmConfigurationId" });
            DropColumn("dbo.Ism", "IsmConfigurationId");
            CreateIndex("dbo.Ism", "Configuration_Id");
            AddForeignKey("dbo.Ism", "Configuration_Id", "dbo.IsmConfigurations", "Id");
        }
    }
}
