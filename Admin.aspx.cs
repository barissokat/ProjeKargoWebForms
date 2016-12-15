using ProjeKargoWebForms.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjeKargoWebForms
{
    public partial class Admin : System.Web.UI.Page
    {
        private KargoContext db = new KargoContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvDataBind();
            }
        }
        private void gvDataBind()
        {
            /*SELECT t.takip_id AS id, i.ad AS gIl, ie.ad AS gIlce, a.mah AS gMahalle, a.sok AS gSokak, a.apt AS gApartman, a.no AS gNo, ki.ad AS gAd, ki.soyad AS gSoyad, ki.tel AS gTel, i1.ad AS aIl, ie1.ad AS aIlce, a1.mah AS aMahalle, a1.sok AS aSokak, a1.apt AS aApartman, a1.no AS aNo, ki1.ad AS aAd, ki1.soyad AS aSoyad, ki1.tel AS aTel, d.ad AS durum, ka.agirlik, ka.yukseklik, ka.en, ka.boy, t.baslangic_tarihi, t.bitis_tarihi 
             * FROM takip AS t 
                INNER JOIN adres AS a ON t.adres_id = a.adres_id 
                INNER JOIN adres AS a1 ON t.adres_id2 = a1.adres_id 
                INNER JOIN kisi AS ki ON a.adres_id = ki.adres_id 
                INNER JOIN kisi AS ki1 ON a1.adres_id = ki1.adres_id 
                INNER JOIN durum AS d ON t.durum_id = d.durum_id 
                INNER JOIN kargo AS ka ON t.kargo_id = ka.kargo_id 
                INNER JOIN il AS i ON a.il_id = i.il_id 
                INNER JOIN il AS i1 ON a1.il_id = i1.il_id 
                INNER JOIN ilce AS ie ON a.ilce_id = ie.ilce_id 
                INNER JOIN ilce AS ie1 ON a1.ilce_id = ie1.ilce_id*/
            var kargolar = from t in db.Takipler
                           join a in db.Adresler on t.AdresId equals a.Id
                           join a2 in db.Adresler on t.AdresId2 equals a2.Id
                           join k in db.Kisiler on a.Id equals k.AdresId
                           join k2 in db.Kisiler on a2.Id equals k2.AdresId
                           join d in db.Durumlar on t.DurumId equals d.Id
                           join ka in db.Kargolar on t.KargoId equals ka.Id
                           join i in db.Iller on a.IlId equals i.Id
                           join i2 in db.Iller on a2.IlId equals i2.Id
                           join ie in db.Ilceler on a.IlceId equals ie.Id
                           join ie2 in db.Ilceler on a2.IlceId equals ie2.Id
                           select new {
                               TakipId = t.Id,
                               gİl = i.Ad,
                               gİlce = ie.Ad,
                               gMahalle = a.Mahalle,
                               gSokak = a.Sokak,
                               gApartman = a.Apartman,
                               gNo = a.No,
                               gAd = k.Ad,
                               gSoyad = k.Soyad,
                               gTel = k.Tel,
                               aİl = i.Ad,
                               aİlce = ie.Ad,
                               aMahalle = a.Mahalle,
                               aSokak = a.Sokak,
                               aApartman = a.Apartman,
                               aNo = a.No,
                               aAd = k.Ad,
                               aSoyad = k.Soyad,
                               aTel = k.Tel,
                           };
            GridViewTest.DataSource = kargolar.ToList();
            GridViewTest.DataBind();
        }
    }
}