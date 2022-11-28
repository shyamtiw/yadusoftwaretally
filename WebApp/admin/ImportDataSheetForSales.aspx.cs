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
using WebApp.admin.ReportModal;

namespace WebApp.admin
{
    public partial class ImportDataSheetForSales : BasePageClass
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
                if (ImportFileType.SelectedValue.ConvertInt() == 1)
                {
                    DataTable ObjGodwnList= ConnModal.FillDataTable("select NEWCAR_RCPT,comp_code,Godw_Code from godown_mst where comp_code="+SiteSession.Comp_MstSession.Comp_Code.Value.ToString()+" order by Godw_Code");

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
                        string strNumaric = "GSTAmt,TotalClaim,CrAmt,CrTax,TotalCredit,Recovered,Rejected,Balance,GST,BasicValue,DiscountSpot,DRF,AssessableValue,IGST28,Cess,TCS".ToUpper();
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
                                    ListDatasd.Add(new keydata() { key = str + Counts.ToString(), DataType = "Date" });
                                }
                                else if (strNumaric.Split(',').Contains(str))
                                {
                                    dataTable.Columns.Add(str + Counts.ToString());

                                    ListDatasd.Add(new keydata() { key = str + Counts.ToString(), DataType = "Decimal" });
                                }
                                else if (str.ToUpper() == ("Godw_Code").ToUpper())
                                {

                                    dataTable.Columns.Add(str + Counts.ToString());
                                    ListDatasd.Add(new keydata() { key = str + Counts.ToString(), DataType = "Numaric" });
                                }

                                else
                                {
                                    dataTable.Columns.Add(str + Counts.ToString());
                                    ListDatasd.Add(new keydata() { key = str + Counts.ToString(), DataType = "String" });
                                }

                            }
                            else
                            {

                                if (str.ToUpper().Contains("DATE"))
                                {

                                    dataTable.Columns.Add(str);
                                    ListDatasd.Add(new keydata() { key = str, DataType = "Date" });
                                }
                                else if (strNumaric.Split(',').Contains(str))
                                {
                                    dataTable.Columns.Add(str);

                                    ListDatasd.Add(new keydata() { key = str, DataType = "Decimal" });
                                }
                             

                                else
                                {
                                    dataTable.Columns.Add(str);
                                    ListDatasd.Add(new keydata() { key = str, DataType = "String" });
                                }
                            }




                        }


                    try
                    {
                        dataTable.Columns.Add("godw_code");
                        dataTable.Columns.Add("comp_code");
                        
                    }
                    catch (Exception ex)
                    {
                        
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

                    dataTable.AsEnumerable().ToList().ForEach(x => {
                        try
                        {
                            var Data = ObjGodwnList.AsEnumerable().Where(p => p["NEWCAR_RCPT"].ToString() == x["OutletCode"].ToString()).ToList().FirstOrDefault();
                            x["godw_code"] = Data["Godw_Code"].ToString();
                            x["comp_code"] = Data["comp_code"].ToString();
                        }
                        catch(Exception ex) { }

                    });




                    var loop = Math.Ceiling(Convert.ToDecimal(dataTable.Rows.Count) / 2000m);
                    OverAllRecore = dataTable.Rows.Count;
                    for (int i = 0; i < loop; i++)
                    {
                        var datax = dataTable.AsEnumerable().Skip(i * 2000).Take(2000).CopyToDataTable();
                        if (datax.Rows.Count > 0)
                        {

                            using (TransactionScope trans = new TransactionScope())
                            {
                                getdata(datax);

                                trans.Complete();
                            }
                            DoneRecored = DoneRecored + datax.Rows.Count;
                        }
                    }


                    //using (TransactionScope trans = new TransactionScope())
                    //{
                    //    getdata(dataTable);

                    //    trans.Complete();
                    //}

                    dataTable = new DataTable();
                        MessageBox.ShowMessage("Success", "Successfully import data", SiteKey.MessageType.success);
                    
                    #endregion
                }
                else if (ImportFileType.SelectedValue.ConvertInt() == 2)
                {

                }
            }
            catch (Exception ex)
            {
                String Message = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                if (Message.Contains("UNIQUE KEY")) { Message = "Record/Username already exists. Please choose another."; }
                string StrMess = "Complete:" + DoneRecored.ToString()+ "\n";
                StrMess = StrMess+ "Pending:" +( OverAllRecore- DoneRecored).ToString() + "\n";
                StrMess = StrMess + "Error:" + Message.Replace("'","") + "\n";


                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "alert('"+ StrMess + "');", true);
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
                using (SqlCommand cmd = new SqlCommand("ImportSPMilClaim"))
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

                    return cell.DateCellValue.ToString("dd-MMM-yyyy");
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

public partial class keydata

{

    public string key { get; set; }
    public string DataType { get; set; }
}

public partial class GetGodwnListNewCarRCPT
{
public  string NEWCAR_RCPT  { get;set;}
    public byte comp_code { get; set; }
    public byte Godw_Code  { get; set; }
}