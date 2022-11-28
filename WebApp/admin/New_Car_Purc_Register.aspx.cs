using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
using Business;
using System.Transactions;
using Class;

namespace WebApp.admin
{
    public partial class New_Car_Purc_Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void saveAccountHead_Click(object sender, EventArgs e)
        {
            if (FileName.Text.Length > 0)
            {
                HSSFWorkbook hssfwb;

                int xc = 1;
                string strmessage = "";


                string FileNamesss = Server.MapPath("~/upload/") + FileName.Text;
                using (FileStream file = new FileStream(FileNamesss, FileMode.Open, FileAccess.Read))
                {
                    hssfwb = new HSSFWorkbook(file);
                }



                var IdRow = new List<Business.ImportExcel>();


                var sheet = hssfwb.GetSheetAt(0); // zero-based index of your target sheet
                var dataTable = new DataTable(sheet.SheetName);
                dataTable.Columns.Add("Text", Type.GetType("System.DateTime"));


                for (int i = 1; i < sheet.PhysicalNumberOfRows; i++)
                {
                    var sheetRow = sheet.GetRow(i);
                    var dtRow = dataTable.NewRow();
                    dtRow.ItemArray = dataTable.Columns
                        .Cast<DataColumn>()
                        .Select(c =>
                        ValuesStrings((sheetRow.GetCell(c.Ordinal, MissingCellPolicy.CREATE_NULL_AS_BLANK)), c.Caption.ToUpper().Contains("DATE") ? "Date" : "String")
                        )
                        .ToArray();
                    dataTable.Rows.Add(dtRow);
                }



                using (TransactionScope trans = new TransactionScope())
                {
                    getdata(dataTable);

                    trans.Complete();
                }


            }
            }

        private void getdata(DataTable dtDetails)
        {



            string constr = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;

            DataRow dr = dtDetails.NewRow();

            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("ImportEInvoice"))
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Details", dtDetails);
                   
                    cmd.ExecuteNonQuery();

                }
            }

        }


        private string ValuesStrings(ICell cell, string str)
        {

            try
            {

                if (str == "Date")
                {
                    string DateTimes = "";
                    try
                    {
                        if (!string.IsNullOrWhiteSpace(cell.ToString()))
                        {
                            var Date = Common.DataForSQL(cell.ToString());
                            if (Date.Length > 0)
                            {
                                DateTimes = Date;
                            }
                            else if (cell.DateCellValue.ToString("dd-MMM-yyyy") != "31-Dec-9999")
                            {

                                DateTimes = cell.DateCellValue.ToString("dd-MMM-yyyy");
                            }
                            else
                            {
                                DateTimes = "NULL";
                            }

                        }
                        else
                        {
                            if (cell.DateCellValue.ToString("dd-MMM-yyyy") != "31-Dec-9999")
                            {

                                DateTimes = cell.DateCellValue.ToString("dd-MMM-yyyy");
                            }
                            else
                            {
                                DateTimes = "NULL";
                            }
                        }
                    }
                    catch
                    {
                        DateTimes = "NULL";
                    }
                    return DateTimes;
                }



                else
                {
                    if (cell.CellType == NPOI.SS.UserModel.CellType.Formula)
                    {
                        try
                        {
                            return cell.NumericCellValue.ToString();
                        }
                        catch
                        {
                            return cell.StringCellValue;
                        }

                    }
                    else
                    {
                        return cell.ToString();
                    }
                }

            }
            catch { return ""; }



        }
    }
}