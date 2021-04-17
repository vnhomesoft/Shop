using Shop.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Models
{
	public class Post
	{
		[Key]
		public long Id { get; set; }

		[MaxLength(200)]
		public string Name { get; set; }

		[MaxLength(300)]
		[Required]
		public string Title { get; set; }

		[Required]
		[AllowHtml]
		public string Content { get; set; }

		[MaxLength(250)]
		public string FeaturedImage { get; set; }

		[MaxLength(500)]
		public string Excerpt { get; set; }

		public PostTypes PostType { get; set; }

		public PublishStatus Status { get; set; }

		public DateTime PublishDate { get; set; }
	}
}