using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
using Business;
using System.Transactions;

namespace WebApp.admin
{
    public partial class frmGroupMasterReport : BasePageClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Common.BindControl(GVData, Global.Context.GroupMasterReports.AsEnumerable().ToList());

            }
            if (Request.QueryString["delete"].ConvertInt() > 0)
            {

                try
                {
                    int projectid = Request.QueryString["delete"].ConvertInt();
                    var obj = Global.Context.GroupMasterReports.SingleOrDefault(p => p.GroupMasterReportId == projectid);
                    obj.Delete();
                    Response.Redirect("frmGroupMasterReport.aspx", false);

                }
                catch (Exception ex)
                {
                    String Message = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                    if (Message.Contains("UNIQUE KEY")) { Message = "Record/Username already exists. Please choose another."; }
                    MessageBox.ShowMessage("Error", Message, SiteKey.MessageType.danger);
                }


            }


            if (Request.QueryString != null && !string.IsNullOrEmpty(Convert.ToString(Request.QueryString["GroupMasterReportId"])) && SaveData.CommandName != "edit")
            {
                SaveData.CommandName = "edit";
                SaveData.CommandArgument = Request.QueryString["GroupMasterReportId"];
                BindEdit(Request.QueryString["GroupMasterReportId"].ConvertInt());
            }
            else if (string.IsNullOrEmpty(Convert.ToString(Request.QueryString["GroupMasterReportId"])) && SaveData.CommandName != "edit")
            {
                SaveData.CommandName = "add";
                SaveData.CommandArgument = "0";
            }




        }

        private void BindEdit(int v)
        {
            try
            {

                var obj = Global.Context.GroupMasterReports.SingleOrDefault(p => p.GroupMasterReportId == v);


                ReportName.Text = obj.ReportName;
                GroupCode.Text = obj.GroupCode.Value.ToString();


            }
            catch { }
        }



        protected void SaveData_Click(object sender, EventArgs e)
        {
            try
            {

                if (Page.IsValid)
                {

                    if (SaveData.CommandArgument.ConvertInt() > 0)
                    {

                        int Id = SaveData.CommandArgument.ConvertInt();



                        if (ReportName.Text.Length > 0 && ReportName.Text.Length > 0)
                        {
                            using (TransactionScope Trans = new TransactionScope())
                            {

                                var objdata = Global.Context.GroupMasterReports.SingleOrDefault(p => p.GroupMasterReportId == Id);

                                objdata.ReportName = ReportName.Text;

                                objdata.GroupCode = GroupCode.Text.ConvertInt();
                                objdata.Save();

                                Trans.Complete();
                            }




                            Response.Redirect("frmGroupMasterReport.aspx", false);

                        }

                    }
                    else
                    {

                        if (ReportName.Text.Length > 0 && GroupCode.Text.Length > 0)
                        {

                            var Id = 0;

                            using (TransactionScope Trans = new TransactionScope())
                            {

                                var objdata = new Business.GroupMasterReport();
                                objdata.ReportName = ReportName.Text;

                                objdata.GroupCode = GroupCode.Text.ConvertInt();
                                objdata.Save();

                                Trans.Complete();
                            }


                            Common.BindControl(GVData, Global.Context.GroupMasterReports.AsEnumerable().ToList());



                            ReportName.Text = "";
                            GroupCode.Text = "";
                            MessageBox.ShowMessage("Success", "successfully data Saved", SiteKey.MessageType.success);
                        }
                    }
                }

                else {
                    MessageBox.ShowMessage("Error", "Please Select Complete Data.", SiteKey.MessageType.danger);
                }



            }
            catch (Exception ex)
            {
                String Message = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                if (Message.Contains("UNIQUE KEY")) { Message = "Record/Username already exists. Please choose another."; }
                MessageBox.ShowMessage("Error", Message, SiteKey.MessageType.danger);
            }
        }

    }
}