﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Shop.Models
{
    public class ShopDbContext : DbContext
    {
        // If DB does not exist yet, it will be created automatically.
        public ShopDbContext() : base("ShopCF") //Specify DB name as "ShopCF"
        {
        }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Category> Categories { get; set; }

		public System.Data.Entity.DbSet<Account> Accounts { get; set; }

		//protected override void OnModelCreating(DbModelBuilder modelBuilder)
		//{
		//    base.OnModelCreating(modelBuilder);
		//    modelBuilder.Entity<Product>().HasRequired(p => p.Category).WithMany();
		//}
	}
}