namespace Shop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Product
    {
        public Product()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
            this.Prices = new HashSet<Price>();
        }
    
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }    // implicit PK, Identity field

        [MaxLength(250)]
        [Display(Name = "Product name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Product ID")]
        public long CategoryId { get; set; }

        [MaxLength(500, ErrorMessage = "Content is too length.")]
        public string Description { get; set; }

        [MaxLength(250)]
        [Display(Name = "Featured image")]
        public string FeatureImage { get; set; }

        //TODO: add product quantity

        public PublishStatus Status { get; set; } 
        [Display(Name = "Publish on date")]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd")]
        public DateTime PublishDate { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
    }
}
