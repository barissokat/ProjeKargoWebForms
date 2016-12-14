using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjeKargoWebForms.Model
{
    public class Takip
    {
        public int Id { get; set; }
        public int AdresId { get; set; }
        public int AdresId2 { get; set; }
        public int DurumId { get; set; }
        public int KargoId { get; set; }
        public DateTime GonderimTarihi { get; set; }
        public DateTime AlimTarihi { get; set; }

        public virtual Adres Adres { get; set; }
        public virtual Adres Adres1 { get; set; }
        public virtual Durum Durum { get; set; }
        public virtual Kargo Kargo { get; set; }
    }
}