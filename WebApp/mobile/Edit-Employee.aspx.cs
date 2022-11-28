using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
using Business;
using WebApp.LIBS.MobileAppCS;
using WebApp.admin.ReportModal;
using System.Transactions;
using System.Data;

namespace WebApp.mobile
{
    public partial class Edit_Employee : BasePageClassMobile
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (SiteSession.PendingBookingMSGCode == 1)
                {
                    Message.ShowMessage("Suc", "Employee Successfully Update!", SiteKey.MessageType.success);
                    SiteSession.PendingBookingMSGCode = 0;
                    Common.BindControl(Itemdata, SiteSession.EmployeeMasterSessionList.ToList());
                }
                Common.BindControldt(GodwnId, ConnModal.FillDataTable("SELECT Godw_Code,Godw_Name FROM Godown_Mst WHERE COMP_cODE=" + SiteSession.LoginUser.Comp_Code + " AND Godw_Code IN (" + SiteSession.LoginUser.Multi_loc + ")"), "Godw_Name", "Godw_Code", "Select");

            }

        }



        protected void btnGetBooking_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            string GoId = GodwnId.SelectedValue.ToString();

            var emp = Global.Context.EmployeeMasters.AsEnumerable().Where(p => p.Location.Split(',').Contains(GoId) && p.Comp_Code == SiteSession.Comp_MstSession.Comp_Code).ToList();
            SiteSession.EmployeeMasterSessionList = emp;

            Common.BindControl(Itemdata, emp.ToList());
        }

    }
}