namespace Shop.Models
{
    using System;
    using System.Collections.Generic;
    
    public class Category
    {
        public Category()
        {
            //this.Products = new HashSet<Product>();
        }
    
        public string DisplayText { get; set; }
        public long Id { get; set; }    

        public virtual ICollection<Product> Products { get; set; }    //TODO: remove
    }
}
