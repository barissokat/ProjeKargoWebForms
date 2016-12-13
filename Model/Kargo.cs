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
        public Nullable<int> Agirlik { get; set; }
        public Nullable<int> Yukseklik { get; set; }
        public Nullable<int> En { get; set; }
        public Nullable<int> Boy { get; set; }

        public virtual ICollection<Takip> Takip { get; set; }

    }
}