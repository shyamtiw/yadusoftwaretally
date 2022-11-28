using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.admin.ReportModal;
using WebApp.LIBS;

namespace WebApp.admin
{
    public partial class BankRecoReport : BasePageClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {



                    DataTable dt = FinancerOutstandingCS.BankrecoReport();



                    gvlocation.DataSource = dt;

                    gvlocation.DataBind();

                }
                catch { }
            }
        }
    }
}