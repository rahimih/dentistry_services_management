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
    
    public partial class outcenterKind
    {
        public outcenterKind()
        {
            this.outcenters = new HashSet<outcenter>();
        }
    
        public byte outcenterKindCode { get; set; }
        public string kindDesc { get; set; }
        public string PrintDesc { get; set; }
    
        public virtual ICollection<outcenter> outcenters { get; set; }
    }
}
