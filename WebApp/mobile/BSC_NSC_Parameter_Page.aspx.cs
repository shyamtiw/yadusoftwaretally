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
    public partial class BSC_NSC_Parameter_Page : BasePageClassMobile
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var Module = Request.QueryString["Module"].ToString();
                var Parameter= Request.QueryString["Parameter"].ToString();
                Common.BindControldt(BSCItem, MobileSales.BSCParameter(Module, Parameter));
            }
        }
    }
}