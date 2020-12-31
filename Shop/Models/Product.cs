namespace Shop.Models
{
    using System;
    using System.Collections.Generic;
    
    public class Product
    {
        public Product()
        {
            //this.OrderDetails = new HashSet<OrderDetail>();
            //this.Prices = new HashSet<Price>();
        }
    
        public long Id { get; set; }
        public string Name { get; set; }
        public long CategoryId { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
    }
}
