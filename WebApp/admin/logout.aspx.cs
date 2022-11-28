using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
namespace WebApp.schooladmin
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteSession.IsLoggedIn = false;
       
            SiteSession.DateGet = Common.DateTimeNow();
            SiteSession.LoginUser = null;
            SiteSession.ParentMenu = null;
            SiteSession.ParentMenu = null;


            Response.Redirect("~/index.aspx", true);
        }
    }
}