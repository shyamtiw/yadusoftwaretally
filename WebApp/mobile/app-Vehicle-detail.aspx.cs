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
    public partial class app_Vehicle_detail : BasePageClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DataRow dr = SiteSession.SalesDataTable.Rows[0];
                Vehicle_Group.Text = dr["Vehicle_Group"].ToString();
                Variant_Code.Text = dr["Variant_Cd"].ToString();
                Variant_Name.Text = dr["Variant_Name"].ToString();
                Color_Code.Text = dr["EColor_CD"].ToString();
                Color_Name.Text = dr["Color_Name"].ToString();
                DMS_DSE.Text = dr["Executive"].ToString();
                DMS_TL.Text = dr["Team_Head"].ToString();
                Trans_Id.Text = dr["TRANS_ID"].ToString();
            }
        }
    }
}