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

namespace WebApp.admin
{
    public partial class FinanceDataList : BasePageClass
    {
        private static int PageSize = 10;
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



        [WebMethod]
        public static string GetCustomers(int pageIndex, string name, string FromDate, string ToDate, string BranchId, string Status, string  FilterbyDt)
        {
            BranchId = BranchId == "All" ? SiteSession.LoginUser.Multi_loc : BranchId;
            Status = Status== "All" ? "Payout Received,Payment Pending,Payout Pending,Complete" : Status;

            



            string f = "", t = "",fdt="";

            if (FromDate.Length > 0)
            {
                f = FromDate.DateConvertTextMatchCaseyyyymmddd().ToString("dd-MMM-yyyy");
            }
            if (ToDate.Length > 0)
            {
                t = ToDate.DateConvertTextMatchCaseyyyymmddd().ToString("dd-MMM-yyyy");
            }

          


            string query = "[FinanceListSearch]";
            SqlCommand cmd = new SqlCommand(query);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.AddWithValue("@SearchTerm", name);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
            cmd.Parameters.AddWithValue("@PageSize", PageSize);

            cmd.Parameters.AddWithValue("@GodwnId", BranchId);
            cmd.Parameters.AddWithValue("@ExportData", 0);


            cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@FromDate", f);
            cmd.Parameters.AddWithValue("@ToDate", t);
            cmd.Parameters.AddWithValue("@FilterbyDt", FilterbyDt.ConvertInt());


            return GetData(cmd, pageIndex).GetXml();
        }

        private static DataSet GetData(SqlCommand cmd, int pageIndex)
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
                        DataTable dt = new DataTable("Pager");
                        dt.Columns.Add("PageIndex");
                        dt.Columns.Add("PageSize");
                        dt.Columns.Add("RecordCount");
                        dt.Rows.Add();
                        dt.Rows[0]["PageIndex"] = pageIndex;
                        dt.Rows[0]["PageSize"] = PageSize;
                        dt.Rows[0]["RecordCount"] = cmd.Parameters["@RecordCount"].Value;
                        ds.Tables.Add(dt);
                        return ds;
                    }
                }
            }
        }

        protected void exportdata_Click(object sender, EventArgs e)
        {


            var  BranchIds = BranchId.SelectedValue.ToString() == "All" ? SiteSession.LoginUser.Multi_loc : BranchId.SelectedValue.ToString();
           var  Statuss = Status.SelectedValue.ToString() == "All" ? "Complete,Update,Pending" : Status.SelectedValue.ToString();





            string f = "", t = "", fdt = "";

            if (FromDate.Text.Length > 0)
            {
                f = FromDate.Text.DateConvertTextMatchCaseyyyymmddd().ToString("dd-MMM-yyyy");
            }
            if (ToDate.Text.Length > 0)
            {
                t = ToDate.Text.DateConvertTextMatchCaseyyyymmddd().ToString("dd-MMM-yyyy");
            }




            string query = "[FinanceListSearch]";
            SqlCommand cmd = new SqlCommand(query);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SearchTerm", txtSearch.Text);
            cmd.Parameters.AddWithValue("@Status", Statuss);
            cmd.Parameters.AddWithValue("@PageIndex", 0);
            cmd.Parameters.AddWithValue("@PageSize", 0);

            cmd.Parameters.AddWithValue("@GodwnId", BranchIds);
            cmd.Parameters.AddWithValue("@ExportData", 1);


            cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@FromDate", f);
            cmd.Parameters.AddWithValue("@ToDate", t);
            cmd.Parameters.AddWithValue("@FilterbyDt", FilterbyDt.SelectedValue.ConvertInt());
           DataTable Table=  GetData(cmd, 0).Tables[0];
            Table.Columns.Remove(Table.Columns["Action"]);
            ExportExcel(Table);




        }

        private void ExportExcel(DataTable dt)
        {
            try
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt, "Finance Data");

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=FinanceDataList.xlsx");
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
    