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
    public partial class BSC_EW_Performance : BasePageClassMobile
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var Region = Request.QueryString["Region"].ToString();
                DataTable dt = MobileSales.EWWKS(Region);
                Common.BindControldt(EWWKSPerformance, dt);

                decimal TotRtl2122 = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["Region_Retail"]));
                decimal TotTgt2122 = System.Math.Ceiling(TotRtl2122 * 0.06m);
                decimal TotEW2122 = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["EWWKS"]));
                decimal TotEW70 = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["EW70PERC"]));
                decimal TotEW80 = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["EW80PERC"]));
                decimal TotBalance = TotTgt2122 - TotEW2122;
                decimal TotageAch = (TotEW2122 > 0 && TotTgt2122 > 0) ? (TotEW2122 / TotTgt2122) * 100 : (TotEW2122 / 1) * 100;
                decimal TotEW70Perc = (TotEW70 > 0 && TotRtl2122 > 0) ? (TotEW70 / TotRtl2122) * 100 : (TotEW70 / 1) * 100;
                decimal TotEW80Perc = (TotEW80 > 0 && TotRtl2122 > 0) ? (TotEW80 / TotRtl2122) * 100 : (TotEW80 / 1) * 100;

                Base2021.Text = ((int)System.Math.Ceiling(TotRtl2122)).ToString();
                Achieved.Text = ((int)System.Math.Ceiling(TotEW2122)).ToString();
                Tgt2122.Text = ((int)System.Math.Ceiling(TotTgt2122)).ToString();
                Balance.Text = ((int)System.Math.Ceiling(TotBalance)).ToString();
                ageAch.Text = TotageAch.ToString("0.00");
                EW70PERC.Text= ((int)System.Math.Ceiling(TotEW70Perc)).ToString();
                EW80PERC.Text = ((int)System.Math.Ceiling(TotEW80Perc)).ToString();

            }


        }
    }
}