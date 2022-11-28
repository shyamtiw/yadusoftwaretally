using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
using Business;
namespace WebApp
{
    public partial class selectgodown : BasePageClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Common.BindControl(GoDownId, SiteSession.GetGodawanListSession.ToList(), "Value", "Id", "All");
            }
        }

        protected void loginbtn_Click(object sender, EventArgs e)
        {
            if (GoDownId.SelectedValue.ConvertInt() > 0)
            {
                SiteSession.GodownId = GoDownId.SelectedValue.ConvertInt();

                Response.Redirect(String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]) ? "~/admin/blankpage.aspx" : Request.QueryString["ReturnUrl"]);
            }
        }
    }
}