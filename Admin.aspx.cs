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
            var subeler = from s in db.Subeler select s;
            GridViewTest.DataSource = subeler.ToList();
            GridViewTest.DataBind();
        }
    }
}