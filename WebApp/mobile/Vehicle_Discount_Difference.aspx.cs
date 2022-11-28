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
    public partial class Vehicle_Discount_Difference : BasePageClassMobile
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DataTable DealerData = new DataTable();
                DataTable dt = new DataTable();
                //DataTable dt11 = new DataTable();
               // dt11 = MobileSales.GetDMSBookingData();
                dt = MobileSales.Discount_Offer_Difference();
                Common.BindControldt(DiscountAnalysis, dt);




                decimal Totofferdifference = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["offer_difference"]));
                offerdifference.Text = Totofferdifference.ToString();
             
            }
        }
    }
}