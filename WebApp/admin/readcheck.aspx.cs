using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
using Business;
using Newtonsoft.Json;

namespace WebApp.admin
{
    public partial class readcheck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void btnUpload_Click(object sender, EventArgs e)

        {

            if (FileUpload1.HasFile)

            {

                string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);

                string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);

                string FolderPath = Server.MapPath("~/upload/");



                string FilePath = (FolderPath + FileName);

                FileUpload1.SaveAs(FilePath);

                Import_To_Grid(FilePath, Extension, rbHDR.SelectedItem.Text);

            }

        }


        private void Import_To_Grid(string FilePath, string Extension, string isHDR)

        {

            string conStr = "";

            switch (Extension.ToLower())

            {

                case ".xls": //Excel 97-03

                    conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]

                             .ConnectionString;

                    break;

                case ".xlsx": //Excel 07

                    conStr = ConfigurationManager.ConnectionStrings["Excel07+ConString"]

                              .ConnectionString;

                    break;

            }

            conStr = String.Format(conStr, FilePath, isHDR);

            OleDbConnection connExcel = new OleDbConnection(conStr);

            OleDbCommand cmdExcel = new OleDbCommand();

            OleDbDataAdapter oda = new OleDbDataAdapter();

            DataTable dt = new DataTable();

            cmdExcel.Connection = connExcel;



            //Get the name of First Sheet

            connExcel.Open();

            DataTable dtExcelSchema;

            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

            connExcel.Close();



            //Read Data from First Sheet

            connExcel.Open();

            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";

            oda.SelectCommand = cmdExcel;

            oda.Fill(dt);

            connExcel.Close();

            string createTable = "";

            foreach (DataColumn headerCell in dt.Columns)
            {
                string str = headerCell.Caption.ToString().Replace(".", "").Replace("/", "").Replace(@"\", "").Replace(" ", "").Replace("(", "").Replace(")", "").Replace("%", "");

                createTable = createTable + Environment.NewLine + str;


                //if (str.ToUpper().Contains("DATE"))
                //{
                //    createTable = createTable + "," + Environment.NewLine + (createTable.Length > 0 ?"[" + str + "] [datetime] NULL" : "[" + str + "] [datetime] NULL");
                //}
                //else
                //{
                //    createTable = createTable + "," + Environment.NewLine + (createTable.Length > 0 ? "[" + str + "] [nvarchar](150) NULL" : "[" + str + "]  [nvarchar](150) NULL");
                //}

            }

            //Bind Data to GridView

            GridView1.Caption = Path.GetFileName(FilePath);

            GridView1.DataSource = dt;

            GridView1.DataBind();

        }

        protected void cacls_Click(object sender, EventArgs e)
        {
            var obj = Business.Global.Context.JsonList("28").ToList();
            string Key = "";
            var GroupbyKeyId = obj.GroupBy(p => p.GodownCode).ToList();

            foreach (var p in GroupbyKeyId)

            {
                Key = p.FirstOrDefault().ASP_TockenId;
                var DataItem = obj.Where(c => c.GodownCode.Value == p.Key.Value).ToList();
                foreach (var x in DataItem)
                {
                    var statusIron = SMZP.GenaretIron(x.Json, x.ASP_Userid, x.ASP_Pwd, x.API_Usrname, x.API_Pwd, x.GST_No, Key);
                    if (statusIron.InfoDtls == null)
                    {
                        if (Common.Convertstring(statusIron.status_cd) == "0" && Common.Convertstring(statusIron.error.error_cd) == "GSP752")
                        {
                            var status = SMZP.GenaretToken(x.ASP_Userid, x.ASP_Pwd, x.API_Usrname, x.API_Pwd, x.GST_No);
                            if (status.Data != null)
                            {
                                Key = status.Data.AuthToken;
                                Global.Context.ExecuteQuery("update Godown_Mst set ASP_TockenId='" + status.Data.AuthToken + "' where Godw_Code=" + p.FirstOrDefault().GodownCode + " and EXPORT_TYPE<3");
                                var statusIronss = SMZP.GenaretIron(x.Json, x.ASP_Userid, x.ASP_Pwd, x.API_Usrname, x.API_Pwd, x.GST_No, Key);
                                if (statusIronss.InfoDtls == null)
                                {
                                    if (Common.Convertstring(statusIronss.status_cd) == "0" || Common.Convertstring(statusIronss.Status) == "0")
                                    {
                                        Global.Context.ExecuteQuery("update EInvoiceDataExcel set ErrorStatus='Error', [Responce]='" + statusIronss.Responce.Replace("'", "''") + "' where EInvoiceDataExcelId=" + x.EInvoiceDataExcelId + "");
                                    }
                                    else
                                    {
                                        Global.Context.ExecuteQuery("update EInvoiceDataExcel set ErrorStatus='Error', [Responce]='" + statusIronss.Responce.Replace("'", "''") + "' where EInvoiceDataExcelId=" + x.EInvoiceDataExcelId + "");
                                    }
                                }
                                else
                                {
                                    Global.Context.ExecuteQuery("update EInvoiceDataExcel set ErrorStatus='IRN Generated',AckNo=" + statusIron.InfoDtls.FirstOrDefault().Desc.AckNo + ",AckDt='" + statusIron.InfoDtls.FirstOrDefault().Desc.AckDt + "',Irn='" + statusIron.InfoDtls.FirstOrDefault().Desc.Irn + "', [Responce]='" + statusIron.Responce.Replace("'", "''") + "' where EInvoiceDataExcelId=" + x.EInvoiceDataExcelId + "");
                                }
                            }
                            else {
                                if (Common.Convertstring(status.status_cd) == "0" || Common.Convertstring(status.Status) == "0")
                                {

                                    Global.Context.ExecuteQuery("update EInvoiceDataExcel set ErrorStatus='Erroneous Case', [Responce]='" + status.Responce.Replace("'", "''") + "' where EInvoiceDataExcelId=" + x.EInvoiceDataExcelId + "");

                                }

                                break;
                            }

                        }
                        else if (Common.Convertstring(statusIron.status_cd) == "0" || Common.Convertstring(statusIron.Status) == "0")
                        {
                            Global.Context.ExecuteQuery("update EInvoiceDataExcel set ErrorStatus='Erroneous Case', [Responce]='" + statusIron.Responce.Replace("'", "''") + "' where EInvoiceDataExcelId=" + x.EInvoiceDataExcelId + "");
                        }
                        else
                        {
                            Global.Context.ExecuteQuery("update EInvoiceDataExcel set ErrorStatus='IRN Generated',AckNo=" + statusIron.InfoDtls.FirstOrDefault().Desc.AckNo + ",AckDt='" + statusIron.InfoDtls.FirstOrDefault().Desc.AckDt + "',Irn='" + statusIron.InfoDtls.FirstOrDefault().Desc.Irn + "', [Responce]='" + statusIron.Responce.Replace("'", "''") + "' where EInvoiceDataExcelId=" + x.EInvoiceDataExcelId + "");
                        }
                       
                    }
                    else
                    {
                        Global.Context.ExecuteQuery("update EInvoiceDataExcel set ErrorStatus='IRN Generated',AckNo=" + statusIron.InfoDtls.FirstOrDefault().Desc.AckNo + ",AckDt='" + statusIron.InfoDtls.FirstOrDefault().Desc.AckDt + "',Irn='" + statusIron.InfoDtls.FirstOrDefault().Desc.Irn + "', [Responce]='" + statusIron.Responce.Replace("'", "''") + "' where EInvoiceDataExcelId=" + x.EInvoiceDataExcelId + "");
                    }

                }

            }





        }
    }
}