﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Yapilacak
    {
        [Key]
        public int YapilacakID { get; set; }
        [Column(TypeName="Varchar")]
        [StringLength(100)]
        public string YapilacakBaslik { get; set; }
        [Column(TypeName = "bit")]
        public bool YapilacakDurum { get; set; }

    }
}