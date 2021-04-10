namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderStatus : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "CouponId", "dbo.Coupons");
            DropIndex("dbo.Orders", new[] { "CouponId" });
            AddColumn("dbo.Orders", "FullName", c => c.String(maxLength: 200));
            AddColumn("dbo.Orders", "Phone", c => c.String(maxLength: 12));
            AddColumn("dbo.Orders", "Email", c => c.String(maxLength: 100));
            AddColumn("dbo.Orders", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "CustomerId", c => c.Long());
            AlterColumn("dbo.Orders", "CouponId", c => c.Long());
            CreateIndex("dbo.Orders", "CouponId");
            AddForeignKey("dbo.Orders", "CouponId", "dbo.Coupons", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CouponId", "dbo.Coupons");
            DropIndex("dbo.Orders", new[] { "CouponId" });
            AlterColumn("dbo.Orders", "CouponId", c => c.Long(nullable: false));
            AlterColumn("dbo.Orders", "CustomerId", c => c.Long(nullable: false));
            DropColumn("dbo.Orders", "Status");
            DropColumn("dbo.Orders", "Email");
            DropColumn("dbo.Orders", "Phone");
            DropColumn("dbo.Orders", "FullName");
            CreateIndex("dbo.Orders", "CouponId");
            AddForeignKey("dbo.Orders", "CouponId", "dbo.Coupons", "Id", cascadeDelete: true);
        }
    }
}
