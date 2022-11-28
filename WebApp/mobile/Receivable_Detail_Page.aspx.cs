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
    public partial class Receivable_Detail_Page : BasePageClassMobile
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                var Schemename = Request.QueryString["Schemename"].ToString();
                var Region = Request.QueryString["Region"].ToString();

                DataTable dt = new DataTable();
              
                    DataTable DealerData = new DataTable();
                    DealerData = MobileSales.DealerCode(Schemename, Region);
                    Common.BindControldt(Repeater1, DealerData);

                
                if (!string.IsNullOrWhiteSpace(Request.QueryString["dealercode"]))
                {
                    dt = MobileSales.BSC_Data_1(Schemename, Region, (Request.QueryString["dealercode"].ToString()));
                }
                else
                {
                    dt = MobileSales.BSC_Data_1(Schemename, Region);
                }
                Common.BindControldt(BSC_Data, dt);

                DataTable dt1 = new DataTable();
                dt1 = MobileSales.Region();

                Common.BindControldt(Repeater3, dt1);

                decimal TotClaim = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["Claim"]));
                decimal TotRecd = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["Recd"]));
                decimal TotReject = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["Reject"]));
                decimal TotRecover = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["Recover"]));
                decimal TotBal = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["Bal"]));

               

                Claim.Text = String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}", TotClaim).ToString();
                Recd.Text = String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}", TotRecd).ToString();
                Reject.Text = String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}", TotReject).ToString();
                Recover.Text = String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}", TotRecover).ToString();
                Bal.Text = String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}", TotBal).ToString();
            }

        }
    }
}