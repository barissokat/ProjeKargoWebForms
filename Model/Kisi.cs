using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjeKargoWebForms.Model
{
    public class Kisi
    {
        public int Id { get; set; }
        public int AdresId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Tel { get; set; }

        public virtual Adres Adres { get; set; }
    }
}