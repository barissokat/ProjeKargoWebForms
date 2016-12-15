using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjeKargoWebForms.Model
{
    public class Adres
    {
        public Adres()
        {
            this.Kisi = new HashSet<Kisi>();
            this.KuryeCagir = new HashSet<KuryeCagir>();
            this.Sube = new HashSet<Sube>();
            this.Takip = new HashSet<Takip>();
        }

        public int Id { get; set; }
        public Nullable<int> IlId { get; set; }
        public Nullable<int> IlceId { get; set; }
        public string Mahalle { get; set; }
        public string Sokak { get; set; }
        public string Apartman { get; set; }
        public string No { get; set; }

        public virtual Il il { get; set; }
        public virtual Ilce ilce { get; set; }
        public virtual ICollection<Kisi> Kisi { get; set; }
        public virtual ICollection<KuryeCagir> KuryeCagir { get; set; }
        public virtual ICollection<Sube> Sube { get; set; }
        public virtual ICollection<Takip> Takip { get; set; }
    }
}