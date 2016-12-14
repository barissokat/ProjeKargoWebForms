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
                new Ilce { IlId = 1, Ad = "Bornova"},
                new Ilce { IlId = 1, Ad = "Çiğli"},
                new Ilce { IlId = 1, Ad = "Gaziemir"},
                new Ilce { IlId = 1, Ad = "Karşıyaka"},
                new Ilce { IlId = 1, Ad = "Konak"},
                new Ilce { IlId = 1, Ad = "Narlıdere"}
            };
            ilceler.ForEach(ilce => context.Ilceler.Add(ilce));
            context.SaveChanges();

            var izmir = new Il { Ad = "İzmir" };
            context.Iller.Add(izmir);
            context.SaveChanges();

            List<Durum> durumlar = new List<Durum>
            {
                new Durum { Ad = "Şube1" },
                new Durum { Ad = "Yolda" },
                new Durum { Ad = "Şube2" },
                new Durum { Ad = "Dağıtımda" },
                new Durum { Ad = "Teslim edildi" }
            };
            durumlar.ForEach(durum => context.Durumlar.Add(durum));
            context.SaveChanges();

            var subeAliagaAdres = new Adres { IlId = 1, IlceId = 1, Mahalle = "Atatürk Mah.", Sokak = "Fatih Sok.", No = "37/D" };
            var subeBornovaAdres = new Adres { IlId = 1, IlceId = 2, Mahalle = "Kazimdirik Mah.", Sokak = "301 Sok.", No = "41" };
            var subeCigliAdres = new Adres { IlId = 1, IlceId = 3, Mahalle = "Ataşehir Mah.", Sokak = "8220 Sok.", No = "18/B" };
            var subeGaziemirAdres = new Adres { IlId = 1, IlceId = 4, Mahalle = "Gazi Mah.", Sokak = "28/25 Sok.", No = "42/A" };
            var subeKarsiyakaAdres = new Adres { IlId = 1, IlceId = 5, Mahalle = "Bostanlı Mah.", Sokak = "Şehitler Sok.", No = "57/A" };
            var subeKonakAdres = new Adres { IlId = 1, IlceId = 6, Mahalle = "Halkapinar Mah.", Sokak = "1204/6 Sok.", No = "40/A" };
            var subeNarlidereAdres = new Adres { IlId = 1, IlceId = 7, Mahalle = "Çamtepe Mah.", Sokak = "Güngören Sok.", No = "43/C" };
            context.Adresler.Add(subeAliagaAdres);
            context.Adresler.Add(subeBornovaAdres);
            context.Adresler.Add(subeCigliAdres);
            context.Adresler.Add(subeGaziemirAdres);
            context.Adresler.Add(subeKarsiyakaAdres);
            context.Adresler.Add(subeKonakAdres);
            context.Adresler.Add(subeNarlidereAdres);
            context.SaveChanges();

            List<Sube> subeler = new List<Sube>
            {
                new Sube { AdresId = subeAliagaAdres.Id, Ad = "Aliağa Şube", Tel = "0 232 614 6840" },
                new Sube { AdresId = subeBornovaAdres.Id, Ad = "Bornova Şube", Tel = "0 232 614 6841" },
                new Sube { AdresId = subeCigliAdres.Id, Ad = "Çiğli Şube", Tel = "0 232 614 6842" },
                new Sube { AdresId = subeGaziemirAdres.Id, Ad = "Gaziemir Şube", Tel = "0 232 614 6843" },
                new Sube { AdresId = subeKarsiyakaAdres.Id, Ad = "Karşıyaka Şube", Tel = "0 232 614 6844" },
                new Sube { AdresId = subeKonakAdres.Id, Ad = "Konak Şube", Tel = "0 232 614 6845" },
                new Sube { AdresId = subeNarlidereAdres.Id, Ad = "Narlıdere Şube", Tel = "0 232 614 6846" }
            };
            subeler.ForEach(sube => context.Subeler.Add(sube));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}