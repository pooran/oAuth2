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
    using System.ComponentModel.DataAnnotations;
    
    public partial class Token
    {
        [Display(Name="Token Id")]
     public System.Guid TokenId { get; set; }
        [Display(Name="Provision Id")]
     public int ProvisionId { get; set; }
        [Display(Name="Expiry Date")]
     public Nullable<System.DateTime> ExpiryDate { get; set; }
    
        [Display(Name="Provision")]
     public virtual Provision Provision { get; set; }
    }
}
