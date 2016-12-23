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
    }
}