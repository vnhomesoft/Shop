namespace Shop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public long Id { get; set; }
        public string DisplayName { get; set; }
        public string Roles { get; set; }
        public long AccountId { get; set; }
    
        public virtual Account Account { get; set; }
    }
}
