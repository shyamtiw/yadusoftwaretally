using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
using Business;
using WebApp.LIBS.MobileAppCS;
using System.Data;

namespace WebApp.mobile
{
    public partial class Finance_Dashbaord : BasePageClassMobile
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();

               // Booking_Transport_Data.Transport_Data();

               

                username.Text = SiteSession.LoginUser.User_Name;
                Email.Text = SiteSession.LoginUser.UserEmail;
                MSPIN.Text = SiteSession.LoginUser.MSPIN;

    
            



            }

        }
    }
}