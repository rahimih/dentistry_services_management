//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PIHO_DENTIST_SOFTWARE
{
    using System;
    using System.Collections.Generic;
    
    public partial class Services_Head
    {
        public Services_Head()
        {
            this.Services_detail = new HashSet<Services_detail>();
        }
    
        public int Services_Head_code { get; set; }
        public string Services_Head_name { get; set; }
        public string Comment { get; set; }
    
        public virtual ICollection<Services_detail> Services_detail { get; set; }
    }
}
