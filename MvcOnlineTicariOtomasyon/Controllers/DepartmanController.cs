using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        Context db = new Context();
        // GET: Departman
        public ActionResult Index()
        {
            var departman = db.Departmans.Where(x => x.DepartmanDurum == true).ToList();
            return View(departman);
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            db.Departmans.Add(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanPasifYap(int id)
        {
            var departman = db.Departmans.Find(id);
            departman.DepartmanDurum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id)
        {
            var departman = db.Departmans.Find(id);
            return View("DepartmanGetir", departman);
        }

        public ActionResult DepartmanGuncelle(Departman d)
        {
            var departman = db.Departmans.Find(d.DepartmanID);
            departman.DepartmanAd = d.DepartmanAd;
            departman.DepartmanDurum = d.DepartmanDurum;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetay(int id)
        {
            var departman = db.Personels.Where(x => x.PersonelID == id).ToList();
            var dptad = db.Departmans.Where(x => x.DepartmanID == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.departmanad = dptad;
            return View(departman);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var satis = db.SatisHarekets.Where(x => x.Personelid == id).ToList();
            var personelbul = db.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.personelad = personelbul;
            return View(satis);
        }
    }
}