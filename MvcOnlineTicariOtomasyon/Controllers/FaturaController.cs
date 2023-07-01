using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context db = new Context();
        public ActionResult Index()
        {
            var faturalar = db.Faturas.ToList();
            return View(faturalar);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {

            return View();

        }
        [HttpPost]
        public ActionResult FaturaEkle(Fatura f)
        {
            db.Faturas.Add(f);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var fatura = db.Faturas.Find(id);
            return View("FaturaGetir", fatura);
        }
        public ActionResult FaturaGuncelle(Fatura f)
        {
            var fatura = db.Faturas.Find(f.FaturaID);
            fatura.FaturaSeriNo = f.FaturaSeriNo;
            fatura.FaturaSiraNo = f.FaturaSiraNo;
            fatura.FaturaVergiDairesi = f.FaturaVergiDairesi;
            fatura.FaturaTarih = f.FaturaTarih;
            fatura.FaturaSaat = f.FaturaSaat;
            fatura.FaturaTeslimAlan = f.FaturaTeslimAlan;
            fatura.FaturaTeslimEden = f.FaturaTeslimEden;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaDetay(int id)
        {
            var fatura = db.FaturaKalems.Where(x => x.Faturaid == id).ToList();
            var faturabul = db.Faturas.Where(x => x.FaturaID == id).Select(y => y.FaturaSeriNo + " " + y.FaturaSiraNo).FirstOrDefault();
            ViewBag.faturano = faturabul;
            return View(fatura);
        }
        [HttpGet]
        public ActionResult YeniKalemEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKalemEkle(FaturaKalem k)
        {
         
            db.FaturaKalems.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}