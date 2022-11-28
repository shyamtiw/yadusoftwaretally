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
    public partial class ISLRMK_Claim_Summary : BasePageClassMobile
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DataTable DealerData = new DataTable();
                DataTable dt = new DataTable();

                if (!string.IsNullOrWhiteSpace(Request.QueryString["dealercodeforcode"]))
                {
                    dt = MobileSales.ISLRMK_Summary(Request.QueryString["Region"].ToString(), (Request.QueryString["dealercodeforcode"].ToString()));
                    DealerData = MobileSales.ISLRMKDealerCode((Request.QueryString["Region"].ToString()));
                    Common.BindControldt(Repeater1, DealerData);
                }
                else if (!string.IsNullOrWhiteSpace(Request.QueryString["Region"]))
                {
                    dt = MobileSales.ISLRMK_Summary((Request.QueryString["Region"].ToString()));
                    DealerData = MobileSales.ISLRMKDealerCode((Request.QueryString["Region"].ToString()));
                    Common.BindControldt(Repeater1, DealerData);

                }
                else
                {
                    dt = MobileSales.ISLRMK_Summary();
                }
                DataTable dt1 = new DataTable();
                dt1 = MobileSales.ISLRMKRegionCode();
                Common.BindControldt(Repeater3, dt1);
                Common.BindControldt(ISLRMK_Claim_Data, dt);


                decimal TotTime_Barred = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["Time_Barred"]));
                decimal TotClarification_Req = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["Clarification_Req"]));
                decimal TotAccept = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["Accept"]));
                decimal TotClarification_Submit = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["Clarification_Submit"]));
                decimal TotReject = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["Reject"]));
                decimal TotMSIL_Submitted = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["MSIL_Submitted"]));
                decimal TotPending_For_Submit = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["Pending_For_Submit"]));
                decimal TotISLRMK = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["Time_Barred"])) + dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["Clarification_Req"])) + dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["Accept"])) + dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["Clarification_Submit"])) + dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["Reject"])) + dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["MSIL_Submitted"])) + dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["Pending_For_Submit"]));



                Time_barred.Text = String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}", TotTime_Barred).ToString();
                Clarification_Req.Text = String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}", TotClarification_Req).ToString();
                Accept.Text = String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}", TotAccept).ToString();
                Clarification_Submit.Text = String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}", TotClarification_Submit).ToString();
                Reject.Text = String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}", TotReject).ToString();
                MSIL_Submitted.Text = String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}", TotMSIL_Submitted).ToString();
                Pending_For_Submit.Text = String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}", TotPending_For_Submit).ToString();
                GTISLRMK.Text = String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}", TotISLRMK).ToString();

            }
        }
    }
}