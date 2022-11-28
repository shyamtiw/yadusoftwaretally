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
    public partial class app_Exchange_detail : BasePageClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataRow dr = SiteSession.SalesDataTable.Rows[0];
                Veh_Regn_No.Text = dr["Veh_Regn_No"].ToString();
                Veh_Chas_No.Text = dr["Veh_Chas_No"].ToString();
                Veh_Engn_No.Text = dr["Veh_Engn_No"].ToString();
                Exch_Type.Text = dr["Exch_Type"].ToString();
                Evaluator_Name.Text = dr["Evaluator_Name"].ToString();
                Model_Variant.Text = dr["Model_Variant"].ToString();
                MFG_Year.Text = dr["MFG_Year"].ToString();
                KMS_Run.Text = dr["KMS_Run"].ToString();
                Purc_Amt.Text = dr["Purc_Amt"].ToString();
                Exch_Offer.Text = dr["Exch_Offer"].ToString();
                Loan_Paid.Text = dr["Loan_Paid"].ToString();
                Insurance_3P.Text = dr["Insurance_3P"].ToString();
                Net_Amt.Text = dr["Net_Amt"].ToString();
                Prop_RF.Text = dr["Prop_RF"].ToString();
                Actual_RF.Text = dr["Actual_RF"].ToString();
                Remarks.Text = dr["Remarks"].ToString();
                Trans_Id.Text = dr["TRANS_ID"].ToString();
            }
        }
    }
}