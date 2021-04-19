namespace Shop.Migrations
{
	using Shop.Models;
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Shop.Models.ShopDbContext";
        }

        protected override void Seed(ShopDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            // Create administrative user
            var admin = context.Users.Where(u => u.Account.LoginName == "admin").FirstOrDefault();
            if(admin != null)
			{
                context.Accounts.Remove(admin.Account);
                context.Users.Remove(admin);
			}
            context.Users.Add(
                   new User
				{
                    Account = new Account
                    {
                        LoginName = "admin",
                        Password = "admin",
                        Email = "admin@example.net"                        
					},
                    Roles = "admin",
                    DisplayName = "Administrator"                   
				});
            context.SaveChanges();

            // Create default categories
            context.Categories.AddOrUpdate(
                c => c.Id,
                new Category {
                    Id = 1,
                    DisplayText = "Uncategorized",
                    ParentId = null
                });
            context.SaveChanges();

            // Create default page
            var posts = new List<Post>
            {
                new Post
                {
                    Name = "about",
                    Title = "About",
                    Content = "<strong>Homesoft is a R&D company</strong>",
                    PublishDate = DateTime.Now,
                    Status = PublishStatus.Published
                },
                new Post
                {
                    Name =  "contact",
                    Title = "Contact",
                    Content = "Email: vnhomesoft@gmail.com",
                    PublishDate = DateTime.Now,
                    Status = PublishStatus.Published
				}
            };
            posts.ForEach(post =>
                context.Posts.AddOrUpdate(
                    p => p.Name,
                    post
                )
            );
            context.SaveChanges();

            // Create sample products
            var products = new List<Product>
            {
                new Product
                {
                    Name = "Product 1",
                    CategoryId = 1,
                    Description = "<p>Description of product 1</p>",
                    FeatureImage = "~/Upload/Product/sample-product-image.png",
                    Prices = new List<Price>{
                        new Price{ApplyDate = DateTime.Now, Type = Models.Enums.PriceType.ProductPrice, Value = 100000}
                    },
                    Status = PublishStatus.Published,
                    PublishDate = DateTime.Now
                },
                new Product
                {
                    Name = "Product 2",
                    CategoryId = 1,
                    Description = "<p>Description of product 2</p>",
                    FeatureImage = "~/Upload/Product/sample-product-image.png",
                    Prices = new List<Price>{
                        new Price{ApplyDate = DateTime.Now, Type = Models.Enums.PriceType.ProductPrice, Value = 110000}
                    },
                    Status = PublishStatus.Published,
                    PublishDate = DateTime.Now
                }
            };
            products.ForEach(product =>
                context.Products.AddOrUpdate(p => p.Name, product));
            context.SaveChanges();
        }
    }
}
