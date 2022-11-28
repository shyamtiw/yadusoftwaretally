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
    public partial class app_Shipping_detail : BasePageClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DataRow dr = SiteSession.SalesDataTable.Rows[0];
                Ship_Customer_Name.Text = dr["Ship_FULL_Name"].ToString();
                Ship_Address.Text = dr["Ship_Address1"].ToString()+ " "+dr["Ship_Address2"].ToString()+ " " +dr["Ship_Address3"].ToString();
                Ship_City.Text = dr["Ship_City"].ToString();
                Ship_State.Text = dr["Ship_State"].ToString();
                Ship_Pincode.Text = dr["Ship_Pin_Cd"].ToString();
                Ship_GST_NUM.Text = dr["Ship_GST_NUM"].ToString();
                Ship_PAN.Text = dr["Ship_PAN"].ToString();
                Trans_Id.Text = dr["TRANS_ID"].ToString();
            }
        }
    }
}