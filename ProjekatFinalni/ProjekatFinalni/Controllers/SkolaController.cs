using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjekatFinalni.Models;
using Rotativa;

namespace ProjekatFinalni.Controllers
{
    public class SkolaController : Controller
    {
        // GET: Skola
        public ActionResult Index()
        {
            BazaProjekatEntities KontakiBaza = new BazaProjekatEntities();
            List<Skola>skole =KontakiBaza.Skola.ToList();
            return View(skole);
        }

    

        public ActionResult Edit(int id)
        {
            using (BazaProjekatEntities dbModel = new BazaProjekatEntities())
            {
                return View(dbModel.Skola.Where(x => x.SkolaID == id).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult Edit(int id, Skola s)
        {
            try
            {
                using (BazaProjekatEntities dbModel = new BazaProjekatEntities())
                {
                    dbModel.Entry(s).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            using (BazaProjekatEntities dbModel = new BazaProjekatEntities())
            {
                return View(dbModel.Skola.Where(x => x.SkolaID == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (BazaProjekatEntities dbModel = new BazaProjekatEntities())
                {
                   
                    Skola skola = dbModel.Skola.Where(x => x.SkolaID == id).FirstOrDefault();
                    
                       
                    
                 
                    var Kontakt = dbModel.Kontakt.Where(x => x.SkolaID == skola.SkolaID);

                    dbModel.Kontakt.RemoveRange(Kontakt);
                    foreach (var k2 in dbModel.Kontakt.Where(x => x.SkolaID == id))
                    {
                        var Telefon = dbModel.Telefon.Where(x => x.KontaktID == k2.KontaktID);
                        dbModel.Telefon.RemoveRange(Telefon);
                        var MailAdresa = dbModel.Telefon.Where(x => x.KontaktID == k2.KontaktID);
                        dbModel.Telefon.RemoveRange(MailAdresa);
                    }
                    dbModel.Skola.Remove(skola);
                    dbModel.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}