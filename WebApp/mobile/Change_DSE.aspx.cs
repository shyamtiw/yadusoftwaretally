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

namespace WebApp.mobile
{
    public partial class Change_DSE : BasePageClassMobile
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (SiteSession.PendingBookingMSGCode  > 0)
                {
                    SiteSession.PendingBookingMSGCode = 0;
                    Message.ShowMessage("Suc", "Request Send for Approval!", SiteKey.MessageType.success);
                }
                Common.BindControldt(GodwnId, ConnModal.FillDataTable("SELECT Godw_Code,Godw_Name FROM Godown_Mst WHERE COMP_cODE="+SiteSession.LoginUser.Comp_Code+" AND Godw_Code IN ("+SiteSession.LoginUser.Multi_loc+")"),"Godw_Name", "Godw_Code","Select");
            }

        }

        protected void GodwnId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GodwnId.SelectedValue != "Select")
            {
                Common.BindControldt(ddldscbookingdata, ConnModal.FillDataTable("select distinct  ExEcutive  from Booking WHERE GE3='bOOKED' AND  Godw_Code=" + GodwnId.SelectedValue + " AND BookingId NOT IN (sELECT BOOKINGID FROM BookingApprovalHistory)"), "ExEcutive", "ExEcutive", "Select");
                Common.BindControldt(ChangeGodwnDSCID, ConnModal.FillDataTable("SELECT (MSPIN+' - '+EmployeeName) as Executive,Location FROM EmployeeMaster WHERE  [Location]='"+ GodwnId.SelectedValue + "'  and Comp_Code="+SiteSession.LoginUser.Comp_Code+" and Designation in (18,19,20)"), "ExEcutive", "ExEcutive", "Select");
            }
            else {
                GodwnId.Items.Clear();
            }

            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#GetBookingData').modal('show')", true);
        }

        protected void btnGetBooking_Click(object sender, EventArgs e)
        {
            Common.BindControldt(Itemdata, ConnModal.FillDataTable("select BookingId, Cust_name+' (' + Trans_id + ')' as Cust_Detail,Trans_id,Trans_Date,Variant_Name,Color_Name,GE1  from Booking WHERE GE3 = 'bOOKED' AND Godw_Code = " + GodwnId.SelectedValue+" AND BookingId NOT IN(sELECT BOOKINGID FROM BookingApprovalHistory) and EXECUTIVE like '%"+ddldscbookingdata.SelectedValue+"%'"));
        }

       
        protected void btnchangedsc_Click(object sender, EventArgs e)
        {
            try
            {
              
                    string strBookingId = "";
                    foreach (RepeaterItem item in Itemdata.Items)
                    {
                        CheckBox chk = (CheckBox)item.FindControl("chk");

                        if (chk != null)
                        {
                            if (chk.Checked)
                            {
                                HiddenField BookingId = (HiddenField)item.FindControl("BookingId");
                                strBookingId = strBookingId.Length > 0 ? strBookingId + "," + BookingId.Value.ToString() : BookingId.Value.ToString();
                            }
                        }
                    }
                using (TransactionScope trans = new TransactionScope())
                {
                    if (strBookingId.Length > 0)
                    {
                        ConnModal.ExequteQuey("update Booking set EXECUTIVE='" + ChangeGodwnDSCID.SelectedValue + "' where Bookingid in (" + strBookingId + ")");
                    }
                    trans.Complete();
                }
                Common.BindControldt(Itemdata, ConnModal.FillDataTable("select BookingId, Cust_name+' (' + Trans_id + ')' as Cust_Detail,Trans_id,Trans_Date,Variant_Name,Color_Name,GE1  from Booking WHERE GE3 = 'bOOKED' AND Godw_Code = " + GodwnId.SelectedValue + " AND BookingId NOT IN(sELECT BOOKINGID FROM BookingApprovalHistory) and EXECUTIVE like '%" + ddldscbookingdata.SelectedValue + "%'"));
                Message.ShowMessage("Suc", "Data successfully submit", SiteKey.MessageType.success);
            }
            catch (Exception ex) { Message.ShowMessage("Suc", ex.Message, SiteKey.MessageType.danger); }
        }
    }
}