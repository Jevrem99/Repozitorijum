using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjekatFinalni.Models;

namespace ProjekatFinalni.Controllers
{
    public class KontaktController : Controller
    {
        // GET: Kontakt
        public ActionResult Index(int skolaid)
        {
            BazaProjekatEntities bazaKontakt = new BazaProjekatEntities();
            List<Kontakt> kontakti = bazaKontakt.Kontakt.Where(x => x.SkolaID == skolaid).ToList();

            Zajedno zajednomodel = new Zajedno();

            List<Zajedno> kontaktiskola = kontakti.Select(x => new Zajedno{ Ime = x.Ime, KontaktID = x.KontaktID, Prezime = x.Prezime ,RadnoMesto = x.RadnoMesto, NazivSkole = x.Skola.NazivSkole, AdresaRegistracije = x.Skola.AdresaRegistracije, Opstina=x.Skola.Opstina, SkolaID = x.SkolaID}).ToList();

            return View(kontaktiskola);
        }
    }
}