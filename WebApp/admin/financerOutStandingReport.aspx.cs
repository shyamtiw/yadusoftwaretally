using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
using Business;
using System.Data;

namespace WebApp.admin
{
    public partial class financerOutStandingReport : BasePageClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int Id = Request.QueryString["Id"].ConvertInt();
                var Data= SiteSession.GroupMasterReport.Where(p => p.GroupMasterReportId == Id).FirstOrDefault();
                ReportName.Text = Data.ReportName;
                DataTable dt = ReportModal.FinancerOutstandingCS.SaleReportOutstandingData(SiteSession.LoginUser.Multi_loc, Data.GroupCode.Value);

                SiteSession.FinanceOutstandingSession = new DataTable();
                SiteSession.FinanceOutstandingSession = dt;

                Common.BindControl(Bank_Ledg_Name, dt.AsEnumerable().GroupBy(p => p["Bank_Ledg_Name"].ToString()).Select(p => new { p.Key }).ToList(), "Key", "Key", "Select");
                Common.BindControl(Branch_Name, dt.AsEnumerable().GroupBy(p => p["Branch_Name"].ToString()).Select(p => new { p.Key }).ToList(), "Key", "Key", "Select");
                Common.BindControl(Age_Bucket, dt.AsEnumerable().GroupBy(p => p["Age_Bucket"].ToString()).Select(p => new { p.Key }).ToList(), "Key", "Key", "Select");
                Common.BindControl(GroupName, dt.AsEnumerable().GroupBy(p => p["GroupName"].ToString()).Select(p => new { p.Key }).ToList(), "Key", "Key", "Select");
                Common.BindControldt(gvlocation, dt);
            }
        }

        protected void GetData_Click(object sender, EventArgs e)
        {
            string Filter = "";
            string Bank = Bank_Ledg_Name.SelectedValue != "Select" ? " Bank_Ledg_Name='" + Bank_Ledg_Name.SelectedValue + "'" : "";
            string Branch_Names = Branch_Name.SelectedValue != "Select" ? "Branch_Name='" + Branch_Name.SelectedValue + "'" : "";
            string Age_Buckets = Age_Bucket.SelectedValue != "Select" ? "Age_Bucket='" + Age_Bucket.SelectedValue + "'" : "";
            string GroupNames = GroupName.SelectedValue != "Select" ? "GroupName='" + GroupName.SelectedValue + "'" : "";
            Filter = Bank;



            if (Filter.Length > 0)
            {


                if (GroupNames.Length > 0)
                {
                    Filter = Filter + " and " + GroupNames;
                }
            }
            else
            {
                if (GroupNames.Length > 0)
                {
                    Filter = GroupNames;
                }
            }


            if (Filter.Length > 0)
            {


                if (Branch_Names.Length > 0)
                {
                    Filter = Filter + " and " + Branch_Names;
                }
            }
            else
            {
                if (Branch_Names.Length > 0)
                {
                    Filter = Branch_Names;
                }
            }



            if (Filter.Length > 0)
            {


                if (Branch_Names.Length > 0)
                {
                    Filter = Filter + " and " + Branch_Names;
                }
            }
            else
            {
                if (Branch_Names.Length > 0)
                {
                    Filter = Branch_Names;
                }
            }


            if (Filter.Length > 0)
            {
                if (Age_Buckets.Length > 0)
                {
                    Filter = Filter + " and " + Age_Buckets;
                }
            }
            else
            {
                if (Age_Buckets.Length > 0)
                {
                    Filter = Age_Buckets;
                }
            }



            var dv1 = new DataView();
            dv1 = SiteSession.FinanceOutstandingSession.DefaultView;
            dv1.RowFilter = Filter;
            DataTable FilterRow = new DataTable();
            FilterRow = dv1.ToTable();

            Common.BindControldt(gvlocation, FilterRow);
        }
    }
}