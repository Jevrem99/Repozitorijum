using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjekatFinalni.Models;

namespace ProjekatFinalni.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Index(int kontaktid)
        {
            BazaProjekatEntities bazaEmail = new BazaProjekatEntities();
            List<MailAdresa> email = bazaEmail.MailAdresa.Where(x => x.KontaktID == kontaktid).ToList();
            return View(email);
        }
    }
}