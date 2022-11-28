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

namespace WebApp.mobile
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               //SMZP.SendNotification("Check", "Data", (new string[] { "b1a991da-8006-4c8a-ae6a-739044100397" }));
                var GetDeviceId = !string.IsNullOrWhiteSpace(Request.QueryString["DeviceId"]) ? Business.UserLogin.GetUserIsDeviceId(Request.QueryString["DeviceId"]) : null;


                if (GetDeviceId != null)
                {

                    DeviceLogin(GetDeviceId);
                }
               
                }
        }

        protected void Logindata_Click(object sender, EventArgs e)
        {





                var objUser = Business.UserLogin.GetUser(email.Text, password.Text);
                if (objUser != null)
                {


                    SiteSession.IsLoggedInMobile = true;
                    SiteSession.LoginUser = objUser;


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


                    try
                    {

                        SiteSession.EmployeeMaster = Global.Context.EmployeeMasters.SingleOrDefault(predicate => predicate.User_Code == objUser.User_Code);
                        SiteSession.DesignationId = SiteSession.EmployeeMaster.Designation.Value;
                    }
                    catch { }

                    SiteSession.FilterKeyHolder = new List<FilterKeyHolder>();


                    SiteSession.StringUserName = objUser.User_Name;

                    SiteSession.Comp_MstSession = Global.Context.Comp_Mst.Where(parameters => parameters.Comp_Code == objUser.Comp_Code.Value).FirstOrDefault();
                    SiteSession.GetGodawanListSession = Business.UserLogin.GetGodawanList(objUser.Multi_loc, objUser.Comp_Code.Value);



                    if (objUser.RoleId != 2)
                    {




                        if (!string.IsNullOrWhiteSpace(objUser.DatabaseIp))
                        {
                            SiteSession.DatabaseIp = objUser.DatabaseIp;
                            SiteSession.DatabseUserName = objUser.DatabseUserName;
                            SiteSession.DatabasePassword = objUser.DatabasePassword;
                            SiteSession.DatabaseName = objUser.DatabaseName;
                        }


                        if (!string.IsNullOrWhiteSpace(objUser.User_mob))
                        {
                            string OTP = Common.Otp();
                            SiteSession.OTP = OTP;
                            try
                            {




                                //string BodyCondande = Global.Context.Teplates.Where(parameters => parameters.TeplateId == 1).FirstOrDefault().Template.Replace("{OTP}", SiteSession.OTP);
                                SiteSession.CheckErrorMessage = SMZP.PlatinumMotocorpLLPSMS(SiteSession.Comp_MstSession.OTPTemplate.Replace("{User_Name}", objUser.User_Name).Replace("{OTP}", OTP), objUser.User_mob);


                            }
                            catch (Exception ex)
                            {
                                string ss = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                                SiteSession.CheckErrorMessage = ss;
                            }



                            if (!string.IsNullOrWhiteSpace(objUser.UserEmail))
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
                                Response.Redirect("otpverification.aspx?");
                            }
                            else
                            {
                                Response.Redirect("otpverification.aspx?ReturnUrl=" + Request.QueryString["ReturnUrl"] + "");
                            }
                        }
                        else
                            if (!string.IsNullOrWhiteSpace(objUser.UserEmail))
                        {
                            string OTP = Common.Otp();
                            SiteSession.OTP = OTP;

                            try
                            {





                                string BodyCondande = Global.Context.Teplates.Where(parameters => parameters.TeplateId == 1).FirstOrDefault().Template.Replace("{OTP}", SiteSession.OTP);
                                Thread ThSendEmail = new Thread(() =>

                                Common.SendOTPEMAIL(BodyCondande, objUser.UserEmail, "vikas@Autovyn.in"));

                                ThSendEmail.IsBackground = true;
                                ThSendEmail.Start();


                            }
                            catch (Exception ex)
                            {
                                string ss = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                            }


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
                                Response.Redirect("otpverification.aspx?", false);
                            }
                            else
                            {
                                Response.Redirect("otpverification.aspx?ReturnUrl=" + Request.QueryString["ReturnUrl"] + "");
                            }

                        }
                        else
                        {
                            var countLoction = objUser.Multi_loc.Split(',');
                            if (countLoction.Count() > 1)
                            {
                                if (String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                                {
                                    Response.Redirect("selectgodown.aspx?", false);
                                }
                                else
                                {
                                    Response.Redirect("selectgodown.aspx?ReturnUrl=" + Request.QueryString["ReturnUrl"] + "", false);
                                }
                            }

                            else

                            {
                                SiteSession.GodownId = countLoction[0].ConvertInt();
                                if (SiteSession.DesignationId >= 18 && SiteSession.DesignationId <= 21)
                                {
                                    Response.Redirect(String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]) ? "Booking_Dashbaord.aspx" : Request.QueryString["ReturnUrl"]);
                                }
                                else if (SiteSession.DesignationId >= 22 && SiteSession.DesignationId <= 25)
                                {
                                    Response.Redirect(String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]) ? "Approver_Dashbaord.aspx" : Request.QueryString["ReturnUrl"]);
                                }
                                else
                                {
                                    Response.Redirect(String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]) ? "Mobile_Home.aspx" : Request.QueryString["ReturnUrl"]);

                                }
                            }
                        }

                    }
                    else if (objUser.RoleId == 2)
                    {
                        if (!string.IsNullOrWhiteSpace(objUser.DatabaseIp))
                        {
                            SiteSession.DatabaseIp = objUser.DatabaseIp;
                            SiteSession.DatabseUserName = objUser.DatabseUserName;
                            SiteSession.DatabasePassword = objUser.DatabasePassword;
                            SiteSession.DatabaseName = objUser.DatabaseName;
                        }


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



                            if (!string.IsNullOrWhiteSpace(objUser.UserEmail))
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
                                Response.Redirect("otpverification.aspx?");
                            }
                            else
                            {
                                Response.Redirect("otpverification.aspx?ReturnUrl=" + Request.QueryString["ReturnUrl"] + "");
                            }
                        }
                        else
                            if (!string.IsNullOrWhiteSpace(objUser.UserEmail))
                        {
                            string OTP = Common.Otp();
                            SiteSession.OTP = OTP;

                            try
                            {





                                string BodyCondande = Global.Context.Teplates.Where(parameters => parameters.TeplateId == 1).FirstOrDefault().Template.Replace("{OTP}", SiteSession.OTP);
                                Thread ThSendEmail = new Thread(() =>

                                Common.SendOTPEMAIL(BodyCondande, objUser.UserEmail, "vikas@Autovyn.in"));

                                ThSendEmail.IsBackground = true;
                                ThSendEmail.Start();


                            }
                            catch (Exception ex)
                            {
                                string ss = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                            }


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
                                Response.Redirect("otpverification.aspx?", false);
                            }
                            else
                            {
                                Response.Redirect("otpverification.aspx?ReturnUrl=" + Request.QueryString["ReturnUrl"] + "");
                            }

                        }
                        else
                        {
                            var countLoction = objUser.Multi_loc.Split(',');
                            if (countLoction.Count() > 1)
                            {
                                if (String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                                {
                                    Response.Redirect("selectgodown.aspx?", false);
                                }
                                else
                                {
                                    Response.Redirect("selectgodown.aspx?ReturnUrl=" + Request.QueryString["ReturnUrl"] + "", false);
                                }
                            }

                            else

                            {
                                SiteSession.GodownId = countLoction[0].ConvertInt();

                                Response.Redirect(String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]) ? "Admin_Dashbaord.aspx" : Request.QueryString["ReturnUrl"]);


                            }
                        }
                    }
                    else if (objUser.RoleId == 5)
                    {
                        if (!string.IsNullOrWhiteSpace(objUser.DatabaseIp))
                        {
                            SiteSession.DatabaseIp = objUser.DatabaseIp;
                            SiteSession.DatabseUserName = objUser.DatabseUserName;
                            SiteSession.DatabasePassword = objUser.DatabasePassword;
                            SiteSession.DatabaseName = objUser.DatabaseName;
                        }


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



                            if (!string.IsNullOrWhiteSpace(objUser.UserEmail))
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
                                Response.Redirect("otpverification.aspx?");
                            }
                            else
                            {
                                Response.Redirect("otpverification.aspx?ReturnUrl=" + Request.QueryString["ReturnUrl"] + "");
                            }
                        }
                        else
                            if (!string.IsNullOrWhiteSpace(objUser.UserEmail))
                        {
                            string OTP = Common.Otp();
                            SiteSession.OTP = OTP;

                            try
                            {





                                string BodyCondande = Global.Context.Teplates.Where(parameters => parameters.TeplateId == 1).FirstOrDefault().Template.Replace("{OTP}", SiteSession.OTP);
                                Thread ThSendEmail = new Thread(() =>

                                Common.SendOTPEMAIL(BodyCondande, objUser.UserEmail, "vikas@Autovyn.in"));

                                ThSendEmail.IsBackground = true;
                                ThSendEmail.Start();


                            }
                            catch (Exception ex)
                            {
                                string ss = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                            }


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
                                Response.Redirect("otpverification.aspx?", false);
                            }
                            else
                            {
                                Response.Redirect("otpverification.aspx?ReturnUrl=" + Request.QueryString["ReturnUrl"] + "");
                            }

                        }
                        else
                        {
                            var countLoction = objUser.Multi_loc.Split(',');
                            if (countLoction.Count() > 1)
                            {
                                if (String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                                {
                                    Response.Redirect("selectgodown.aspx?", false);
                                }
                                else
                                {
                                    Response.Redirect("selectgodown.aspx?ReturnUrl=" + Request.QueryString["ReturnUrl"] + "", false);
                                }
                            }

                            else

                            {
                                SiteSession.GodownId = countLoction[0].ConvertInt();

                                Response.Redirect(String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]) ? "Finance_Dashbaord.aspx" : Request.QueryString["ReturnUrl"]);


                            }
                        }
                    }
                    else if (objUser.RoleId == 6)
                    {
                        if (!string.IsNullOrWhiteSpace(objUser.DatabaseIp))
                        {
                            SiteSession.DatabaseIp = objUser.DatabaseIp;
                            SiteSession.DatabseUserName = objUser.DatabseUserName;
                            SiteSession.DatabasePassword = objUser.DatabasePassword;
                            SiteSession.DatabaseName = objUser.DatabaseName;
                        }


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



                            if (!string.IsNullOrWhiteSpace(objUser.UserEmail))
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
                                Response.Redirect("otpverification.aspx?");
                            }
                            else
                            {
                                Response.Redirect("otpverification.aspx?ReturnUrl=" + Request.QueryString["ReturnUrl"] + "");
                            }
                        }
                        else
                            if (!string.IsNullOrWhiteSpace(objUser.UserEmail))
                        {
                            string OTP = Common.Otp();
                            SiteSession.OTP = OTP;

                            try
                            {





                                string BodyCondande = Global.Context.Teplates.Where(parameters => parameters.TeplateId == 1).FirstOrDefault().Template.Replace("{OTP}", SiteSession.OTP);
                                Thread ThSendEmail = new Thread(() =>

                                Common.SendOTPEMAIL(BodyCondande, objUser.UserEmail, "vikas@Autovyn.in"));

                                ThSendEmail.IsBackground = true;
                                ThSendEmail.Start();


                            }
                            catch (Exception ex)
                            {
                                string ss = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                            }


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
                                Response.Redirect("otpverification.aspx?", false);
                            }
                            else
                            {
                                Response.Redirect("otpverification.aspx?ReturnUrl=" + Request.QueryString["ReturnUrl"] + "");
                            }

                        }
                        else
                        {
                            var countLoction = objUser.Multi_loc.Split(',');
                            if (countLoction.Count() > 1)
                            {
                                if (String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                                {
                                    Response.Redirect("selectgodown.aspx?", false);
                                }
                                else
                                {
                                    Response.Redirect("selectgodown.aspx?ReturnUrl=" + Request.QueryString["ReturnUrl"] + "", false);
                                }
                            }

                            else

                            {
                                SiteSession.GodownId = countLoction[0].ConvertInt();

                                Response.Redirect(String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]) ? "Exchange_Dashbaord.aspx" : Request.QueryString["ReturnUrl"]);


                            }
                        }
                    }



                }

                else
                {
                    message.Text = " <div class='alert alert-danger alert-dismissible'><h4><i class='icon fa fa-ban'></i> Error!</h4>User- Not Found</div>";
                }
            
        }

        private void DeviceLogin(User_Tbl objUser)
        {
            if (objUser != null)
            {


                SiteSession.IsLoggedInMobile = true;
                SiteSession.LoginUser = objUser;
                try
                {

                    SiteSession.EmployeeMaster = Global.Context.EmployeeMasters.SingleOrDefault(predicate => predicate.User_Code == objUser.User_Code);
                    SiteSession.DesignationId = SiteSession.EmployeeMaster.Designation.Value;
                }
                catch { }

                SiteSession.FilterKeyHolder = new List<FilterKeyHolder>();


                SiteSession.StringUserName = objUser.User_Name;

                SiteSession.Comp_MstSession = Global.Context.Comp_Mst.Where(parameters => parameters.Comp_Code == objUser.Comp_Code.Value).FirstOrDefault();
                SiteSession.GetGodawanListSession = Business.UserLogin.GetGodawanList(objUser.Multi_loc, objUser.Comp_Code.Value);



                if (objUser.RoleId != 2)
                {




                    if (!string.IsNullOrWhiteSpace(objUser.DatabaseIp))
                    {
                        SiteSession.DatabaseIp = objUser.DatabaseIp;
                        SiteSession.DatabseUserName = objUser.DatabseUserName;
                        SiteSession.DatabasePassword = objUser.DatabasePassword;
                        SiteSession.DatabaseName = objUser.DatabaseName;
                    }


                        var countLoction = objUser.Multi_loc.Split(',');
                        if (countLoction.Count() > 1)
                        {
                            if (String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                            {
                                Response.Redirect("selectgodown.aspx?", false);
                            }
                            else
                            {
                                Response.Redirect("selectgodown.aspx?ReturnUrl=" + Request.QueryString["ReturnUrl"] + "", false);
                            }
                        }

                        else

                        {
                            SiteSession.GodownId = countLoction[0].ConvertInt();
                            if (SiteSession.DesignationId >= 18 && SiteSession.DesignationId <= 21)
                            {
                                Response.Redirect(String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]) ? "Booking_Dashbaord.aspx" : Request.QueryString["ReturnUrl"]);
                            }
                            else if (SiteSession.DesignationId >= 22 && SiteSession.DesignationId <= 25)
                            {
                                Response.Redirect(String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]) ? "Approver_Dashbaord.aspx" : Request.QueryString["ReturnUrl"]);
                            }
                            else
                            {
                                Response.Redirect(String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]) ? "Mobile_Home.aspx" : Request.QueryString["ReturnUrl"]);

                            }
                       
                    }

                }
                else if (objUser.RoleId == 2)
                {
                    if (!string.IsNullOrWhiteSpace(objUser.DatabaseIp))
                    {
                        SiteSession.DatabaseIp = objUser.DatabaseIp;
                        SiteSession.DatabseUserName = objUser.DatabseUserName;
                        SiteSession.DatabasePassword = objUser.DatabasePassword;
                        SiteSession.DatabaseName = objUser.DatabaseName;
                    }

                    var countLoction = objUser.Multi_loc.Split(',');
                    if (countLoction.Count() > 1)
                    {
                        if (String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                        {
                            Response.Redirect("selectgodown.aspx?", false);
                        }
                        else
                        {
                            Response.Redirect("selectgodown.aspx?ReturnUrl=" + Request.QueryString["ReturnUrl"] + "", false);
                        }
                    }

                    else
                    {
                        SiteSession.GodownId = countLoction[0].ConvertInt();
                        Response.Redirect(String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]) ? "Admin_Dashbaord.aspx" : Request.QueryString["ReturnUrl"]);
                    }
                }
                else if (objUser.RoleId == 5)
                {
                    if (!string.IsNullOrWhiteSpace(objUser.DatabaseIp))
                    {
                        SiteSession.DatabaseIp = objUser.DatabaseIp;
                        SiteSession.DatabseUserName = objUser.DatabseUserName;
                        SiteSession.DatabasePassword = objUser.DatabasePassword;
                        SiteSession.DatabaseName = objUser.DatabaseName;
                    }

                    var countLoction = objUser.Multi_loc.Split(',');
                    if (countLoction.Count() > 1)
                    {
                        if (String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                        {
                            Response.Redirect("selectgodown.aspx?", false);
                        }
                        else
                        {
                            Response.Redirect("selectgodown.aspx?ReturnUrl=" + Request.QueryString["ReturnUrl"] + "", false);
                        }
                    }
                    else

                    {
                        SiteSession.GodownId = countLoction[0].ConvertInt();
                        Response.Redirect(String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]) ? "Finance_Dashbaord.aspx" : Request.QueryString["ReturnUrl"]);
                    }
                }
                else if (objUser.RoleId == 6)
                {
                    if (!string.IsNullOrWhiteSpace(objUser.DatabaseIp))
                    {
                        SiteSession.DatabaseIp = objUser.DatabaseIp;
                        SiteSession.DatabseUserName = objUser.DatabseUserName;
                        SiteSession.DatabasePassword = objUser.DatabasePassword;
                        SiteSession.DatabaseName = objUser.DatabaseName;
                    }
                        var countLoction = objUser.Multi_loc.Split(',');
                        if (countLoction.Count() > 1)
                        {
                            if (String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                            {
                                Response.Redirect("selectgodown.aspx?", false);
                            }
                            else
                            {
                                Response.Redirect("selectgodown.aspx?ReturnUrl=" + Request.QueryString["ReturnUrl"] + "", false);
                            }
                        }
                        else
                        {
                            SiteSession.GodownId = countLoction[0].ConvertInt();

                            Response.Redirect(String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]) ? "Exchange_Dashbaord.aspx" : Request.QueryString["ReturnUrl"]);


                        }
                    
                }



            }

            else
            {
                message.Text = " <div class='alert alert-danger alert-dismissible'><h4><i class='icon fa fa-ban'></i> Error!</h4>User- Not Found</div>";
            }
        }
    }

}
