using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Common
{
	public class DataUtils
	{
		public static IEnumerable<Category> GetCategories(ShopDbContext db, Category current = null)
		{
			if (current == null)
			{
				return db.Categories.ToList();
			}

			// Exclude current category and all its children
			List<Category> categories = db.Categories.ToList();
			categories.RemoveAll(item => item.Id == current.Id || item.ParentId == current.Id);
			return categories;
		}

		public static IDictionary<string, string> GetRolesList()
		{
			return new Dictionary<string, string> {
				{"admin", "Administrator" },
				{"user", "Normal User" }
			};
		}
	}
}