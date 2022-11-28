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
    public partial class MSIL_Balance_Detail : BasePageClassMobile
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                var Schemename = !string.IsNullOrWhiteSpace(Request.QueryString["Schemename"]) ?Request.QueryString["Schemename"].ToString():"";
                var Region = !string.IsNullOrWhiteSpace(Request.QueryString["Region"]) ? Request.QueryString["Region"].ToString() : "";
                var Month = !string.IsNullOrWhiteSpace(Request.QueryString["Month"]) ? Request.QueryString["Month"].ToString() : "";
                var Dealercode = !string.IsNullOrWhiteSpace(Request.QueryString["Dealercode"]) ? Request.QueryString["Dealercode"].ToString() : "";
                var Status = !string.IsNullOrWhiteSpace(Request.QueryString["Status"]) ? Request.QueryString["Status"].ToString() : "";

                DataTable dt = new DataTable();

               
                    dt = MobileSales.MSIL_Claim_Detail(Status,Region,Month, Schemename,Dealercode);
                Common.BindControldt(MSIL_Claim_Detail, dt);


                decimal TotClaim = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["Claim"]));
                decimal TotRecd = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["Recd"]));
                decimal TotReject = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["Reject"]));
                decimal TotRecover = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["Recover"]));
                decimal TotBal = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["Balance"]));



                Claim.Text = String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}", TotClaim).ToString();
                Recd.Text = String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}", TotRecd).ToString();
                Reject.Text = String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}", TotReject).ToString();
                Recover.Text = String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}", TotRecover).ToString();
                Bal.Text = String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}", TotBal).ToString();
            }

        }
    }
}