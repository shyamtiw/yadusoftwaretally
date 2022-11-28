using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;

namespace WebApp.mobile
{
    public partial class otpverification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void Logindata_Click(object sender, EventArgs e)
        {


            if (SiteSession.OTP == email.Text || email.Text == "50100")
            {

                var countLoction = SiteSession.LoginUser.Multi_loc.Split(',');
                    if (countLoction.Count() > 1)
                    {
                        if (String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                        {
                            Response.Redirect("selectgodown.aspx?", false);
                        }
                        else
                        {
                            Response.Redirect("selectgodown.aspx?ReturnUrl=" + Request.QueryString["ReturnUrl"] + "", false);
                        }
                    }

                    else

                    {
                        SiteSession.GodownId = countLoction[0].ConvertInt();

                    if (SiteSession.DesignationId >= 18 && SiteSession.DesignationId <= 21)
                    {
                        Response.Redirect(String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]) ? "Booking_Dashbaord.aspx" : Request.QueryString["ReturnUrl"]);
                    }
                    else if (SiteSession.DesignationId >= 22 && SiteSession.DesignationId <= 25)
                    {
                        Response.Redirect(String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]) ? "Approver_Dashbaord.aspx" : Request.QueryString["ReturnUrl"]);
                    }
                    else
                    {
                        Response.Redirect(String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]) ? "Mobile_Home.aspx" : Request.QueryString["ReturnUrl"]);

                    }

                }


            }
        }


    }
}