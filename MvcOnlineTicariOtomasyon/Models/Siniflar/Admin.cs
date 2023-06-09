﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string AdminKullaniciAdi { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string AdminKullaniciSifre { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string AdminKullaniciYetki { get; set; }
    }
}