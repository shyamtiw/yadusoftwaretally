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
    public partial class MSIL_Receivable : BasePageClassMobile
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                DataTable dt = new DataTable();

                DataTable dt1 = new DataTable();
                dt1 = MobileSales.DealerCode();

                if (!string.IsNullOrWhiteSpace(Request.QueryString["Region"]))
                {
                    dt = MobileSales.BSC_Data((Request.QueryString["Region"].ToString()));

                }
                else
                {
                    dt = MobileSales.BSC_Data();
                }
                Common.BindControldt(Repeater2, dt);


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