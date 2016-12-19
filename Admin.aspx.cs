﻿using ProjeKargoWebForms.DAL;
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
                var durum = from c in db.Durumlar select new { c.Id, c.Ad };

                ddlGonderenIl.DataSource = il.ToList();
                ddlGonderenIl.DataValueField = "Id";
                ddlGonderenIl.DataTextField = "Ad";
                ddlGonderenIl.DataBind();
                ddlGonderenIl.Items.Insert(0, new ListItem("Bir il seçiniz"));
                ddlGonderenIlce.Items.Insert(0, new ListItem("Bir ilçe seçiniz"));

                ddlAliciIl.DataSource = il.ToList();
                ddlAliciIl.DataValueField = "Id";
                ddlAliciIl.DataTextField = "Ad";
                ddlAliciIl.DataBind();
                ddlAliciIl.Items.Insert(0, new ListItem("Bir il seçiniz"));
                ddlAliciIlce.Items.Insert(0, new ListItem("Bir ilçe seçiniz"));

                ddlDurum.DataSource = durum.ToList();
                ddlDurum.DataValueField = "Id";
                ddlDurum.DataTextField = "Ad";
                ddlDurum.DataBind();
                ddlDurum.Items.Insert(0, new ListItem("---"));

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
            if (ddlGonderenIl.SelectedIndex >= 0)
            {
                var sec = ddlGonderenIl.SelectedIndex;
                var ilce = from i in db.Ilceler where i.IlId == sec select new { i.Id, i.Ad };
                ddlGonderenIlce.DataSource = ilce.ToList();
                ddlGonderenIlce.DataValueField = "Id";
                ddlGonderenIlce.DataTextField = "Ad";
                ddlGonderenIlce.DataBind();
            }
            ddlGonderenIlce.Items.Insert(0, new ListItem("Bir ilçe seçiniz"));
        }

        protected void ddlaIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAliciIl.SelectedIndex >= 0)
            {
                var sec = ddlAliciIl.SelectedIndex;
                var ilce = from i in db.Ilceler where i.IlId == sec select new { i.Id, i.Ad };
                ddlAliciIlce.DataSource = ilce.ToList();
                ddlAliciIlce.DataValueField = "Id";
                ddlAliciIlce.DataTextField = "Ad";
                ddlAliciIlce.DataBind();
            }
            ddlAliciIlce.Items.Insert(0, new ListItem("Bir ilçe seçiniz"));
        }

        protected void gvKargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedRowIndex = gvKargo.SelectedIndex;
            GridViewRow row = gvKargo.Rows[selectedRowIndex];
            tbTakipId.Text = row.Cells[1].Text;
            tbGonderenAd.Text = row.Cells[2].Text;
            tbGonderenSoyad.Text = row.Cells[3].Text;
            tbGonderenTel.Text = row.Cells[4].Text;
            tbGonderenMahalle.Text = row.Cells[7].Text;
            tbGonderenSokak.Text = row.Cells[8].Text;
            tbGonderenApartman.Text = row.Cells[9].Text;
            tbGonderenNo.Text = row.Cells[10].Text;
            tbAliciAd.Text = row.Cells[11].Text;
            tbAliciSoyad.Text = row.Cells[12].Text;
            tbAliciTel.Text = row.Cells[13].Text;
            tbAliciMahalle.Text = row.Cells[16].Text;
            tbAliciSokak.Text = row.Cells[17].Text;
            tbAliciApartman.Text = row.Cells[18].Text;
            tbAliciNo.Text = row.Cells[19].Text;
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
            ddlGonderenIl.SelectedIndex = idgIl;

            var GIlce = from ie in db.Ilceler where ie.IlId == idgIl select new { ie.Id, ie.Ad };
            ddlGonderenIlce.DataSource = GIlce.ToList();
            ddlGonderenIlce.DataValueField = "Id";
            ddlGonderenIlce.DataTextField = "Ad";
            ddlGonderenIlce.DataBind();
            ddlGonderenIlce.Items.Insert(0, new ListItem("Bir ilçe seçiniz"));

            string gilce = row.Cells[6].Text;
            var selectedGIlce = (from ie in db.Ilceler where ie.IlId == idgIl && ie.Ad == gilce select ie).SingleOrDefault();
            int idgIlce = selectedGIlce.Id;
            ddlGonderenIlce.SelectedIndex = Convert.ToInt32(idgIlce);


            string ail = row.Cells[14].Text;
            var selectedAIl = (from i in db.Iller where i.Ad == gil select i).SingleOrDefault();
            int idaIl = selectedAIl.Id;
            ddlAliciIl.SelectedIndex = Convert.ToInt32(idaIl);

            var AIlce = from ie in db.Ilceler where ie.IlId == idaIl select new { ie.Id, ie.Ad };
            ddlAliciIlce.DataSource = AIlce.ToList();
            ddlAliciIlce.DataValueField = "Id";
            ddlAliciIlce.DataTextField = "Ad";
            ddlAliciIlce.DataBind();
            ddlAliciIlce.Items.Insert(0, new ListItem("Bir ilçe seçiniz"));

            string ailce = row.Cells[15].Text;
            var selectedAIlce = (from ie in db.Ilceler where ie.IlId == idaIl && ie.Ad == ailce select ie).SingleOrDefault();
            int idaIlce = selectedAIlce.Id;
            ddlAliciIlce.SelectedIndex = Convert.ToInt32(idaIlce);
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
            tbGonderenAd.Text = string.Empty;
            tbGonderenSoyad.Text = string.Empty;
            tbGonderenTel.Text = string.Empty;
            ddlGonderenIl.SelectedIndex = 0;
            ddlGonderenIlce.SelectedIndex = 0;
            tbGonderenMahalle.Text = string.Empty;
            tbGonderenSokak.Text = string.Empty;
            tbGonderenApartman.Text = string.Empty;
            tbGonderenNo.Text = string.Empty;
            tbAliciAd.Text = string.Empty;
            tbAliciSoyad.Text = string.Empty;
            tbAliciTel.Text = string.Empty;
            ddlAliciIl.SelectedIndex = 0;
            ddlAliciIlce.SelectedIndex = 0;
            tbAliciMahalle.Text = string.Empty;
            tbAliciSokak.Text = string.Empty;
            tbAliciApartman.Text = string.Empty;
            tbAliciNo.Text = string.Empty;
            lblKargoSonuc.Text = "";
            /* GEÇİCİ ÇÖZÜM
             * Yukarıdaki birden fazla il eklendiğinde oluşabilecek hata sonrası bu kısmıda düzelt.
             * 
             */
            ddlGonderenIlce.Items.Clear();
            ddlAliciIlce.Items.Clear();
            ddlGonderenIlce.Items.Insert(0, new ListItem("Bir ilçe seçiniz"));
            ddlAliciIlce.Items.Insert(0, new ListItem("Bir ilçe seçiniz"));
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

                    var gil = ddlGonderenIl.SelectedIndex;
                    var gilce = ddlGonderenIlce.SelectedItem.Text.ToString();
                    gIl = db.Iller.Find(gil);
                    gIlce = (from i in db.Iller
                             join ie in db.Ilceler on i.Id equals ie.IlId
                             where ie.IlId == gil && ie.Ad == gilce
                             select ie).SingleOrDefault();
                    gAdres.IlId = gil;
                    gAdres.IlceId = gIlce.Id;

                    gAdres.Mahalle = tbGonderenMahalle.Text;
                    gAdres.Sokak = tbGonderenSokak.Text;
                    gAdres.Apartman = tbGonderenApartman.Text;
                    gAdres.No = tbGonderenNo.Text;
                    db.Adresler.Add(gAdres);
                    db.SaveChanges();

                    gKisi.AdresId = gAdres.Id;
                    gKisi.Ad = tbGonderenAd.Text;
                    gKisi.Soyad = tbGonderenSoyad.Text;
                    gKisi.Tel = tbGonderenTel.Text;
                    db.Kisiler.Add(gKisi);
                    db.SaveChanges();

                    var ail = ddlAliciIl.SelectedIndex;
                    var ailce = ddlAliciIlce.SelectedItem.Text.ToString();
                    aIl = db.Iller.Find(ail);
                    aIlce = (from i in db.Iller
                             join ie in db.Ilceler on i.Id equals ie.IlId
                             where ie.IlId == ail && ie.Ad == ailce
                             select ie).SingleOrDefault();
                    aAdres.IlId = ail;
                    aAdres.IlceId = aIlce.Id;

                    aAdres.Mahalle = tbAliciMahalle.Text;
                    aAdres.Sokak = tbAliciSokak.Text;
                    aAdres.Apartman = tbAliciApartman.Text;
                    aAdres.No = tbAliciNo.Text;
                    db.Adresler.Add(aAdres);
                    db.SaveChanges();

                    aKisi.AdresId = aAdres.Id;
                    aKisi.Ad = tbAliciAd.Text;
                    aKisi.Soyad = tbAliciSoyad.Text;
                    aKisi.Tel = tbAliciTel.Text;
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

                    lblKargoSonuc.Text = "Kargo başarıyla eklendi.";
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

                    var gil = ddlGonderenIl.SelectedIndex;
                    var gilce = ddlGonderenIlce.SelectedItem.Text.ToString();
                    gIl = db.Iller.Find(gil);
                    gIlce = (from i in db.Iller
                             join ie in db.Ilceler on i.Id equals ie.IlId
                             where ie.IlId == gil && ie.Ad == gilce
                             select ie).SingleOrDefault();
                    gAdres.IlId = gil;
                    gAdres.IlceId = gIlce.Id;

                    gAdres.Mahalle = tbGonderenMahalle.Text;
                    gAdres.Sokak = tbGonderenSokak.Text;
                    gAdres.Apartman = tbGonderenApartman.Text;
                    gAdres.No = tbGonderenNo.Text;

                    gKisi = (from a in db.Adresler
                             join k in db.Kisiler on a.Id equals k.AdresId
                             where k.AdresId == gAdres.Id
                             select k).SingleOrDefault();
                    gKisi.Ad = tbGonderenAd.Text;
                    gKisi.Soyad = tbGonderenSoyad.Text;
                    gKisi.Tel = tbGonderenTel.Text;


                    aAdres = (from t in db.Takipler
                              join a in db.Adresler on t.AdresId1 equals a.Id
                              where a.Id == takip.AdresId1
                              select a).SingleOrDefault();

                    var ail = ddlAliciIl.SelectedIndex;
                    var ailce = ddlAliciIlce.SelectedItem.Text.ToString();
                    aIl = db.Iller.Find(ail);
                    aIlce = (from i in db.Iller
                             join ie in db.Ilceler on i.Id equals ie.IlId
                             where ie.IlId == ail && ie.Ad == ailce
                             select ie).SingleOrDefault();
                    aAdres.IlId = ail;
                    aAdres.IlceId = aIlce.Id;

                    aAdres.Mahalle = tbAliciMahalle.Text;
                    aAdres.Sokak = tbAliciSokak.Text;
                    aAdres.Apartman = tbAliciApartman.Text;
                    aAdres.No = tbAliciNo.Text;

                    aKisi = (from a in db.Adresler
                             join k in db.Kisiler on a.Id equals k.AdresId
                             where k.AdresId == aAdres.Id
                             select k).SingleOrDefault();
                    aKisi.Ad = tbAliciAd.Text;
                    aKisi.Soyad = tbAliciSoyad.Text;
                    aKisi.Tel = tbAliciTel.Text;

                    lblKargoSonuc.Text = "Kargo başarıyla güncellendi.";
                }
                db.SaveChanges();
                gvKargoDataBind();


                
            }
            catch (Exception)
            {
                lblKargoSonuc.Text = "İşlem başarısız oldu.";
            }

            gvKargo.SelectedIndex = -1;
            tbTakipId.Text = string.Empty;
            tbAgirlik.Text = string.Empty;
            tbYukseklik.Text = string.Empty;
            tbEn.Text = string.Empty;
            tbBoy.Text = string.Empty;
            tbGonderenAd.Text = string.Empty;
            tbGonderenSoyad.Text = string.Empty;
            tbGonderenTel.Text = string.Empty;
            ddlGonderenIl.SelectedIndex = 0;
            ddlGonderenIlce.SelectedIndex = 0;
            tbGonderenMahalle.Text = string.Empty;
            tbGonderenSokak.Text = string.Empty;
            tbGonderenApartman.Text = string.Empty;
            tbGonderenNo.Text = string.Empty;
            tbAliciAd.Text = string.Empty;
            tbAliciSoyad.Text = string.Empty;
            tbAliciTel.Text = string.Empty;
            ddlAliciIl.SelectedIndex = 0;
            ddlAliciIlce.SelectedIndex = 0;
            tbAliciMahalle.Text = string.Empty;
            tbAliciSokak.Text = string.Empty;
            tbAliciApartman.Text = string.Empty;
            tbAliciNo.Text = string.Empty;
            /* GEÇİCİ ÇÖZÜM
             * Yukarıdaki birden fazla il eklendiğinde oluşabilecek hata sonrası bu kısmıda düzelt.
             * 
             */
            ddlGonderenIlce.Items.Clear();
            ddlAliciIlce.Items.Clear();
            ddlGonderenIlce.Items.Insert(0, new ListItem("Bir ilçe seçiniz"));
            ddlAliciIlce.Items.Insert(0, new ListItem("Bir ilçe seçiniz"));
            /**/
        }

        protected void btnDurumDegis_Click(object sender, EventArgs e)
        {
            try
            {
                var takipId = Convert.ToInt32(tbTakipNo.Text);
                Takip takip = db.Takipler.Find(takipId);
                takip.DurumId = ddlDurum.SelectedIndex;

                lblDurumSonuc.Text = "Başarıyla güncellenmiştir.";
                db.SaveChanges();
                gvKargoDataBind();
            }
            catch (Exception)
            {
                lblDurumSonuc.Text = "Böyle bir kayıt bulunmamaktadır.";
            }
            tbTakipNo.Text = string.Empty;
            ddlDurum.SelectedIndex = 0;
        }
    }
}