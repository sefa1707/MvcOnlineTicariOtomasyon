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

        public int Urunid { get; set; }
        public int Cariid { get; set; }
        public int Personelid { get; set; }

        public virtual Urun Urun{ get; set; }
        public virtual Cari Cari { get; set; }
        public virtual Personel Personel { get; set; }
    }
}