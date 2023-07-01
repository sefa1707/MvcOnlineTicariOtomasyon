using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context db = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult PartialKayitOl()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialKayitOl(Cari c)
        {
            db.Caris.Add(c);
            //c.CariDurum = true;
            db.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult CariGirisFormu()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariGirisFormu(Cari c)
        {
            var kullanicidogrulama = db.Caris.FirstOrDefault(x => x.CariMail == c.CariMail  && x.CariSifre == c.CariSifre);
            if (kullanicidogrulama != null)
            {
                FormsAuthentication.SetAuthCookie(kullanicidogrulama.CariMail, false);
                Session["CariMail"] = kullanicidogrulama.CariMail.ToString();
                return RedirectToAction("Index", "CariPanel");
            }
            else
            {
                return RedirectToAction("Index","Login");
            }

        }

        public ActionResult PersonelGirisFormu()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonelGirisFormu(Personel p)
        {
            var kullanicidogrulama = db.Personels.FirstOrDefault(x => x.PersonelMail == p.PersonelMail && x.PersonelSifre == p.PersonelSifre);
            if (kullanicidogrulama != null)
            {
                FormsAuthentication.SetAuthCookie(kullanicidogrulama.PersonelMail, false);
                Session["PersonelMail"] = kullanicidogrulama.PersonelMail.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }
    }
}