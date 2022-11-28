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
    public partial class Additional_Discount_Analysis_Summary : BasePageClassMobile
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
                    dt = MobileSales.DiscountAnalysis(Request.QueryString["Region"], Request.QueryString["dealercode"]);
                    Common.BindControldt(DiscountAnalysis, dt);
                }
                else if (!string.IsNullOrWhiteSpace(Request.QueryString["Region"]))
                {
                    dt = MobileSales.DiscountAnalysis(Request.QueryString["Region"]);
                    Common.BindControldt(DiscountAnalysis, dt);
                }
                else
                {
                    dt = MobileSales.DiscountAnalysis();
                    Common.BindControldt(DiscountAnalysis, dt);
                }


                dt1 = MobileSales.Region();
                Common.BindControldt(Repeater3, dt1);

                dt2 = MobileSales.DealerCode2(Request.QueryString["Region"]);
                Common.BindControldt(Repeater1, dt2);



                decimal TotSale = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["Sale"]));
                decimal TotDiscount = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["Additional_Discount"]));


                Retail.Text = String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}", TotSale.ToString());
                Discount.Text = String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}", TotDiscount.ToString());
                pervehicle.Text = ((int)System.Math.Ceiling((TotDiscount / (TotSale > 0 ? TotSale : 1)))).ToString(); 

            }
        }
    }
}