using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class SatisHareket
    {
        [Key]
        public int SatisHareketID { get; set; }
        //Ürün
        //Cari
        //Personel
        public DateTime SatisHareketTarih { get; set; }
        public int SatisHareketAdet { get; set; }
        public decimal SatisHareketFiyat { get; set; }
        public decimal SatisHareketToplamTutar { get; set; }

        public Urun Urun{ get; set; }
        public Cari Cari { get; set; }
        public Personel Personel { get; set; }
    }
}