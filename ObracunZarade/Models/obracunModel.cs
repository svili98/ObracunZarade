using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ObracunZarade.Models
{
    public class obracunModel
    {
        [Display(Name="Broj obracuna:")]
        public int ObracunID { get; set; }
        [Display(Name = "Ime:")]
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        [Display(Name = "Casova rada:")]
        public int fondCasova { get; set; }


        [Display(Name = "Neto zarada:")]
        public decimal osnNetoZarada { get; set; }

        [Display(Name = "Iznos poreza:")]
        public decimal iznPoreza { get; set; }

        [Display(Name = "Iznos doprinosa za Penzijsko i invalidsko osiguranje:")]
        public decimal iznDoprinosaPIO { get; set; }

        [Display(Name = "Iznos doprinosa za zdravstveno osiguranje:")]
        public decimal iznDoprinosaZaZdrav { get; set; }
        [Display(Name = "Iznos doprinosa za slucaj nezaposlenosti:")]
        public decimal iznDoprinosaZaNezap { get; set; }
        [Display(Name = "Neto osnovica")]
        public decimal netoOsnovica { get; set; }
        [Display(Name = "Bruto zarada")]
        public decimal BrutoPlata { get; set; }

        public string btn { get; set; }





    }
   
}