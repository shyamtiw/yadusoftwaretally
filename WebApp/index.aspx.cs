using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
using System.Text.RegularExpressions;
using Business;
using System.IO;
using SelectPdf;
using System.Configuration;
using System.Threading;
using System.Net.Mail;
using WebApp.admin.ReportModal;
using WebApp.TallyData;

namespace WebApp
{
    public partial class index : System.Web.UI.Page
    {

        public static bool SendEmail = false;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                //DataMangementJsonTwoData.GetDGetData((new DateTime(2021,9,1)),new DateTime(2021, 9, 30),9);

                //Response.Redirect("mobile/", false);

            }

            //try
            //{

            //    MailMessage message = new MailMessage();
            //    message.From = new MailAddress("info@Autovyn.in");

            //    message.To.Add(new MailAddress("narendra.singh439@gmail.com"));

            //    message.Subject = "your subject";
            //    message.Body = "content of your email";

            //    SmtpClient client = new SmtpClient();
            //    client.Send(message);
            //}
            //catch(Exception ex) { }

        }

        protected void login_Click(object sender, EventArgs e)
        {

            var GetDeviceId = !string.IsNullOrWhiteSpace(Request.QueryString["DeviceId"]) ? Business.UserLogin.GetUserIsDeviceId(Request.QueryString["DeviceId"]) : null;


            if (GetDeviceId != null)
            {

                DeviceLogin(GetDeviceId);
            }
            else
            {
                var objUser = Business.UserLogin.GetUser(Email.Text, Password.Text);
                if (objUser != null)
                {

                    try
                    {
                        string DeviceId = "";
                        string MobileName = "";

                        if (!string.IsNullOrWhiteSpace(Request.QueryString["DeviceId"]))
                        {
                            DeviceId = Request.QueryString["DeviceId"].ToString();
                        }
                        if (!string.IsNullOrWhiteSpace(Request.QueryString["MobileName"]))
                        {
                            MobileName = Request.QueryString["MobileName"].ToString();
                        }
                        var objdata = Global.Context.User_Tbl.SingleOrDefault(p => p.User_Code == objUser.User_Code);
                        objdata.DeviceId = DeviceId;
                        objdata.MobileName = MobileName;
                        objdata.Save();
                    }
                    catch { }


                    SiteSession.IsLoggedIn = true;
                    SiteSession.LoginUser = objUser;


                    SiteSession.FilterKeyHolder = new List<FilterKeyHolder>();
                    SiteSession.GroupMasterReport = Global.Context.GroupMasterReports.AsEnumerable().ToList();
                    try
                    {
                        SiteSession.AllotOption = new List<AllotOption>();
                        SiteSession.AllotOption = Business.Global.Context.AllotOptions.Where(parameters => parameters.UserId == objUser.User_Code).ToList();
                    }
                    catch { }
                    SiteSession.ParentMenu = Business.Global.Context.ParentMenu(objUser.User_Code).ToList();
                    SiteSession.SubMenu = Business.Global.Context.SubMenu(objUser.User_Code).ToList();
                    SiteSession.StringUserName = objUser.User_Name;
                    SiteSession.Comp_MstSession = Global.Context.Comp_Mst.Where(parameters => parameters.Comp_Code == objUser.Comp_Code.Value).FirstOrDefault();
                    SiteSession.GetGodawanListSession = Business.UserLogin.GetGodawanList(objUser.Multi_loc, objUser.Comp_Code.Value);
                    if (!string.IsNullOrWhiteSpace(objUser.DatabaseIp))
                    {
                        SiteSession.DatabaseIp = objUser.DatabaseIp;
                        SiteSession.DatabseUserName = objUser.DatabseUserName;
                        SiteSession.DatabasePassword = objUser.DatabasePassword;
                        SiteSession.DatabaseName = objUser.DatabaseName;
                    }

                    try
                    {

                        string ConStr = "Data Source=" + SiteSession.DatabaseIp + ";Initial Catalog=" + SiteSession.DatabaseName + ";persist security info=True;user id=" + SiteSession.DatabseUserName + ";password=" + SiteSession.DatabasePassword + ";multipleactiveresultsets=True;Timeout=60";
                        Thread ThFinanceFillData = new Thread(() => FillfinaceData(ConStr));
                        ThFinanceFillData.IsBackground = true;
                        ThFinanceFillData.Start();


                    }
                    catch { }

                    if (objUser.RoleId != 1)
                    {







                        if (!string.IsNullOrWhiteSpace(objUser.User_mob))
                        {
                            string OTP = Common.Otp();
                            SiteSession.OTP = OTP;
                            try
                            {




                                //string BodyCondande = Global.Context.Teplates.Where(parameters => parameters.TeplateId == 1).FirstOrDefault().Template.Replace("{OTP}", SiteSession.OTP);
                                SMZP.PlatinumMotocorpLLPSMS(SiteSession.Comp_MstSession.OTPTemplate.Replace("{User_Name}", objUser.User_Name).Replace("{OTP}", OTP), objUser.User_mob);

                            }
                            catch (Exception ex)
                            {
                                string ss = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                            }



                            if (!string.IsNullOrWhiteSpace(objUser.UserEmail) && SendEmail)
                            {
                                try
                                {





                                    string BodyCondande = Global.Context.Teplates.Where(parameters => parameters.TeplateId == 1).FirstOrDefault().Template.Replace("{OTP}", SiteSession.OTP);
                                    Thread ThSendEmail = new Thread(() =>

                                    Common.SendOTPEMAIL(BodyCondande, objUser.UserEmail, "vikas@autovyn.in"));

                                    ThSendEmail.IsBackground = true;
                                    ThSendEmail.Start();


                                }
                                catch (Exception ex)
                                {
                                    string ss = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                                }
                            }




                            if (String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                            {
                                Response.Redirect("~/otpverifay.aspx?");
                            }
                            else
                            {
                                Response.Redirect("~/otpverifay.aspx?ReturnUrl=" + Request.QueryString["ReturnUrl"] + "");
                            }
                        }
                        else
                            if (!string.IsNullOrWhiteSpace(objUser.UserEmail) && SendEmail)
                        {
                            string OTP = Common.Otp();
                            SiteSession.OTP = OTP;

                            try
                            {





                                string BodyCondande = Global.Context.Teplates.Where(parameters => parameters.TeplateId == 1).FirstOrDefault().Template.Replace("{OTP}", SiteSession.OTP);
                                Thread ThSendEmail = new Thread(() =>

                                Common.SendOTPEMAIL(BodyCondande, objUser.UserEmail, "vikas@autovyn.in"));

                                ThSendEmail.IsBackground = true;
                                ThSendEmail.Start();


                            }
                            catch (Exception ex)
                            {
                                string ss = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                            }



                            try
                            { }
                            catch { }
                            try
                            {

                                if (!string.IsNullOrWhiteSpace(objUser.User_mob))
                                {
                                    SMZP.PlatinumMotocorpLLPSMS(SiteSession.Comp_MstSession.OTPTemplate.Replace("{User_Name}", objUser.User_Name).Replace("{OTP}", OTP), objUser.User_mob);
                                }

                            }
                            catch (Exception ex)
                            {
                                string ss = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                            }




                            if (String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                            {
                                Response.Redirect("~/otpverifay.aspx?");
                            }
                            else
                            {
                                Response.Redirect("~/otpverifay.aspx?ReturnUrl=" + Request.QueryString["ReturnUrl"] + "");
                            }

                        }
                        else
                        {
                            if (String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                            {
                                Response.Redirect("~/selectgodown.aspx?");
                            }
                            else
                            {
                                Response.Redirect("~/selectgodown.aspx?ReturnUrl=" + Request.QueryString["ReturnUrl"] + "");
                            }
                        }

                    }
                    else
                    {
                        Response.Redirect("~/admin/blankpage.aspx");
                    }




                }

                else
                {
                    message.Text = " <div class='alert alert-danger alert-dismissible'><h4><i class='icon fa fa-ban'></i> Error!</h4>User- Not Found</div>";
                }
            }

        }






        private void DeviceLogin(Business.User_Tbl objUser)
        {



            SiteSession.IsLoggedIn = true;
            SiteSession.LoginUser = objUser;


            SiteSession.FilterKeyHolder = new List<FilterKeyHolder>();
            SiteSession.GroupMasterReport = Global.Context.GroupMasterReports.AsEnumerable().ToList();
            try
            {
                SiteSession.AllotOption = new List<AllotOption>();
                SiteSession.AllotOption = Business.Global.Context.AllotOptions.Where(parameters => parameters.UserId == objUser.User_Code).ToList();
            }
            catch { }
            SiteSession.ParentMenu = Business.Global.Context.ParentMenu(objUser.User_Code).ToList();
            SiteSession.SubMenu = Business.Global.Context.SubMenu(objUser.User_Code).ToList();
            SiteSession.StringUserName = objUser.User_Name;

            SiteSession.Comp_MstSession = Global.Context.Comp_Mst.Where(parameters => parameters.Comp_Code == objUser.Comp_Code.Value).FirstOrDefault();
            SiteSession.GetGodawanListSession = Business.UserLogin.GetGodawanList(objUser.Multi_loc, objUser.Comp_Code.Value);

            if (objUser.RoleId != 1)
            {




                if (!string.IsNullOrWhiteSpace(objUser.DatabaseIp))
                {
                    SiteSession.DatabaseIp = objUser.DatabaseIp;
                    SiteSession.DatabseUserName = objUser.DatabseUserName;
                    SiteSession.DatabasePassword = objUser.DatabasePassword;
                    SiteSession.DatabaseName = objUser.DatabaseName;
                }


                Response.Redirect("~/selectgodown.aspx?ReturnUrl=" + Request.QueryString["ReturnUrl"] + "");

            }

        }




        private void FillfinaceData(string ConStr)
        {
            try
            {
                OtherSqlConn.ExequteQuey1("insert into Finance SELECT  x.*,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null FROM Finance right JOIN (select distinct CONVERT(nvarchar(200), TRANS_id) as DMSINVNo, convert(datetime,TRANS_DATE) as DelvOn,CONVERT(nvarchar(200), CUST_NAME) as CustomerName,isnull( (select top 1 CONVERT(nvarchar(200), UPPER(MODEL_DESC) ) from model_variant_master where  model_variant_master.VARIANT_CD=gd_fdi_trans.VARIANT_CD),'') as ModelName,CONVERT(nvarchar(200), CHASSIS_NUM ) as ChasNo,CONVERT(nvarchar(200), EXECUTIVE ) as ErpExecutive,CONVERT(nvarchar(200), CUST_ID) CustId, convert (int, (select top 1 Godw_code from godown_mst where godown_mst.NEWCAR_RCPT=LOC_CD) ) as BranchId,VARIANT_CD,VIN from gd_fdi_trans where TRANS_TYPE='VS') AS X  on Finance.BranchId=x.BranchId and Finance.DMSINVNo=x.DMSINVNo where isnull(FinanceId,0)=0", ConStr);
            }
            catch { }


          


        }




    }

}
