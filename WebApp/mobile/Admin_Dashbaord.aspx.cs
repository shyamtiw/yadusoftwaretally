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
using System.IO;
using ClosedXML.Excel;

namespace WebApp.mobile
{
    public partial class Admin_Dashbaord : BasePageClassMobile
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();

               // Booking_Transport_Data.Transport_Data();

               

                username.Text = SiteSession.LoginUser.User_Name;
                Email.Text = SiteSession.LoginUser.UserEmail;
                MSPIN.Text = SiteSession.LoginUser.MSPIN;

    
            



            }

        }


        protected void ExportData_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = ConnModal.FillDataTable("select Godw_Name,PARENT_GROUP,DEALER_MAP_CD,TRANS_TYPE,TRANS_DATE,TRANS_ID,TRANS_REF_NUM,TRANS_REF_DATE,Variant_Name,Color_Name,GST_NO,CUST_NAME,isnull(EXECUTIVE,'') as EXECUTIVE,isnull(TEAM_HEAD,'') as TEAM_HEAD,ISNULL( GE1,'')  as FuelType,GE3 as BookingStatus, isnull((select Name from Master  where Master.MasterId=Insu_Type),'') as Insurance_Type,isnull(Insu_amt,0) as InsuranceAmount,isnull((select Name from Master  where Master.MasterId=EW_Type),'') as EW_Type,isnull(EW_amt,0) as EW_Amount,isnull((select Name from Master  where Master.MasterId=RTO_Type),'') as RTO_Type,isnull(RTO_amt,0) as RTO_Amount,isnull(MSGA_amt,0) as MSGA_Amount,isnull((select Name from Master  where Master.MasterId=MSR_Type),'') as MSR_Type,isnull((select Name from Master  where Master.MasterId=FASTAG_Type),'') as FASTAG_Type,isnull(FASTAG_amt,0) as FASTAG_Amount,isnull(NonMGA_AMT,0) as NonMGA_AMT,isnull(ON_Road_Price,0) as ON_Road_Price,isnull(MSR_AMT,0) as MSR_AMT,isnull(MSD_Discount,0) as MSD_Discount,isnull(Buffer_Discount,0) as Buffer_Discount,isnull(RIPS_Support1,0) as RIPS_Support1,isnull(RIPS_Support2,0) as RIPS_Support2,isnull(RIPS_Support3,0) as RIPS_Support3,isnull(Additional_Discount,0) as Additional_Discount,isnull(Trc_Amt,0) as TRC_Amount,isnull( (select Name from Master  where Master.MasterId=Insu_CompName),'') as Insurance_CompnayName,isnull( (select top 1 EmployeeName from EmployeeMaster where EmployeeMaster.User_Code=BookingApprovalHistory.User_Code),'') as LastStatusUpdateUser, case when BookingApprovalHistory.[Status]=2 then 'Send For Recommendation' when BookingApprovalHistory.[Status]=4 then 'Discount Approved' when BookingApprovalHistory.[Status]=3 then 'Discount Rejected' else 'Pending' end   as LastStatus,isnull(BookingApprovalHistory.Remark,'') as LastRemark,case when [Date] is null then '' else  CONVERT(varchar,BookingApprovalHistory.[Date],103)+' '+CONVERT(varchar,BookingApprovalHistory.[Date],114)  end as LastUpdateDate,isnull((select top 1 EmployeeName from EmployeeMaster where EmployeeMaster.User_Code=BookingApprovalHistory.RequestSendTo),'') as LastRequestSendTo,isnull(BookingApprovalHistory.RequestAmount,0) as LastRequestAmount from (select * from Booking where comp_code=" + SiteSession.LoginUser.Comp_Code + " and Godw_Code in (" + SiteSession.LoginUser.Multi_loc + ")) as Booking left join (select NEWCAR_RCPT,Godw_Name from  Godown_Mst)  as  g on Booking.LOC_CD=g.NEWCAR_RCPT left join BookingApprovalHistory on  Booking.BookingId=BookingApprovalHistory.BookingId ");
                ExportExcel(dt);
            }
            catch { }
        }

        private void ExportExcel(DataTable dt)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Data");


                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=BookingData.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }
    }
}