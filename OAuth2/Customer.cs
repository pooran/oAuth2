//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OAuth2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer
    {
        public Customer()
        {
            this.Provisions = new HashSet<Provision>();
        }
    
        public System.Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
    
        public virtual ICollection<Provision> Provisions { get; set; }
    }
}
