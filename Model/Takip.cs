using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjeKargoWebForms.Model
{
    public class Takip
    {
        public int Id { get; set; }
        public Nullable<int> AdresId { get; set; }
        public Nullable<int> AdresId2 { get; set; }
        public Nullable<int> DurumId { get; set; }
        public Nullable<int> KargoId { get; set; }
        public DateTime GonderimTarihi { get; set; }
        public DateTime AlimTarihi { get; set; }

        public virtual Adres Adres { get; set; }
        public virtual Adres Adres1 { get; set; }
        public virtual Durum Durum { get; set; }
        public virtual Kargo Kargo { get; set; }
    }
}