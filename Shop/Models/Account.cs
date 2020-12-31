namespace Shop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Account
    {
        public Account()
        {
            //this.Customers = new HashSet<Customer>();
            //this.Users = new HashSet<User>();
        }
    
        public long Id { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public short Locked { get; set; }
        public string ActivationCode { get; set; }
    
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
