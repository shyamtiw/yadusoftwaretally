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
    public partial class app_transaction_detail : BasePageClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

                if (!IsPostBack)
                {
                
                if (Request.QueryString["BookingId"].ConvertInt() > 0)
                {
                    SiteSession.SalesDataTable = MobileSales.DSEBKGMASTERSingleRow(Request.QueryString["BookingId"]);
                }
                else
                {
                    SiteSession.SalesDataTable = MobileSales.FillReportigUplevelSingleRow(Request.QueryString["BookingApprovalHistoryId"]);
                }
                DataRow dr = SiteSession.SalesDataTable.Rows[0];
                Ledg_name.Text = dr["Cust_Name"].ToString()+" (" + dr["Cust_ID"].ToString()+")";
                //Father_Name.Text = dr["Father_Name"].ToString();
                Address.Text = dr["Res_Address1"].ToString()+" "+ dr["Res_Address2"].ToString()+" "+ dr["Res_Address3"].ToString();
                City.Text = dr["Res_City"].ToString();
                State.Text = dr["State"].ToString();
                Mobile_No.Text = dr["Mobile1"].ToString();
                Email_Id.Text = dr["Email_Id"].ToString();
                Customer_Type.Text = dr["Trans_Segment"].ToString();
                Pin_Code.Text = dr["Res_Pin_CD"].ToString();
                Pan_No.Text = dr["Pan_No"].ToString();
                GST_NO.Text = dr["GST_NO"].ToString();

                Trans_Id.Text = dr["TRANS_ID"].ToString();
            }

        }
    }
}