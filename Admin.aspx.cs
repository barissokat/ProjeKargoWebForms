using ProjeKargoWebForms.DAL;
using ProjeKargoWebForms.Model;
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
                var il = from i in db.Iller select new { i.Id, i.Ad };

                ddlgIl.DataSource = il.ToList();
                ddlgIl.DataValueField = "Id";
                ddlgIl.DataTextField = "Ad";
                ddlgIl.DataBind();
                ddlgIl.Items.Insert(0, new ListItem("Bir il seçiniz"));
                ddlgIlce.Items.Insert(0, new ListItem("Bir ilçe seçiniz"));

                ddlaIl.DataSource = il.ToList();
                ddlaIl.DataValueField = "Id";
                ddlaIl.DataTextField = "Ad";
                ddlaIl.DataBind();
                ddlaIl.Items.Insert(0, new ListItem("Bir il seçiniz"));
                ddlaIlce.Items.Insert(0, new ListItem("Bir ilçe seçiniz"));

                gvKargoDataBind();
            }
        }
        private void gvKargoDataBind()
        {
            var kargolar = from t in db.Takipler
                           join a in db.Adresler on t.AdresId equals a.Id
                           join a2 in db.Adresler on t.AdresId1 equals a2.Id
                           join k in db.Kisiler on a.Id equals k.AdresId
                           join k2 in db.Kisiler on a2.Id equals k2.AdresId
                           join d in db.Durumlar on t.DurumId equals d.Id
                           join ka in db.Kargolar on t.KargoId equals ka.Id
                           join i in db.Iller on a.IlId equals i.Id
                           join i2 in db.Iller on a2.IlId equals i2.Id
                           join ie in db.Ilceler on a.IlceId equals ie.Id
                           join ie2 in db.Ilceler on a2.IlceId equals ie2.Id
                           select new
                           {
                               TakipId = t.Id,
                               gAd = k.Ad,
                               gSoyad = k.Soyad,
                               gTel = k.Tel,
                               gİl = i.Ad,
                               gİlce = ie.Ad,
                               gMahalle = a.Mahalle,
                               gSokak = a.Sokak,
                               gApartman = a.Apartman,
                               gNo = a.No,
                               aAd = k2.Ad,
                               aSoyad = k2.Soyad,
                               aTel = k2.Tel,
                               aİl = i2.Ad,
                               aİlce = ie2.Ad,
                               aMahalle = a2.Mahalle,
                               aSokak = a2.Sokak,
                               aApartman = a2.Apartman,
                               aNo = a2.No,
                               Ağırlık = ka.Agirlik,
                               Yükseklik = ka.Yukseklik,
                               ka.En,
                               ka.Boy,
                               Durum = d.Ad,
                           };
            gvKargo.DataSource = kargolar.ToList();
            gvKargo.DataBind();
        }

        protected void ddlgIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlgIl.SelectedIndex >= 0)
            {
                var sec = ddlgIl.SelectedIndex;
                var ilce = from i in db.Ilceler where i.IlId == sec select new { i.Id, i.Ad };
                ddlgIlce.DataSource = ilce.ToList();
                ddlgIlce.DataValueField = "Id";
                ddlgIlce.DataTextField = "Ad";
                ddlgIlce.DataBind();
            }
            ddlgIlce.Items.Insert(0, new ListItem("Bir ilçe seçiniz"));
        }

        protected void ddlaIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlaIl.SelectedIndex >= 0)
            {
                var sec = ddlaIl.SelectedIndex;
                var ilce = from i in db.Ilceler where i.IlId == sec select new { i.Id, i.Ad };
                ddlaIlce.DataSource = ilce.ToList();
                ddlaIlce.DataValueField = "Id";
                ddlaIlce.DataTextField = "Ad";
                ddlaIlce.DataBind();
            }
            ddlaIlce.Items.Insert(0, new ListItem("Bir ilçe seçiniz"));
        }

        protected void gvKargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedRowIndex = gvKargo.SelectedIndex;
            GridViewRow row = gvKargo.Rows[selectedRowIndex];
            tbTakipId.Text = row.Cells[1].Text;
            tbgAd.Text = row.Cells[2].Text;
            tbgSoyad.Text = row.Cells[3].Text;
            tbgTel.Text = row.Cells[4].Text;
            tbgMah.Text = row.Cells[7].Text;
            tbgSok.Text = row.Cells[8].Text;
            tbgApart.Text = row.Cells[9].Text;
            tbgNo.Text = row.Cells[10].Text;
            tbaAd.Text = row.Cells[11].Text;
            tbaSoyad.Text = row.Cells[12].Text;
            tbaTel.Text = row.Cells[13].Text;
            tbaMah.Text = row.Cells[16].Text;
            tbaSok.Text = row.Cells[17].Text;
            tbaApart.Text = row.Cells[18].Text;
            tbaNo.Text = row.Cells[19].Text;
            tbAgirlik.Text = row.Cells[20].Text;
            tbYukseklik.Text = row.Cells[21].Text;
            tbEn.Text = row.Cells[22].Text;
            tbBoy.Text = row.Cells[23].Text;
            /* GEÇİCİ ÇÖZÜM
             * Birden fazla il eklendiği zaman sıkıntı çıkarabilir. 
             * Kesin kontrol et değiştir.*/
            string gil = row.Cells[5].Text;
            var selectedGIl = (from i in db.Iller where i.Ad == gil select i).SingleOrDefault();
            int idgIl = selectedGIl.Id;
            ddlgIl.SelectedIndex = idgIl;

            var GIlce = from ie in db.Ilceler where ie.IlId == idgIl select new { ie.Id, ie.Ad };
            ddlgIlce.DataSource = GIlce.ToList();
            ddlgIlce.DataValueField = "Id";
            ddlgIlce.DataTextField = "Ad";
            ddlgIlce.DataBind();
            ddlgIlce.Items.Insert(0, new ListItem("Bir ilçe seçiniz"));

            string gilce = row.Cells[6].Text;
            var selectedGIlce = (from ie in db.Ilceler where ie.IlId == idgIl && ie.Ad == gilce select ie).SingleOrDefault();
            int idgIlce = selectedGIlce.Id;
            ddlgIlce.SelectedIndex = Convert.ToInt32(idgIlce);


            string ail = row.Cells[14].Text;
            var selectedAIl = (from i in db.Iller where i.Ad == gil select i).SingleOrDefault();
            int idaIl = selectedAIl.Id;
            ddlaIl.SelectedIndex = Convert.ToInt32(idaIl);

            var AIlce = from ie in db.Ilceler where ie.IlId == idaIl select new { ie.Id, ie.Ad };
            ddlaIlce.DataSource = AIlce.ToList();
            ddlaIlce.DataValueField = "Id";
            ddlaIlce.DataTextField = "Ad";
            ddlaIlce.DataBind();
            ddlaIlce.Items.Insert(0, new ListItem("Bir ilçe seçiniz"));

            string ailce = row.Cells[15].Text;
            var selectedAIlce = (from ie in db.Ilceler where ie.IlId == idaIl && ie.Ad == ailce select ie).SingleOrDefault();
            int idaIlce = selectedAIlce.Id;
            ddlaIlce.SelectedIndex = Convert.ToInt32(idaIlce);
            /**/
        }

        protected void btnYeniKargo_Click(object sender, EventArgs e)
        {
            gvKargo.SelectedIndex = -1;
            tbTakipId.Text = string.Empty;
            tbAgirlik.Text = string.Empty;
            tbYukseklik.Text = string.Empty;
            tbEn.Text = string.Empty;
            tbBoy.Text = string.Empty;
            tbgAd.Text = string.Empty;
            tbgSoyad.Text = string.Empty;
            tbgTel.Text = string.Empty;
            ddlgIl.SelectedIndex = 0;
            ddlgIlce.SelectedIndex = 0;
            tbgMah.Text = string.Empty;
            tbgSok.Text = string.Empty;
            tbgApart.Text = string.Empty;
            tbgNo.Text = string.Empty;
            tbaAd.Text = string.Empty;
            tbaSoyad.Text = string.Empty;
            tbaTel.Text = string.Empty;
            ddlaIl.SelectedIndex = 0;
            ddlaIlce.SelectedIndex = 0;
            tbaMah.Text = string.Empty;
            tbaSok.Text = string.Empty;
            tbaApart.Text = string.Empty;
            tbaNo.Text = string.Empty;
            lblSonuc.Text = "";
            /* GEÇİCİ ÇÖZÜM
             * Yukarıdaki birden fazla il eklendiğinde oluşabilecek hata sonrası bu kısmıda düzelt.
             * 
             */
            ddlgIlce.Items.Clear();
            ddlaIlce.Items.Clear();
            ddlgIlce.Items.Insert(0, new ListItem("Bir ilçe seçiniz"));
            ddlaIlce.Items.Insert(0, new ListItem("Bir ilçe seçiniz"));
            /**/

            tbAgirlik.Focus();
        }

        protected void btnKargo_Click(object sender, EventArgs e)
        {
            Takip takip;
            Kisi gKisi;
            Adres gAdres;
            Il gIl;
            Ilce gIlce;
            Kisi aKisi;
            Adres aAdres;
            Il aIl;
            Ilce aIlce;
            Kargo kargo;
            int selectedRowIndex = gvKargo.SelectedIndex;

            try
            {
                if (selectedRowIndex < 0)
                {
                    takip = new Takip();
                    gAdres = new Adres();
                    aAdres = new Adres();
                    gKisi = new Kisi();
                    aKisi = new Kisi();
                    kargo = new Kargo();

                    var gil = ddlgIl.SelectedIndex;
                    var gilce = ddlgIlce.SelectedItem.Text.ToString();
                    gIl = db.Iller.Find(gil);
                    gIlce = (from i in db.Iller
                             join ie in db.Ilceler on i.Id equals ie.IlId
                             where ie.IlId == gil && ie.Ad == gilce
                             select ie).SingleOrDefault();
                    gAdres.IlId = gil;
                    gAdres.IlceId = gIlce.Id;

                    gAdres.Mahalle = tbgMah.Text;
                    gAdres.Sokak = tbgSok.Text;
                    gAdres.Apartman = tbgApart.Text;
                    gAdres.No = tbgNo.Text;
                    db.Adresler.Add(gAdres);
                    db.SaveChanges();

                    gKisi.AdresId = gAdres.Id;
                    gKisi.Ad = tbgAd.Text;
                    gKisi.Soyad = tbgSoyad.Text;
                    gKisi.Tel = tbgTel.Text;
                    db.Kisiler.Add(gKisi);
                    db.SaveChanges();

                    var ail = ddlaIl.SelectedIndex;
                    var ailce = ddlaIlce.SelectedItem.Text.ToString();
                    aIl = db.Iller.Find(ail);
                    aIlce = (from i in db.Iller
                             join ie in db.Ilceler on i.Id equals ie.IlId
                             where ie.IlId == ail && ie.Ad == ailce
                             select ie).SingleOrDefault();
                    aAdres.IlId = ail;
                    aAdres.IlceId = aIlce.Id;

                    aAdres.Mahalle = tbaMah.Text;
                    aAdres.Sokak = tbaSok.Text;
                    aAdres.Apartman = tbaApart.Text;
                    aAdres.No = tbaNo.Text;
                    db.Adresler.Add(aAdres);
                    db.SaveChanges();

                    aKisi.AdresId = aAdres.Id;
                    aKisi.Ad = tbaAd.Text;
                    aKisi.Soyad = tbaSoyad.Text;
                    aKisi.Tel = tbaTel.Text;
                    db.Kisiler.Add(aKisi);
                    db.SaveChanges();

                    kargo.Agirlik = Convert.ToInt32(tbAgirlik.Text);
                    kargo.Yukseklik = Convert.ToInt32(tbYukseklik.Text);
                    kargo.En = Convert.ToInt32(tbEn.Text);
                    kargo.Boy = Convert.ToInt32(tbBoy.Text);
                    db.Kargolar.Add(kargo);
                    db.SaveChanges();

                    takip.AdresId = gAdres.Id;
                    takip.AdresId1 = aAdres.Id;
                    takip.DurumId = 1;
                    takip.KargoId = kargo.Id;
                    takip.GonderimTarihi = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    db.Takipler.Add(takip);
                    db.SaveChanges();

                    lblSonuc.Text = "Kargo başarıyla eklendi.";
                }
                else
                {
                    int tid = Convert.ToInt32(tbTakipId.Text);
                    takip = db.Takipler.Find(tid);

                    takip.Kargo.Agirlik = Convert.ToInt32(tbAgirlik.Text);
                    takip.Kargo.Yukseklik = Convert.ToInt32(tbYukseklik.Text);
                    takip.Kargo.En = Convert.ToInt32(tbEn.Text);
                    takip.Kargo.Boy = Convert.ToInt32(tbBoy.Text);

                    gAdres = (from t in db.Takipler
                              join a in db.Adresler on t.AdresId equals a.Id
                              where a.Id == takip.AdresId
                              select a).SingleOrDefault();

                    var gil = ddlgIl.SelectedIndex;
                    var gilce = ddlgIlce.SelectedItem.Text.ToString();
                    gIl = db.Iller.Find(gil);
                    gIlce = (from i in db.Iller
                             join ie in db.Ilceler on i.Id equals ie.IlId
                             where ie.IlId == gil && ie.Ad == gilce
                             select ie).SingleOrDefault();
                    gAdres.IlId = gil;
                    gAdres.IlceId = gIlce.Id;

                    gAdres.Mahalle = tbgMah.Text;
                    gAdres.Sokak = tbgSok.Text;
                    gAdres.Apartman = tbgApart.Text;
                    gAdres.No = tbgNo.Text;

                    gKisi = (from a in db.Adresler
                             join k in db.Kisiler on a.Id equals k.AdresId
                             where k.AdresId == gAdres.Id
                             select k).SingleOrDefault();
                    gKisi.Ad = tbgAd.Text;
                    gKisi.Soyad = tbgSoyad.Text;
                    gKisi.Tel = tbgTel.Text;


                    aAdres = (from t in db.Takipler
                              join a in db.Adresler on t.AdresId1 equals a.Id
                              where a.Id == takip.AdresId1
                              select a).SingleOrDefault();

                    var ail = ddlaIl.SelectedIndex;
                    var ailce = ddlaIlce.SelectedItem.Text.ToString();
                    aIl = db.Iller.Find(ail);
                    aIlce = (from i in db.Iller
                             join ie in db.Ilceler on i.Id equals ie.IlId
                             where ie.IlId == ail && ie.Ad == ailce
                             select ie).SingleOrDefault();
                    aAdres.IlId = ail;
                    aAdres.IlceId = aIlce.Id;

                    aAdres.Mahalle = tbaMah.Text;
                    aAdres.Sokak = tbaSok.Text;
                    aAdres.Apartman = tbaApart.Text;
                    aAdres.No = tbaNo.Text;

                    aKisi = (from a in db.Adresler
                             join k in db.Kisiler on a.Id equals k.AdresId
                             where k.AdresId == aAdres.Id
                             select k).SingleOrDefault();
                    aKisi.Ad = tbaAd.Text;
                    aKisi.Soyad = tbaSoyad.Text;
                    aKisi.Tel = tbaTel.Text;

                    lblSonuc.Text = "Kargo başarıyla güncellendi.";
                }
                db.SaveChanges();
                gvKargoDataBind();


                
            }
            catch (Exception)
            {
                lblSonuc.Text = "İşlem başarısız oldu.";
            }

            gvKargo.SelectedIndex = -1;
            tbTakipId.Text = string.Empty;
            tbAgirlik.Text = string.Empty;
            tbYukseklik.Text = string.Empty;
            tbEn.Text = string.Empty;
            tbBoy.Text = string.Empty;
            tbgAd.Text = string.Empty;
            tbgSoyad.Text = string.Empty;
            tbgTel.Text = string.Empty;
            ddlgIl.SelectedIndex = 0;
            ddlgIlce.SelectedIndex = 0;
            tbgMah.Text = string.Empty;
            tbgSok.Text = string.Empty;
            tbgApart.Text = string.Empty;
            tbgNo.Text = string.Empty;
            tbaAd.Text = string.Empty;
            tbaSoyad.Text = string.Empty;
            tbaTel.Text = string.Empty;
            ddlaIl.SelectedIndex = 0;
            ddlaIlce.SelectedIndex = 0;
            tbaMah.Text = string.Empty;
            tbaSok.Text = string.Empty;
            tbaApart.Text = string.Empty;
            tbaNo.Text = string.Empty;
            /* GEÇİCİ ÇÖZÜM
             * Yukarıdaki birden fazla il eklendiğinde oluşabilecek hata sonrası bu kısmıda düzelt.
             * 
             */
            ddlgIlce.Items.Clear();
            ddlaIlce.Items.Clear();
            ddlgIlce.Items.Insert(0, new ListItem("Bir ilçe seçiniz"));
            ddlaIlce.Items.Insert(0, new ListItem("Bir ilçe seçiniz"));
            /**/
        }
    }
}