using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Fatura
    {
        [Key]
        public int FaturaID { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string FaturaSeriNo { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string FaturaSiraNo { get; set; }
        public DateTime FaturaTarih { get; set; }
        public DateTime FaturaSaat { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string FaturaVergiDairesi { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string FaturaTelimAlan { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string FaturaTelimEden { get; set; }

        public ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}