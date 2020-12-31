namespace Shop.Models
{
    using System;    
    
    public partial class Customer
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Nullable<long> AccountId { get; set; }
    
        public virtual Account Account { get; set; }
    }
}
