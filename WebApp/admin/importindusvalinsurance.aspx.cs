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
    public partial class importindusvalinsurance : BasePageClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Upload(object sender, EventArgs e)
        {
            //Upload and save the file

            ErrorNote.Text = "";

            string sstestss = "";
            try
            {



                #region ImportClaim
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






                    var sheet = hssfwb.GetSheetAt(0);
                    var dataTable = new DataTable(sheet.SheetName);

                    // write the header row
                    var headerRow = sheet.GetRow(0);
                    var ListDatasd = new List<keydata>();
                    foreach (var headerCell in headerRow)
                    {
                        string str = headerCell.ToString().Replace(".", "").Replace("/", "").Replace(" ", "").Replace("(", "").Replace(")", "").Replace("%", "").Replace(@"\", "").Replace("#", "").Replace("64", "sixtyfour");
                        var Counts = ListDatasd.Where(p => p.key.ToUpper() == str.ToUpper()).Count();

                        if (Counts > 0)
                        {
                            dataTable.Columns.Add(str + Counts.ToString(), Type.GetType("System.String"));
                            ListDatasd.Add(new keydata() { key = str, DataType = "Date" });
                        }
                        else
                        {
                            dataTable.Columns.Add(str, Type.GetType("System.String"));
                            ListDatasd.Add(new keydata() { key = str, DataType = "Date" });

                        }

                    }









                    // write the rest
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
                    dataTable.Columns.Remove(dataTable.Columns[0]);


                    using (TransactionScope trans = new TransactionScope())
                    {
                        getdata(dataTable.AsEnumerable().Where(cc => cc["PolicyNo"].ToString().Length > 0).CopyToDataTable());

                        trans.Complete();
                    }
                    MessageBox.ShowMessage("Success", "Successfully import data", SiteKey.MessageType.success);
                }
                #endregion
                FileName.Text = "";

            }
            catch (Exception ex)
            {
                String Message = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                if (Message.Contains("UNIQUE KEY")) { Message = "Record/Username already exists. Please choose another."; }
                MessageBox.ShowMessage("Error", Message, SiteKey.MessageType.danger);

                ErrorNote.Text = ErrorNote.Text + "<br/>" + Message;

            }



        }


        private void getdata(DataTable dtDetails)
        {



            string constr = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;

            DataRow dr = dtDetails.NewRow();

            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("sp_importindusvalinsurance"))
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Details", dtDetails);
                    cmd.Parameters.AddWithValue("@Comp_Code", SiteSession.Comp_MstSession.Comp_Code);
                    cmd.ExecuteNonQuery();

                }
            }

        }



        private string ValuesStrings(ICell cell, string str)
        {

            try
            {

                if (str.ToUpper() == "DATE")
                {
                    string  DateTimes = "";
                    try
                    {
                        if (!string.IsNullOrWhiteSpace(cell.ToString()))
                        {
                          var Date=  Common.DataForSQL(cell.ToString());
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


        protected void StuclsIds_TextChanged(object sender, EventArgs e)
        {
            if (StuclsIds.Text.Length > 0)
            {
                FileName.Text = StuclsIds.Text;
            }
        }

    }

}
