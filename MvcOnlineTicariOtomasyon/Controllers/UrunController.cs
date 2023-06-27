using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context db = new Context();
        public ActionResult Index()
        {
            var urun = db.Uruns.Where(x => x.UrunDurum == true).ToList();
            //var urun = db.Uruns.ToList(); //tümünü getiriyor.
            return View(urun);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> kategoribul = (from x in db.Kategoris.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.KategoriAd,
                                                    Value = x.KategoriID.ToString()
                                                }).ToList();
            ViewBag.kategoriadi = kategoribul;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(Urun u)
        {
            db.Uruns.Add(u);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunPasifYap(int id)
        {
            var urun = db.Uruns.Find(id);
            urun.UrunDurum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            var urun= db.Uruns.Find(id);
            List<SelectListItem> kategoribul = (from x in db.Kategoris.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.KategoriAd,
                                                    Value = x.KategoriID.ToString()
                                                }).ToList();
            ViewBag.kategoriadi = kategoribul;
            return View("UrunGetir", urun);
        }

        public ActionResult UrunGuncelle(Urun u)
        {
            var urun = db.Uruns.Find(u.UrunID);
            urun.UrunAd = u.UrunAd;
            urun.UrunMarka = u.UrunMarka;
            urun.UrunDurum = u.UrunDurum;
            urun.UrunGorsel = u.UrunGorsel;
            urun.UrunAlisFiyat = u.UrunAlisFiyat;
            urun.UrunSatisFiyati = u.UrunSatisFiyati;
            urun.UrunStok = u.UrunStok;
            urun.Kategoriid = u.Kategoriid;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunListesi()
        {
            var urunlistesi = db.Uruns.ToList();
            return View(urunlistesi);
        }

    }
}