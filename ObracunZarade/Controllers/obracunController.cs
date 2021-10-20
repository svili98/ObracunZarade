using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ObracunZarade.Models;
using System.Linq;
using System.Web.Mvc;

namespace ObracunZarade.Controllers
{
    public class obracunController : Controller
    {
        private SqlConnection conn;
        private void connection()
        {
            string constr = "data source=desktop-kmn8om7\\mssqlserver98;initial catalog=obracunBaza;integrated security=True;";
            conn = new SqlConnection(constr);
        }
        public ActionResult DodajObracun()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DodajObracun(obracunModel obm, string btn)
        {
            decimal cenaCasa = Convert.ToDecimal(Math.Round(183.94,2));
            try
            {
                if (btn == "izracunaj")
                {
                    obm.netoOsnovica = Math.Round(((obm.osnNetoZarada - 1830) / Convert.ToDecimal(0.701)),2); //Formula za izracunavanje BZ
                    obm.iznDoprinosaPIO = Math.Round(((obm.netoOsnovica * Convert.ToDecimal(11.5)) / 100),2); // Stopa 11.5& za Penz. i Invalid. na zaradu
                    obm.iznDoprinosaZaZdrav = Math.Round(((obm.netoOsnovica * Convert.ToDecimal(5.15)) / 100),2); //Stopa 5.15%
                    obm.iznDoprinosaZaNezap = Math.Round(((obm.netoOsnovica * Convert.ToDecimal(0)) / 100),2); //Stopa 0.75%
                    obm.iznPoreza = Math.Round((obm.iznDoprinosaPIO + obm.iznDoprinosaZaNezap + obm.iznDoprinosaZaZdrav),2); // Ukpuno poreza i doprinosa
                    obm.BrutoPlata = Math.Round((obm.netoOsnovica + obm.iznPoreza),2);
                    ViewBag.Message = "Uspesno obracunato!";
                    return View(obm);
                }
                if (btn == "Sacuvaj")
                {
                    obm.netoOsnovica = Math.Round(((obm.osnNetoZarada - 1830) / Convert.ToDecimal(0.701)), 2); //Formula za izracunavanje BZ
                    obm.iznDoprinosaPIO = Math.Round(((obm.netoOsnovica * Convert.ToDecimal(11.5)) / 100), 2); // Stopa 11.5& za Penz. i Invalid. na zaradu
                    obm.iznDoprinosaZaZdrav = Math.Round(((obm.netoOsnovica * Convert.ToDecimal(5.15)) / 100), 2); //Stopa 5.15%
                    obm.iznDoprinosaZaNezap = Math.Round(((obm.netoOsnovica * Convert.ToDecimal(0)) / 100), 2); //Stopa 0.75%
                    obm.iznPoreza = Math.Round((obm.iznDoprinosaPIO + obm.iznDoprinosaZaNezap + obm.iznDoprinosaZaZdrav), 2); // Ukpuno poreza i doprinosa
                    obm.BrutoPlata = Math.Round((obm.netoOsnovica + obm.iznPoreza), 2);
                   
                    
                    if (DodajObracunBool(obm))
                        {
                            ViewBag.Message = "Obracun je uspesno upisan u bazu!";
                            return View(obm);
                        }
                        return View(obm);
                    
                }

                
               
                return View(obm);
            }
            catch
            {
                ViewBag.Message = "Dogodila se greska";
                return View(obm);
            }
        }
         

        [HttpPut]
       
       
        public bool DodajObracunBool(obracunModel obm)
        {
           
            connection();
            SqlCommand c = new SqlCommand("SQLQuery6", conn);
            c.CommandType = CommandType.StoredProcedure;
            c.Parameters.AddWithValue("@Ime", obm.Ime);
            c.Parameters.AddWithValue("@Prezime", obm.Prezime);
            c.Parameters.AddWithValue("@Adresa", obm.Adresa);
            c.Parameters.AddWithValue("@fondCasova", obm.fondCasova);
            c.Parameters.AddWithValue("@osnNetoZarada", obm.osnNetoZarada);
            c.Parameters.AddWithValue("@iznPoreza", obm.iznPoreza);
            c.Parameters.AddWithValue("@iznDoprinosaPIO", obm.iznDoprinosaPIO);
            c.Parameters.AddWithValue("@iznDoprinosaZaZdrav", obm.iznDoprinosaZaZdrav);
            c.Parameters.AddWithValue("@iznDoprinosaZaNezap", obm.iznDoprinosaZaNezap);
            c.Parameters.AddWithValue("@netoOsnovica", obm.netoOsnovica);
            c.Parameters.AddWithValue("@BrutoPlata", obm.BrutoPlata);
          //  c.Parameters.Add("@ObracunID", SqlDbType.Int).Direction = ParameterDirection.Output;
            conn.Open();
          //  obm.ObracunID = Convert.ToInt32( c.Parameters["@ObracunID"].Value.ToString());
            int i = c.ExecuteNonQuery();
            conn.Close();
            if (i >=1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}