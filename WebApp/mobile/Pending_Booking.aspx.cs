using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
using Business;
using WebApp.LIBS.MobileAppCS;

namespace WebApp.mobile
{
    public partial class Pending_Booking : BasePageClassMobile
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (SiteSession.PendingBookingMSGCode  > 0)
                {
                    SiteSession.PendingBookingMSGCode = 0;
                    Message.ShowMessage("Suc", "Request Send for Approval!", SiteKey.MessageType.success);
                }

                if (Request.QueryString["status"].ConvertInt() > 0)
                {
                    Common.BindControldt(LoopItem, MobileSales.DSEBKGMASTER(Request.QueryString["status"].ConvertInt(), SiteSession.LoginUser.MSPIN, SiteSession.LoginUser.Multi_loc));
                }
                else

                {
                    Common.BindControldt(ZeroPendingItem, MobileSales.DSEBKGMASTER(Request.QueryString["status"].ConvertInt(), SiteSession.LoginUser.MSPIN, SiteSession.LoginUser.Multi_loc));
                }

                


                


            }

        }
    }
}