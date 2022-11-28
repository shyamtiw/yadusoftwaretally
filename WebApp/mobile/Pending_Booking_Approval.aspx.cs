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
    public partial class Pending_Booking_Approval : BasePageClassMobile
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (SiteSession.PendingBookingMSGCode > 0)
                {
                    
                    if(SiteSession.PendingBookingMSGCode==2)
                    {  Message.ShowMessage("Suc", SiteSession.PendingBookingMSG, SiteKey.MessageType.warning);
                    }
                    else if (SiteSession.PendingBookingMSGCode == 3)
                    {
                        Message.ShowMessage("Suc", SiteSession.PendingBookingMSG, SiteKey.MessageType.danger);
                    }
                    else if (SiteSession.PendingBookingMSGCode == 4)
                    {
                        Message.ShowMessage("Suc", SiteSession.PendingBookingMSG, SiteKey.MessageType.success);
                    }
                    SiteSession.PendingBookingMSGCode = 0;
                    SiteSession.PendingBookingMSG = "";
                }

                Common.BindControldt(LoopItem, MobileSales.FillReportigUplevel(Request.QueryString["status"].ConvertInt()));
            }

        }
    }
}