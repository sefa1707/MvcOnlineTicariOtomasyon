﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GaleriController : Controller
    {
        // GET: Galeri
        Context db = new Context();
        public ActionResult Index()
        {
            var gorsel = db.Uruns.ToList();
            return View(gorsel);
        }
    }
}