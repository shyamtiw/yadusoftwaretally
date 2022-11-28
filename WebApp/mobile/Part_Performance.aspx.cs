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
    public partial class Part_Performance : BasePageClassMobile
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var Region = Request.QueryString["Region"].ToString();

                DataTable DealerData = new DataTable();
                DataTable dt = new DataTable();

                if (!string.IsNullOrWhiteSpace(Request.QueryString["DealerCode"])) 
                {
                    dt = MobileSales.Service_Performance(Region, Request.QueryString["DealerCode"].ToString());
                    DealerData = MobileSales.Service_Location(Region);
                }
                else
                {
                    dt = MobileSales.Service_Performance(Region);
                    DealerData = MobileSales.Service_Location(Region);
                }
                Common.BindControldt(ServicePerformance, dt);
                Common.BindControldt(Repeater1, DealerData);

                decimal TotLoad1920 = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["Load1920"]));
                decimal TotLoad2021 = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["Load2021"]));
                decimal TotLoad2122 = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["Load2122"]));
                decimal TotPARt1920 = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["PARt1920"]));
                decimal TotPARt2021 = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["PARt2021"]));
                decimal TotPARt2122 = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["PARt2122"]));

                decimal GWT2122O2021 = (TotLoad2122 - TotLoad2021) / (TotLoad2021 > 0 ? TotLoad2021 : 1)  * 100;
                decimal GWT2122O1920 = (TotLoad2122 - TotLoad1920) / (TotLoad1920>0? TotLoad1920:1) * 100;
                decimal GWT2021O1920 = (TotLoad2021 - TotLoad1920) / (TotLoad1920 > 0 ? TotLoad1920 : 1)* 100;

                Load1920.Text = ((int)System.Math.Ceiling(TotPARt1920)).ToString();
                Load2021.Text = ((int)System.Math.Ceiling(TotPARt2021)).ToString();
                Load2122.Text = ((int)System.Math.Ceiling(TotPARt2122)).ToString();
                Growth2122Over1920.Text = ((int)System.Math.Ceiling(GWT2122O1920)).ToString();
                Growth2122Over2021.Text = ((int)System.Math.Ceiling(GWT2122O2021)).ToString();
                Growth2021Over1920.Text = ((int)System.Math.Ceiling(GWT2021O1920)).ToString();
                Perveh21.Text = ((int)System.Math.Ceiling((TotPARt2122 / (TotLoad2122 > 0 ? TotLoad2122 : 1)))).ToString();
                Perveh20.Text = ((int)System.Math.Ceiling((TotPARt2021 / (TotLoad2021 > 0 ? TotLoad2021 : 1)))).ToString();
                Perveh19.Text = ((int)System.Math.Ceiling((TotPARt1920 / (TotLoad1920 > 0 ? TotLoad1920 : 1)))).ToString();

            }

        }
    }
}