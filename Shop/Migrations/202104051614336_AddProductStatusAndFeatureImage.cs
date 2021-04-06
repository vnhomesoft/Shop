namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductStatusAndFeatureImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Description", c => c.String(maxLength: 500));
            AddColumn("dbo.Products", "FeatureImage", c => c.String(maxLength: 250));
            AddColumn("dbo.Products", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "PushlishDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "Name", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Name", c => c.String());
            DropColumn("dbo.Products", "PushlishDate");
            DropColumn("dbo.Products", "Status");
            DropColumn("dbo.Products", "FeatureImage");
            DropColumn("dbo.Products", "Description");
        }
    }
}
