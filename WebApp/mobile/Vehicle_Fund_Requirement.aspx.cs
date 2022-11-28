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
    public partial class Vehicle_Fund_Requirement : BasePageClassMobile
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DataTable DealerData = new DataTable();
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                if (!string.IsNullOrWhiteSpace(Request.QueryString["dealercode"]))
                {
                    dt = MobileSales.FundRequirement(Request.QueryString["Region"], Request.QueryString["Dealercode"]);
                    Common.BindControldt(FundRequirement, dt);
                }
                else if (!string.IsNullOrWhiteSpace(Request.QueryString["Region"]))
                {
                    dt = MobileSales.FundRequirement(Request.QueryString["Region"]);
                    Common.BindControldt(FundRequirement, dt);
                }
                else
                {
                    dt = MobileSales.FundRequirement();
                    Common.BindControldt(FundRequirement, dt);
                }


                dt1 = MobileSales.Region();
                Common.BindControldt(Repeater3, dt1);

                dt2 = MobileSales.DealerCode1(Request.QueryString["Region"]);
                Common.BindControldt(Repeater1, dt2);



                decimal Totpbooking = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["Pending_booking"]));
                decimal Totfundneededindent = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["Fund_needed_indent"]));
                decimal Totfundrequirement = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["Fund_Requirement"]));
                decimal Totcurrentstock = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["Current_Stock"]));
                decimal Totsalesinceapr20 = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["Sale_Since_Apr20"]));


                pbooking.Text = Totpbooking.ToString();
                fundneededindent.Text = Totfundneededindent.ToString();
                fundrequirement1.Text = String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}", Totfundrequirement).ToString();
                currentstock.Text =  Totcurrentstock.ToString();
                salesinceapr20.Text =  Totsalesinceapr20.ToString();



            }
        }
    }
}