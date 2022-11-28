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
    public partial class Vehicle_Discount_Breakup : BasePageClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                SiteSession.SalesDataTable = MobileSales.Discount_Offer_Difference(Request.QueryString["Invno"]);
                DataRow dr = SiteSession.SalesDataTable.Rows[0];
                Ledg_name.Text = dr["CustomerName"].ToString() + " (" + dr["Customerid"].ToString() + ")";
                InvNo.Text = dr["Invno"].ToString();
                InvDt.Text = dr["Invdt"].ToString();
                DSE.Text = dr["DSE"].ToString();
                offer_given.Text = dr["Club_COnsumer_offer"].ToString();
                msilconsoffer.Text = dr["MSIL_COnsumer_offer"].ToString();
                msilrips1.Text = dr["MSIL_RIPS1_Offer"].ToString();
                msilrips2.Text = dr["MSIL_RIPS2_Offer"].ToString();
                msilrips3.Text = dr["MSIL_RIPS3_Offer"].ToString();
                mssfoffer.Text = dr["MSSFDiscount"].ToString();
                CSD_PRICE_DIFFERENCE.Text = dr["csd_price_difference"].ToString();
                Post_Sale_Discount.Text = dr["Post_Sale_Discount"].ToString();
                offerdifference.Text = dr["offer_difference"].ToString();
                midate.Text = dr["midate"].ToString();
                variantdesc.Text= dr["variantdesc"].ToString();
                Locationcode.Text= dr["Locationcode"].ToString();
            }


        }
    }
}