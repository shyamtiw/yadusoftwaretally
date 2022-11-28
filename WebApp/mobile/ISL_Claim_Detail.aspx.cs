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
    public partial class ISL_Claim_Detail : BasePageClassMobile
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                DataTable DealerData = new DataTable();
                DataTable dt = new DataTable();
                dt = MobileSales.ISLRMK_Detail();
                Common.BindControldt(ISLRMK_Claim_Detail, dt);

            }
        }
    }
}