using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjeKargoWebForms.Model
{
    public class KuryeCagir
    {
        public int Id { get; set; }
        public Nullable<int> AdresId { get; set; }
        public Nullable<int> KuryeciId { get; set; }

        public virtual Adres Adres { get; set; }
        public virtual Kuryeci Kuryeci { get; set; }
    }
}