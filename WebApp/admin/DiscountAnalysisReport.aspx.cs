using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
using Business;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;
using System.IO;
using ClosedXML.Excel;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;

namespace WebApp.admin
{
    public partial class DiscountAnalysisReport :  BasePageClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrWhiteSpace(SiteSession.LoginUser.Multi_loc))
                {



                    Common.BindControl(BranchId, SiteSession.GetGodawanListSession.ToList(), "Value", "Id", "All");




                    //var obj = Global.Context.ExecuteStoreQuery<reciptdata>("select ReceiptId,RecNo,RecptDate,(substitute+CustomerName) as CustomerName,Amount from Receipt where Comp_code=" + SiteSession.Compnay.Comp_Code + " and godw_code in(" + SiteSession.LoginUser.Godw_code + ")  and  DepartmentId  in(" + SiteSession.LoginUser.DepartmentId + ")").ToList();
                    //Common.BindControl(gvlocation, obj);
                }
            }
        }

        protected void GetData_Click(object sender, EventArgs e)
        {
          var   BranchIds = BranchId.SelectedValue == "All" ? SiteSession.LoginUser.Multi_loc : BranchId.SelectedValue.ToString();
           var  Statuss = Status.SelectedValue == "All" ? "Complete,Update,Pending" : Status.SelectedValue.ToString();


            string f = "", t = "";

            if (FromDate.Text.Length > 0)
            {
                f = FromDate.Text.DateConvertTextMatchCase().ToString("dd-MMM-yyyy");
            }
            if (ToDate.Text.Length > 0)
            {
                t = ToDate.Text.DateConvertTextMatchCase().ToString("dd-MMM-yyyy");
            }

            string query = "[DiscountAnalysisReport]";
            SqlCommand cmd = new SqlCommand(query);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SearchTerm", txtSearch.Text);
            cmd.Parameters.AddWithValue("@Status", Statuss);
           
            cmd.Parameters.AddWithValue("@GodwnId", BranchIds);
            


            
            cmd.Parameters.AddWithValue("@FromDate", f);
            cmd.Parameters.AddWithValue("@ToDate", t);
            cmd.Parameters.AddWithValue("@FilterbyDt", FilterbyDt.SelectedValue.ConvertInt());


            DataTable Data = GetDataStore(cmd).Tables[0];


            try
            {
                ExportExcel(Data);
            }
            catch { }

            //var workbook = new HSSFWorkbook();
            //var sheet = workbook.CreateSheet();
            //ICellStyle    _doubleCellStyle = workbook.CreateCellStyle();


            //ICellStyle cellStyleBorder = workbook.CreateCellStyle();
            //cellStyleBorder.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            //cellStyleBorder.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            //cellStyleBorder.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            //cellStyleBorder.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
           


            //IRow row = sheet.CreateRow(0);
            //for (int x = 0; x < Data.Tables[0].Columns.Count; x++)
            //{
            //    row.CreateCell(x, CellType.String).SetCellValue(Data.Tables[0].Columns[x].Caption);
            //}

            //int i = 1;


            //foreach (DataRow _mp in Data.Tables[0].Rows)
            //{
            //    IRow row2 = sheet.CreateRow(i);
            //    for (int x = 0; x < Data.Tables[0].Columns.Count; x++)
            //    {

            //        row2.CreateCell(x, CellType.String).SetCellValue(_mp[x].ToString());
            //    }

            //    i = i + 1;
            //}



            //string filename = "Export_" + Guid.NewGuid() + ".xls";
            //string fullpath = Server.MapPath("~/ExportExcelFiles/") + filename;

            //using (FileStream stream = new FileStream(fullpath, FileMode.Create, FileAccess.Write))
            //{


            //    workbook.Write(stream);

            //}

            //downloadexcel.NavigateUrl = "~/ExportExcelFiles/" + filename;
            //downloadexcel.Visible = true;


        }



        private static DataSet GetDataStore(SqlCommand cmd)
        {
            string strConnString = "Data Source=" + SiteSession.DatabaseIp + ";Initial Catalog=" + SiteSession.DatabaseName + ";persist security info=True;user id=" + SiteSession.DatabseUserName + ";password=" + SiteSession.DatabasePassword + ";multipleactiveresultsets=True;Timeout=300";
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    cmd.CommandTimeout = int.MaxValue;
                    sda.SelectCommand = cmd;
                    using (DataSet ds = new DataSet())
                    {
                        sda.Fill(ds, "Customers");
                       
                        
                        return ds;
                    }
                }
            }
        }


        private void ExportExcel(DataTable dt)
        {
            try
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt, "Discount Analysis Data");

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Discount Analysis.xlsx");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
            }
            catch { }
        }
    }
}