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
                var il = from i in db.Iller select new { i.Id, i.Ad };

                ddlgIl.DataSource = il.ToList();
                ddlgIl.DataValueField = "il_id";
                ddlgIl.DataTextField = "ad";
                ddlgIl.DataBind();
                ddlgIl.Items.Insert(0, new ListItem("---"));
                ddlgIlce.Items.Insert(0, new ListItem("---"));

                ddlaIl.DataSource = il.ToList();
                ddlaIl.DataValueField = "il_id";
                ddlaIl.DataTextField = "ad";
                ddlaIl.DataBind();
                ddlaIl.Items.Insert(0, new ListItem("---"));
                ddlaIlce.Items.Insert(0, new ListItem("---"));

                gvKargoDataBind();
            }
        }
        private void gvKargoDataBind()
        {
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

        protected void btnYeniKargo_Click(object sender, EventArgs e)
        {

        }

        protected void btnKargo_Click(object sender, EventArgs e)
        {

        }
    }
}