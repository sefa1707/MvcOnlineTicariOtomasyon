using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context db = new Context();
        public ActionResult Index()
        {
            var cari = db.Caris.Where(x => x.CariDurum == true).ToList();
            return View(cari);
        }
        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariEkle(Cari c)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            db.Caris.Add(c);
            c.CariDurum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariPasifYap(int id)
        {
            var cari = db.Caris.Find(id);
            cari.CariDurum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariGetir(int id)
        {
            var cari = db.Caris.Find(id);
            return View("CariGetir", cari);
        }
        public ActionResult CariGuncelle(Cari c)
        {
            if(!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var cari = db.Caris.Find(c.CariID);
            cari.CariAd = c.CariAd;
            cari.CariSoyad = c.CariSoyad;
            cari.CariSehir = c.CariSehir;
            cari.CariMail = c.CariMail;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSatis(int id)
        {
            var satis = db.SatisHarekets.Where(x => x.Cariid == id).ToList();
            var caribul = db.Caris.Where(x => x.CariID == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.cariad = caribul;
            return View(satis);
        }
    }
}