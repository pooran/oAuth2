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
    
    public partial class Provision
    {
        public Provision()
        {
            this.Tokens = new HashSet<Token>();
        }
    
        [Display(Name="Provision Id")]
     public int ProvisionId { get; set; }
        [Display(Name="Customer Id")]
     public System.Guid CustomerId { get; set; }
        [Display(Name="Application Id")]
     public int ApplicationId { get; set; }
        [Display(Name="Domain")]
     public string Domain { get; set; }
        [Display(Name="Redirect Url")]
     public string RedirectUrl { get; set; }
        [Display(Name="Is Enabled")]
     public bool IsEnabled { get; set; }
        [Display(Name="Secret")]
     public System.Guid Secret { get; set; }
    
        [Display(Name="Application")]
     public virtual Application Application { get; set; }
        [Display(Name="Customer")]
     public virtual Customer Customer { get; set; }
        [Display(Name="Tokens")]
     public virtual ICollection<Token> Tokens { get; set; }
    }
}