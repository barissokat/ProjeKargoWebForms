using ProjeKargoWebForms.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjeKargoWebForms.DAL
{
    public class KargoInitializer : CreateDatabaseIfNotExists<KargoContext>
    {
        protected override void Seed(KargoContext context)
        {
            List<Kuryeci> kuryeciler = new List<Kuryeci>
            {
                new Kuryeci { Ad = "Cihan", Soyad = "Akpınar" },
                new Kuryeci { Ad = "Remzi", Soyad = "Bilgi" },
                new Kuryeci { Ad = "Mehmet", Soyad = "Çelikkol" },
                new Kuryeci { Ad = "Erhan", Soyad = "Dönmez" },
                new Kuryeci { Ad = "Gürbüz", Soyad = "Eroğlu" },
                new Kuryeci { Ad = "Hüseyin", Soyad = "Gökçek" }
            };
            kuryeciler.ForEach(kuryeci => context.Kuryeciler.Add(kuryeci));
            context.SaveChanges();

            List<Ilce> ilceler = new List<Ilce>
            {
                new Ilce { IlId = 1, Ad = "Aliağa"},
                new Ilce { IlId = 1, Ad = "Balçova"},
                new Ilce { IlId = 1, Ad = "Bayındır"},
                new Ilce { IlId = 1, Ad = "Bayraklı"},
                new Ilce { IlId = 1, Ad = "Bergama"},
                new Ilce { IlId = 1, Ad = "Beydağ"},
                new Ilce { IlId = 1, Ad = "Bornova"},
                new Ilce { IlId = 1, Ad = "Buca"},
                new Ilce { IlId = 1, Ad = "Çeşme"},
                new Ilce { IlId = 1, Ad = "Çiğli"},
                new Ilce { IlId = 1, Ad = "Dikili"},
                new Ilce { IlId = 1, Ad = "Foça"},
                new Ilce { IlId = 1, Ad = "Gaziemir"},
                new Ilce { IlId = 1, Ad = "Güzelbahçe"},
                new Ilce { IlId = 1, Ad = "Karabağlar"},
                new Ilce { IlId = 1, Ad = "Karaburun"},
                new Ilce { IlId = 1, Ad = "Karşıyaka"},
                new Ilce { IlId = 1, Ad = "Kemalpaşa"},
                new Ilce { IlId = 1, Ad = "Kınık"},
                new Ilce { IlId = 1, Ad = "Kiraz"},
                new Ilce { IlId = 1, Ad = "Konak"},
                new Ilce { IlId = 1, Ad = "Menderes"},
                new Ilce { IlId = 1, Ad = "Menemen"},
                new Ilce { IlId = 1, Ad = "Narlıdere"},
                new Ilce { IlId = 1, Ad = "Ödemiş"},
                new Ilce { IlId = 1, Ad = "Seferihisar"},
                new Ilce { IlId = 1, Ad = "Selçuk"},
                new Ilce { IlId = 1, Ad = "Tire"},
                new Ilce { IlId = 1, Ad = "Torbalı"},
                new Ilce { IlId = 1, Ad = "Urla"}
            };
            ilceler.ForEach(ilce => context.Ilceler.Add(ilce));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}