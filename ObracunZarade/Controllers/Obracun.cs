//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ObracunZarade.Controllers
{
    using System;
    using System.Collections.Generic;
    
    public partial class Obracun
    {
        public int ObracunID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public Nullable<int> fondCasova { get; set; }
        public Nullable<decimal> osnNetoZarada { get; set; }
        public Nullable<decimal> iznPoreza { get; set; }
        public Nullable<decimal> iznDoprinosaPio { get; set; }
        public Nullable<decimal> iznDoprinosaZaZdrav { get; set; }
        public Nullable<decimal> iznDoprinosaZaNezap { get; set; }
        public Nullable<decimal> netoOsnovica { get; set; }
        public Nullable<decimal> BrutoPlata { get; set; }
    }
}
