using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
using Business;
using WebApp.LIBS.MobileAppCS;

namespace WebApp.mobile
{
    public partial class Salesdashboard : BasePageClassMobile
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var Loc_Code= string.Join(",", SiteSession.GetGodawanListSession.Select(x => x.Id.ToString()).ToArray());
                Common.BindControldt(LoopItem, MobileSales.SalesDiscountApprovalList(Loc_Code));
            }
        }
    }
}