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
            return View(kontakti);
        }
    }
}