using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
using Business;
namespace WebApp.mobile
{
    public partial class selectgodown : BasePageClassMobile
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Common.BindControl(GoDownId, SiteSession.GetGodawanListSession.ToList(), "Value", "Id", "All");
            }
        }

        protected void loginbtn_Click(object sender, EventArgs e)
        {
            if (GoDownId.SelectedValue.ConvertInt() > 0)
            {
                SiteSession.GodownId = GoDownId.SelectedValue.ConvertInt();
                //if(SiteSession.LoginUser.RoleId==2)
                //{
                //    Response.Redirect(String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]) ? "Admin_Dashbaord.aspx" : Request.QueryString["ReturnUrl"]);
                //}
                //if (SiteSession.LoginUser.RoleId == 5)
                //{
                //    Response.Redirect(String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]) ? "Finance_Dashbaord.aspx" : Request.QueryString["ReturnUrl"]);
                //}
                //if (SiteSession.LoginUser.RoleId == 6)
                //{
                //    Response.Redirect(String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]) ? "Exchange_Dashbaord.aspx" : Request.QueryString["ReturnUrl"]);
                //}
                if (SiteSession.DesignationId >= 18 && SiteSession.DesignationId <= 21)
                {
                    Response.Redirect(String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]) ? "Booking_Dashbaord.aspx" : Request.QueryString["ReturnUrl"]);
                }
                else if (SiteSession.DesignationId >= 22 && SiteSession.DesignationId <= 25)
                {
                    Response.Redirect(String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]) ? "Approver_Dashbaord.aspx" : Request.QueryString["ReturnUrl"]);
                }
                else
                {
                    Response.Redirect(String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]) ? "Admin_Dashbaord.aspx" : Request.QueryString["ReturnUrl"]);

                }

            }
        }
    }
}