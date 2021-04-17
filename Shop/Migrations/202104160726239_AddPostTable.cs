namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPostTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Title = c.String(nullable: false, maxLength: 300),
                        Content = c.String(nullable: false),
                        FeaturedImage = c.String(maxLength: 250),
                        Excerpt = c.String(maxLength: 500),
                        PostType = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        PublishDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Posts");
        }
    }
}
