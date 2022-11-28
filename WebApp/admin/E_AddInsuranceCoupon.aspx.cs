using Business;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.UI;
using WebApp.LIBS;

using System.Transactions;
using System.Web.UI.WebControls;
using System.Web.Script.Services;
using System.Web.Services;
namespace WebApp.admin
{
    public partial class E_AddInsuranceCoupon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                try
                {
                    sendemail.Visible = WebApp.LIBS.SiteSession.AllotOption.Where(p => p.OptionId == (int)WebApp.LIBS.SiteKey.OptionShow.SendCouponEmail).Count() > 0 ? true : false;
                    WhatsApp.Visible = WebApp.LIBS.SiteSession.AllotOption.Where(p => p.OptionId == (int)WebApp.LIBS.SiteKey.OptionShow.SendCouponWa).Count() > 0 ? true : false;
                    PrintData.Visible = WebApp.LIBS.SiteSession.AllotOption.Where(p => p.OptionId == (int)WebApp.LIBS.SiteKey.OptionShow.PrintCoupon).Count() > 0 ? true : false;
                }
                catch { }
                IssueDate.Text = Common.DateTimeNow().ToString("dd/MM/yyy");
                FillTable();

                int MasterIds = (int)SiteKey.MasterParent.ECoupon;


                Common.BindControl(MasterId, Global.Context.Masters.Where(p => p.MasterParentId == MasterIds).Select(p => new { p.MasterId, Names = p.Name }).ToList(), "Names", "MasterId", "Select");


            }
            #region Location
            if (Request.QueryString != null && !string.IsNullOrEmpty(Convert.ToString(Request.QueryString["InsuranceCouponId"])) && LIBS.Common.ConvertInt(savelocation.CommandArgument) == 0)
            {
                savelocation.CommandArgument = Convert.ToString(Request.QueryString["InsuranceCouponId"]);
                BindLocation(LIBS.Common.ConvertInt(savelocation.CommandArgument));
            }
            if (Request.QueryString["InsuranceCouponId"].ConvertInt() > 0)
            {
                if (Request.QueryString != null && !string.IsNullOrEmpty(Convert.ToString(Request.QueryString["InsuranceCouponId"])) && LIBS.Common.ConvertInt(savelocation.CommandArgument) != Request.QueryString["InsuranceCouponId"].ConvertInt())
                {
                    savelocation.CommandArgument = Convert.ToString(Request.QueryString["InsuranceCouponId"]);
                }
            }
            #endregion
        }


        #region LocationData
        private void FillTable()
        {
            try
            {
                int Id = Request.QueryString["ECoupanEntryId"].ConvertInt();

                var Tot = Global.Context.ECoupanEntries.SingleOrDefault(p => p.ECoupanEntryId == Id);

             
                VehicleNo.Text = Tot.VehicleRegnNo.ToString();
                CustomerName.Text = Tot.CustomerName.ToString();
                MobNo.Text = Tot.CustomerMobileNo;
                EmailId.Text = Tot.EmailNos;
                var Payment = Global.Context.E_InsuranceCoupon.AsEnumerable().Where(p => p.InsuranceIndividualId == Id).ToList();

                LIBS.Common.BindControl(gvlocation, Payment);

            }
            catch (Exception ex)
            {


            }


        }


        protected void gvsession_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "Sessionactive")
                {
                    int Id = Convert.ToInt32(e.CommandArgument);

                    Common.SendCouponOnWa(Id);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Successfully", "alert('Message Send on thread.');'", true);




                }
            }
            catch (Exception ex)
            {
                String Message = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                if (Message.Contains("UNIQUE KEY")) { Message = "Record already exists. Please enter another."; }
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "alert('" + Message + "');'", true);



            }
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string sendwa(string Id)
        {
            try
            {


                int Ids = Convert.ToInt32(Id);

                Common.SendCouponOnWa(Ids);

                return "Message Send on thread";
            }
            catch (Exception ex)
            {
                String Message = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                if (Message.Contains("UNIQUE KEY")) { Message = "Record already exists. Please enter another."; }


                return Message;

            }
        }





        private void BindLocation(int v)
        {
            var obj = Global.Context.E_InsuranceCoupon.SingleOrDefault(p => p.InsuranceCouponId == v);
            {

                MasterId.SelectedValue = obj.MasterId.Value.ToString();

                MobNo.Text = obj.MobNo;

                IssueDate.Text = obj.IssueDate.Value.ToString("dd/MM/yyyy");
                ExpiryDateofPolicy.Text = obj.PolicyExpiryDate.Value.ToString("dd/MM/yyyy");
                MIAdvisorName.Text=obj.DealersExecutive;

            }
        }


        protected void savelocation_Click(object sender, EventArgs e)
        {
            try
            {

                if (Page.IsValid)
                {
                    int Id = Request.QueryString["ECoupanEntryId"].ConvertInt();

                    if (LIBS.Common.ConvertInt(savelocation.CommandArgument) > 0)
                    {
                        using (TransactionScope Trans = new TransactionScope())
                        {
                            int projectid = LIBS.Common.ConvertInt(savelocation.CommandArgument);
                            var obj = Global.Context.E_InsuranceCoupon.SingleOrDefault(p => p.InsuranceCouponId == projectid);
                            {
                                obj.MasterId = MasterId.SelectedValue.ConvertInt();

                                obj.MobNo = MobNo.Text;
                                obj.IssueDate = IssueDate.Text.DateConvertTextMatchCase();
                                obj.EmailId = EmailId.Text;
                                obj.DealersExecutive = MIAdvisorName.Text;

                                obj.PolicyExpiryDate = ExpiryDateofPolicy.Text.DateConvertTextMatchCase();
                                obj.Save();
                                FillTable();
                                Trans.Complete();
                            }
                            Common.Createdblog(savelocation.CommandArgument, "Update");
                        }
                        Response.Redirect("E_AddInsuranceCoupon.aspx?ECoupanEntryId=" + Id + "", false);
                    }
                    else
                    {
                        using (TransactionScope Trans = new TransactionScope())
                        {
                            Business.E_InsuranceCoupon obj = new Business.E_InsuranceCoupon();

                            //var objcode = Global.Context.ExecuteStoreQuery<GEtNo>("select isnull( ((select top 1 Code from [Master] where Master.MasterId="+ MasterId.SelectedValue + ")+'/20-21/'+ REPLACE(STR(convert (nvarchar(50),((select COUNT(*)+1 from E_InsuranceCoupon where Comp_Code=" + SiteSession.Comp_MstSession.Comp_Code + " and MasterId=" + MasterId.SelectedValue + " ))),5),' ', '0')),'')  as code").FirstOrDefault().code;


                            obj.MasterId = MasterId.SelectedValue.ConvertInt();
                            //obj.Code = objcode;
                            obj.EmailId = EmailId.Text;
                            obj.CreatedBy = SiteSession.LoginUser.User_Code;
                            obj.IsApprove = false;
                            obj.IsReject = false;
                            obj.MobNo = MobNo.Text;
                            obj.DealersExecutive = MIAdvisorName.Text;
                            
                            obj.PolicyExpiryDate  = ExpiryDateofPolicy.Text.DateConvertTextMatchCase();
                            obj.IssueDate = IssueDate.Text.DateConvertTextMatchCase();

                            obj.Comp_Code = SiteSession.Comp_MstSession.Comp_Code;
                            obj.InsuranceIndividualId = Id;
                            //obj.Code = objcode;

                            obj.Save();
                            
                            Common.Createdblog(obj.InsuranceCouponId.ToString(), "Insert");

                            FillTable();
                            Trans.Complete();
                        }


                        IssueDate.Text = "";
                        MasterId.SelectedIndex = 0;

                        MessageBox.ShowMessage("Success", "successfully data Saved", SiteKey.MessageType.success);
                    }

                }

            }
            catch (Exception ex)
            {
                String Message = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                if (Message.Contains("UNIQUE KEY")) { Message = "Record/Username already exists. Please choose another."; }
                MessageBox.ShowMessage("Error", Message, SiteKey.MessageType.danger);
            }
        }
        #endregion



        protected void WhatsApp_Click(object sender, EventArgs e)
        {
            try
            {

                string gtt = "";
                for (int i = 0; i < gvlocation.Rows.Count; i++)
                {
                    if ((gvlocation.Rows[i].FindControl("ck") as CheckBox).Checked)
                    {
                        gtt = gtt.Length > 0 ? gtt + "," + (gvlocation.Rows[i].FindControl("InsuranceCouponId") as HiddenField).Value.ToString() : (gvlocation.Rows[i].FindControl("InsuranceCouponId") as HiddenField).Value.ToString();

                    }


                }

                Common.SendCouponOnWaMultipal(gtt);

                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "RefreshParentScript", "alert('Message Send on thread')", true);

            }
            catch (Exception ex)
            {
                String Message = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                if (Message.Contains("UNIQUE KEY")) { Message = "Record already exists. Please enter another."; }

                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "RefreshParentScript", "alert('" + Message + "')", true);




            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                var objListOfDocument = new List<Emailer.AttachmentStream>();
                string STREmailId = "";
                string gtt = "";
                for (int i = 0; i < gvlocation.Rows.Count; i++)
                {
                    if ((gvlocation.Rows[i].FindControl("ck") as CheckBox).Checked)
                    {
                        gtt = gtt.Length > 0 ? gtt + "," + (gvlocation.Rows[i].FindControl("InsuranceCouponId") as HiddenField).Value.ToString() : (gvlocation.Rows[i].FindControl("InsuranceCouponId") as HiddenField).Value.ToString();

                    }
                    if (!string.IsNullOrWhiteSpace((gvlocation.Rows[i].FindControl("EmailId") as HiddenField).Value))
                    {
                        STREmailId = (gvlocation.Rows[i].FindControl("EmailId") as HiddenField).Value;
                    }

                }
                if (STREmailId.Length > 0)
                {

                    objListOfDocument.Add(new Emailer.AttachmentStream() { FileName = "Coupon", File = Common.E_CreatePDF(gtt, SiteSession.Comp_MstSession.Comp_Name), Extranson = "pdf", subExtranson = "pdf" });


                    var BodyCondande = Global.Context.Teplates.Where(Page => Page.TeplateId == 2).FirstOrDefault().Template.Replace("{COMP_Name}", SiteSession.Comp_MstSession.Comp_Name);

                    var objs = Emailer.Mailer.SendMail(STREmailId, ConfigurationSettings.AppSettings["SMTPUserName"], "", BodyCondande, "Coupon", null, true, "", "vikas@autovyn.in", null, objListOfDocument, SiteSession.Comp_MstSession.Comp_Name + " Discount Coupon");
                    if (objs == "Send")
                    {

                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "RefreshParentScript", "alert('Successfully Send Email.')", true);

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "RefreshParentScript", "alert('" + objs + "')", true);

                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "RefreshParentScript", "alert('could not found EmailId.Please Enter EmailId')", true);

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "RefreshParentScript", "alert('" + (ex.InnerException != null ? ex.InnerException.Message : ex.Message) + "')", true);


            }
        }







        protected void PrintData_Click(object sender, EventArgs e)
        {
            string gtt = "";
            for (int i = 0; i < gvlocation.Rows.Count; i++)
            {
                if ((gvlocation.Rows[i].FindControl("ck") as CheckBox).Checked)
                {
                    gtt = gtt.Length > 0 ? gtt + "," + (gvlocation.Rows[i].FindControl("InsuranceCouponId") as HiddenField).Value.ToString() : (gvlocation.Rows[i].FindControl("InsuranceCouponId") as HiddenField).Value.ToString();

                }


            }
            string url = "print/E_multipalcouponprint.aspx?Id=" + gtt + "&&CompName=" + SiteSession.Comp_MstSession.Comp_Name + "";
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "RefreshParentScript", "window.open('" + url + "','mywindow', 'menubar=1,resizable=1,scrollbars=1,width=1000,height=700');", true);
        }
    }
}