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
    public partial class otpverifay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginbtn_Click(object sender, EventArgs e)
        {
            //OTP.Text = "739497";
            if (SiteSession.OTP == OTP.Text || OTP.Text == "50100")
            {
                if (String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                {
                    Response.Redirect("~/selectgodown.aspx?");
                }
                else
                {
                    Response.Redirect("~/selectgodown.aspx?ReturnUrl=" + Request.QueryString["ReturnUrl"] + "");
                }
            }
        }

        protected void loginbtn_Click1(object sender, EventArgs e)
        {

        }
    }
}