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
    public partial class app_User_Master : BasePageClassMobile
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                DataTable dt = new DataTable();

                dt = MobileSales.LocationMaster(SiteSession.LoginUser.Multi_loc);
                Common.BindControldt(Location, dt, "Godw_Name", "Godw_Code", "Select");

            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            try
            {
                int EMpID = EmployeeName.SelectedValue.ConvertInt();
                // 

                var checkdata = Global.Context.ExecuteStoreQuery<checkholder>("select Count(*) as Keydata from user_tbl where user_name = '" + UserName.Text + "' and comp_Code = " + SiteSession.LoginUser.Comp_Code + "").FirstOrDefault().Keydata;
                if (checkdata == 0)
                {
                    using (TransactionScope trans = new TransactionScope())
                    {

                        var objemp = Global.Context.EmployeeMasters.SingleOrDefault(p => p.EmployeeId == EMpID);


                        var objuser = new User_Tbl();
                        objuser.MSPIN = objemp.MSPIN;
                        objuser.User_Name = UserName.Text;
                        objuser.User_Pwd = UserPassword.Text;
                        objuser.Module_Code = 3;
                        objuser.User_Color = "GAINSBORO";
                        objuser.Edit_Days = "365";
                        objuser.Export_Type = 1;
                        objuser.Comp_Code = SiteSession.LoginUser.Comp_Code;
                        objuser.Multi_loc = Location.SelectedValue;
                        objuser.User_mob = objemp.MobileNo;
                        objuser.UserEmail = objemp.EmailId;
                        objuser.RoleId = 5;
                        objuser.DatabaseIp = SiteSession.DatabaseIp;
                        objuser.DatabseUserName = SiteSession.DatabseUserName;
                        objuser.DatabasePassword = SiteSession.DatabasePassword;
                        objuser.DatabaseName = SiteSession.DatabaseName;
                        objuser.Save();
                        objemp.User_Code = objuser.User_Code;
                        objemp.Save();
                        trans.Complete();
                    }

                    Message.ShowMessage("Suc", "User Created Successfully!", SiteKey.MessageType.success);
                    UserName.Text = "";
                    UserPassword.Text = "";
                    EmployeeName.Items.Clear();
                    Location.SelectedIndex = 0;

                }
                else
                {
                    Message.ShowMessage("Suc", "User Already Exists!", SiteKey.MessageType.warning);
                    //Error User Already Exits 
                }


            }
            catch (Exception ex) { Message.ShowMessage("Suc", ex.Message, SiteKey.MessageType.danger); }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                DataTable dt = new DataTable();
                string LocationId = Location.SelectedValue;
                var emp = Global.Context.EmployeeMasters.AsEnumerable().Where(p => p.Location.Split(',').Contains(LocationId) && p.Comp_Code == SiteSession.Comp_MstSession.Comp_Code).ToList().Select(p => p.EmployeeId.ToString()).ToArray();
                dt = MobileSales.EmployeeFIllEMpIDWise(string.Join(",", emp.ToArray()));
                Common.BindControldt(EmployeeName, dt, "EmployeeName", "EmployeeId", "Select");
            }
            catch (Exception ex) { Message.ShowMessage("Suc", ex.Message, SiteKey.MessageType.danger); }
        }
    }
}



public class checkholder
{
    public int Keydata { get; set; }


}