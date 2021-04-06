namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPriceType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prices", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Prices", "Type");
        }
    }
}
