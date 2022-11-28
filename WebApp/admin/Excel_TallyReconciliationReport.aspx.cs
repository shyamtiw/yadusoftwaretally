using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
using Business;
using System.Data;
using NPOI.HSSF.UserModel;
using System.IO;
using NPOI.SS.UserModel;
using ClosedXML.Excel;
using WebApp.admin.ReportModal;
using Class;

namespace WebApp.admin
{
    public partial class Excel_TallyReconciliationReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Common.BindControl(Branchid, SiteSession.GetGodawanListSession.ToList(), "Value", "Id", "Select");

            }
        }

        protected void saveAccountHead_Click(object sender, EventArgs e)
        {
            if (Branchid.SelectedValue.ConvertInt() > 0 && FromDate.Text.Length > 0 && ToDate.Text.Length > 0)
            {




                DataTable dataTable = new DataTable();


                DataTable Listdata = DataMangementJsonTwoData.GetDGetDataFromTallyRecod(FromDate.Text.DateConvertTextMatchCase(), ToDate.Text.DateConvertTextMatchCase(), Branchid.SelectedValue.ConvertInt());

                try
                {
                    ExportExcel(Listdata);
                }
                catch (Exception ex) { }
            }
        }
        private string ValuesStrings(ICell cell, string str)
        {

            try
            {

                if (str == "Date")
                {

                    return cell.DateCellValue.ToString("dd/MM/yyyy");
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
                FileNames.Text = StuclsIds.Text;
            }
        }

        private void ExportExcel(DataTable dt)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Trialbalance");

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=SqlExport.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }

        protected void ImportaallyData_Click(object sender, EventArgs e)
        {
            try
            {
               
                    ErrorNote.ForeColor = System.Drawing.Color.Yellow;
                    ErrorNote.Text = "Waiting : Importing data";
                    
                    HSSFWorkbook hssfwb;

                    int xc = 1;
                    string strmessage = "";
                    string FileNamesss = Server.MapPath("~/upload/") + FileNames.Text;
                    using (FileStream file = new FileStream(FileNamesss, FileMode.Open, FileAccess.Read))
                    {
                        hssfwb = new HSSFWorkbook(file);
                    }


                    var ItemList = new List<TallyConvertTable>();

                    var sheet = hssfwb.GetSheetAt(0); // zero-based index of your target sheet
                    var dataTable = new DataTable(sheet.SheetName);
                    string strNumaric = "GSTAmt,TotalClaim,CrAmt,CrTax,TotalCredit,Recovered,Rejected,Balance,GST,BasicValue,DiscountSpot,DRF,AssessableValue,IGST28,Cess,TCS".ToUpper();
                    // write the header row
                    var headerRow = sheet.GetRow(0);
                    var ListDatasd = new List<keydata>();
                    foreach (var headerCell in headerRow)
                    {
                        string str = Common.ReplaceChar(headerCell.ToString()).Replace(Environment.NewLine, "").ToString().Replace(".", "").Replace(",", "").Replace("/", "").Replace(" ", "").Replace("(", "").Replace(")", "").Replace("%", "").Replace(@"\", "");
                        dataTable.Columns.Add(new DataColumn(str) { DefaultValue = "", Caption = Common.ReplaceChar(headerCell.ToString()).Replace(Environment.NewLine, "").ToString().ToString(), DataType = typeof(String) });

                    }

                    //BranchId Get
                    int BranchDataId = 0;
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

                        try
                        {
                            BranchDataId = SiteSession.GetGodawanListSession.Where(p => p.Value.Contains(dtRow["Branch"].ToString())).FirstOrDefault().Id;
                        }
                        catch { }
                        break;

                    }
                        //end 

                        var TallyColumn = dataTable.Columns;
                    List<CollSpecification> CollList = new List<CollSpecification>();
                    DataTable MaperData = OtherSqlConn.FillDataTable("select * from DMSTallyLedgerMapper where GodwCode=" + BranchDataId + "");
                    foreach (DataColumn dc in TallyColumn)
                    {
                        var dr = MaperData.AsEnumerable().Where(p => p["TallyLedgerName"].ToString().ToUpper() == dc.Caption.ToUpper()).FirstOrDefault();
                        if (dr != null)
                        {
                            CollList.Add(new CollSpecification()
                            {
                                Caption = dc.Caption,
                                CollName = dc.ColumnName,
                                DMSLedger = dr["DMSLedgerName"].ToString(),
                                TaxType = dr["TaxType"].ToString(),
                                tax = dr["GSTCategory"].ToString().ConvertDecimal(),

                            });
                        }

                    }

                    var TaxableColl = CollList.Where(p => p.TaxType.ToUpper() == "Taxable".ToUpper()).ToList();
                    var CGSTColl = CollList.Where(p => p.TaxType.ToUpper() == "CGST".ToUpper()).ToList();
                    var SGSTColl = CollList.Where(p => p.TaxType.ToUpper() == "SGST".ToUpper()).ToList();
                    var IGSTColl = CollList.Where(p => p.TaxType.ToUpper() == "IGST".ToUpper()).ToList();
                    var CessColl = CollList.Where(p => p.TaxType.ToUpper() == "CESS".ToUpper()).ToList();
                    var TCSColl = CollList.Where(p => p.TaxType.ToUpper() == "CESS".ToUpper()).ToList();
                    List<TallyConvertTable> ListData = new List<TallyConvertTable>();
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

                    if (dtRow["Particulars"].ToString() != "Grand Total")
                    {
                        List<TaxCategorySpecification> taxCat = new List<TaxCategorySpecification>();

                        TaxableColl.ForEach(p =>
                        {
                            if (dtRow[p.CollName].ToString().ConvertDecimal() > 0)
                            {
                                if (taxCat.Where(px => px.tax == p.tax).Count() == 0)
                                {
                                    taxCat.Add(new TaxCategorySpecification() { tax = p.tax });
                                }
                            }

                        });
                        taxCat.ForEach(ppt =>
                        {
                            var Item = new TallyConvertTable();
                            Item.partygstIn = dtRow["GSTINUIN"].ToString();
                            Item.partyName = dtRow["Particulars"].ToString();
                            Item.voucherDate = dtRow["Date"].ToString();
                            Item.voucherNumber = dtRow["VoucherNo"].ToString();
                            Item.MXCATE = ppt.tax;
                            var TaxableDataColl = TaxableColl.Where(p => p.tax == ppt.tax).ToList();
                            if (TaxableDataColl.Count() > 0)
                            {
                                var taxableamt = 0m;
                                TaxableDataColl.ForEach(cv => { taxableamt += dtRow[cv.CollName].ToString().ConvertDecimal(); });
                                Item.TAXABLEVALUE = taxableamt;

                                var Igstamt = 0m;
                                IGSTColl.Where(p => p.tax == ppt.tax).ToList().ForEach(cv => { Igstamt += dtRow[cv.CollName].ToString().ConvertDecimal(); });
                                Item.IGSTAMT = Igstamt;
                                Item.IGSTRATE = ppt.tax;

                                var CGSTPer = Common.RoundMath(ppt.tax / 2m);
                                var CGSTamt = 0m;
                                CGSTColl.Where(p => p.tax == CGSTPer).ToList().ForEach(cv => { CGSTamt += dtRow[cv.CollName].ToString().ConvertDecimal(); });
                                Item.CGSTAMT = CGSTamt;
                                Item.CGSTRATE = CGSTPer;

                                var SGSTamt = 0m;
                                SGSTColl.Where(p => p.tax == CGSTPer).ToList().ForEach(cv => { SGSTamt += dtRow[cv.CollName].ToString().ConvertDecimal(); });
                                Item.SGSTAMT = SGSTamt;
                                Item.SGSTRATE = CGSTPer;



                            }
                            var CessCollAmt = 0m;
                            var CessCollTax = 0m;
                            CessColl.ToList().ForEach(cv =>
                            {
                                try
                                {
                                    CessCollAmt += dtRow[cv.CollName].ToString().ConvertDecimal();
                                    CessCollTax = cv.tax;
                                }
                                catch { }

                            });
                            Item.KeralaFloodCessAmount = CessCollAmt;
                            Item.KeralaFloodCessRate = CessCollTax;

                            var TCSCollAmt = 0m;
                            var TCSCollTax = 0m;
                            CessColl.ToList().ForEach(cv =>
                            {
                                try
                                {
                                    TCSCollAmt += dtRow[cv.CollName].ToString().ConvertDecimal();
                                    TCSCollTax = cv.tax;
                                }
                                catch { }

                            });
                            Item.TCSAmount = TCSCollAmt;
                            Item.TCSRate = TCSCollTax;

                            Item.GrossAmount = dtRow["GrossTotal"].ToString().ConvertDecimal();

                            try
                            {
                                Item.godwnid = BranchDataId;
                            }
                            catch { }
                            ItemList.Add(Item);



                        });

                        if (taxCat.Count() == 0)
                        {
                            var Item = new TallyConvertTable();
                            Item.partygstIn = dtRow["GSTINUIN"].ToString();
                            Item.partyName = dtRow["Particulars"].ToString();
                            Item.voucherDate = dtRow["Date"].ToString();
                            Item.voucherNumber = dtRow["VoucherNo"].ToString();
                            try
                            {
                                Item.godwnid = SiteSession.GetGodawanListSession.Where(p => p.Value.Contains(dtRow["Branch"].ToString())).FirstOrDefault().Id;
                            }
                            catch { }
                            ItemList.Add(Item);
                        }
                    }

                    }
                    DataTable dt = CreateDatatable.GenericListToDataTableNullAlowed(ItemList.ToList());
                    OtherSqlConn.ExecuteSTORETallyDataImport(dt);
                    ErrorNote.ForeColor = System.Drawing.Color.Green;
                    ErrorNote.Text = "Success: Successfully import data";
                    MessageBox.ShowMessage("Success", "Successfully import data", SiteKey.MessageType.success);
                

             
               

            }
            catch (Exception ex)
            {
                String Message = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                if (Message.Contains("UNIQUE KEY")) { Message = "Record/Username already exists. Please choose another."; }
                MessageBox.ShowMessage("Error", Message, SiteKey.MessageType.danger);
                ErrorNote.ForeColor =  System.Drawing.Color.Red;
                ErrorNote.Text = "Error: " + Message;

            }
        }
    }
}


public partial class TallyConvertTable
{

    public string partyName { get; set; }
    public string partygstIn { get; set; }
    public string placeOfSupply
    { get; set; } = "";
    public decimal MXCATE { get; set; }
    public string voucherNumber
    { get; set; }
    public string voucherDate
    { get; set; }
    public decimal TAXABLEVALUE
    { get; set; }
    public decimal IGSTRATE
    { get; set; }
    public decimal IGSTAMT
    { get; set; }
    public decimal CGSTRATE
    { get; set; }
    public decimal CGSTAMT
    { get; set; }
    public decimal SGSTRATE
    { get; set; }
    public decimal SGSTAMT
    { get; set; }
    public decimal KeralaFloodCessRate
    { get; set; }
    public decimal KeralaFloodCessAmount
    { get; set; }
    public decimal TCSRate
    { get; set; }
    public decimal TCSAmount
    { get; set; }
    public decimal GrossAmount
    { get; set; }
    public int  godwnid
    { get; set; }
}

public class CollSpecification
{
    public string CollName { get; set; }
    public string Caption { get; set; }
    public string DMSLedger { get; set; }
    public string TaxType { get; set; }
    public decimal tax { get; set; }

}

public class TaxCategorySpecification
{
    public decimal tax { get; set; }


}
