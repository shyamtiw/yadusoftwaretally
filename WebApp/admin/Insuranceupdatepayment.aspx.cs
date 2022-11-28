using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
namespace WebApp.admin
{
    public partial class Insuranceupdatepayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillTable();
                Common.BindControl(BranchId, Business.UserLogin.GetGodawanListEInvoiceInserWithValue(SiteSession.Comp_MstSession.Comp_Code.Value).ToList(), "Value", "Id", "Select");
                int MasterIds = (int)SiteKey.MasterParent.PaymentMothod;

              
                Common.BindControl(MasterId, Global.Context.Masters.Where(p=> p.MasterParentId == MasterIds).Select(p=> new {p.MasterId,Names=p.Name }).ToList(), "Names", "MasterId", "Select");


            }
            #region Location
            if (Request.QueryString != null && !string.IsNullOrEmpty(Convert.ToString(Request.QueryString["InsuranceupdatepaymentId"])) && LIBS.Common.ConvertInt(savelocation.CommandArgument) == 0)
            {
                savelocation.CommandArgument = Convert.ToString(Request.QueryString["InsuranceupdatepaymentId"]);
                BindLocation(LIBS.Common.ConvertInt(savelocation.CommandArgument));
            }
            if (Request.QueryString["InsuranceupdatepaymentId"].ConvertInt() > 0)
            {
                if (Request.QueryString != null && !string.IsNullOrEmpty(Convert.ToString(Request.QueryString["InsuranceupdatepaymentId"])) && LIBS.Common.ConvertInt(savelocation.CommandArgument) != Request.QueryString["InsuranceupdatepaymentId"].ConvertInt())
                {
                    savelocation.CommandArgument = Convert.ToString(Request.QueryString["InsuranceupdatepaymentId"]);
                }
            }
            #endregion
        }


        #region LocationData
        private void FillTable()
        {
            try
            {
                int Id = Request.QueryString["InsuranceIndividualId"].ConvertInt();

                 var Tot= Global.Context.InsuranceIndividuals.SingleOrDefault(p => p.InsuranceIndividualId == Id).GrossTotalPremium.ConvertDecimal();
                var Payment = Global.Context.Insuranceupdatepayments.AsEnumerable().Where(p => p.InsuranceIndividualId == Id).ToList();
                PremiumAmount.Text = Tot.ToString();
                BalanceAmount.Text= (Tot - Payment.Sum(p => p.ReceiptAmount.Value)).ToString();
                LIBS.Common.BindControl(gvlocation, Payment);

            }
            catch { }


        }


        private void BindLocation(int v)
        {
            var obj = Global.Context.Insuranceupdatepayments.SingleOrDefault(p => p.InsuranceupdatepaymentId == v);
            {

                BranchId.SelectedValue = obj.BranchId.Value.ToString();
                MasterId.SelectedValue = obj.MasterId.Value.ToString();
                ReceiptNo.Text = obj.ReceiptNo;

                ReceiptAmount.Text = obj.ReceiptAmount.Value.ToString();
                ReceiptDate.Text = obj.ReceiptDate.Value.ToString("dd/MM/yyyy");


                try
                {
                    Remark.Text = obj.Remark;
                }
                catch { }
            }
        }



        protected void savelocation_Click(object sender, EventArgs e)
        {
            try
            {

                if (Page.IsValid)
                {
                    int Id = Request.QueryString["InsuranceIndividualId"].ConvertInt();
                    var FileNames = UploadFile("UpdatePayment_", Fileupload);
                    if (LIBS.Common.ConvertInt(savelocation.CommandArgument) > 0)
                    {
                        using (TransactionScope Trans = new TransactionScope())
                        {
                            int projectid = LIBS.Common.ConvertInt(savelocation.CommandArgument);
                            var obj = Global.Context.Insuranceupdatepayments.SingleOrDefault(p => p.InsuranceupdatepaymentId == projectid);
                            {
                                obj.BranchId = BranchId.SelectedValue.ConvertInt();
                                obj.MasterId = MasterId.SelectedValue.ConvertInt();
                                obj.ReceiptNo = ReceiptNo.Text;
                                obj.ReceiptDate = ReceiptDate.Text.DateConvertTextMatchCase();
                                obj.ReceiptAmount = ReceiptAmount.Text.ConvertDecimal();
                                obj.Remark = Remark.Text;
                                if (FileNames.Length > 0)
                                {
                                    obj.Fileupload = FileNames;
                                }
                                obj.Save();
                                FillTable();
                                Trans.Complete();
                            }
                        }
                        Response.Redirect("Insuranceupdatepayment.aspx?InsuranceIndividualId="+Id+"", false);
                    }
                    else
                    {
                        using (TransactionScope Trans = new TransactionScope())
                        {
                            Business.Insuranceupdatepayment obj = new Business.Insuranceupdatepayment();


                              obj.BranchId = BranchId.SelectedValue.ConvertInt();
                            obj.MasterId = MasterId.SelectedValue.ConvertInt();
                            obj.ReceiptNo = ReceiptNo.Text;
                            obj.ReceiptDate = ReceiptDate.Text.DateConvertTextMatchCase();
                            obj.ReceiptAmount = ReceiptAmount.Text.ConvertDecimal();
                            obj.Fileupload = FileNames;
                            obj.Remark = Remark.Text;
                            obj.InsuranceIndividualId = Id;
                            obj.Save();
                            FillTable();
                            Trans.Complete();
                        }
                        Remark.Text = "";
                        BranchId.SelectedIndex = 0;
                        MasterId.SelectedIndex = 0;
                        ReceiptNo.Text = "";
                        ReceiptDate.Text = "";
                        ReceiptAmount.Text = "";
                        ReceiptNo.Text = "";
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
        private string UploadFile(string Name, FileUpload files)
        {
            try
            {
                if (Fileupload.HasFile)
                {

                    string filename = "" + Name.ToLower() + "_" + Guid.NewGuid() + files.FileName;
                    string fullpath = Server.MapPath("~/upload/") + filename;
                    files.SaveAs(fullpath);
                    return filename;
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                return "";
            }
        }
    }
}