using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        Context db = new Context();
        // GET: Satis
        public ActionResult Index()
        {
            var satis = db.SatisHarekets.ToList();
            return View(satis);
        }
        [HttpGet]
        public ActionResult YeniSatisYap()
        {
            List<SelectListItem> urunbul = (from x in db.Uruns.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.UrunAd,
                                                Value = x.UrunID.ToString()
                                            }).ToList();
            ViewBag.urunadi = urunbul;

            List<SelectListItem> caribul = (from x in db.Caris.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CariAd + " " + x.CariSoyad,
                                                Value = x.CariID.ToString()
                                            }).ToList();
            ViewBag.cariadi = caribul;

            List<SelectListItem> personelbul = (from x in db.Personels.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                    Value = x.PersonelID.ToString()
                                                }).ToList();
            ViewBag.personeladi = personelbul;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatisYap(SatisHareket s)
        {
            s.SatisHareketTarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.SatisHarekets.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> urunbul = (from x in db.Uruns.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.UrunAd,
                                                Value = x.UrunID.ToString()
                                            }).ToList();
            ViewBag.urunadi = urunbul;

            List<SelectListItem> caribul = (from x in db.Caris.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CariAd + " " + x.CariSoyad,
                                                Value = x.CariID.ToString()
                                            }).ToList();
            ViewBag.cariadi = caribul;

            List<SelectListItem> personelbul = (from x in db.Personels.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                    Value = x.PersonelID.ToString()
                                                }).ToList();
            ViewBag.personeladi = personelbul;
            var satis = db.SatisHarekets.Find(id);
            return View("SatisGetir", satis);
        }

        public ActionResult SatisGuncelle(SatisHareket s)
        {
            var satis = db.SatisHarekets.Find(s.SatisHareketID);
            satis.Urunid = s.Urunid;
            satis.Cariid = s.Cariid;
            satis.Personelid = s.Personelid;
            satis.SatisHareketAdet = s.SatisHareketAdet;
            satis.SatisHareketFiyat = s.SatisHareketFiyat;
            satis.SatisHareketToplamTutar = s.SatisHareketToplamTutar;
            satis.SatisHareketTarih=DateTime.Parse(DateTime.Now.ToShortDateString());
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisDetay(int id)
        {
            var satisidbul = db.SatisHarekets.Where(x => x.SatisHareketID == id).Select(y => y.SatisHareketID).FirstOrDefault();
            ViewBag.satisid = satisidbul;
            var satis = db.SatisHarekets.Where(x => x.SatisHareketID == id).ToList();
            return View(satis);
        }
 

    }
}