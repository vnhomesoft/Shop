namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixPublishDateName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "PublishDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Products", "PushlishDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "PushlishDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Products", "PublishDate");
        }
    }
}
