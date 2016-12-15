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
        public Nullable<int> AdresId1 { get; set; }
        public Nullable<int> DurumId { get; set; }
        public Nullable<int> KargoId { get; set; }
        public Nullable<DateTime> GonderimTarihi { get; set; }
        public Nullable<DateTime> AlimTarihi { get; set; }

        public virtual Adres Adres { get; set; }
        public virtual Durum Durum { get; set; }
        public virtual Kargo Kargo { get; set; }
    }
}