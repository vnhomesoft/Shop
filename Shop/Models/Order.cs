namespace Shop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {

        public Order()
        {
            //this.OrderDetails = new HashSet<OrderDetail>();
        }
    
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public System.DateTime OrderTime { get; set; }
        public long CouponId { get; set; }
    
        public virtual Coupon Coupon { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
