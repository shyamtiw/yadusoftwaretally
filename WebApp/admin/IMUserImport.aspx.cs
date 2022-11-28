using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
using Business;
using NPOI.HSSF.UserModel;
using System.IO;
using System.Data;
using NPOI.SS.UserModel;
using System.Transactions;
using System.Data.SqlClient;
using System.Globalization;

namespace WebApp.admin
{
    public partial class IMUserImport : BasePageClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Upload(object sender, EventArgs e)
        {
            //Upload and save the file


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



                    var IdRow = new List<Business.ImportExcel>();




                    var sheet = hssfwb.GetSheetAt(0); // zero-based index of your target sheet
                    var dataTable = new DataTable(sheet.SheetName);
                  
                    // write the header row
                    var headerRow = sheet.GetRow(0);
                  
                    foreach (var headerCell in headerRow)
                    {
                        string str = headerCell.ToString().Replace(".", "").Replace("/", "").Replace(" ", "").Replace("(", "").Replace(")", "").Replace("%", "").Replace(@"\", "").Replace("#", "");

                        if (!string.IsNullOrWhiteSpace(str) && str.Length > 0)
                        {
                            dataTable.Columns.Add(str, Type.GetType("System.String"));
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
                        if (dtRow["FirstName"].ToString().Length > 0)
                        {
                            dataTable.Rows.Add(dtRow);
                        }
                    }

                    foreach (DataRow dr in dataTable.AsEnumerable().OrderBy(p=> Convert.ToInt32( p["DesignationID"])).CopyToDataTable().Rows)
                    {
                        getdataSameBD(dr);
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

              

            }

          
        }
        public string ToTitleCase(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }

        private void getdataSameBD(DataRow  dtDetails )
        {

            var ConectionString = "Data Source=dealercrm.cejxtcrkhjcp.ap-south-1.rds.amazonaws.com;Initial Catalog=dealercrm;persist security info=True;user id=DCRMAdmin;password=DCRMProdMaruTi#22; multipleactiveresultsets=True;Timeout=30";

            string Password = ToTitleCase(Common.RandomString(6)) + "@123";

            using (SqlConnection con = new SqlConnection(ConectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("sp_SubmitUserandUserDetailWithAutoynDefault"))
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FirstName", dtDetails["FirstName"]);
                    cmd.Parameters.AddWithValue("@LastName", dtDetails["LastName"]);
                    cmd.Parameters.AddWithValue("@BusinessLineId", dtDetails["BusinessLineID"]);
                    cmd.Parameters.AddWithValue("@DateOfBirth",  dtDetails["DateOfBirth"]);
                    cmd.Parameters.AddWithValue("@DateofJoining", dtDetails["DateofJoining"]);
                    cmd.Parameters.AddWithValue("@primaryContactNo", dtDetails["PrimaryContactNumber"]);
                    cmd.Parameters.AddWithValue("@DesignationId", dtDetails["DesignationID"]);
                    cmd.Parameters.AddWithValue("@EmailId", dtDetails["Email"]);
                    cmd.Parameters.AddWithValue("@QualificationID", dtDetails["QualificationID"]);
                    cmd.Parameters.AddWithValue("@DealerId", dtDetails["Dealerid"]);
                    cmd.Parameters.AddWithValue("@ProcessType", dtDetails["ProcessType"]);
                    cmd.Parameters.AddWithValue("@Password", dtDetails["Password"]);

                    DataTable t1 = new DataTable();
                    using (SqlDataAdapter a = new SqlDataAdapter(cmd))
                    {
                        a.Fill(t1);
                    }

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


        protected void StuclsIds_TextChanged(object sender, EventArgs e)
        {
            if (StuclsIds.Text.Length > 0)
            {
                FileName.Text = StuclsIds.Text;
            }
        }



    }
}