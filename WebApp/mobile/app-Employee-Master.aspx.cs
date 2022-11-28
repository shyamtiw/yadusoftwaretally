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

namespace WebApp.mobile
{
    public partial class app_Employee_Master : BasePageClassMobile
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                DataTable dt = new DataTable();

                dt = MobileSales.LocationMaster(SiteSession.LoginUser.Multi_loc);
                Common.BindControldt(Location, dt, "Godw_Name", "Godw_Code", "Select");

                dt = MobileSales.DesignationMaster();
                Common.BindControldt(Designation, dt, "Name", "MasterId", "Select");
                if (Request.QueryString["EmployeeId"].ConvertInt() >0)
                {
                    UpdateFillData(Request.QueryString["EmployeeId"].ConvertInt());
                }
                

            }
        }


        private void UpdateFillData(int Id)
        {

            var objEmp = Global.Context.EmployeeMasters.SingleOrDefault(p => p.EmployeeId == Id);

            EmployeeCode.Text = objEmp.EmployeeCode;
            Designation.SelectedValue = objEmp.Designation.Value.ToString();
            Employeename.Text = objEmp.EmployeeName;
            Location.SelectedValue = objEmp.Location.ToString();
            MobileNo.Text = objEmp.MobileNo;
            MSPIN.Text = objEmp.MSPIN;
            Emailid.Text = objEmp.EmailId;
            IsOtpEnabled.Checked = objEmp.OtpEnable.Value;


            EmployeeCode.Enabled = false;
            Designation.Enabled = false;
            Location.Enabled = false;
            Employeename.Enabled = false;
            



        }

        protected void submit_Click(object sender, EventArgs e)
        {
            try
            {

                if (Request.QueryString["EmployeeId"].ConvertInt() > 0)
                {
                    ConnModal.ExequteQuey("update EmployeeMaster set MSPIN ='" + MSPIN.Text + "', Mobileno = '" + MobileNo.Text + "', Emailid = '" + Emailid.Text + "' where Employeeid = " + Request.QueryString["EmployeeId"].ToString() + "");
                    SiteSession.PendingBookingMSGCode = 1;
                    Response.Redirect("Edit-Employee.aspx", false);

                }
                else
                {
                    DataTable dt = new DataTable();
                    dt = MobileSales.CheckEmployee(EmployeeCode.Text, MSPIN.Text, MobileNo.Text, Emailid.Text);

                    if (dt.Rows.Count == 0)
                    {

                        ConnModal.ExequteQuey("insert into EmployeeMaster (EmployeeCode,Employeename,Designation,Location,MSPIN,Mobileno,Emailid,Reporting1,OtpEnable,Comp_Code) values('" + EmployeeCode.Text + "', '" + Employeename.Text + "', " + Designation.SelectedValue + ", '" + Location.SelectedValue + "', '" + MSPIN.Text + "', '" + MobileNo.Text + "', '" + Emailid.Text + "', '" + Reporting1.Text + "'," + (IsOtpEnabled.Checked ? "1" : "0") + "," + SiteSession.LoginUser.Comp_Code + ")");
                        
                        Message.ShowMessage("Suc", "Employee Created Successfully!", SiteKey.MessageType.success);
                    }
                    else
                    {
                        var msg = dt.Rows[0][0].ToString();
                      
                        Message.ShowMessage("Suc", msg + " Already Exist! ", SiteKey.MessageType.warning);

                    }
                }
            }
            catch (Exception ex) { Message.ShowMessage("Suc", ex.Message, SiteKey.MessageType.danger); }
        }

    }
}