using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjeKargoWebForms.Model
{
    public class Durum
    {
        public Durum()
        {
            this.Takip = new HashSet<Takip>();
        }

        public int Id { get; set; }
        public string Ad { get; set; }

        public virtual ICollection<Takip> Takip { get; set; }
    }
}