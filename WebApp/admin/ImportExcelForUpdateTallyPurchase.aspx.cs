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
    public partial class ImportExcelForUpdateTallyPurchase : System.Web.UI.Page
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



                    var IdRow = new List<Business.ImportExcel>();




                    var sheet = hssfwb.GetSheetAt(0); // zero-based index of your target sheet
                    var dataTable = new DataTable(sheet.SheetName);

                    var headerRow = sheet.GetRow(0);
                    foreach (var headerCell in headerRow)
                    {
                        dataTable.Columns.Add(headerCell.ToString());
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

                    //10,37VIN

                    string MULInvoicenumber = string.Join(",", dataTable.AsEnumerable().GroupBy(p => p[13]).Select(p => "'" + p.Key.ToString() + "'").ToArray());
                    string VIN = string.Join(",", dataTable.AsEnumerable().GroupBy(p => p[40]).Select(p => "'" + p.Key.ToString() + "'").ToArray());
                    var FilterDataDB = Global.Context.ExecuteStoreQuery<GETFilterTrans>("select Max(UTD) as UTD, Trans_Ref_Num,vin from  gd_fdi_trans where Trans_Ref_Num in (" + MULInvoicenumber + ") and vin in (" + VIN + ")  and len(isnull(Trans_Ref_Num,''))>0 and len(isnull(vin,''))>0 and isnull(AutoVYN_Flag,'')='' and trans_type='VP' group by Trans_Ref_Num,vin").ToList();
                    var loop = Math.Ceiling(Convert.ToDecimal(FilterDataDB.Count) / 20m);
                    for (int i = 0; i < loop; i++)
                    {
                        var dtPage = FilterDataDB.Skip(i * 20).Take(20).ToList();
                        string strupdateData = "";
                        dtPage.ForEach(p =>
                        {
                            DataRow dr = dataTable.AsEnumerable().Where(xpc => xpc[13].ToString() == p.Trans_Ref_Num && xpc[40].ToString() == p.vin).FirstOrDefault();

                            if (strupdateData.Length > 0)
                            {
                                strupdateData = strupdateData + ";update gd_fdi_trans set basic_price=" + dr[41].ToString() + " ,taxable_value=" + dr[32].ToString() + ", service_amount=" + dr[7].ToString() + ",AutoVYN_Flag='1' ,ge15=" +( dr[44].ToString().Length>0? dr[44].ToString():"0") + " where utd=" + p.UTD + "";
                            }
                            else
                            {
                                strupdateData = "update gd_fdi_trans set basic_price=" + dr[41].ToString() + " ,taxable_value=" + dr[32].ToString() + ", service_amount=" + dr[7].ToString() + ",AutoVYN_Flag='1' ,ge15=" + Common.ConvertDecimal(dr[44]) + " where utd=" + p.UTD + "";
                            }
                            strupdateData = strupdateData + ";update gd_fdi_trans_charges set  Charge_AMT=" + Common.ConvertDecimal(dr[35]) + "  where utd='" + p.UTD + "' and Charge_type='IGVA'";
                            strupdateData = strupdateData + ";update gd_fdi_trans_charges set  Charge_AMT=" + Common.ConvertDecimal(dr[36]) + "  where utd='" + p.UTD + "' and Charge_type='GCVA'";
                            strupdateData = strupdateData + ";update gd_fdi_trans_charges set  Charge_AMT=" + Common.ConvertDecimal(dr[47]) + "  where utd='" + p.UTD + "' and Charge_type='IGSA'";
                            strupdateData = strupdateData + ";update gd_fdi_trans_charges set  Charge_AMT=" + Common.ConvertDecimal(dr[48]) + "  where utd='" + p.UTD + "' and Charge_type='GCSA'";
                            strupdateData = strupdateData + ";update gd_fdi_trans_charges set  Charge_AMT=" + Common.ConvertDecimal(dr[49]) + "  where utd='" + p.UTD + "' and Charge_type='TCSA'";
                            strupdateData = strupdateData + ";update gd_fdi_trans_charges set  Charge_AMT=" + Common.ConvertDecimal(dr[33]) + "  where utd='" + p.UTD + "' and Charge_type='CGVA'";
                            strupdateData = strupdateData + ";update gd_fdi_trans_charges set  Charge_AMT=" + Common.ConvertDecimal(dr[34]) + "  where utd='" + p.UTD + "' and Charge_type='SGVA'";

                        });

                        if (strupdateData.Length > 0)
                        {
                            using (TransactionScope trans = new TransactionScope())
                            {

                                getdata(strupdateData);

                                trans.Complete();
                            }
                        }

                    }



                    if (sstestss.Length > 0)
                    {
                        ErrorNote.Text = "ERROR: problem with GODOWN CODE  on this Document Number: " + sstestss;
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


        private void getdata(string dtDetails)
        {



            string constr = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;



            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("ExecuteQuery"))
                {
                    cmd.Connection = con;
                    cmd.CommandTimeout = int.MaxValue;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@str", dtDetails);

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


        protected void StuclsIds_TextChanged(object sender, EventArgs e)
        {
            if (StuclsIds.Text.Length > 0)
            {
                FileName.Text = StuclsIds.Text;
            }
        }

    }

}

public partial class GETFilterTrans
{
    public string Trans_Ref_Num { get; set; }
    public string vin { get; set; }

    public int UTD { get; set; }
}
