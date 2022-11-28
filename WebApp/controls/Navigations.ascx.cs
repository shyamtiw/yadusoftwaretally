using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using WebApp.LIBS;
using System.Data;


namespace WebApp.controls
{
    public partial class Navigations : System.Web.UI.UserControl
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Common.BindControl(rptParentMenu, SiteSession.ParentMenu.ToList());
                Common.BindControl(alonemenu, Global.Context.SubMenuAlone(SiteSession.LoginUser.User_Code).ToList());
            }
        }

        protected void rptParentMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Business.ParentMenu_Result item = (Business.ParentMenu_Result)e.Item.DataItem;
                Repeater rptSubMenu = (Repeater)e.Item.FindControl("rptSubMenu");

              
                    Common.BindControl(rptSubMenu, SiteSession.SubMenu.Where(x => x.ParentId == item.MenuId).ToList());

              
            }
        }

    }
}