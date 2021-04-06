using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models.ViewModels
{
	public class ProductView
	{
		public ProductView()
		{
		}

		public ProductView(Product product)
		{
			if(product == null)
			{
				return;
			}

			Id = product.Id;
			Name = product.Name;
			CategoryId = product.CategoryId;
			Status = product.Status;
			PublishDate = product.PublishDate;
			FeatureImage = product.FeatureImage;
			Price = product.Prices.Where(p => p.Type == Enums.PriceType.ProductPrice && p.ApplyDate <= DateTime.Now)
				.OrderByDescending(p => p.ApplyDate)
				.FirstOrDefault()?.Value ?? 0;
		}
	
		public void CopyToProduct(ref Product product)
		{
			product.Name = Name;
			if (product.Prices.Count > 0)
			{
				product.Prices.First().Value = Price;	// TODO: use product price
			}
			product.PublishDate = PublishDate;
			product.Status = Status;
			product.CategoryId = CategoryId;
			product.Description = Description;
			product.Id = Id;
		}
		public long Id { get; set; }

		public string Name { get; set; }

		public long CategoryId { get; set; }

		public PublishStatus Status { get; set; }

		public DateTime PublishDate { get; set; }

		public string FeatureImage { get; set; }

		public decimal Price { get; set; }

		public string Description { get; set; }

		public HttpPostedFileBase UploadFile { get; set; }
	}
}