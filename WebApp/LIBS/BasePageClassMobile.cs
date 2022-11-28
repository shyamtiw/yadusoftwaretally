using Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using WebApp.LIBS;

namespace WebApp.LIBS
{
    public class BasePageClassMobile : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            string pagename = e.ToString();

            if (!SiteSession.IsLoggedInMobile)
            {
                if (Request.RawUrl.Contains("mobile"))
                {
                    Response.Redirect("~/mobile/index.aspx?ReturnUrl=" + Request.RawUrl, true);
                }
            }
        }
    }
}

