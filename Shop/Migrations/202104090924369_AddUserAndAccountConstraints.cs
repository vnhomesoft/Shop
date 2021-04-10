namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserAndAccountConstraints : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "LoginName", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Roles", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Roles", c => c.String());
            AlterColumn("dbo.Accounts", "Email", c => c.String());
            AlterColumn("dbo.Accounts", "Password", c => c.String());
            AlterColumn("dbo.Accounts", "LoginName", c => c.String());
        }
    }
}
