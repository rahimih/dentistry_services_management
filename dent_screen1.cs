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
    
    public partial class dent_screen1
    {
        public int pk_dent_Screen1 { get; set; }
        public Nullable<int> fk_dent_Screen2 { get; set; }
        public Nullable<int> toothid_old { get; set; }
        public Nullable<int> fk_dent_neededService { get; set; }
        public string SpecificationDate { get; set; }
        public string PAComment { get; set; }
        public string Tcomment { get; set; }
        public string RctComment2 { get; set; }
        public Nullable<int> toothid { get; set; }
        public string DentalSurgeryComment { get; set; }
        public string ExtractionComment { get; set; }
        public string CLComment { get; set; }
        public string OtherFindingComment { get; set; }
        public Nullable<bool> deleted { get; set; }
    }
}
