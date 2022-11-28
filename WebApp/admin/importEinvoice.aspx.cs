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
    public partial class importEinvoice : System.Web.UI.Page
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
                    string strNumaric = "GSTAmt,TotalClaim,CrAmt,CrTax,TotalCredit,Recovered,Rejected,Balance,GST".ToUpper();
                    // write the header row
                    var headerRow = sheet.GetRow(0);
                    var ListDatasd = new List<keydata>();
                    foreach (var headerCell in headerRow)
                    {
                        string str = headerCell.ToString().Replace(".", "").Replace("/", "").Replace(" ", "").Replace("(", "").Replace(")", "").Replace("%", "").Replace(@"\", "").Replace("#", "");
                        var Counts = ListDatasd.Where(p => p.key.ToUpper() == str.ToUpper()).Count();

                        if (Counts > 0)
                        {


                            if (str.ToUpper().Contains("DATE"))
                            {

                                dataTable.Columns.Add(str + Counts.ToString(), Type.GetType("System.String"));
                                ListDatasd.Add(new keydata() { key = str, DataType = "Date" });
                            }



                            else
                            {
                                dataTable.Columns.Add(str + Counts.ToString(), Type.GetType("System.String"));
                                ListDatasd.Add(new keydata() { key = str, DataType = "String" });
                            }
                        }
                        else
                        {
                            if (str.ToUpper().Contains("DATE"))
                            {

                                dataTable.Columns.Add(str, Type.GetType("System.String"));
                                ListDatasd.Add(new keydata() { key = str, DataType = "Date" });
                            }



                            else
                            {
                                dataTable.Columns.Add(str, Type.GetType("System.String"));
                                ListDatasd.Add(new keydata() { key = str, DataType = "String" });
                            }
                        }

                    }



                    if (ListDatasd.Where(p => p.key == "Dealer_cd").Count() == 0)
                    {
                        dataTable.Columns.Add("Dealer_cd", Type.GetType("System.String"));
                    }
                    if (ListDatasd.Where(p => p.key == "For_cd").Count() == 0)
                    {
                        dataTable.Columns.Add("For_cd", Type.GetType("System.String"));
                    }
                    dataTable.Columns.Add("Itemjson");
                    dataTable.Columns.Add("Comp_Code");







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

                    var GSTSate = Business.StateLevel.GetList();
                    var objgodwan = SiteSession.GetGodawanListSession.ToList();
                    //using (TransactionScope trans = new TransactionScope())
                    //{
                    //    getdata(dataTable);

                    //    trans.Complete();
                    //}

                    var Groups = dataTable.AsEnumerable().GroupBy(p => p["DocumentNo"]).ToList();

                    var ss = CreateDatatable.GenericListToDataTableNullAlowed(Groups.Select(p => new { SupplyTypeCode = p.FirstOrDefault()["SupplyTypeCode"].ToString(), ReverseCharge = p.FirstOrDefault()["ReverseCharge"].ToString(), EComGSTN = p.FirstOrDefault()["EComGSTN"].ToString(), IGSTIntra = p.FirstOrDefault()["IGSTIntra"].ToString(), DocumentType = p.FirstOrDefault()["DocumentType"].ToString(), DocumentNo = p.FirstOrDefault()["DocumentNo"].ToString(), DocumentDate = p.FirstOrDefault()["DocumentDate"].ToString(), BuyerGSTN = p.FirstOrDefault()["BuyerGSTN"].ToString(), BuyerLegalName = p.FirstOrDefault()["BuyerLegalName"].ToString(), BuyerTradeName = p.FirstOrDefault()["BuyerTradeName"].ToString(), BuyerPOS = p.FirstOrDefault()["BuyerPOS"].ToString(), BuyerAddr1 = p.FirstOrDefault()["BuyerAddr1"].ToString(), BuyerAddr2 = p.FirstOrDefault()["BuyerAddr2"].ToString(), BuyerLocation = p.FirstOrDefault()["BuyerLocation"].ToString(), BuyerPINCode = p.FirstOrDefault()["BuyerPINCode"].ToString(), BuyerState = p.FirstOrDefault()["BuyerState"].ToString(), BuyerPhoneNumber = p.FirstOrDefault()["BuyerPhoneNumber"].ToString(), BuyerEmailID = p.FirstOrDefault()["BuyerEmailID"].ToString(), DispatchName = p.FirstOrDefault()["DispatchName"].ToString(), DispatchAddr1 = p.FirstOrDefault()["DispatchAddr1"].ToString(), DispatchAddr2 = p.FirstOrDefault()["DispatchAddr2"].ToString(), DispatchLocation = p.FirstOrDefault()["DispatchLocation"].ToString(), DispatchPINCode = p.FirstOrDefault()["DispatchPINCode"].ToString(), DispatchState = p.FirstOrDefault()["DispatchState"].ToString(), ShippingGSTN = p.FirstOrDefault()["ShippingGSTN"].ToString(), ShippingLegalName = p.FirstOrDefault()["ShippingLegalName"].ToString(), ShippingTradeName = p.FirstOrDefault()["ShippingTradeName"].ToString(), ShippingAddr1 = p.FirstOrDefault()["ShippingAddr1"].ToString(), ShippingAddr2 = p.FirstOrDefault()["ShippingAddr2"].ToString(), ShippingLocation = p.FirstOrDefault()["ShippingLocation"].ToString(), ShippingPINCode = p.FirstOrDefault()["ShippingPINCode"].ToString(), ShippingState = p.FirstOrDefault()["ShippingState"].ToString(), TotalTaxableValue = p.FirstOrDefault()["TotalTaxableValue"].ToString(), SGSTAmt1 = p.FirstOrDefault()["SGSTAmt1"].ToString(), CGSTAmt1 = p.FirstOrDefault()["CGSTAmt1"].ToString(), IGSTAmt1 = p.FirstOrDefault()["IGSTAmt1"].ToString(), CessAmount = p.FirstOrDefault()["CessAmount"].ToString(), StateCessAmount = p.FirstOrDefault()["StateCessAmount"].ToString(), Discount1 = p.FirstOrDefault()["Discount1"].ToString(), OtherCharges1 = p.FirstOrDefault()["OtherCharges1"].ToString(), RoundOff = p.FirstOrDefault()["RoundOff"].ToString(), TotalInvoiceValue = p.FirstOrDefault()["TotalInvoiceValue"].ToString(), TotalInvoiceValueinAdditionalCurrency = p.FirstOrDefault()["TotalInvoiceValueinAdditionalCurrency"].ToString(), ShippingBillNo = p.FirstOrDefault()["ShippingBillNo"].ToString(), ShippingBillDate = p.FirstOrDefault()["ShippingBillDate"].ToString(), Port = p.FirstOrDefault()["Port"].ToString(), SupplierRefund = p.FirstOrDefault()["SupplierRefund"].ToString(), ForeignCurrency = p.FirstOrDefault()["ForeignCurrency"].ToString(), CountryCode = p.FirstOrDefault()["CountryCode"].ToString(), ExportDutyAmount = p.FirstOrDefault()["ExportDutyAmount"].ToString(), TransID = p.FirstOrDefault()["TransID"].ToString(), TransName = p.FirstOrDefault()["TransName"].ToString(), TransMode = p.FirstOrDefault()["TransMode"].ToString(), Distance = p.FirstOrDefault()["Distance"].ToString(), TransDocNo = p.FirstOrDefault()["TransDocNo"].ToString(), TransDocDate = p.FirstOrDefault()["TransDocDate"].ToString(), VehicleNo = p.FirstOrDefault()["VehicleNo"].ToString(), VehicleType = p.FirstOrDefault()["VehicleType"].ToString(), PayeeName = p.FirstOrDefault()["PayeeName"].ToString(), AccountNumber = p.FirstOrDefault()["AccountNumber"].ToString(), Mode = p.FirstOrDefault()["Mode"].ToString(), BranchIFSCCode = p.FirstOrDefault()["BranchIFSCCode"].ToString(), TermofPayment = p.FirstOrDefault()["TermofPayment"].ToString(), PaymentInstuction = p.FirstOrDefault()["PaymentInstuction"].ToString(), CreditTransfer = p.FirstOrDefault()["CreditTransfer"].ToString(), DirectDebit = p.FirstOrDefault()["DirectDebit"].ToString(), CreditDays = p.FirstOrDefault()["CreditDays"].ToString(), PaidedAmount = p.FirstOrDefault()["PaidedAmount"].ToString(), DueAmount = p.FirstOrDefault()["DueAmount"].ToString(), Remarks = p.FirstOrDefault()["Remarks"].ToString(), InvoicePeriodStartDate = p.FirstOrDefault()["InvoicePeriodStartDate"].ToString(), InvoicePeriodEndDate = p.FirstOrDefault()["InvoicePeriodEndDate"].ToString(), OriginalInvoice = p.FirstOrDefault()["OriginalInvoice"].ToString(), PreceedingInvoiceDate = p.FirstOrDefault()["PreceedingInvoiceDate"].ToString(), OtherReference = p.FirstOrDefault()["OtherReference"].ToString(), ReceiptAdviceNumber = p.FirstOrDefault()["ReceiptAdviceNumber"].ToString(), DateofReceiptAdvice = p.FirstOrDefault()["DateofReceiptAdvice"].ToString(), LotBatchReferenceNumber = p.FirstOrDefault()["LotBatchReferenceNumber"].ToString(), ContractReferenceNumber = p.FirstOrDefault()["ContractReferenceNumber"].ToString(), AnyOtherReference = p.FirstOrDefault()["AnyOtherReference"].ToString(), ProjectReferenceNumber = p.FirstOrDefault()["ProjectReferenceNumber"].ToString(), VendorPOReferenceNumber = p.FirstOrDefault()["VendorPOReferenceNumber"].ToString(), VendorPOReferenceDate = p.FirstOrDefault()["VendorPOReferenceDate"].ToString(), SupportingDocURL = p.FirstOrDefault()["SupportingDocURL"].ToString(), SupportingDocinBase64Format = p.FirstOrDefault()["SupportingDocinBase64Format"].ToString(), AnyAdditionalInformation = p.FirstOrDefault()["AnyAdditionalInformation"].ToString(), Itemjson = "", GodownCode = 0, Dealer_cd = p.FirstOrDefault()["Dealer_cd"].ToString(), For_cd = p.FirstOrDefault()["For_cd"].ToString(), Comp_Code = p.FirstOrDefault()["Comp_Code"].ToString() }).ToList());
                    string josn = "";
                    ss.AsEnumerable().ToList().ForEach(c =>
                    {
                        josn = "";
                        var Filterrw = dataTable.AsEnumerable().Where(p => p["DocumentNo"].ToString() == c["DocumentNo"].ToString());
                        Filterrw.AsEnumerable().OrderBy(p => Convert.ToInt32(p["SlNo"])).ToList().ForEach(vb =>
                        {


                            //var sssv= (vb["BatchExpiryDate"].ToString().Trim().ToUpper() == "NULL" ? "" : Common.DateConvert(vb["BatchExpiryDate"].ToString(), "dd-MMM-yyyy").ToString("dd/MM/yyy"));
                            //var ssk=(vb["WarrantyDate"].ToString().Trim().ToUpper() == "NULL" ? "" : Common.DateConvert(vb["WarrantyDate"].ToString(), "dd-MMM-yyyy").ToString("dd/MM/yyy"));



                            josn = josn = josn.Length > 0 ? josn + "," + "{" +
      "^SlNo^: ^" + vb["SlNo"] + "^," +
        "^PrdDesc^: ^" + vb["ProductDescription"] + "^," +
        "^IsServc^: ^" + (vb["Is_Service"].ToString().ToUpper() == "YES" ? "Y" : "N") + "^," +
        "^HsnCd^: ^" + vb["HSNCode"] + "^," +
        "^Barcde^: ^" + vb["HSNCode"] + "^," +
        "^Qty^: " + Common.ConvertDecimal((vb["Quantity"].ToString().Length > 0 ? vb["Quantity"].ToString() : "0")).ToString("0.00") + "," +
        "^FreeQty^: " + Common.ConvertDecimal((vb["FreeQuantity"].ToString().Length > 0 ? vb["FreeQuantity"].ToString() : "0")).ToString("0.00") + "," +
        "^Unit^: ^NOS^," +
        "^UnitPrice^: " + Common.ConvertDecimal((vb["UnitPrice"].ToString().Length > 0 ? vb["UnitPrice"].ToString() : "0")).ToString("0.00") + "," +
        "^TotAmt^: " + Common.ConvertDecimal((vb["GrossAmount"].ToString().Length > 0 ? vb["GrossAmount"].ToString() : "0")).ToString("0.00") + "," +
        "^Discount^: " + Common.ConvertDecimal((vb["Discount"].ToString().Length > 0 ? vb["Discount"].ToString() : "0")).ToString("0.00") + "," +
        "^PreTaxVal^: " + Common.ConvertDecimal((vb["PreTaxValue"].ToString().Length > 0 ? vb["PreTaxValue"].ToString() : "0")).ToString("0.00") + "," +
        "^AssAmt^: " + Common.ConvertDecimal((vb["TaxableValue"].ToString().Length > 0 ? vb["TaxableValue"].ToString() : "0")).ToString("0.00") + "," +
        "^GstRt^: " + Common.ConvertDecimal((vb["GSTRate"].ToString().Length > 0 ? vb["GSTRate"].ToString() : "0")).ToString("0.00") + "," +
        "^IgstAmt^: " + Common.ConvertDecimal((vb["IGSTAmt"].ToString().Length > 0 ? vb["IGSTAmt"].ToString() : "0")).ToString("0.00") + "," +
        "^CgstAmt^: " + Common.ConvertDecimal((vb["CGSTAmt"].ToString().Length > 0 ? vb["CGSTAmt"].ToString() : "0")).ToString("0.00") + "," +
        "^SgstAmt^: " + Common.ConvertDecimal((vb["SGSTAmt"].ToString().Length > 0 ? vb["SGSTAmt"].ToString() : "0")).ToString("0.00") + "," +
        "^CesRt^: " + Common.ConvertDecimal((vb["CessRate"].ToString().Length > 0 ? vb["CessRate"].ToString() : "0")).ToString("0.00") + "," +
        "^CesAmt^: " + Common.ConvertDecimal((vb["CessAmtAdval"].ToString().Length > 0 ? vb["CessAmtAdval"].ToString() : "0")).ToString("0.00") + "," +
        "^CesNonAdvlAmt^: " + Common.ConvertDecimal((vb["CessNonAdvalAmt"].ToString().Length > 0 ? vb["CessNonAdvalAmt"].ToString() : "0")).ToString("0.00") + "," +
        "^StateCesRt^: " + Common.ConvertDecimal((vb["StateCessRate"].ToString().Length > 0 ? vb["StateCessRate"].ToString() : "0")).ToString("0.00") + "," +
        "^StateCesAmt^: " + Common.ConvertDecimal((vb["StateCessAdvalAmt"].ToString().Length > 0 ? vb["StateCessAdvalAmt"].ToString() : "0")).ToString("0.00") + "," +
        "^StateCesNonAdvlAmt^: " + Common.ConvertDecimal((vb["StateCessNonAdvalAmt"].ToString().Length > 0 ? vb["StateCessNonAdvalAmt"].ToString() : "0")).ToString("0.00") + "," +
        "^OthChrg^: " + Common.ConvertDecimal((vb["OtherCharges"].ToString().Length > 0 ? vb["OtherCharges"].ToString() : "0")).ToString("0.00") + "," +
        "^TotItemVal^: " + Common.ConvertDecimal((vb["ItemTotal"].ToString().Length > 0 ? vb["ItemTotal"].ToString() : "0")).ToString("0.00") + "," +
        "^OrdLineRef^: ^" + vb["OrderLineReference"] + "^," +
        "^OrgCntry^: ^IN^," +
        "^PrdSlNo^: ^" + vb["UniqueItemSlNo"] + "^" +



          "} " : "{" +
    "^SlNo^: ^" + vb["SlNo"] + "^," +
        "^PrdDesc^: ^" + vb["ProductDescription"] + "^," +
        "^IsServc^: ^" + (vb["Is_Service"].ToString().ToUpper() == "YES" ? "Y" : "N") + "^," +
        "^HsnCd^: ^" + vb["HSNCode"] + "^," +
        "^Barcde^: ^" + vb["HSNCode"] + "^," +
        "^Qty^: " + Common.ConvertDecimal((vb["Quantity"].ToString().Length > 0 ? vb["Quantity"].ToString() : "0")).ToString("0.00") + "," +
        "^FreeQty^: " + Common.ConvertDecimal((vb["FreeQuantity"].ToString().Length > 0 ? vb["FreeQuantity"].ToString() : "0")).ToString("0.00") + "," +
        "^Unit^: ^NOS^," +
        "^UnitPrice^: " + Common.ConvertDecimal((vb["UnitPrice"].ToString().Length > 0 ? vb["UnitPrice"].ToString() : "0")).ToString("0.00") + "," +
        "^TotAmt^: " + Common.ConvertDecimal((vb["GrossAmount"].ToString().Length > 0 ? vb["GrossAmount"].ToString() : "0")).ToString("0.00") + "," +
        "^Discount^: " + Common.ConvertDecimal((vb["Discount"].ToString().Length > 0 ? vb["Discount"].ToString() : "0")).ToString("0.00") + "," +
        "^PreTaxVal^: " + Common.ConvertDecimal((vb["PreTaxValue"].ToString().Length > 0 ? vb["PreTaxValue"].ToString() : "0")).ToString("0.00") + "," +
        "^AssAmt^: " + Common.ConvertDecimal((vb["TaxableValue"].ToString().Length > 0 ? vb["TaxableValue"].ToString() : "0")).ToString("0.00") + "," +
        "^GstRt^: " + Common.ConvertDecimal((vb["GSTRate"].ToString().Length > 0 ? vb["GSTRate"].ToString() : "0")).ToString("0.00") + "," +
        "^IgstAmt^: " + Common.ConvertDecimal((vb["IGSTAmt"].ToString().Length > 0 ? vb["IGSTAmt"].ToString() : "0")).ToString("0.00") + "," +
        "^CgstAmt^: " + Common.ConvertDecimal((vb["CGSTAmt"].ToString().Length > 0 ? vb["CGSTAmt"].ToString() : "0")).ToString("0.00") + "," +
        "^SgstAmt^: " + Common.ConvertDecimal((vb["SGSTAmt"].ToString().Length > 0 ? vb["SGSTAmt"].ToString() : "0")).ToString("0.00") + "," +
        "^CesRt^: " + Common.ConvertDecimal((vb["CessRate"].ToString().Length > 0 ? vb["CessRate"].ToString() : "0")).ToString("0.00") + "," +
        "^CesAmt^: " + Common.ConvertDecimal((vb["CessAmtAdval"].ToString().Length > 0 ? vb["CessAmtAdval"].ToString() : "0")).ToString("0.00") + "," +
        "^CesNonAdvlAmt^: " + Common.ConvertDecimal((vb["CessNonAdvalAmt"].ToString().Length > 0 ? vb["CessNonAdvalAmt"].ToString() : "0")).ToString("0.00") + "," +
        "^StateCesRt^: " + Common.ConvertDecimal((vb["StateCessRate"].ToString().Length > 0 ? vb["StateCessRate"].ToString() : "0")).ToString("0.00") + "," +
        "^StateCesAmt^: " + Common.ConvertDecimal((vb["StateCessAdvalAmt"].ToString().Length > 0 ? vb["StateCessAdvalAmt"].ToString() : "0")).ToString("0.00") + "," +
        "^StateCesNonAdvlAmt^: " + Common.ConvertDecimal((vb["StateCessNonAdvalAmt"].ToString().Length > 0 ? vb["StateCessNonAdvalAmt"].ToString() : "0")).ToString("0.00") + "," +
        "^OthChrg^: " + Common.ConvertDecimal((vb["OtherCharges"].ToString().Length > 0 ? vb["OtherCharges"].ToString() : "0")).ToString("0.00") + "," +
        "^TotItemVal^: " + Common.ConvertDecimal((vb["ItemTotal"].ToString().Length > 0 ? vb["ItemTotal"].ToString() : "0")).ToString("0.00") + "," +
        "^OrdLineRef^: ^" + vb["OrderLineReference"] + "^," +
        "^OrgCntry^: ^IN^," +
        "^PrdSlNo^: ^" + vb["UniqueItemSlNo"] + "^" +



            "}";
                        });
                        c["Itemjson"] = josn;

                        try
                        {
                            c["BuyerState"] = GSTSate.SingleOrDefault(p => p.StateName == c["BuyerState"].ToString().Trim().ToUpper()).SateCode;
                        }
                        catch { }
                        //c["GodownCode"] = 28;
                        try
                        {
                            var checkdata= c["DocumentNo"].ToString().Split('/')[0].ToString().ToUpper().Replace(" ","");
                            if (checkdata == "EWC" || checkdata == "CRI" || checkdata == "PDI" || checkdata == "CCP")
                            {
                                c["GodownCode"] = objgodwan.Where(p => p.BR_EWC == c["DocumentNo"].ToString().Split('/')[1].ToString()).FirstOrDefault().Id;


                            }
                            else if (checkdata == "TCU" || checkdata == "SRS" )
                            {
                                c["GodownCode"] = objgodwan.Where(p => p.BR_TCU == c["DocumentNo"].ToString().Split('/')[1].ToString()).FirstOrDefault().Id;


                            }
                            else

                            {
                                c["GodownCode"] = objgodwan.Where(p => p.DlrCode == checkdata).FirstOrDefault().Id;
                            }
                        }
                        catch (Exception ex)
                        {
                            sstestss = sstestss + "," + c["DocumentNo"].ToString()+"  "+ex.Message;
                            c["GodownCode"] = 0;
                        }
                        c["ShippingState"] = c["BuyerState"].ToString(); // GSTSate.SingleOrDefault(p => p.StateName == c["ShippingState"].ToString().Trim().ToUpper()).SateCode;

                        c["Comp_Code"] = SiteSession.Comp_MstSession.Comp_Code.Value.ToString();



                    });
                    string createTable = "";
                    foreach (DataColumn headerCell in ss.Columns)
                    {
                        string strk = headerCell.ToString().Replace(".", "").Replace("/", "").Replace(" ", "").Replace("(", "").Replace(")", "").Replace("%", "").Replace(@"\", "").Replace("#", "");

                        createTable = createTable + Environment.NewLine + strk;
                    }
                    if (sstestss.Length > 0)
                    {
                        ErrorNote.Text = "ERROR: problem with GODOWN CODE  on this Document Number: " + sstestss;
                    }


                    using (TransactionScope trans = new TransactionScope())
                    {
                        getdata(ss.AsEnumerable().Where(cc => Convert.ToInt32(cc["GodownCode"]) > 0).CopyToDataTable());

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
                using (SqlCommand cmd = new SqlCommand("ImportEInvoice"))
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Details", dtDetails);
                    cmd.Parameters.AddWithValue("@Comp_Code",SiteSession.Comp_MstSession.Comp_Code);
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
