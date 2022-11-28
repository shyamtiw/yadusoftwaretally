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


namespace WebApp.admin
{
    public partial class frmAutoDebitImport : BasePageClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {

            }
        }


        protected void Upload(object sender, EventArgs e)
        {
            //Upload and save the file
            int DoneRecored = 0;
            int OverAllRecore = 0;

            try
            {
             

                    #region ImportClaim

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
                    string strNumaric = "TRANSACTIONAMOUNT".ToUpper();
                    // write the header row
                    var headerRow = sheet.GetRow(0);
                    var ListDatasd = new List<keydata>();
                    foreach (var headerCell in headerRow)
                    {
                        string str = headerCell.ToString().Replace(".", "").Replace("/", "").Replace(" ", "").Replace("(", "").Replace(")", "").Replace("%", "");
                        var Counts = ListDatasd.Where(p => p.key.ToUpper() == str.ToUpper()).Count();


                        if (Counts > 0)
                        {
                            if (str.ToUpper().Contains("DATE"))
                            {
                                dataTable.Columns.Add(str + Counts.ToString());
                            }
                            else if (strNumaric.Split(',').Contains(str))
                            {
                                dataTable.Columns.Add(str + Counts.ToString());

                               
                            }
                            else
                            {
                                dataTable.Columns.Add(str + Counts.ToString());
                                ListDatasd.Add(new keydata() { key = str + Counts.ToString(), DataType = "String" });
                            }

                        }
                        else
                        {
                                dataTable.Columns.Add(str);
                                ListDatasd.Add(new keydata() { key = str, DataType = "String" });  
                        }
                    }

                 
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
                    dataTable.Columns.Add("Godw_Code");
                    dataTable.Columns.Add("Comp_Code");


                    foreach (DataRow dr in dataTable.Rows)
                    {
                        dr["Godw_Code"] = SiteSession.GodownId;
                        dr["Comp_Code"] = SiteSession.Comp_MstSession.Comp_Code.Value;
                    }

                    using (TransactionScope trans = new TransactionScope())
                    {
                        getdata(dataTable.AsEnumerable().Where(p=> Common.Convertstring( p["TRANSACTIONOUTLET"]).Length>0).CopyToDataTable());

                        trans.Complete();
                    }

                    dataTable = new DataTable();
                    MessageBox.ShowMessage("Success", "Successfully import data", SiteKey.MessageType.success);

                    #endregion
                
                
            }
            catch (Exception ex)
            {
                String Message = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                if (Message.Contains("UNIQUE KEY")) { Message = "Record/Username already exists. Please choose another."; }
                string StrMess = "Complete:" + DoneRecored.ToString() + "\n";
                StrMess = StrMess + "Pending:" + (OverAllRecore - DoneRecored).ToString() + "\n";
                StrMess = StrMess + "Error:" + Message.Replace("'", "") + "\n";


                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "alert('" + StrMess + "');", true);
                MessageBox.ShowMessage("Error", Message, SiteKey.MessageType.danger);
            }



        }


        private void getdata(DataTable dtDetails)
        {
            string constr = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;

            DataRow dr = dtDetails.NewRow();

            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("ImportDebitEntry"))
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Details", dtDetails);
                    cmd.Parameters.AddWithValue("@Comp_Code",SiteSession.Comp_MstSession.Comp_Code.Value);
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
                            var  Dates = Common.DataForSQLwITHtIME(cell.ToString());
                            if (Dates != null)
                            {
                                DateTimes = Dates;
                            }
                            else if (cell.DateCellValue.ToString("dd-MMM-yyyy") != "31-Dec-9999")
                            {

                                DateTimes = cell.DateCellValue.ToString("dd-MMM-yyyy hh:mm tt");
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

                                DateTimes = cell.DateCellValue.ToString("dd-MMM-yyyy hh:mm tt");
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
            catch(Exception ex) { return ""; }



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
