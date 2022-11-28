using System;
using System.Data;
using WebApp.LIBS;
using WebApp.LIBS.MobileAppCS;

namespace WebApp.mobile
{
    public partial class MSIL_Statement_Detail : BasePageClassMobile
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                DataTable dt = new DataTable();

                if (!string.IsNullOrWhiteSpace(Request.QueryString["TranType"]))
                {
                    dt = MobileSales.MarutiStatementDetail((Request.QueryString["Type"].ToString()), (Request.QueryString["DealerCode"].ToString()), (Request.QueryString["Account"].ToString()), (Request.QueryString["TranType"].ToString()), SiteSession.LoginUser.Comp_Code.ToString());
                }
                else if (!string.IsNullOrWhiteSpace(Request.QueryString["Account"]))
                {
                    dt = MobileSales.MarutiStatementDetail((Request.QueryString["Type"].ToString()), (Request.QueryString["DealerCode"].ToString()),(Request.QueryString["Account"].ToString()),null, SiteSession.LoginUser.Comp_Code.ToString());
                }
                else
                {
                    dt = MobileSales.MarutiStatementDetail(null,null,null, SiteSession.LoginUser.Comp_Code.ToString());
                }
                Common.BindControldt(MSIL_Statement_Detail1, dt);

                DataTable dt1 = new DataTable();
                dt1 = MobileSales.MarutiStatementTranType(SiteSession.LoginUser.Comp_Code.ToString());
                Common.BindControldt(Repeater3, dt1);
            }

        }
    }
}