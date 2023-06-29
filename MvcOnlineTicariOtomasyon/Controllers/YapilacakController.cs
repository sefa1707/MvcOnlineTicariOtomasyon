using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class YapilacakController : Controller
    {
        // GET: Yapilacak
        Context db = new Context();
        public ActionResult Index()
        {
            var carisay = db.Caris.Count().ToString();
            ViewBag.carisayi = carisay;
            var urunsay = db.Uruns.Count().ToString();
            ViewBag.urunsayi = urunsay;
            var satissay = db.SatisHarekets.Count().ToString();
            ViewBag.satissayi = satissay;
            var kategorisay = db.Kategoris.Count().ToString();
            ViewBag.kategorisayi = kategorisay;
            var yapilacak = db.Yapilacaks.ToList();
            return View(yapilacak);
        }
    }
}