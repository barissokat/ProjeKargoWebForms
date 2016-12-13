using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjeKargoWebForms.Model
{
    public class Ilce
    {
        public Ilce()
        {
            this.Adres = new HashSet<Adres>();
        }

        public int Id { get; set; }
        public Nullable<int> IlId { get; set; }
        public string Ad { get; set; }

        public virtual Il Il { get; set; }
        public virtual ICollection<Adres> Adres { get; set; }
    }
}