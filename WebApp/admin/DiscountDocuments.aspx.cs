using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.admin.ReportModal;
using Business;
using WebApp.LIBS;
using System.IO;

namespace WebApp.admin
{
    public partial class DiscountDocuments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString != null && !string.IsNullOrEmpty(Convert.ToString(Request.QueryString["ReciptId"])) && LIBS.Common.ConvertInt(savelocation.CommandArgument) == 0)
                {
                    savelocation.CommandArgument = Convert.ToString(Request.QueryString["ReciptId"]);
                    FillData();

                }

            }
        }

        private void FillData()
        {

            DataRow FianceData = OtherSqlConn.FillDataTable("select isnull(DiscountDocument,'') as DiscountDocument from Finance where   FinanceId=" + Request.QueryString["ReciptId"].ToString() + "").AsEnumerable().FirstOrDefault();
            string[] Array = FianceData["DiscountDocument"].ToString().Split('~');
            List<DocumentList> Dalist = new List<DocumentList>();
            
            foreach (string Arraydata in Array)
            {
                if (Arraydata.Length > 0)
                {
                    var StringFiles = Arraydata.Split('=');
                    Dalist.Add(new DocumentList() { FileName = StringFiles[1], TitleData = StringFiles[0], RealName = Arraydata });
                }

            }
            Common.BindControl(gvlocation, Dalist.ToList());

        }

        private string UploadFile(string Name, FileUpload files)
        {
            try
            {
                if (files.HasFile)
                {
                    var extantion = System.IO.Path.GetExtension(files.FileName);
                    string filename =  Guid.NewGuid() + extantion;
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

        protected void savelocation_Click(object sender, EventArgs e)
        {

            try
            {

               var DocName=  UploadFile(DocumentName.Text, MasterId);
                if (DocName.Length > 0)
                {
                    DataRow FianceData = OtherSqlConn.FillDataTable("select isnull(DiscountDocument,'') as DiscountDocument from Finance where   FinanceId=" + Request.QueryString["ReciptId"].ToString() + "").AsEnumerable().FirstOrDefault();
                    string Array = FianceData["DiscountDocument"].ToString();
                    if (Array.Length > 0)
                    {
                        Array += "~" + DocumentName.Text.Trim() + "=" + DocName;
                    }
                    else
                    {
                        Array=  DocumentName.Text.Trim() + "=" + DocName;
                    }


                    OtherSqlConn.ExequteQuey("Update Finance set DiscountDocument='"+ Array.Replace("'","''") + "'  where   FinanceId=" + Request.QueryString["ReciptId"].ToString() + "");

                    FillData();

                    MessageBox.ShowMessage("Success", "successfully data Saved", SiteKey.MessageType.success);
                }
                else

                {
                    MessageBox.ShowMessage("Error", "Document not upload", SiteKey.MessageType.danger);
                }
            }
            catch (Exception ex)
            {
                String Message = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                if (Message.Contains("UNIQUE KEY")) { Message = "Record/Username already exists. Please choose another."; }
                MessageBox.ShowMessage("Error", Message, SiteKey.MessageType.danger);
            }

        }

        protected void gvlocation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "DeleteFile")
                {
                    string Id =  e.CommandArgument.ToString();
                   
                        var StringFiles = Id.Split('=');

                    string file_name = StringFiles[1];
                    
                    string path = Server.MapPath("~/upload/" + file_name);
                    FileInfo file = new FileInfo(path);
                    
                    if (file.Exists)//check file exsit or not  
                    {
                        file.Delete();
                        string FilesName = "";
                        DataRow FianceData = OtherSqlConn.FillDataTable("select isnull(DiscountDocument,'') as DiscountDocument from Finance where   FinanceId=" + Request.QueryString["ReciptId"].ToString() + "").AsEnumerable().FirstOrDefault();
                        string[] Array = FianceData["DiscountDocument"].ToString().Split('~');
                        List<DocumentList> Dalist = new List<DocumentList>();
                        foreach (string Arraydata in Array)
                        {
                            if (Id != Arraydata)
                            {
                                FilesName += FilesName.Length > 0 ? FilesName + "~" + Arraydata : Arraydata;

                            }


                        }


                        OtherSqlConn.ExequteQuey("Update Finance set DiscountDocument='" + FilesName.Replace("'", "''") + "'  where   FinanceId=" + Request.QueryString["ReciptId"].ToString() + "");

                        FillData();

                        MessageBox.ShowMessage("Deleted", "successfully data Delete", SiteKey.MessageType.success);
                    }
                }
            }
            catch (Exception ex)
            {
                String Message = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                if (Message.Contains("UNIQUE KEY")) { Message = "Record already exists. Please enter another."; }
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "alert('" + Message + "');'", true);



            }
        }
    }
}

public partial class DocumentList
{

    public string TitleData { get; set; }
    public string RealName { get; set; }
    public string FileName { get; set; }
}