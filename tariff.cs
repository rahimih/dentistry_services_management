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
    
    public partial class tariff
    {
        public int Tariffcode { get; set; }
        public string Tariffkind { get; set; }
        public string TariffBegindate { get; set; }
        public Nullable<System.DateTime> TariffBegindate_Eng { get; set; }
        public string Tariffenddate { get; set; }
        public Nullable<System.DateTime> Tariffenddate_Eng { get; set; }
        public Nullable<int> Zarib { get; set; }
        public Nullable<int> Kindpaient { get; set; }
        public Nullable<int> Kindjobpaient_managment { get; set; }
        public Nullable<int> Kindjobpaient_company { get; set; }
        public Nullable<int> year { get; set; }
        public Nullable<int> Tariffkind_int { get; set; }
        public Nullable<int> Feranshiz { get; set; }
        public Nullable<bool> deleted { get; set; }
    }
}
