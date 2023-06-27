﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class istatistikController : Controller
    {
        // GET: istatistik
        Context db = new Context();
        public ActionResult Index()
        {
            var deger1=db.Caris.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = db.Uruns.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = db.Personels.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = db.Kategoris.Count().ToString();
            ViewBag.d4= deger4;

            var deger5 = db.Uruns.Sum(x=>x.UrunStok).ToString();
            ViewBag.d5 = deger5;
            var deger6 = (from x in db.Uruns select x.UrunMarka).Distinct().Count().ToString();
            ViewBag.d6 = deger6;
            var deger7 = db.Uruns.Count(x => x.UrunStok <=20).ToString();
            ViewBag.d7 = deger7;
            var deger8 = (from x in db.Uruns orderby x.UrunSatisFiyati descending select x.UrunAd).FirstOrDefault();
            ViewBag.d8 = deger8;

            var deger9 = (from x in db.Uruns orderby x.UrunSatisFiyati ascending select x.UrunAd).FirstOrDefault();
            ViewBag.d9 = deger9;
            var deger10 = db.Uruns.Count(x => x.UrunAd =="Buzdolabı").ToString();
            ViewBag.d10 = deger10;
            var deger11 = db.Uruns.Count(x => x.UrunAd == "Laptop").ToString();
            ViewBag.d11 = deger11;
            var deger12 = db.Uruns.GroupBy(x => x.UrunMarka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d12 = deger12;

            var deger13 = db.Uruns.Where(u=>u.UrunID==(db.SatisHarekets.GroupBy(x => x.Urunid).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k=>k.UrunAd).FirstOrDefault();
                
            ViewBag.d13 = deger13;

            var deger14 = db.SatisHarekets.Sum(x => x.SatisHareketToplamTutar).ToString();
            ViewBag.d14 = deger14;
            DateTime bugun = DateTime.Today;
            var deger15 = db.SatisHarekets.Count(x => x.SatisHareketTarih == bugun).ToString();
            ViewBag.d15 = deger15;
            var deger16 = db.SatisHarekets.Where(x => x.SatisHareketTarih == bugun).Sum(y => y.SatisHareketToplamTutar).ToString();
            ViewBag.d16 = deger16;

            return View();
        }
    }
}