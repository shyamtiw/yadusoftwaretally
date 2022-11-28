using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
using Business;
using WebApp.admin.ReportModal;

namespace WebApp.admin.Reports
{
    public partial class OutstandingRemark : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Common.BindControldt(gvlocation, ReportModal.SalesReportModal.SaleReportOutstandingData(SiteSession.LoginUser.Multi_loc));
            }
        }
    }
}