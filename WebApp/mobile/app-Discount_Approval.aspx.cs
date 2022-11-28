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
using WebApp.admin.ReportModal;
using System.Transactions;

namespace WebApp.mobile
{
    public partial class app_Discount_Approval : BasePageClassMobile
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int[] MasterId = { 4, 5, 6, 7 };

                var MasterData = Global.Context.Masters.AsEnumerable().Where(p => MasterId.Contains(p.MasterParentId.Value)).ToList();

                try
                {
                    DataRow dr = SiteSession.SalesDataTable.Rows[0];
                    Trans_Id.Text = dr["TRANS_ID"].ToString();

                    if (dr["BookingApprovalHistoryId"].ToString().ConvertInt() > 0)
                    {
                        Response.Redirect("app-Discount_Approver.aspx", false);
                    }
                }
                catch
                {
                    DataTable dt = new DataTable();
                    int[] des = SiteKey.ReportingManagerDSE.Split(',').Select(p => Convert.ToInt32(p)).ToArray();

                    var emp = Global.Context.EmployeeMasters.AsEnumerable().Where(p => des.Contains(p.Designation.Value) && p.Location.Split(',').Contains(SiteSession.GodownId.ToString()) && p.Comp_Code == SiteSession.Comp_MstSession.Comp_Code).ToList().Select(p => p.EmployeeId.ToString()).ToArray();
                    dt = MobileSales.FillReportigManager(string.Join(",", emp));
                    //dt = MobileSales.FillReportigManager(SiteKey.ReportingManagerDSE);
                    Common.BindControldt(EmployeeName, dt, "EmployeeName", "EmployeeId", "Select");
                }

                try
                {
                    DataRow dr = SiteSession.SalesDataTable.Rows[0];
                    try
                    {
                        Insu_Typex.Text = MasterData.Where(p => p.MasterId == Common.ConvertInt(dr["Insu_Type"])).FirstOrDefault().Name;
                    }
                    catch { }

                    Insu_Amt.Text = dr["Insu_Amt"].TrimEndZero();
                    try
                    {
                        EW_Type.Text = MasterData.Where(p => p.MasterId == Common.ConvertInt(dr["EW_Type"])).FirstOrDefault().Name;
                    }
                    catch { }
                    EW_Amt.Text = dr["EW_Amt"].TrimEndZero();
                    try
                    {
                        RTO_Type.Text = MasterData.Where(p => p.MasterId == Common.ConvertInt(dr["RTO_Type"])).FirstOrDefault().Name;
                    }
                    catch { }

                    RTO_Amt.Text = (Common.ConvertDecimal(dr["RTO_Amt"]) + Common.ConvertDecimal(dr["Trc_Amt"])).TrimEndZero();
             
                    MSGA_AMT.Text = dr["MSGA_AMT"].TrimEndZero();

                    MSR_AMT.Text = dr["MSR_AMT"].TrimEndZero();

                    FasTag_Amt.Text = dr["FasTag_Amt"].TrimEndZero();
                    Trans_Id.Text = dr["TRANS_ID"].ToString();


                }
                catch { }


              
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            try
            {


                DataRow dr = SiteSession.SalesDataTable.Rows[0];
                var checkdata = Global.Context.ExecuteStoreQuery<checkholder>("select COUNT(*) as [Keydata]  from  BookingApprovalHistory where  BookingId="+ dr["BookingId"].ToString() + " and Status<>3").FirstOrDefault().Keydata;
                if (checkdata > 0)
                {
                    Message.ShowMessage("Suc", "Pending Request Already Exist!", SiteKey.MessageType.warning);
                }
                else
                {

                    using (TransactionScope trans = new TransactionScope())
                    {


                        var objemp = new BookingApprovalHistory();


                        var objuser = new BookingApprovalHistory();
                        objuser.Date = Common.DateTimeNow();
                        objuser.BookingId = dr["BookingId"].ToString().ConvertInt();
                        objuser.RequestAmount = Requestamt.Text.ConvertDecimal();
                        objuser.Remark = RequestRemark.Text;
                        objuser.User_Code = SiteSession.LoginUser.User_Code;
                        objuser.RequestSendTo = EmployeeName.SelectedValue.ConvertInt();
                        objuser.Status = (int)SiteKey.BookingStatus.Recommed;
                        objuser.Save();

                        var objlog = new BookingLog();
                        objlog.Date = Common.DateTimeNow();
                        objlog.Remark = RequestRemark.Text;
                        objlog.Status = (int)SiteKey.BookingStatus.Recommed; ;
                        objlog.BookingApprovalHistoryId = objuser.BookingApprovalHistoryId;
                        objlog.UserCode = SiteSession.LoginUser.User_Code;
                        objlog.Amount = Requestamt.Text.ConvertDecimal();
                        objlog.Save();
                        trans.Complete();

                    }
                    try
                    {
                        var DeviceId = Business.UserLogin.GetUserDeviceId(EmployeeName.SelectedValue.ConvertInt());
                        if (!string.IsNullOrWhiteSpace(DeviceId))
                        {
                            string EmpName = SiteSession.EmployeeMaster.EmployeeName + "(" + SiteSession.EmployeeMaster.Master.Name + ")";


                            SMZP.SendNotification("Discount Request", "Request by " + EmpName, (new string[] { DeviceId }));
                        }
                    }
                    catch { }


                    SiteSession.PendingBookingMSGCode = 1;
                    Response.Redirect("Pending_Booking.aspx",false);
                    
                    Requestamt.Text = "";
                    RequestRemark.Text = "";
                    EmployeeName.SelectedIndex = 0;
                }
            }
            catch (Exception ex) { Message.ShowMessage("Suc", ex.Message, SiteKey.MessageType.danger); }

        }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

          

        }
    }
}


