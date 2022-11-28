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
    public partial class Fund_Balance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                DataTable dt = new DataTable();

                if (!string.IsNullOrWhiteSpace(Request.QueryString["Type"]))
                { 
                    dt = MobileSales.Daily_Fund_Balance(Request.QueryString["Type"]);
                }
                else
                {
                    dt = MobileSales.Daily_Fund_Balance();
                }
                Common.BindControldt(Fund_Balance1, dt);

                decimal TotCashS = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["CashS"]));
                decimal TotCashF = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["CashF"]));
                decimal TotCashSF = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["TotalSF"]));
              


                Cashs.Text = String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}", TotCashS).ToString();
                Cashf.Text = String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}", TotCashF).ToString();
                Cashsf.Text = String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}", TotCashSF).ToString();



            }

        }
    }
}