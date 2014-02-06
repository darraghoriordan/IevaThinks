namespace IsmsWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tryingtoaddfk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ism", "IsmConfiguration_Id", "dbo.IsmConfigurations");
            DropIndex("dbo.Ism", new[] { "IsmConfiguration_Id" });
            AlterColumn("dbo.Ism", "IsmConfiguration_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Ism", name: "IsmConfiguration_Id", newName: "IsmConfigurationId");
            CreateIndex("dbo.Ism", "IsmConfigurationId");
            AddForeignKey("dbo.Ism", "IsmConfigurationId", "dbo.IsmConfigurations", "Id", cascadeDelete: true);


        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ism", "IsmConfigurationId", "dbo.IsmConfigurations");
            DropIndex("dbo.Ism", new[] { "IsmConfigurationId" });
            RenameColumn(table: "dbo.Ism", name: "IsmConfigurationId", newName: "IsmConfiguration_Id");
            AlterColumn("dbo.Ism", "IsmConfiguration_Id", c => c.Int());
            CreateIndex("dbo.Ism", "IsmConfiguration_Id");
            AddForeignKey("dbo.Ism", "IsmConfiguration_Id", "dbo.IsmConfigurations", "Id");
        }
    }
}
