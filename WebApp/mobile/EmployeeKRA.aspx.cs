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
    public partial class EmployeeKRA : BasePageClassMobile
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                DataTable dt = new DataTable();

                dt = MobileSales.EmployeeKRA();
                Common.BindControldt(EmployeeKRA1, dt);
                
                string Jobtitle = dt.AsEnumerable().Max(p => (p["Jobtitle"].ToString()));
                string Reportto = dt.AsEnumerable().Max(p => (p["Reportto"].ToString()));
                string JobPurppose = dt.AsEnumerable().Max(p => (p["JobPurpose"].ToString()));

                jobpurpose.Text = JobPurppose.ToString();
                jobtitle.Text = Jobtitle.ToString();
                reportto.Text = Reportto.ToString();

            }
        }
      protected void Submits_Click(object sender, EventArgs e)
        {
            try
            {
            //    ConnModal.ExequteQuey("update bkg_mst set finc_name='" + FinancerName.SelectedValue + "' where trans_id='" + Request.QueryString["Sob_no"] + "' and loc_cd='" + Request.QueryString["Loc_Code"] + "'");
            }
            catch { }
        }
              protected void Deletes_Click(object sender, EventArgs e)
        {
            try
            {
                //    ConnModal.ExequteQuey("update bkg_mst set finc_name='" + FinancerName.SelectedValue + "' where trans_id='" + Request.QueryString["Sob_no"] + "' and loc_cd='" + Request.QueryString["Loc_Code"] + "'");
            }
            catch { }
        }
    }
}