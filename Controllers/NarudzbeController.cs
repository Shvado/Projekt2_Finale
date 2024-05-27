using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projekt.Models;

namespace Projekt.Controllers
{
    public class NarudzbeController : Controller
    {
        private RestoranContext db = new RestoranContext();

      
        public ActionResult Index()
        {
            return View(db.Narudzbas.ToList());
        }

       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Narudzba narudzba = db.Narudzbas.Find(id);
            if (narudzba == null)
            {
                return HttpNotFound();
            }
            return View(narudzba);
        }

       
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_narudzba,Ime_hrana,Ime_pice,Ime_adresa,Ime_mobitel")] Narudzba narudzba)
        {
            if (ModelState.IsValid)
            {
                db.Narudzbas.Add(narudzba);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(narudzba);
        }

      
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Narudzba narudzba = db.Narudzbas.Find(id);
            if (narudzba == null)
            {
                return HttpNotFound();
            }
            return View(narudzba);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_narudzba,Ime_hrana,Ime_pice,Ime_adresa,Ime_mobitel")] Narudzba narudzba)
        {
            if (ModelState.IsValid)
            {
                db.Entry(narudzba).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(narudzba);
        }

       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Narudzba narudzba = db.Narudzbas.Find(id);
            if (narudzba == null)
            {
                return HttpNotFound();
            }
            return View(narudzba);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Narudzba narudzba = db.Narudzbas.Find(id);
            if (narudzba != null)
            {
                db.Narudzbas.Remove(narudzba);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
