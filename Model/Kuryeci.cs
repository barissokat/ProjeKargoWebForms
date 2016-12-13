using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjeKargoWebForms.Model
{
    public class Kuryeci
    {
        public Kuryeci()
        {
            this.KuryeCagir = new HashSet<KuryeCagir>();
        }

        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public virtual ICollection<KuryeCagir> KuryeCagir { get; set; }
    }
}