using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjekatFinalni.Models;

namespace ProjekatFinalni.Controllers
{
    public class KorisnikAdminController : Controller
    {
        // GET: KorisnikAdmin

        Korisnik kmodel = new Korisnik();
        public ActionResult Dodaj(int id = 0)
        {
            return View(kmodel);
        }

        public ActionResult Izlistaj()
        {
            BazaProjekatEntities4 dbKorisnici = new BazaProjekatEntities4();
            List<Korisnik> korisnici = dbKorisnici.Korisniks.ToList();
            return View(korisnici);
            
        }

        [HttpPost]
        public ActionResult Dodaj(Korisnik korisnikmodel)
        {
            using (BazaProjekatEntities4 Modelkorisnik = new BazaProjekatEntities4())
            {
                if (Modelkorisnik.Korisniks.Any(x => x.Korisnickoime == korisnikmodel.Korisnickoime))
                {
                    ViewBag.DuplicateMessage = "Korisnicko ime vec postoji.";
                    return View("Index", korisnikmodel);
                }
                Modelkorisnik.Korisniks.Add(korisnikmodel);
                Modelkorisnik.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Dodavanje Korisnika Uspelo";



            return RedirectToAction("Izlistaj", "KorisnikAdmin");
        }
        public ActionResult Edit(int id)
        {
            using (var dbModel = new BazaProjekatEntities4())
            {
                var user = dbModel.Korisniks.FirstOrDefault(x => x.KorisnikID == id);
                //Uraditi ako je korisnik Null , vratiti "nije nadjen korisnik" 

                var vm = new EditUserVm { Id = id };
                vm.Korisnickoime = user.Korisnickoime;
                vm.Admin = user.DaLiJeAdmin;
                vm.Gost = user.Gost;
                vm.PravoUnosa = user.PravoUnosa;
                return View(vm);
            }
        }
        public ActionResult Edit2(int id)
        {
            using (var dbModel = new BazaProjekatEntities4())
            {
                var user = dbModel.Korisniks.FirstOrDefault(x => x.KorisnikID == id);
                //Uraditi ako je korisnik Null , vratiti "nije nadjen korisnik" 

                var vm = new LozinkaAdmin { Id = id };
            
          
                return View(vm);
            }
        }
        [HttpPost]
        public ActionResult Edit(EditUserVm model)
        {
            
                var db = new BazaProjekatEntities4();
                var user = db.Korisniks.FirstOrDefault(x => x.KorisnikID == model.Id);
                // to do : Do a null check on user to be safe :)

                // Map the property values from view model to entity object
                user.Korisnickoime = model.Korisnickoime;
                user.DaLiJeAdmin = model.Admin;
                user.PotvrdiLozinku = user.Lozinka;
                user.Gost = model.Gost;
                user.PravoUnosa = model.PravoUnosa;
            
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            
            return RedirectToAction("Izlistaj");
        }
        [HttpPost]
        public ActionResult Edit2(LozinkaAdmin model)
        {

            var db = new BazaProjekatEntities4();
            var user = db.Korisniks.FirstOrDefault(x => x.KorisnikID == model.Id);
            // to do : Do a null check on user to be safe :)

            // Map the property values from view model to entity object

            user.Lozinka = model.Lozinka;
            user.PotvrdiLozinku = model.PotvrdiLozinku;

            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Izlistaj");
        }

        public ActionResult Delete(int id)
        {
            using (BazaProjekatEntities4 dbModel = new BazaProjekatEntities4())
            {
                return View(dbModel.Korisniks.Where(x => x.KorisnikID == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (BazaProjekatEntities4 dbModel = new BazaProjekatEntities4())
                {
                    Korisnik korisnik = dbModel.Korisniks.Where(x => x.KorisnikID == id).FirstOrDefault();
                    dbModel.Korisniks.Remove(korisnik);
                    dbModel.SaveChanges();
                }
                return RedirectToAction("Izlistaj");
            }
            catch
            {
                return View();
            }
        }
    }
}