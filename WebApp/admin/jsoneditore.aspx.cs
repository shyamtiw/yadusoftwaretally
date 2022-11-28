using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;

namespace WebApp.admin
{
    public partial class jsoneditore : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Val.Value = SiteSession.FilterKeyHolderResponce.Where(p => p.Key == Request.QueryString["id"].ToString()).FirstOrDefault().Value;
            }
        }
    }
}