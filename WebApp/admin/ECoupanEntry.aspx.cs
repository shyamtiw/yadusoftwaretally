using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
using Business;
namespace WebApp.admin
{
    public partial class ECoupanEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {


                
                if (Request.QueryString["ECoupanEntryId"].ConvertInt() > 0)
                {
                    int Id = Request.QueryString["ECoupanEntryId"].ConvertInt();
                    DefaultEntry(Id);

                }
                

            }
        }

        protected void savelocation_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["ECoupanEntryId"].ConvertInt() > 0)
                {

                    int Id = Request.QueryString["ECoupanEntryId"].ConvertInt();
                   
                    var obj = Global.Context.ECoupanEntries.SingleOrDefault(p => p.ECoupanEntryId == Id);
                    obj.CustomerName = CustomerNames.Text;
                    obj.CustomerMobileNo = CustomerMobileNo.Text;
                    obj.VehicleRegnNo = VehicleRegnNo.Text;
                    obj.EmailNos = EmailNos.Text;
                    obj.CompId = SiteSession.Comp_MstSession.Comp_Code.Value;
                    obj.GodwnId = SiteSession.GodownId;
                    obj.UserId = SiteSession.LoginUser.User_Code;

                    obj.Save();

                    Response.Redirect("E_IndusvalinsuranceList.aspx", false );
                }

                else

                {
                    
                    var obj = new Business.ECoupanEntry();

                    obj.CustomerName = CustomerNames.Text;
                    obj.CustomerMobileNo = CustomerMobileNo.Text;
                    obj.EmailNos = EmailNos.Text;
                    
                    obj.VehicleRegnNo = VehicleRegnNo.Text;
                    obj.CreateDate = Common.DateTimeNow().Date;
                    obj.CompId = SiteSession.Comp_MstSession.Comp_Code.Value;
                    obj.GodwnId = SiteSession.GodownId;
                    obj.UserId = SiteSession.LoginUser.User_Code;
                    
                    obj.Save();
                    CustomerNames.Text = "";
                    CustomerMobileNo.Text = "";
                    EmailNos.Text = "";
                    VehicleRegnNo.Text = "";
                    MessageBox.ShowMessage("Successfully", "Entry Successfully Save", SiteKey.MessageType.success);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.ShowMessage("Error", ex.Message, SiteKey.MessageType.danger);
                
            }
        }


        private void DefaultEntry(int GodownId)
        {




            var obj = Global.Context.ECoupanEntries.SingleOrDefault(p => p.ECoupanEntryId == GodownId);
            CustomerNames.Text = obj.CustomerName;
            CustomerMobileNo.Text = obj.CustomerMobileNo;
            VehicleRegnNo.Text = obj.VehicleRegnNo;
            EmailNos.Text = obj.EmailNos;
         

        }




    }
}