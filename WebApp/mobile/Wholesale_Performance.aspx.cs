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
    public partial class Wholesale_Performance : BasePageClassMobile
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                var Region = Request.QueryString["Region"].ToString();
                DataTable dt = MobileSales.WholeSale_Performance(Region);
                Common.BindControldt(WSPerformance, dt);

                decimal TotBase2021=  dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["2020-21"]));
                decimal TotAchieved = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["2021-22"]));
                decimal TotTgt2122 = System.Math.Ceiling(TotBase2021 * 1.30m);
                decimal TotBalance = TotTgt2122- TotAchieved;
                decimal TotageAch =(TotAchieved>0 && TotTgt2122 >0)?  (TotAchieved /TotTgt2122)*100: (TotAchieved / 1)*100;

                Base2021.Text = ((int)System.Math.Ceiling(TotBase2021)).ToString();
                Achieved.Text = ((int)System.Math.Ceiling(TotAchieved)).ToString();
                Tgt2122.Text = ((int)System.Math.Ceiling(TotTgt2122)).ToString();
                Balance.Text = ((int)System.Math.Ceiling(TotBalance)).ToString();
                ageAch.Text = TotageAch.ToString("0.00");


            }

        }
    }
}