using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjekatFinalni.Models;

namespace ProjekatFinalni.Controllers
{
    public class TelefoniController : Controller
    {
        // GET: Telefoni
        public ActionResult Index(int tkontaktid)
        {
            BazaProjekatEntities bazaTelefoni = new BazaProjekatEntities();
            List<Telefon> telefoni = bazaTelefoni.Telefon.Where(x => x.KontaktID == tkontaktid).ToList();
            return View(telefoni);
        }
    }
}