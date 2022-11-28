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
using WebApp.admin.ReportModal;

namespace WebApp.mobile
{
    public partial class app_Financer_detail : BasePageClassMobile
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                DataTable dt = new DataTable();

                dt = MobileSales.BankFinancerMaster();
                Common.BindControldt(FinancerName, dt, "Misc_Name", "Misc_Code", "Select");

                Financer_Name.Text = "";
                Financer_Branch.Text = "";
                Loan_Type.Text = "";
                Finance_Do_Number.Text = "";
                Finance_DO_Amount.Text = "";
                Finance_PF_Charges.Text = "";
                PO_Number.Text = "";
                PO_Date.Text = "";
                PO_AMT.Text = "";

                DataRow dr = SiteSession.SalesDataTable.Rows[0];
                Trans_Id.Text = dr["TRANS_ID"].ToString();

            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {

            Financer_Branch.Text = "";
        }

        protected void Submits_Click(object sender, EventArgs e)
        {
            try
            {
                ConnModal.ExequteQuey("update bkg_mst set Payment_Mode='"+ BranchName.Text + "', Payment_for='"+ LoanType.SelectedValue + "', finc_name='" + FinancerName.SelectedValue + "' where trans_id='" + Request.QueryString["Sob_no"] + "' and loc_cd='" + Request.QueryString["Loc_Code"] + "'");
            }
            catch { }
        }
    }
}