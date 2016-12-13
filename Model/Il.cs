using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjeKargoWebForms.Model
{
    public class Il
    {
        public Il()
        {
            this.Adres = new HashSet<Adres>();
            this.Ilce = new HashSet<Ilce>();
        }

        public int Id { get; set; }
        public string Ad { get; set; }

        public virtual ICollection<Adres> Adres { get; set; }
        public virtual ICollection<Ilce> Ilce { get; set; }
    }
}