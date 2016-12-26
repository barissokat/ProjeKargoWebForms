using ProjeKargoWebForms.DAL;
using ProjeKargoWebForms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjeKargoWebForms
{
    public partial class User : System.Web.UI.Page
    {
        private KargoContext db = new KargoContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var il = from i in db.Iller select new { i.Id, i.Ad };

                ddlSubeIli.DataSource = il.ToList();
                ddlSubeIli.DataValueField = "Id";
                ddlSubeIli.DataTextField = "Ad";
                ddlSubeIli.DataBind();
                ddlSubeIli.Items.Insert(0, new ListItem("Bir il seçiniz"));
                ddlSubeIlce.Items.Insert(0, new ListItem("Bir ilçe seçiniz"));

                ddlKuryeIl.DataSource = il.ToList();
                ddlKuryeIl.DataValueField = "Id";
                ddlKuryeIl.DataTextField = "Ad";
                ddlKuryeIl.DataBind();
                ddlKuryeIl.Items.Insert(0, new ListItem("Bir il seçiniz"));
                ddlKuryeIlce.Items.Insert(0, new ListItem("Bir il seçiniz"));
            }
        }

        protected void btnKargomNerede_Click(object sender, EventArgs e)
        {
            try
            {
                int intControl = new int();
                var koid = Int32.TryParse(tbTakipNo.Text, out intControl);
                if (koid == true)
                {
                    var tid = Convert.ToInt32(tbTakipNo.Text);
                    Takip takip = db.Takipler.Find(tid);
                    if (takip != null)
                    {
                        if (takip.DurumId == 1)
                        {
                            var sonuc = (from t in db.Takipler
                                         join a in db.Adresler on t.AdresId equals a.Id
                                         join ie in db.Ilceler on a.IlceId equals ie.Id
                                         where t.Id == tid
                                         select new { ie.Ad }).SingleOrDefault();
                            lblTakipSonuc.Text = sonuc.Ad.ToString() + "'da";
                        }
                        else if (takip.DurumId == 3)
                        {
                            var sonuc = (from t in db.Takipler
                                         join a in db.Adresler on t.AdresId1 equals a.Id
                                         join ie in db.Ilceler on a.IlceId equals ie.Id
                                         where t.Id == tid
                                         select new { ie.Ad }).SingleOrDefault();
                            lblTakipSonuc.Text = sonuc.Ad.ToString() + "'da";
                        }
                        else
                        {
                            lblTakipSonuc.Text = takip.Durum.Ad.ToString();
                        }
                    }
                    else
                        lblTakipSonuc.Text = "Takip numarasını kontrol ediniz.";
                }
                else
                    lblTakipSonuc.Text = "Lütfen rakam giriniz.";
            }
            catch (Exception)
            {
                lblTakipSonuc.Text = "Lütfen rakam giriniz.";
            }
        }

        protected void btnTakipTemizle_Click(object sender, EventArgs e)
        {
            tbTakipNo.Text = string.Empty;
            lblTakipSonuc.Text = string.Empty;
        }

        protected void btnSube_Click(object sender, EventArgs e)
        {
            var il = ddlSubeIli.SelectedIndex;
            var ilce = ddlSubeIlce.SelectedIndex;
            var sube = from s in db.Subeler
                       join a in db.Adresler on s.AdresId equals a.Id
                       join i in db.Iller on a.IlId equals i.Id
                       join ie in db.Ilceler on a.IlceId equals ie.Id
                       where i.Id == il && ie.Id == ilce
                       select new { id = s.Id, sube = s.Ad, tel = s.Tel, il = i.Ad, ilce = ie.Ad, mahale = a.Mahalle, sokak = a.Sokak };
            gvSube.DataSource = sube.ToList();
            gvSube.DataBind();
        }

        protected void btnSubeTemizle_Click(object sender, EventArgs e)
        {
            clearSube();
            gvSube.EmptyDataText = "Yeni bir arama yapınız.";
            gvSube.DataBind();
        }
        protected void ddlSubeIli_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSubeIli.SelectedIndex >= 0)
            {
                var il = ddlSubeIli.SelectedIndex;
                var ilce = from ie in db.Ilceler where ie.IlId == il select new { ie.Id, ie.Ad };
                ddlSubeIlce.DataSource = ilce.ToList();
                ddlSubeIlce.DataValueField = "Id";
                ddlSubeIlce.DataTextField = "Ad";
                ddlSubeIlce.DataBind();
            }
            ddlSubeIlce.Items.Insert(0, new ListItem("Bir ilçe seçiniz"));
        }
        private void clearSube()
        {
            ddlSubeIli.SelectedIndex = 0;
            ddlSubeIlce.Items.Clear();
            ddlSubeIlce.Items.Insert(0, new ListItem("Bir ilçe seçiniz"));
            ddlSubeIlce.SelectedIndex = 0;
            gvSube.DataSource = null;
        }

        protected void btnKurye_Click(object sender, EventArgs e)
        {
            Kisi Kisi = new Kisi();
            Adres Adres = new Adres();
            KuryeCagir KuryeCagir = new KuryeCagir();
            Il Il = new Il();
            Ilce Ilce = new Ilce();
            try
            {
                var il = ddlKuryeIl.SelectedIndex;
                var ilce = ddlKuryeIlce.SelectedItem.Text.ToString();
                Il = db.Iller.Find(il);
                Ilce = (from i in db.Iller
                        join ie in db.Ilceler on i.Id equals ie.IlId
                        where ie.IlId == il && ie.Ad == ilce
                        select ie).SingleOrDefault();
                Adres.IlId = il;
                Adres.IlceId = Ilce.Id;
                Adres.Mahalle = tbKuryeMah.Text;
                Adres.Sokak = tbKuryeSok.Text;
                Adres.No = tbKuryeNo.Text;
                Adres.Apartman = tbKuryeApt.Text;
                db.Adresler.Add(Adres);

                Kisi.AdresId = Adres.Id;
                Kisi.Ad = tbKuryeAd.Text;
                Kisi.Soyad = tbKuryeSoyad.Text;
                Kisi.Tel = tbKuryeTel.Text;
                db.Kisiler.Add(Kisi);

                Random rndm = new Random();
                int kid = rndm.Next(1, 6);

                KuryeCagir.AdresId = Adres.Id;
                KuryeCagir.KuryeciId = kid;
                db.KuryeCagirlar.Add(KuryeCagir);

                db.SaveChanges();
                lblkcSonuc.Text = "Kuryeniz kısa bir süre içinde gönderilecektir.";
            }
            catch (Exception)
            {
                lblkcSonuc.Text = "İşleminiz gerçekleştirilemedi.";
            }
            clearKurye();
        }

        protected void ddlKuryeIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlKuryeIl.SelectedIndex >= 0)
            {
                var sec = ddlKuryeIl.SelectedIndex;
                var ilce = from ie in db.Ilceler where ie.IlId == sec select new { ie.IlId, ie.Ad };
                ddlKuryeIlce.DataSource = ilce.ToList();
                ddlKuryeIlce.DataValueField = "IlId";
                ddlKuryeIlce.DataTextField = "Ad";
                ddlKuryeIlce.DataBind();
            }
            ddlKuryeIlce.Items.Insert(0, new ListItem("Bir ilçe seçiniz"));
        }
        private void clearKurye()
        {
            tbKuryeAd.Text = string.Empty;
            tbKuryeSoyad.Text = string.Empty;
            tbKuryeTel.Text = string.Empty;
            ddlKuryeIl.SelectedIndex = 0;
            ddlKuryeIlce.Items.Clear();
            ddlKuryeIlce.Items.Insert(0, new ListItem("Bir ilçe seçiniz"));
            ddlKuryeIlce.SelectedIndex = 0;
            tbKuryeMah.Text = string.Empty;
            tbKuryeSok.Text = string.Empty;
            tbKuryeApt.Text = string.Empty;
            tbKuryeNo.Text = string.Empty;
        }
    }
}