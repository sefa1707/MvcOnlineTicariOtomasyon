using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context db = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var carimailbilgi = (string)Session["CariMail"];
            var degerler = db.Caris.FirstOrDefault(x => x.CariMail == carimailbilgi);
            ViewBag.carimail = carimailbilgi;
            return View(degerler);
        }

        public ActionResult CariIndex()
        {
            return View();
        }

        public ActionResult CariSiparislerim()
        {
            var carimailbilgi = (string)Session["CariMail"];
            var id = db.Caris.Where(x => x.CariMail == carimailbilgi.ToString()).Select(y => y.CariID).FirstOrDefault();
            var siparisler = db.SatisHarekets.Where(x => x.Cariid == id).ToList();
            return View(siparisler);
        }
    }
}