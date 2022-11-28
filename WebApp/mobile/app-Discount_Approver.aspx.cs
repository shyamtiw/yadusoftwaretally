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
    public partial class app_Discount_Approver : BasePageClassMobile
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                int[] MasterId = { 4, 5, 6, 7 };

                var MasterData = Global.Context.Masters.AsEnumerable().Where(p => MasterId.Contains(p.MasterParentId.Value)).ToList();


                DataTable dt = new DataTable();
                string Desingation = "";
                var Designationid = Global.Context.EmployeeMasters.Where(p => p.User_Code == SiteSession.LoginUser.User_Code).FirstOrDefault().Designation;

                if (Designationid == 22)
                {
                    Desingation = SiteKey.ReportingManagerSM;
                }
                else if (Designationid == 23)
                {
                    Desingation = SiteKey.ReportingManagerGM;
                }
                else if (Designationid == 24)
                {
                    Desingation = SiteKey.ReportingManagerCEO;
                }



                if (Designationid == 25)
                {
                    RequestStatus.Items.Clear();
                    ListItem one = new ListItem("Reject", "3");
                    ListItem two = new ListItem("Approve", "3");
                    RequestStatus.Items.Add(one);
                    RequestStatus.Items.Add(two);
                }
                DataRow dr = SiteSession.SalesDataTable.Rows[0];

                Trans_Id.Text = dr["TRANS_ID"].ToString();
                Requestamt.Text = dr["RequestAmount1"].ToString();
                RequestRemark.Text = dr["Remark"].ToString();
                try
                {
                    RequestStatus.SelectedValue = dr["Status1"].ToString();
                }

                catch { }

                int[] des = Desingation.Split(',').Select(p => Convert.ToInt32(p)).ToArray();

                var emp = Global.Context.EmployeeMasters.AsEnumerable().Where(p => des.Contains(p.Designation.Value) && p.Location.Split(',').Contains(SiteSession.GodownId.ToString()) && p.Comp_Code == SiteSession.Comp_MstSession.Comp_Code).ToList().Select(p => p.EmployeeId.ToString()).ToArray();
                dt = MobileSales.FillReportigManager(string.Join(",", emp));
                Common.BindControldt(EmployeeName, dt, "EmployeeName", "EmployeeId", "Select");

                try
                {
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
                var checkdata = Global.Context.ExecuteStoreQuery<checkholder>("select COUNT(*) as [Keydata]  from  BookingApprovalHistory where  BookingApprovalHistoryId=" + dr["BookingApprovalHistoryId"].ToString() + " and Status<>3 and User_Code="+SiteSession.LoginUser.User_Code+"").FirstOrDefault().Keydata;
                //if (checkdata > 0)
                //{
                //    Message.ShowMessage("Suc", "Pending Request Already Exist!", SiteKey.MessageType.success);
                //}
                //else
                {

                    using (TransactionScope trans = new TransactionScope())
                    {



                        int Id = Convert.ToInt32(dr["BookingApprovalHistoryId"]);
                        var objuser = Global.Context.BookingApprovalHistories.SingleOrDefault(p => p.BookingApprovalHistoryId == Id);
                        objuser.Date = Common.DateTimeNow();

                        objuser.RequestAmount = Requestamt.Text.ConvertDecimal();
                        objuser.Remark = RequestRemark.Text;
                       
                            objuser.User_Code = SiteSession.LoginUser.User_Code;

                            objuser.RequestSendTo = EmployeeName.SelectedValue.ConvertInt();
                        
                        
                        objuser.Status = RequestStatus.SelectedValue.ConvertInt();
                        objuser.Save();


                     
                        if (RequestStatus.SelectedValue.ConvertInt() == 3 || RequestStatus.SelectedValue.ConvertInt() == 4)
                        {
                            int BookingId = Convert.ToInt32(dr["BookingId"]);
                            var objBooking = Global.Context.Bookings.SingleOrDefault(p => p.BookingId == BookingId);
                            objBooking.Additional_Discount = RequestStatus.SelectedValue.ConvertInt() == 4 ? objuser.RequestAmount.Value : 0;
                            objBooking.Save();

                        }


                        var objlog = new BookingLog();
                        objlog.Date = Common.DateTimeNow();
                        objlog.Remark = RequestRemark.Text;
                        objlog.Status = RequestStatus.SelectedValue.ConvertInt();
                        objlog.BookingApprovalHistoryId = objuser.BookingApprovalHistoryId;
                        objlog.UserCode = SiteSession.LoginUser.User_Code;
                        objlog.Amount = Requestamt.Text.ConvertDecimal();
                        objlog.Save();
                        trans.Complete();


                        try
                        {
                            if (RequestStatus.SelectedValue.ConvertInt() == 3 || RequestStatus.SelectedValue.ConvertInt() == 4)
                            {
                                int[]  objUserDeviceId = Global.Context.BookingLogs.Where(p => p.BookingApprovalHistoryId == objuser.BookingApprovalHistoryId && p.UserCode != objlog.UserCode).Select(p => p.UserCode.Value).ToArray();
                                var DeviceId = Business.UserLogin.GetUserDeviceIdMultipal(objUserDeviceId);
                                if ((DeviceId).Count()>0)
                                {
                                    string EmpName = SiteSession.EmployeeMaster.EmployeeName + "(" + SiteSession.EmployeeMaster.Master.Name + ")";

                                    var Status = RequestStatus.SelectedValue.ConvertInt() == 3 ? "Reject" : "Approve";
                                    SMZP.SendNotification("Discount Request", Status + " by " + EmpName, DeviceId);
                                }
                            }
                            else
                            {

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

                            }
                        }
                        catch { }

                    }


                    SiteSession.PendingBookingMSGCode = RequestStatus.SelectedValue.ConvertInt();
                        SiteSession.PendingBookingMSG = "Discount " + RequestStatus.SelectedItem.Text;
                    

                    Response.Redirect("Pending_Booking_Approval.aspx", false);


                    
                }
            }
            catch (Exception ex) { Message.ShowMessage("Suc", ex.Message, SiteKey.MessageType.danger); }

        }

           protected void RequestStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RequestStatus.SelectedValue.ConvertInt() == 3)
            {
                EmployeeName.Enabled = false;
                RequestRemark.Enabled = true;

            }
            else if (RequestStatus.SelectedValue.ConvertInt() == 4)
            {
                EmployeeName.Enabled = false;
            }
            else
            {
                EmployeeName.Enabled = true;
                RequestRemark.Enabled = true;
            }

        }
    }
}


