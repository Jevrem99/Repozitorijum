using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjekatFinalni.Models;

namespace ProjekatFinalni.Controllers
{
    public class DodavanjeSkoleController : Controller
    {
        // GET: DodavanjeSkole
        public ActionResult Novi()
        {
            var skola = new Skola();
            var kontakt = new Kontakt();
        
            return View(skola); 
        }
        [HttpPost]
        public ActionResult Novi(Skola skolica1,Kontakt korisnik1)
        {
            BazaProjekatEntities bazaSkola = new BazaProjekatEntities();
            //bazaSkola.Skolas.Add(skolica1);
            //bazaSkola.Kontakts.Add(korisnik1);
            //bazaSkola.SaveChanges();
           

            return Redirect("Novi");
        }
    }
}