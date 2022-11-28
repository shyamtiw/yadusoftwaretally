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
    public partial class MSIL_Statement_Summary : BasePageClassMobile
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                DataTable dt = new DataTable();

                if (!string.IsNullOrWhiteSpace(Request.QueryString["Account"]))
                {
                    dt = MobileSales.MarutiStatement((Request.QueryString["Type"].ToString()),(Request.QueryString["Account"].ToString()), SiteSession.LoginUser.Comp_Code.ToString());

                }
                else if (!string.IsNullOrWhiteSpace(Request.QueryString["Type"]))
                {
                    dt = MobileSales.MarutiStatement((Request.QueryString["Type"].ToString()),null, SiteSession.LoginUser.Comp_Code.ToString());
                }
                else
                {
                    dt = MobileSales.MarutiStatement(null,null, SiteSession.LoginUser.Comp_Code.ToString());
                }
                Common.BindControldt(MSIL_Statement_Data, dt);


                DataTable dt1 = new DataTable();
                dt1 = MobileSales.MarutiStatementType(SiteSession.LoginUser.Comp_Code.ToString());
                Common.BindControldt(Repeater3, dt1);


                DataTable dt2 = new DataTable();
                if (!string.IsNullOrWhiteSpace(Request.QueryString["Type"]))
                {
                    dt2 = MobileSales.MarutiStatementAccount((Request.QueryString["Type"].ToString()), SiteSession.LoginUser.Comp_Code.ToString());
                }
                else
                {
                    dt2 = MobileSales.MarutiStatementAccount(null, SiteSession.LoginUser.Comp_Code.ToString());
                }
                    Common.BindControldt(Repeater1, dt2);

            }
        }
    }
}