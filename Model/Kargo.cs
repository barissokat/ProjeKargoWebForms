using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjeKargoWebForms.Model
{
    public class Kargo
    {
        public Kargo()
        {
            this.Takip = new HashSet<Takip>();
        }

        public int Id { get; set; }
        public int Agirlik { get; set; }
        public int Yukseklik { get; set; }
        public int En { get; set; }
        public int Boy { get; set; }

        public virtual ICollection<Takip> Takip { get; set; }

    }
}