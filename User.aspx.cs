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
    }
}