using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context db = new Context();
        public ActionResult Index()
        {
            var personel = db.Personels.Where(x => x.PersonelDurum == true).ToList();
            return View(personel);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> departmanbul = (from x in db.Departmans.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.DepartmanAd,
                                                    Value = x.DepartmanID.ToString()
                                                }).ToList();
            ViewBag.departmanadi = departmanbul;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            if(Request.Files.Count>0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/"+dosyaadi+uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/Image/" + dosyaadi + uzanti;
            }
            db.Personels.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> departmanbul = (from x in db.Departmans.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.DepartmanAd,
                                                     Value = x.DepartmanID.ToString()
                                                 }).ToList();
            ViewBag.departmanadi = departmanbul;
            var personel = db.Personels.Find(id);
            return View("PersonelGetir", personel);
        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/Image/" + dosyaadi + uzanti;
            }
            var personel = db.Personels.Find(p.PersonelID);
            personel.PersonelAd = p.PersonelAd;
            personel.PersonelSoyad = p.PersonelSoyad;
            personel.PersonelGorsel = p.PersonelGorsel;
            personel.Departmanid = p.Departmanid;
            personel.PersonelDurum = p.PersonelDurum;
            personel.PersonelTelefon = p.PersonelTelefon;
            personel.PersonelMail = p.PersonelMail;
            personel.PersonelSifre = p.PersonelSifre;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelListe()
        {
            var personel = db.Personels.ToList();
            return View(personel);
        }
    }
}