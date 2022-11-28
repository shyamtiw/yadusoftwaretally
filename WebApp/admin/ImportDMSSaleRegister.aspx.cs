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
using WebApp.admin.ReportModal;

namespace WebApp.admin
{
    public partial class ImportDMSSaleRegister : BasePageClass
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






                    var sheet = hssfwb.GetSheetAt(0);
                    var dataTable = new DataTable(sheet.SheetName);

                    // write the header row
                    var headerRow = sheet.GetRow(0);
                    var ListDatasd = new List<keydata>();
                    string col = "";
                    string[] DPSDTAETIME = { "CREATED_DATETIME", "DUE_DATETIME", "UPDATED_TIME", "INVOICE_DATE", "NEW_POLICY_ISSUE_DATE", "VEHICLE_SALE_DATE", "DATETIME_CLOSED", "DATETIME_OPENED", "CALL_RESULT_DATE_TIME" };
                    if (ImportFileType.SelectedValue.ConvertInt() == 33 || ImportFileType.SelectedValue.ConvertInt() == 32 || ImportFileType.SelectedValue.ConvertInt() == 34)
                    {
                        foreach (var headerCell in headerRow)
                        {
                            string str = headerCell.ToString().Replace(".", "").Replace("/", "").Replace(" ", "").Replace("(", "").Replace(")", "").Replace("%", "").Replace(@"\", "").Replace("#", "").Replace("64", "sixtyfour");
                            var Counts = ListDatasd.Where(p => p.key.ToUpper() == str.ToUpper()).Count();

                            if (Counts > 0)
                            {
                                dataTable.Columns.Add(str + Counts.ToString(), Type.GetType("System.String"));
                                ListDatasd.Add(new keydata() { key = str, DataType = "Date" });
                                col = col + Environment.NewLine + str + Counts.ToString();
                            }
                            else
                            {
                                dataTable.Columns.Add(str, Type.GetType("System.String"));
                                ListDatasd.Add(new keydata() { key = str, DataType = "Date" });
                                col = col + Environment.NewLine + str;
                            }



                        }
                    }
                    else if (ImportFileType.SelectedValue.ConvertInt() == 45 || ImportFileType.SelectedValue.ConvertInt() == 46 || ImportFileType.SelectedValue.ConvertInt() == 47)
                    {
                        foreach (var headerCell in headerRow)
                        {
                            string str = headerCell.ToString().Replace(".", "").Replace("/", "").Replace(" ", "").Replace("(", "").Replace(")", "").Replace("%", "").Replace(@"\", "");
                            var Counts = ListDatasd.Where(p => p.key.ToUpper() == str.ToUpper()).Count();

                            if (Counts > 0)
                            {
                                dataTable.Columns.Add(str + Counts.ToString(), Type.GetType("System.String"));
                                ListDatasd.Add(new keydata() { key = str, DataType = "Date" });
                                col = col + Environment.NewLine + str + Counts.ToString();
                            }
                            else
                            {
                                dataTable.Columns.Add(str, Type.GetType("System.String"));
                                ListDatasd.Add(new keydata() { key = str, DataType = "Date" });
                                col = col + Environment.NewLine + str;
                            }



                        }
                    }
                  else   if (ImportFileType.SelectedValue.ConvertInt() == 48)
                    {
                        foreach (var headerCell in headerRow)
                        {
                            string str = headerCell.ToString().Replace(".", "").Replace("/", "").Replace(" ", "").Replace("(", "").Replace(")", "").Replace("%", "").Replace(@"\", "").Replace("#", "").Replace("64", "sixtyfour");
                            var Counts = ListDatasd.Where(p => p.key.ToUpper() == str.ToUpper()).Count();

                            if (Counts > 0)
                            {
                                dataTable.Columns.Add(str + Counts.ToString(), Type.GetType("System.String"));
                                ListDatasd.Add(new keydata() { key = str, DataType = "Date" });
                                col = col + Environment.NewLine + str + Counts.ToString();
                            }
                            else
                            {
                                dataTable.Columns.Add(str, Type.GetType("System.String"));
                                ListDatasd.Add(new keydata() { key = str, DataType = "Date" });
                                col = col + Environment.NewLine + str;
                            }



                        }
                    }

                    else
                    {
                        foreach (var headerCell in headerRow)
                        {
                            string str = headerCell.ToString().Replace(".", "").Replace("/", "").Replace(" ", "").Replace("(", "").Replace(")", "").Replace("%", "").Replace(@"\", "").Replace("#", "").Replace("64", "sixtyfour").Replace(@"_", "").Replace(@"-", "");
                            var Counts = ListDatasd.Where(p => p.key.ToUpper() == str.ToUpper()).Count();

                            if (Counts > 0)
                            {
                                dataTable.Columns.Add(str + Counts.ToString(), Type.GetType("System.String"));
                                ListDatasd.Add(new keydata() { key = str, DataType = "Date" });
                                col = col + Environment.NewLine + str + Counts.ToString();
                            }
                            else
                            {
                                dataTable.Columns.Add(str, Type.GetType("System.String"));
                                ListDatasd.Add(new keydata() { key = str, DataType = "Date" });
                                col = col + Environment.NewLine + str;
                            }



                        }
                    }









                    if (ImportFileType.SelectedValue.ConvertInt() == 33)
                    {
                        // write the rest
                        for (int i = 1; i < sheet.PhysicalNumberOfRows; i++)
                        {
                            var sheetRow = sheet.GetRow(i);
                            var dtRow = dataTable.NewRow();
                            dtRow.ItemArray = dataTable.Columns
                                .Cast<DataColumn>()
                                .Select(c =>
                                ValuesStringsTrans((sheetRow.GetCell(c.Ordinal, MissingCellPolicy.CREATE_NULL_AS_BLANK)), c.Caption.ToUpper().Contains("DATE") ? "Date" : "String")
                                )
                                .ToArray();
                            dataTable.Rows.Add(dtRow);
                        }

                    }
                    else if (ImportFileType.SelectedValue.ConvertInt() == 45 || ImportFileType.SelectedValue.ConvertInt() == 46 || ImportFileType.SelectedValue.ConvertInt() == 47)
                    {
                        for (int i = 1; i < sheet.PhysicalNumberOfRows; i++)
                        {
                            var sheetRow = sheet.GetRow(i);
                            var dtRow = dataTable.NewRow();
                            dtRow.ItemArray = dataTable.Columns
                                .Cast<DataColumn>()
                                .Select(c =>
                                ValuesStringsDPS((sheetRow.GetCell(c.Ordinal, MissingCellPolicy.CREATE_NULL_AS_BLANK)),

                              (DPSDTAETIME.Contains(c.Caption)?"DATETIME":
                                (c.Caption.ToUpper().Contains("DATE") ? "Date" : "String"))
                                
                                )
                                )
                                .ToArray();
                            dataTable.Rows.Add(dtRow);
                        }
                    }
                    else if (ImportFileType.SelectedValue.ConvertInt() == 48)
                    {
                        for (int i = 1; i < sheet.PhysicalNumberOfRows; i++)
                        {
                            var sheetRow = sheet.GetRow(i);
                            var dtRow = dataTable.NewRow();
                            dtRow.ItemArray = dataTable.Columns
                                .Cast<DataColumn>()
                                .Select(c =>
                                ValuesStringsDPS((sheetRow.GetCell(c.Ordinal, MissingCellPolicy.CREATE_NULL_AS_BLANK)),

                              (DPSDTAETIME.Contains(c.Caption) ? "DATETIME" :
                                (c.Caption.ToUpper().Contains("DATE") ? "Date" : "String")),
                              c.Caption

                                )
                                )
                                .ToArray();
                            dataTable.Rows.Add(dtRow);
                        }
                    }
                    
                    else
                    {
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
                    }


                    if (ImportFileType.SelectedValue.ConvertInt() == 10)
                    {
                        getdata(dataTable.AsEnumerable().Where(cc => cc["Trxnumber"].ToString().Length > 0).CopyToDataTable(), "SP_IMPORT_MSIL_STATEMENt");

                    }
                    else if (ImportFileType.SelectedValue.ConvertInt() == 2)
                    {
                        getdata(dataTable.AsEnumerable().Where(cc => cc["CREDITNOTENUMBER"].ToString().Length > 0).CopyToDataTable(), "SP_IMPORT_TCN_ACN");

                    }
                    else if (ImportFileType.SelectedValue.ConvertInt() == 3)
                    {
                        getdata(dataTable.AsEnumerable().Where(cc => cc["InvNo"].ToString().Length > 0).CopyToDataTable(), "sp_importsaleregister");

                    }
                    else if (ImportFileType.SelectedValue.ConvertInt() == 6)
                    {
                        getdata(dataTable.AsEnumerable().Where(cc => cc["InvNo"].ToString().Length > 0).CopyToDataTable(), "sp_New_Car_Purc_Register");

                    }
                    if (ImportFileType.SelectedValue.ConvertInt() == 11)
                    {
                        getdata(dataTable.AsEnumerable().Where(cc => cc["NewCarVin"].ToString().Length > 0).CopyToDataTable(), "SP_IMPORT_EXCHANGE_CLAIM");

                    }
                    if (ImportFileType.SelectedValue.ConvertInt() == 12)
                    {
                        getdata(dataTable.AsEnumerable().Where(cc => cc["NewCarVin"].ToString().Length > 0).CopyToDataTable(), "SP_IMPORT_ISLRMK_CLAIM");

                    }
                    if (ImportFileType.SelectedValue.ConvertInt() == 13)
                    {
                        getdata(dataTable.AsEnumerable().Where(cc => cc["TrxNumber"].ToString().Length > 0).CopyToDataTable(), "SP_IMPORT_MSIL_STATEMENT");

                    }
                    if (ImportFileType.SelectedValue.ConvertInt() == 14)
                    {
                        getdata(dataTable.AsEnumerable().Where(cc => cc["INVNO"].ToString().Length > 0).CopyToDataTable(), "SP_BSC_BASE1219");

                    }
                    if (ImportFileType.SelectedValue.ConvertInt() == 15)
                    {
                        getdata(dataTable.AsEnumerable().Where(cc => cc["Region"].ToString().Length > 0).CopyToDataTable(), "SP_SERVICE_PERFORMANCE");

                    }
                    if (ImportFileType.SelectedValue.ConvertInt() == 16)
                    {
                        getdata(dataTable.AsEnumerable().Where(cc => cc["DealerCode"].ToString().Length > 0).CopyToDataTable(), "SP_IMPORT_BSC_Sale_Register");



                    }
                    if (ImportFileType.SelectedValue.ConvertInt() == 17)
                    {
                        getdata(dataTable.AsEnumerable().Where(cc => cc["DealerCode"].ToString().Length > 0).CopyToDataTable(), "SP_IMPORT_BSC_Sale_Return");

                    }
                    if (ImportFileType.SelectedValue.ConvertInt() == 18)
                    {
                        getdata(dataTable.AsEnumerable().Where(cc => cc["DealerCode"].ToString().Length > 0).CopyToDataTable(), "SP_IMPORT_BSC_Pending_Booking");
                    }
                    if (ImportFileType.SelectedValue.ConvertInt() == 19)
                    {
                        getdataSameBD(dataTable.AsEnumerable().Where(cc => cc["MODELID"].ToString().Length > 0).CopyToDataTable(), "SP_IMPORT_CONS_DISC");

                    }
                    if (ImportFileType.SelectedValue.ConvertInt() == 20)
                    {
                        getdata(dataTable.AsEnumerable().Where(cc => cc["Schemename"].ToString().Length > 0).CopyToDataTable(), "SP_IMPORT_SCHEME_TARGET");

                    }
                    if (ImportFileType.SelectedValue.ConvertInt() == 21)
                    {
                        getdata(dataTable.AsEnumerable().Where(cc => cc["FinNo"].ToString().Length > 0).CopyToDataTable(), "SP_IMPORT_EXTRANEt_DISPATCH");

                    }
                    if (ImportFileType.SelectedValue.ConvertInt() == 22)
                    {
                        getdata(dataTable.AsEnumerable().Where(cc => cc["IndentNumber"].ToString().Length > 0).CopyToDataTable(), "SP_IMPORT_PENDING_INDENT");

                    }
                    if (ImportFileType.SelectedValue.ConvertInt() == 23)
                    {
                        getdata(dataTable.AsEnumerable().Where(cc => cc["ORDERNO"].ToString().Length > 0).CopyToDataTable(), "SP_IMPORT_NONOMS_INDENT");

                    }
                    if (ImportFileType.SelectedValue.ConvertInt() == 25)
                    {
                        getdata(dataTable.AsEnumerable().Where(cc => cc["Account"].ToString().Length > 0).CopyToDataTable(), "SP_IMPORT_MSIL_Dail_Sale_Statement");

                    }
                    if (ImportFileType.SelectedValue.ConvertInt() == 26)
                    {
                        getdata(dataTable.AsEnumerable().Where(cc => cc["DealerCode"].ToString().Length > 0).CopyToDataTable(), "SP_IMPORT_MSIL_Daily_Service_Statement");

                    }
                    if (ImportFileType.SelectedValue.ConvertInt() == 27)
                    {
                        getdata(dataTable.AsEnumerable().Where(cc => cc["DealerCode"].ToString().Length > 0).CopyToDataTable(), "SP_IMPORT_BI_NewCarStock");

                    }
                    if (ImportFileType.SelectedValue.ConvertInt() == 28)
                    {
                        getdata(dataTable.AsEnumerable().Where(cc => cc["JobTitle"].ToString().Length > 0).CopyToDataTable(), "SP_IMPORT_EmployeeKRA");

                    }
                    if (ImportFileType.SelectedValue.ConvertInt() == 29)
                    {

                        //0 as Godw_Code,
                        //0 as Comp_Code
                        try { DataColumn dcg = new DataColumn("Godw_Code") { DefaultValue = "0", DataType = Type.GetType("System.String") }; dataTable.Columns.Add(dcg); } catch { }
                        try { DataColumn dcc = new DataColumn("Comp_Code") { DefaultValue = "0", DataType = Type.GetType("System.String") }; dataTable.Columns.Add(dcc); } catch { }

                        DataTable dt = CreateDatatable.GenericListToDataTableNullAlowed(dataTable.AsEnumerable().Select(dr => new
                        {
                            REQUESTID = dr["RequestId"].ToString(),
                            POLICYNO = dr["PolicyNo"].ToString(),
                            TRANSACTIONID = dr["Doc"].ToString(),
                            CUSTOMERNAME = dr["CustomerName"].ToString(),
                            REGISTRATIONNO = "",
                            TRANSACTIONOUTLET = dr["OutletCode"].ToString(),
                            TRANSACTIONTYPE = dr["type"].ToString(),
                            TRANSACTIONAMOUNT = dr["DebitOrCredit"].ToString().ToUpper() == "DEBIT" ? Common.ConvertDecimal(dr["AutoDebitAmmount"].ToString()) * -1m : Common.ConvertDecimal(dr["AutoDebitAmmount"].ToString()),



                            DESCRIPTION = "Executive Name: " + dr["ExecutiveName"].ToString() + " || " + "Insurance Company: " + dr["InsuranceCompany"].ToString() + " || Escrow Account No.: " + dr["EscrowAccountNo"].ToString(),
                            TRANSAMNTDEDUCTIONDATE = dr["TransactionDate"].ToString(),

                            Godw_Code = dr["Godw_Code"].ToString().ConvertInt(),
                            Comp_Code = dr["Comp_Code"].ToString().ConvertInt()

                        }).ToList()); ;


                        getdata(dt.AsEnumerable().Where(cc => cc["REQUESTID"].ToString().Length > 0).CopyToDataTable(), "ImportDebitEntry");

                    }
                    if (ImportFileType.SelectedValue.ConvertInt() == 30)
                    {

                        try { DataColumn dcg = new DataColumn("Godw_Code") { DefaultValue = "0", DataType = Type.GetType("System.String") }; dataTable.Columns.Add(dcg); } catch { }
                        try { DataColumn dcc = new DataColumn("Comp_Code") { DefaultValue = "0", DataType = Type.GetType("System.String") }; dataTable.Columns.Add(dcc); } catch { }

                        DataTable dt = CreateDatatable.GenericListToDataTableNullAlowed(dataTable.AsEnumerable().Where(p => p["TransactionDate"].ToString() != "null").ToList().Select(dr => new
                        {
                            REQUESTID = dr["RequestID"].ToString(),
                            INSURANCECOMPANY = dr["InsuranceCompany"].ToString(),
                            POLICYNO = dr["PolicyNo"].ToString(),
                            TRANSACTIONID = dr["TransactionID"].ToString(),
                            CUSTOMERNAME = dr["CustomerName"].ToString(),
                            REGISTRATIONNO = dr["RegistrationNo"].ToString(),
                            TRANSACTIONOUTLET = dr["TransactionOutlet"].ToString(),
                            TRANSACTIONTYPE = dr["TransactionType"].ToString(),
                            TRANSACTIONAMOUNT = dr["TransactionType"].ToString().ToString().ToUpper() == "DEBIT" ? Common.ConvertDecimal(dr["TransactionAmount"].ToString()) * -1m : Common.ConvertDecimal(dr["TransactionAmount"].ToString()),
                            DESCRIPTION = dr["Description"].ToString(),
                            TRANSDATE = dr["TransactionDate"].ToString(),
                            TRANSPOSTEDDATE = dr["TransactionDate"].ToString(),
                            BANKTRANSACTIONID = dr["ChargeBankTransactionID"].ToString(),
                            Godw_Code = dr["Godw_Code"].ToString().ConvertInt(),
                            Comp_Code = dr["Comp_Code"].ToString().ConvertInt()

                        }).ToList());

                        getdata(dt.AsEnumerable().Where(cc => cc["REQUESTID"].ToString().Length > 0).CopyToDataTable(), "ImportClamInsuCreditCardEntry");

                    }
                    if (ImportFileType.SelectedValue.ConvertInt() == 32)
                    {
                        //0 as Godw_Code,
                        //0 as Comp_Code
                        DataTable dt = CreateDatatable.GenericListToDataTableNullAlowed(dataTable.AsEnumerable().Select(p => new { UTD = p["UTD"].ToString(), CommunicateTo = p["CommunicateTo"].ToString(), CustomerID = p["CustomerID"].ToString(), CustomerName = p["CustomerName"].ToString(), DealerCode = p["DealerCode"].ToString(), Dealerforcode = p["Dealerforcode"].ToString(), DealerMapCode = p["DealerMapCode"].ToString(), District = p["District"].ToString(), DOA = p["DOA"].ToString(), DOB = p["DOB"].ToString(), EmailID = p["EmailID"].ToString(), Gender = p["Gender"].ToString(), GST = p["GST"].ToString(), LocationCode = p["LocationCode"].ToString(), MaritalStatus = p["MaritalStatus"].ToString(), Mobile1 = p["Mobile1"].ToString(), Mobile2 = p["Mobile2"].ToString(), OffCity = p["OffCity"].ToString(), OffPhone = p["OffPhone"].ToString(), OffPinCode = p["OffPinCode"].ToString(), Off_Address1 = p["Off_Address1"].ToString(), Off_Address2 = p["Off_Address2"].ToString(), Off_Address3 = p["Off_Address3"].ToString(), OutletCode = p["OutletCode"].ToString(), PAN = p["PAN"].ToString(), ParentGroup = p["ParentGroup"].ToString(), ResAddress1 = p["ResAddress1"].ToString(), ResAddress2 = p["ResAddress2"].ToString(), ResAddress3 = p["ResAddress3"].ToString(), ResCity = p["ResCity"].ToString(), ResPhone = p["ResPhone"].ToString(), ResPinCode = p["ResPinCode"].ToString(), Salutation = p["Salutation"].ToString(), ShipCity = p["ShipCity"].ToString(), ShipFullName = p["ShipFullName"].ToString(), ShipGST = p["ShipGST"].ToString(), ShipPAN = p["ShipPAN"].ToString(), ShipPinCode = p["ShipPinCode"].ToString(), ShipState = p["ShipState"].ToString(), ShipUIN = p["ShipUIN"].ToString(), Ship_Address1 = p["Ship_Address1"].ToString(), Ship_Address2 = p["Ship_Address2"].ToString(), Ship_Address3 = p["Ship_Address3"].ToString(), State = p["State"].ToString(), Tehsil = p["Tehsil"].ToString(), TIN = p["TIN"].ToString(), UIN = p["UIN"].ToString(), Village = p["Village"].ToString() }).ToList());
                        getdataTransctions(dt, "Importgd_gd_fdi_trans_customer");

                    }

                    if (ImportFileType.SelectedValue.ConvertInt() == 33)
                    {
                        //0 as Godw_Code,
                        //0 as Comp_Code
                        DataTable dt = CreateDatatable.GenericListToDataTableNullAlowed(dataTable.AsEnumerable().Select(p => new { UTD = p["UTD"].ToString(), BasicPrice = p["BasicPrice"].ToString(), ChassisNumber = p["ChassisNumber"].ToString(), ColorCode = p["ColorCode"].ToString(), CustID = p["CustID"].ToString(), CustName = p["CustName"].ToString(), DealerCode = p["DealerCode"].ToString(), Dealerforcode = p["Dealerforcode"].ToString(), DealerMapCode = p["DealerMapCode"].ToString(), DepositBank = p["DepositBank"].ToString(), Discount = p["Discount"].ToString(), EngineNumber = p["EngineNumber"].ToString(), Executive = p["Executive"].ToString(), FinName = p["FinName"].ToString(), GE1 = p["GE1"].ToString(), GE10 = p["GE10"].ToString(), GE11 = p["GE11"].ToString(), GE12 = p["GE12"].ToString(), GE13 = p["GE13"].ToString(), GE14 = p["GE14"].ToString(), GE15 = p["GE15"].ToString(), GE2 = p["GE2"].ToString(), GE3 = p["GE3"].ToString(), GE4 = p["GE4"].ToString(), GE5 = p["GE5"].ToString(), GE6 = p["GE6"].ToString(), GE7 = p["GE7"].ToString(), GE8 = p["GE8"].ToString(), GE9 = p["GE9"].ToString(), GST = p["GST"].ToString(), HSN = p["HSN"].ToString(), LocationCode = p["LocationCode"].ToString(), ModelCode = p["ModelCode"].ToString(), OutletCode = p["OutletCode"].ToString(), ParentGroup = p["ParentGroup"].ToString(), PaymentMode = p["PaymentMode"].ToString(), PlaceofSupply = p["PlaceofSupply"].ToString(), ServiceAmount = p["ServiceAmount"].ToString(), TaxableValue = p["TaxableValue"].ToString(), Teamhead = p["Teamhead"].ToString(), TransactionDate = p["TransactionDate"].ToString(), TransactionID = p["TransactionID"].ToString(), TransactionQuantity = p["TransactionQuantity"].ToString(), TransactionRefDate = p["TransactionRefDate"].ToString(), TransactionRefNum = p["TransactionRefNum"].ToString(), TransactionSegment = p["TransactionSegment"].ToString(), TransactionType = p["TransactionType"].ToString(), VariantCode = p["VariantCode"].ToString(), VIN = p["VIN"].ToString() }).ToList());
                        getdataTransctions(dt, "Importgd_fdi_trans");

                    }
                    if (ImportFileType.SelectedValue.ConvertInt() == 34)
                    {
                        //0 as Godw_Code,
                        //0 as Comp_Code
                        DataTable dt = CreateDatatable.GenericListToDataTableNullAlowed(dataTable.AsEnumerable().Select(p => new { UTD = p["UTD"].ToString(), ParentGroup = p["ParentGroup"].ToString(), DealerMapCode = p["DealerMapCode"].ToString(), LocationCode = p["LocationCode"].ToString(), DealerCode = p["DealerCode"].ToString(), Dealerforcode = p["Dealerforcode"].ToString(), OutletCode = p["OutletCode"].ToString(), HSN = p["HSN"].ToString(), Chargecode = p["Chargecode"].ToString(), ChargeType = p["ChargeType"].ToString(), ChargeDescription = p["ChargeDescription"].ToString(), ChargeRate = p["ChargeRate"].ToString(), ChargeAmount = p["ChargeAmount"].ToString(), MSILShare = p["MSILShare"].ToString(), DealerShare = p["DealerShare"].ToString() }).ToList());
                        getdataTransctions(dt, "Importgd_gd_fdi_trans_charges");

                    }

                    if (ImportFileType.SelectedValue.ConvertInt() == 35)
                    {
                        //0 as Godw_Code,
                        //0 as Comp_Code
                        DataTable dt = CreateDatatable.GenericListToDataTableNullAlowed(dataTable.AsEnumerable().Select(p => new
                        {
                            Region = p["Region"].ToString(),
                            Parent = p["Parent"].ToString(),
                            DealerMapCD = p["DealerMapCD"].ToString(),
                            LocCD = p["LocCD"].ToString(),
                            Type = p["Type"].ToString(),
                            DealerName = p["DealerName"].ToString(),
                            LocDesc = p["LocDesc"].ToString(),
                            SalesCD = p["SalesCD"].ToString(),
                            ServiceCD = p["ServiceCD"].ToString(),
                            SparesCD = p["SparesCD"].ToString(),
                            ForCD = p["ForCD"].ToString(),
                            OutletCode = p["OutletCode"].ToString(),
                            TVCode = p["TVCode"].ToString(),
                            DealerCategory = p["DealerCategory"].ToString(),
                            ConsigneeCD = p["ConsigneeCD"].ToString(),
                            SalesStockYard = p["SalesStockYard"].ToString(),
                            SparesStockYard = p["SparesStockYard"].ToString(),
                            DealerAddress1 = p["DealerAddress1"].ToString(),
                            DealerAddress2 = p["DealerAddress2"].ToString(),
                            BSC = p["BSC"].ToString(),
                            SalesLiveDate = p["SalesLiveDate"].ToString(),
                            ServiceLiveDate = p["ServiceLiveDate"].ToString(),
                            ActivationDate = p["ActivationDate"].ToString(),
                            GSTNum = p["GSTNum"].ToString(),
                            Channel = p["Channel"].ToString(),
                            DealerCity = p["DealerCity"].ToString(),
                            OutletType = p["OutletType"].ToString(),
                            ActiveInactive = p["ActiveInactive"].ToString()

                        }).ToList());
                        getdataTransctions(dt, "Import_DMS_Live_Master");

                    }

                    if (ImportFileType.SelectedValue.ConvertInt() == 48)
                    {
                        //0 as Godw_Code,
                        //0 as Comp_Code

                        //DataTable dt = CreateDatatable.GenericListToDataTableNullAlowed(dataTable.AsEnumerable().Select(dr => new
                        //{
                        //    DIALING_LIST_ID = Common.ConvertInt64(dr["DIALING_LIST_ID"]),
                        //    CREATED_DATETIME = Common.Convertstring(dr["CREATED_DATETIME"]),
                        //    SOURCE = Common.Convertstring(dr["SOURCE"]),
                        //    CAMPAIGN_SFID = Common.Convertstring(dr["CAMPAIGN_SFID"]),
                        //    CAMPAIGN_LCMID = Common.Convertstring(dr["CAMPAIGN_LCMID"]),
                        //    SVOC_ID = Common.ConvertInt64(dr["SVOC_ID"]),
                        //    CUST_SFID = Common.Convertstring(dr["CUST_SFID"]),
                        //    CUST_NAME = Common.Convertstring(dr["CUST_NAME"]),
                        //    CUST_NUMBER = Common.Convertstring(dr["CUST_NUMBER"]),
                        //    CUST_EMAIL = Common.Convertstring(dr["CUST_EMAIL"]),
                        //    DEALER_SFID = Common.Convertstring(dr["DEALER_SFID"]),
                        //    RECORD_SFID = Common.Convertstring(dr["RECORD_SFID"]),
                        //    DUE_DATETIME = Common.Convertstring(dr["DUE_DATETIME"]),
                        //    SRV_TYPE = Common.Convertstring(dr["SRV_TYPE"]),
                        //    SRV_NUMBER = Common.Convertstring(dr["SRV_NUMBER"]),
                        //    AGENT_SFID = Common.Convertstring(dr["AGENT_SFID"]),
                        //    CHANNEL = Common.Convertstring(dr["CHANNEL"]),
                        //    PRIORITY = Common.Convertstring(dr["PRIORITY"]),
                        //    DEALER_DPT_CODE = Common.Convertstring(dr["DEALER_DPT_CODE"]),
                        //    STATUS = Common.Convertstring(dr["STATUS"]),
                        //    UPDATED_TIME = Common.Convertstring(dr["UPDATED_TIME"]),
                        //    FAILURE_REASON = Common.Convertstring(dr["FAILURE_REASON"]),
                        //    SF_STATUS = Common.Convertstring(dr["SF_STATUS"]),
                        //    DPS_STATUS = Common.Convertstring(dr["DPS_STATUS"]),
                        //    CASE_SFID = Common.Convertstring(dr["CASE_SFID"]),
                        //    PHONE_1 = Common.Convertstring(dr["PHONE_1"]),
                        //    PHONE_2 = Common.Convertstring(dr["PHONE_2"]),
                        //    PHONE_3 = Common.Convertstring(dr["PHONE_3"]),
                        //    CAMPAIGN_NAME = Common.Convertstring(dr["CAMPAIGN_NAME"]),
                        //    VEHICLE_REG_NUMBER = Common.Convertstring(dr["VEHICLE_REG_NUMBER"]),
                        //    VIN = Common.Convertstring(dr["VIN"]),
                        //    CUSTOMER_NAME = Common.Convertstring(dr["CUSTOMER_NAME"]),
                        //    CUSTOMER_TYPE = Common.Convertstring(dr["CUSTOMER_TYPE"]),
                        //    GENDER = Common.Convertstring(dr["GENDER"]),
                        //    PREFERRED_PRIMARY_LANGUAGE = Common.Convertstring(dr["PREFERRED_PRIMARY_LANGUAGE"]),
                        //    PREFERRED_SECONDARY_LANGUAGE = Common.Convertstring(dr["PREFERRED_SECONDARY_LANGUAGE"]),
                        //    POLICY_NO = Common.Convertstring(dr["POLICY_NO"]),
                        //    TRUE_VALUE_FLAG = Common.Convertstring(dr["TRUE_VALUE_FLAG"]),
                        //    INVOICE_DATE = Common.Convertstring(dr["INVOICE_DATE"]),
                        //    INVOICE_NUM = Common.Convertstring(dr["INVOICE_NUM"]),
                        //    NEW_POLICY_ISSUE_DATE = Common.Convertstring(dr["NEW_POLICY_ISSUE_DATE"]),
                        //    POLICY_START_DATE = Common.Convertstring(dr["POLICY_START_DATE"]),
                        //    POLICY_END_DATE = Common.Convertstring(dr["POLICY_END_DATE"]),
                        //    ENQUIRY_SFID = Common.Convertstring(dr["ENQUIRY_SFID"]),
                        //    VEHICLE_SUBMODEL = Common.Convertstring(dr["VEHICLE_SUBMODEL"]),
                        //    VEHICLE_COLOR = Common.Convertstring(dr["VEHICLE_COLOR"]),
                        //    YEAR_OF_MANUFACTURING = Common.ConvertInt(dr["YEAR_OF_MANUFACTURING"]),
                        //    ENGINE_NO = Common.Convertstring(dr["ENGINE_NO"]),
                        //    CHASSIS_NO = Common.Convertstring(dr["CHASSIS_NO"]),
                        //    VEHICLE_SALE_DATE = Common.Convertstring(dr["VEHICLE_SALE_DATE"]),
                        //    ODOMETER_READING = Common.ConvertInt64(dr["ODOMETER_READING"]),
                        //    NEXT_SRV_DUE_DATE = Common.Convertstring(dr["NEXT_SRV_DUE_DATE"]),
                        //    IS_CTI_FLAG = Common.Convertstring(dr["IS_CTI_FLAG"]),
                        //    IS_ADHOC_CAMPAIGN_CALL = Common.Convertstring(dr["IS_ADHOC_CAMPAIGN_CALL"]),
                        //    NONMI_POLICY_NO = Common.Convertstring(dr["NONMI_POLICY_NO"]),
                        //    NONMI_INSURANCE_COMPANY = Common.Convertstring(dr["NONMI_INSURANCE_COMPANY"]),
                        //    NONMI_POLICY_ISSUE_DATE = Common.Convertstring(dr["NONMI_POLICY_ISSUE_DATE"]),
                        //    NONMI_NEW_POLICY_EXPRIY_DATE = Common.Convertstring(dr["NONMI_NEW_POLICY_EXPRIY_DATE"]),
                        //    REASON_FOR_LOST = Common.Convertstring(dr["REASON_FOR_LOST"]),
                        //    NEW_LOST_RENEWAL_LOST_FLAG = Common.Convertstring(dr["NEW_LOST_RENEWAL_LOST_FLAG"]),
                        //    CAMPAIGN_TYPE = Common.Convertstring(dr["CAMPAIGN_TYPE"]),
                        //    DEALER_NAME = Common.Convertstring(dr["DEALER_NAME"]),
                        //    CASE_OWNER = Common.Convertstring(dr["CASE_OWNER"]),
                        //    CASE_RECORD_TYPE = Common.Convertstring(dr["CASE_RECORD_TYPE"]),
                        //    CONTACT_NAME = Common.Convertstring(dr["CONTACT_NAME"]),
                        //    CREATED_BY = Common.Convertstring(dr["CREATED_BY"]),
                        //    DATETIME_CLOSED = Common.Convertstring(dr["DATETIME_CLOSED"]),
                        //    DATETIME_OPENED = Common.Convertstring(dr["DATETIME_OPENED"]),
                        //    DESCRIPTION = Common.Convertstring(dr["DESCRIPTION"]),
                        //    STATUS_MSG = Common.Convertstring(dr["STATUS_MSG"]),
                        //    CALL_RESULT_DISPOSITION = Common.Convertstring(dr["CALL_RESULT_DISPOSITION"]),
                        //    CALL_RESULT_CCE_REMARK = Common.Convertstring(dr["CALL_RESULT_CCE_REMARK"]),
                        //    CALL_RESULT_DATE_TIME = Common.Convertstring(dr["CALL_RESULT_DATE_TIME"]),
                        //    CALL_RESULT_CALLBACK_DATE_TIME = Common.Convertstring(dr["CALL_RESULT_CALLBACK_DATE_TIME"]),
                        //    CALL_RESULT_FOLLOWUP_FLAG = Common.Convertstring(dr["CALL_RESULT_FOLLOWUP_FLAG"]),
                        //    DIALER_STATUS = Common.Convertstring(dr["DIALER_STATUS"]),
                        //    RECORD_LIST_ID = Common.ConvertInt64(dr["RECORD_LIST_ID"]),
                        //    PROPENSITY = Common.Convertstring(dr["PROPENSITY"]),
                        //    VEHICLE_SFID = Common.Convertstring(dr["VEHICLE_SFID"]),
                        //    WORKSHOP_NAME = Common.Convertstring(dr["WORKSHOP_NAME"]),
                        //    SERVICE_DUE_DATE = Common.Convertstring(dr["SERVICE_DUE_DATE"]),
                        //    DNC_NUMBERS = Common.Convertstring(dr["DNC_NUMBERS"]),
                        //    CROSS_SELL_OPPORTUNITY = Common.Convertstring(dr["CROSS_SELL_OPPORTUNITY"]),
                        //    VEHICLE_MODEL = Common.Convertstring(dr["VEHICLE_MODEL"]),
                        //    VEHICLE_FUEL = Common.Convertstring(dr["VEHICLE_FUEL"]),
                        //    EW_EXPIRY_DATE = Common.Convertstring(dr["EW_EXPIRY_DATE"]),
                        //    MCP_EXPIRY_DATE = Common.Convertstring(dr["MCP_EXPIRY_DATE"]),
                        //    LAST_PSF_STATUS = Common.Convertstring(dr["LAST_PSF_STATUS"]),
                        //    VEHICLE_SALEDATE = Common.Convertstring(dr["VEHICLE_SALEDATE"]),
                        //    PROBABILITY_OF_CONVERSION = Common.Convertstring(dr["PROBABILITY_OF_CONVERSION"]),
                        //    CRITICAL_CUSTOMER = Common.Convertstring(dr["CRITICAL_CUSTOMER"]),
                        //    LAST_JC_OPEN_DATE = Common.Convertstring(dr["LAST_JC_OPEN_DATE"]),
                        //    LAST_JC_NUMBER = Common.Convertstring(dr["LAST_JC_NUMBER"]),
                        //    VEHICLE_ODOMETER = Common.ConvertInt64(dr["VEHICLE_ODOMETER"]),
                        //    LOYALITY_POINTS = Common.ConvertDecimal(dr["LOYALITY_POINTS"]),
                        //    LOYALITY_CARD_NUMBER = Common.Convertstring(dr["LOYALITY_CARD_NUMBER"]),
                        //    LAST_PICKUP_DATE = Common.Convertstring(dr["LAST_PICKUP_DATE"]),
                        //    LAST_PICKUP_LOCATION = Common.Convertstring(dr["LAST_PICKUP_LOCATION"]),
                        //    COMPLAINT_MODE = Common.Convertstring(dr["COMPLAINT_MODE"]),
                        //    CONTACT_STATUS = Common.Convertstring(dr["CONTACT_STATUS"]),
                        //    LAST_SCH_SERVICE = Common.Convertstring(dr["LAST_SCH_SERVICE"]),
                        //    LAST_SCH_SERVICE_DATE = Common.Convertstring(dr["LAST_SCH_SERVICE_DATE"]),
                        //    LAST_SCH_SERVICE_MILEAGE = Common.ConvertInt64(dr["LAST_SCH_SERVICE_MILEAGE"]),
                        //    BILL_NUMBER = Common.Convertstring(dr["BILL_NUMBER"]),
                        //    COMPLAINT_NUMBER = Common.Convertstring(dr["COMPLAINT_NUMBER"]),
                        //    COMPLAINT_DESCRIPTION = Common.Convertstring(dr["COMPLAINT_DESCRIPTION"]),
                        //    LAST_FOLLOWUP_REMARKS = Common.Convertstring(dr["LAST_FOLLOWUP_REMARKS"]),
                        //    COMPLAINT_STATUS = Common.Convertstring(dr["COMPLAINT_STATUS"]),
                        //    CUSTOMER_VOC = Common.Convertstring(dr["CUSTOMER_VOC"]),
                        //    SERVICE_APPOINTMENT_NUMBER = Common.Convertstring(dr["SERVICE_APPOINTMENT_NUMBER"]),
                        //    SERVICE_APPOINTMENT_DATE = Common.Convertstring(dr["SERVICE_APPOINTMENT_DATE"]),
                        //    PREFERED_WORKSOPE_NAME = Common.Convertstring(dr["PREFERED_WORKSOPE_NAME"]),
                        //    PREFERED_WORKSOPE_CODE = Common.Convertstring(dr["PREFERED_WORKSOPE_CODE"]),
                        //    SERVICE_ADVISOR = Common.Convertstring(dr["SERVICE_ADVISOR"]),
                        //    CALL_PRIORITY = Common.Convertstring(dr["CALL_PRIORITY"]),
                        //    APPOINTMENT_WORKSHOP = Common.Convertstring(dr["APPOINTMENT_WORKSHOP"]),
                        //    LAST_DROP_LOCATION = Common.Convertstring(dr["LAST_DROP_LOCATION"]),
                        //    LAST_DROP_DATE = Common.Convertstring(dr["LAST_DROP_DATE"]),
                        //    CAMPAIGN_SUBTYPE = Common.Convertstring(dr["CAMPAIGN_SUBTYPE"]),
                        //    CROSS_SELL_OPPORTUNITY_SVOC = Common.Convertstring(dr["CROSS_SELL_OPPORTUNITY_SVOC"]),
                        //    PRIORITY_NO = Common.Convertstring(dr["PRIORITY_NO"]),
                        //    TECHNICIAN = Common.Convertstring(dr["TECHNICIAN"]),
                        //    BILL_DATE = Common.Convertstring(dr["BILL_DATE"]),
                        //    APPOINTMENT_TYPE = Common.Convertstring(dr["APPOINTMENT_TYPE"]),
                        //    APPOINTMENT_SERVICE_TYPE = Common.Convertstring(dr["APPOINTMENT_SERVICE_TYPE"]),
                        //    APPOINTMENT_PICKUP_TYPE = Common.Convertstring(dr["APPOINTMENT_PICKUP_TYPE"]),
                        //    APPOINTMENT_PICKUP_LOCATION = Common.Convertstring(dr["APPOINTMENT_PICKUP_LOCATION"]),
                        //    APPOINTMENT_PICKUP_DATE = Common.Convertstring(dr["APPOINTMENT_PICKUP_DATE"]),
                        //    APPOINTMENT_PICKUP_DRIVER = Common.Convertstring(dr["APPOINTMENT_PICKUP_DRIVER"]),
                        //    APPOINTMENT_DROP_LOCATION = Common.Convertstring(dr["APPOINTMENT_DROP_LOCATION"]),
                        //    APPOINTMENT_DROP_DATE = Common.Convertstring(dr["APPOINTMENT_DROP_DATE"]),
                        //    APPOINTMENT_DROP_DRIVER = Common.Convertstring(dr["APPOINTMENT_DROP_DRIVER"]),
                        //    APPOINTMENT_SLOT = Common.Convertstring(dr["APPOINTMENT_SLOT"]),
                        //    APPOINTMENT_SLOT_TIME = Common.Convertstring(dr["APPOINTMENT_SLOT_TIME"]),
                        //    APPOINTMENT_REMARKS = Common.Convertstring(dr["APPOINTMENT_REMARKS"]),
                        //    SA_CODE = Common.Convertstring(dr["SA_CODE"]),
                        //    LAST_JC_SRVTYPE = Common.Convertstring(dr["LAST_JC_SRVTYPE"]),
                        //    PARENT_GROUP = Common.Convertstring(dr["PARENT_GROUP"]),
                        //    DEALER_MAP_CD = Common.Convertstring(dr["DEALER_MAP_CD"]),
                        //    LOC_CD = Common.Convertstring(dr["LOC_CD"]),
                        //    COMP_FA = Common.Convertstring(dr["COMP_FA"]),
                        //    REF_RECORD_LIST_ID = Common.Convertstring(dr["REF_RECORD_LIST_ID"]),
                        //    LAST_JC_BILL_DATE = Common.Convertstring(dr["LAST_JC_BILL_DATE"]),
                        //    VEH_IN_WORKSHOP = Common.Convertstring(dr["VEH_IN_WORKSHOP"]),
                        //    APPOINTMENT_TAKEN = Common.Convertstring(dr["APPOINTMENT_TAKEN"]),
                        //    COMPLAINT_PENDING = Common.Convertstring(dr["COMPLAINT_PENDING"]),
                        //    STAR_RATING = Common.Convertstring(dr["STAR_RATING"]),
                        //    POLICY_TYPE = Common.Convertstring(dr["POLICY_TYPE"]),
                        //    SECONDARY_POLICY_NO = Common.Convertstring(dr["SECONDARY_POLICY_NO"]),
                        //    SECONDARY_POLICY_EXPIRY_DATE = Common.Convertstring(dr["SECONDARY_POLICY_EXPIRY_DATE"]),
                        //    MI_OUTLET_CODE = Common.Convertstring(dr["MI_OUTLET_CODE"]),
                        //    MI_OUTLET_NAME = Common.Convertstring(dr["MI_OUTLET_NAME"]),
                        //    UNIQUE_CAMPAIGN_ID = Common.Convertstring(dr["UNIQUE_CAMPAIGN_ID"]),
                        //    VEHICLE_TYPE = Common.Convertstring(dr["VEHICLE_TYPE"]),
                        //    EW_TIER = Common.Convertstring(dr["EW_TIER"]),
                        //    LOYALTY_TIER = Common.Convertstring(dr["LOYALTY_TIER"]),
                        //    MCP_TIER = Common.Convertstring(dr["MCP_TIER"]),
                        //    CCP_TIER = Common.Convertstring(dr["CCP_TIER"]),
                        //    DELIVERY_DATE = Common.Convertstring(dr["DELIVERY_DATE"]),
                        //    CUSTOMER_TAG = Common.Convertstring(dr["CUSTOMER_TAG"]),
                        //    CUST_PIN = Common.Convertstring(dr["CUST_PIN"]),
                        //    LAST_SERVICE_WORKSHOP = Common.Convertstring(dr["LAST_SERVICE_WORKSHOP"]),
                        //    DND_APPLICABILITY = Common.Convertstring(dr["DND_APPLICABILITY"]),
                        //    NO_OF_CALL_ATTEMPTS = Common.ConvertInt(dr["NO_OF_CALL_ATTEMPTS"]),
                        //    AVG_CONVERSION_EFFORT = Common.ConvertDecimal(dr["AVG_CONVERSION_EFFORT"]),
                        //    BILL_AMOUNT = Common.ConvertDecimal(dr["BILL_AMOUNT"]),
                        //    LAST_CALL_DATETIME = Common.Convertstring(dr["LAST_CALL_DATETIME"]),
                        //    NO_OF_FOLLOWUP_DONE = Common.ConvertInt(dr["NO_OF_FOLLOWUP_DONE"]),
                        //    TYPE_OF_CALL = Common.Convertstring(dr["TYPE_OF_CALL"]),
                        //    CUST_CATEGORY = Common.Convertstring(dr["CUST_CATEGORY"]),
                        //    MONTHS_SINCE_LOST = Common.Convertstring(dr["MONTHS_SINCE_LOST"]),
                        //    OVERDUE_DAYS = Common.Convertstring(dr["OVERDUE_DAYS"]),
                        //    HOLDUP_LOCATION = Common.Convertstring(dr["HOLDUP_LOCATION"]),
                        //    CCP_EXP_DT = Common.Convertstring(dr["CCP_EXP_DT"]),
                        //    PW_EXP_DATE = Common.Convertstring(dr["PW_EXP_DATE"]),
                        //    APP_SOURCE = dr["APP_SOURCE"].ToString()

                        //}).ToList());
                        getdataTransctions(dataTable, "Import_DPSDump");

                    }


                    if (ImportFileType.SelectedValue.ConvertInt() == 36)
                    {
                        //0 as Godw_Code,
                        //0 as Comp_Code
                        DataTable dt = CreateDatatable.GenericListToDataTableNullAlowed(dataTable.AsEnumerable().Select(p => new
                        {
                            Sellingparent = p["Sellingparent"].ToString(),
                            ServiceDlrCd = p["ServiceDlrCd"].ToString(),
                            ServiceLoc = p["ServiceLoc"].ToString(),
                            ServiceDlrGstNum = p["ServiceDlrGstNum"].ToString(),
                            LotNum = p["LotNum"].ToString(),
                            GstLotNum = p["GstLotNum"].ToString(),
                            LotDate = p["LotDate"].ToString(),
                            LotAmt = p["LotAmt"].ToString(),
                            TaxAmt = p["TaxAmt"].ToString(),
                            Taxyn = p["Taxyn"].ToString(),
                            Status = p["Status"].ToString(),
                            PaymentDetails = p["PaymentDetails"].ToString(),
                            SellingParent = p["SellingParent"].ToString(),
                            SellingDlrCd = p["SellingDlrCd"].ToString(),
                            Sellingloc = p["Sellingloc"].ToString(),
                            SellingGstNum = p["SellingGstNum"].ToString(),

                        }).ToList());
                        getdataTransctions(dt, "Import_DMS_FSC_Income");

                    }



                    if (ImportFileType.SelectedValue.ConvertInt() == 37)
                    {
                        //0 as Godw_Code,
                        //0 as Comp_Code
                        if (SiteSession.LoginUser.User_Code == 345)
                        {
                            DataTable dt = CreateDatatable.GenericListToDataTableNullAlowed(dataTable.AsEnumerable().Select(p => new
                            {
                                Serviceparent = p["Serviceparent"].ToString(),
                                ServiceDlrCd = p["ServiceDlrCd"].ToString(),
                                ServiceLoc = p["ServiceLoc"].ToString(),
                                ServiceDlrGstNum = p["ServiceDlrGstNum"].ToString(),
                                LotNum = p["LotNum"].ToString(),
                                GstLotNum = p["GstLotNum"].ToString(),
                                LotDate = p["LotDate"].ToString(),
                                LotAmt = p["LotAmt"].ToString(),
                                TaxAmt = p["TaxAmt"].ToString(),
                                Taxyn = p["Taxyn"].ToString(),
                                Status = p["Status"].ToString(),
                                PaymentDetails = p["PaymentDetails"].ToString(),
                                SellingParent = p["SellingParent"].ToString(),
                                SellingDlrCd = p["SellingDlrCd"].ToString(),
                                Sellingloc = p["Sellingloc"].ToString(),
                                SellingGstNum = p["SellingGstNum"].ToString(),
                                TCS = p["TDS"].ToString()

                            }).ToList());
                            getdataTransctions(dt, "Import_DMS_FSC_Expense");
                        }
                        else
                        {
                            DataTable dt = CreateDatatable.GenericListToDataTableNullAlowed(dataTable.AsEnumerable().Select(p => new
                            {
                                Serviceparent = p["Serviceparent"].ToString(),
                                ServiceDlrCd = p["ServiceDlrCd"].ToString(),
                                ServiceLoc = p["ServiceLoc"].ToString(),
                                ServiceDlrGstNum = p["ServiceDlrGstNum"].ToString(),
                                LotNum = p["LotNum"].ToString(),
                                GstLotNum = p["GstLotNum"].ToString(),
                                LotDate = p["LotDate"].ToString(),
                                LotAmt = p["LotAmt"].ToString(),
                                TaxAmt = p["TaxAmt"].ToString(),
                                Taxyn = p["Taxyn"].ToString(),
                                Status = p["Status"].ToString(),
                                PaymentDetails = p["PaymentDetails"].ToString(),
                                SellingParent = p["SellingParent"].ToString(),
                                SellingDlrCd = p["SellingDlrCd"].ToString(),
                                Sellingloc = p["Sellingloc"].ToString(),
                                SellingGstNum = p["SellingGstNum"].ToString() 
                              

                            }).ToList());
                            getdataTransctions(dt, "Import_DMS_FSC_Expense");
                        }

                    }

                    if (ImportFileType.SelectedValue.ConvertInt() == 35)
                    {
                        //0 as Godw_Code,
                        //0 as Comp_Code
                        DataTable dt = CreateDatatable.GenericListToDataTableNullAlowed(dataTable.AsEnumerable().Select(p => new
                        {
                            Region = p["Region"].ToString(),
                            Parent = p["Parent"].ToString(),
                            DealerMapCD = p["DealerMapCD"].ToString(),
                            LocCD = p["LocCD"].ToString(),
                            Type = p["Type"].ToString(),
                            DealerName = p["DealerName"].ToString(),
                            LocDesc = p["LocDesc"].ToString(),
                            SalesCD = p["SalesCD"].ToString(),
                            ServiceCD = p["ServiceCD"].ToString(),
                            SparesCD = p["SparesCD"].ToString(),
                            ForCD = p["ForCD"].ToString(),
                            OutletCode = p["OutletCode"].ToString(),
                            TVCode = p["TVCode"].ToString(),
                            DealerCategory = p["DealerCategory"].ToString(),
                            ConsigneeCD = p["ConsigneeCD"].ToString(),
                            SalesStockYard = p["SalesStockYard"].ToString(),
                            SparesStockYard = p["SparesStockYard"].ToString(),
                            DealerAddress1 = p["DealerAddress1"].ToString(),
                            DealerAddress2 = p["DealerAddress2"].ToString(),
                            BSC = p["BSC"].ToString(),
                            SalesLiveDate = p["SalesLiveDate"].ToString(),
                            ServiceLiveDate = p["ServiceLiveDate"].ToString(),
                            ActivationDate = p["ActivationDate"].ToString(),
                            GSTNum = p["GSTNum"].ToString(),
                            Channel = p["Channel"].ToString(),
                            DealerCity = p["DealerCity"].ToString(),
                            OutletType = p["OutletType"].ToString(),
                            ActiveInactive = p["ActiveInactive"].ToString()

                        }).ToList());
                        getdataTransctions(dt, "Import_DMS_Live_Master");

                    }
                    if (ImportFileType.SelectedValue.ConvertInt() == 38)
                    {
                        //0 as Godw_Code,
                        //0 as Comp_Code


                        var ListData = dataTable.AsEnumerable().ToList().Select(p => new
                        {
                            ProcessName = "",
                            INVOICENUM = p["INVOICENUM"].ToString(),
                            INVOICEDATE = p["INVOICEDATE"].ToString(),
                            PlaceofSupply = p["PlaceofSupply"].ToString(),
                            NameofCustomer = p["NameofCustomer"].ToString(),
                            GoodsService = p["GoodsService"].ToString(),
                            GSTNUM = p["GSTNUM"].ToString(),
                            HSNSACCODE = p["HSNSACCODE"].ToString(),
                            PAN = p["PAN"].ToString(),
                            Quantity = p["Quantity"].ToString(),
                            TotalInvoiceValue = p["TotalInvoiceValue"].ToString(),
                            TAXABLEVALUE = p["TAXABLEVALUE"].ToString(),
                            IGSTRATE = p["IGSTRATE"].ToString(),
                            IGSTAMT = p["IGSTAMT"].ToString(),
                            CGSTRATE = p["CGSTRATE"].ToString(),
                            CGSTAMT = p["CGSTAMT"].ToString(),
                            SGSTRATE = p["SGSTRATE"].ToString(),
                            SGSTAMT = p["SGSTAMT"].ToString(),
                            KeralaFloodCessRate = p["KeralaFloodCessRate"].ToString(),
                            KeralaFloodCessAmount = p["KeralaFloodCessAmount"].ToString(),
                            TCSRate = p["TCSRate"].ToString(),
                            TCSAmount = p["TCSAmount"].ToString(),
                            GrossAmount = p["GrossAmount"].ToString(),
                            TotalTaxCate = (Common.ConvertDecimal(p["IGSTRATE"]) + Common.ConvertDecimal(p["CGSTRATE"]) + Common.ConvertDecimal(p["SGSTRATE"]))

                        }).ToList();

                        DataTable dt = CreateDatatable.GenericListToDataTableNullAlowed(ListData.GroupBy(p => new { p.INVOICENUM, p.HSNSACCODE, p.TotalTaxCate }).Select(p => new
                        {
                            ProcessName = p.FirstOrDefault().ProcessName,
                            INVOICENUM = p.FirstOrDefault().INVOICENUM,
                            INVOICEDATE = p.FirstOrDefault().INVOICEDATE,
                            PlaceofSupply = p.FirstOrDefault().PlaceofSupply,
                            NameofCustomer = p.FirstOrDefault().NameofCustomer,
                            GoodsService = p.FirstOrDefault().GoodsService,
                            GSTNUM = p.FirstOrDefault().GSTNUM,
                            HSNSACCODE = p.FirstOrDefault().HSNSACCODE,
                            PAN = p.FirstOrDefault().PAN,
                            Quantity = p.Sum(X => WebApp.LIBS.Common.ConvertDecimal(X.Quantity)).ToString(),
                            TotalInvoiceValue = p.Sum(X => WebApp.LIBS.Common.ConvertDecimal(X.TotalInvoiceValue)).ToString(),
                            TAXABLEVALUE = p.Sum(X => WebApp.LIBS.Common.ConvertDecimal(X.TAXABLEVALUE)).ToString(),
                            IGSTRATE = p.FirstOrDefault().IGSTRATE,
                            IGSTAMT = p.Sum(X => WebApp.LIBS.Common.ConvertDecimal(X.IGSTAMT)).ToString(),
                            CGSTRATE = p.FirstOrDefault().CGSTRATE,

                            CGSTAMT = p.Sum(X => WebApp.LIBS.Common.ConvertDecimal(X.CGSTAMT)).ToString(),
                            SGSTRATE = p.FirstOrDefault().SGSTRATE,
                            SGSTAMT = p.Sum(X => WebApp.LIBS.Common.ConvertDecimal(X.SGSTAMT)).ToString(),
                            KeralaFloodCessRate = p.FirstOrDefault().KeralaFloodCessRate,
                            KeralaFloodCessAmount = p.Sum(X => WebApp.LIBS.Common.ConvertDecimal(X.KeralaFloodCessAmount)).ToString(),


                            TCSRate = p.FirstOrDefault().TCSRate,
                            TCSAmount = p.Sum(X => WebApp.LIBS.Common.ConvertDecimal(X.TCSAmount)).ToString(),
                            GrossAmount = p.Sum(X => WebApp.LIBS.Common.ConvertDecimal(X.GrossAmount)).ToString(),
                            TotalTaxCate = p.Key.TotalTaxCate.ToString()



                        }).ToList()); ;
                        getdataTransctions(dt, "ImporttallydataValidate");

                    }


                    if (ImportFileType.SelectedValue.ConvertInt() == 39)
                    {
                        //0 as Godw_Code,
                        //0 as Comp_Code
                        DataTable dt = CreateDatatable.GenericListToDataTableNullAlowed(dataTable.AsEnumerable().Select(p => new
                        {
                            DealerParentGroup = p["DealerParentGroup"].ToString(),
                            DealerRegion = p["DealerRegion"].ToString(),
                            DealerLocationCode = p["DealerLocationCode"].ToString(),
                            DealerCode = p["DealerCode"].ToString(),
                            DealerName = p["DealerName"].ToString(),
                            OutletCode = p["OutletCode"].ToString(),
                            LoyaltyCardNumber = p["LoyaltyCardNumber"].ToString(),
                            LoyaltyCardStatus = p["LoyaltyCardStatus"].ToString(),
                            EnrollmentDate = p["EnrollmentDate"].ToString(),
                            Tier = p["Tier"].ToString(),
                            BalPoint = p["BalPoint"].ToString(),
                            LoyaltyInvoiceNo = p["LoyaltyInvoiceNo"].ToString(),
                            LoyaltyInvoiceDate = p["LoyaltyInvoiceDate"].ToString(),
                            CustomerName = p["CustomerName"].ToString(),
                            VIN = p["VIN"].ToString(),
                            VehicleInvoiceDate = p["VehicleInvoiceDate"].ToString(),
                            NoofBadgesAvailed = p["NoofBadgesAvailed"].ToString(),
                            NoofReferralsMade = p["NoofReferralsMade"].ToString(),
                            ExchangeBonusEarned = p["ExchangeBonusEarned"].ToString(),


                        }).ToList());
                        getdataTransctions(dt, "SP_MSR_Import");

                    }

                    if (ImportFileType.SelectedValue.ConvertInt() == 40)
                    {

                        dataTable.Columns.Remove(dataTable.Columns[0]);
                        DataTable dt = CreateDatatable.GenericListToDataTableNullAlowed(dataTable.AsEnumerable().Select(dr => new
                        {

                            IssueNo = dr["IssueNo"].ToString(),
                            PartNoLabourCode = dr["PartNoLabourCode"].ToString(),
                            Description = dr["Description"].ToString(),
                            HSNSAC = dr["HSNSAC"].ToString(),
                            UnitPrice = Common.ConvertDecimal(dr["UnitPrice"]),
                            Qty = Common.ConvertDecimal(dr["Qty"]),
                            CGSTRate = Common.ConvertDecimal(dr["CGSTRate"]),
                            SGSTRate = Common.ConvertDecimal(dr["SGSTRate"]),
                            IGSTRate = Common.ConvertDecimal(dr["IGSTRate"]),
                            TaxableAmountRs = Common.ConvertDecimal(dr["TaxableAmountRs"]),
                            Type = dr["Type"].ToString(),
                            BILLNo = dr["BILLNo"].ToString(),
                            BillDate = dr["BillDate"].ToString(),
                            SaleLedger = dr["SaleLedger"].ToString(),
                            CustomerLedger = dr["CustomerLedger"].ToString(),
                            BookName = dr["BookName"].ToString(),
                            Loc_CD = dr["LocCD"].ToString(),


                        }).ToList());
                        getdataTransctions(dt, "Import_MSILWarrantyClaim");

                    }

                    if (ImportFileType.SelectedValue.ConvertInt() == 43)
                    {
                        //0 as Godw_Code,
                        //0 as Comp_Code

                        DataTable dt = CreateDatatable.GenericListToDataTableNullAlowed(dataTable.AsEnumerable().Select(dr => new
                        {

                            Loccd = dr["Loccd"].ToString(),
                            StockTrfIssueNo = dr["StockTrfIssueNo"].ToString(),
                            StockTrfIssueDate = dr["StockTrfIssueDate"].ToString(),
                            StockReceiptNo = dr["StockReceiptNo"].ToString(),
                            StockReceiptDate = dr["StockReceiptDate"].ToString(),
                            Chassisnumber = dr["Chassisnumber"].ToString(),
                            Enginenumber = dr["Enginenumber"].ToString(),
                            Variantcode = dr["Variantcode"].ToString(),
                            VariantDescription = dr["VariantDescription"].ToString(),
                            Colorcode = dr["Colorcode"].ToString(),
                            ColorDescription = dr["ColorDescription"].ToString(),
                            Keynumber = dr["Keynumber"].ToString(),
                            FromLocationCode = dr["FromLocationCode"].ToString(),
                            ToLocationCode = dr["ToLocationCode"].ToString(),
                            NetDealerprice = dr["NetDealerprice"].ToString(),
                            Receivedby = dr["Receivedby"].ToString(),
                            Purchaseprice = dr["Purchaseprice"].ToString(),
                            Taxablevalue = dr["Taxablevalue"].ToString(),
                            Transportamount = dr["Transportamount"].ToString(),
                            Servicecharge = dr["Servicecharge"].ToString(),
                            Subtotalservice = dr["Subtotalservice"].ToString(),



                        }).ToList());
                        getdataTransctions(dt, "ImportUpdateSTO");

                    }


                    if (ImportFileType.SelectedValue.ConvertInt() == 44)
                    {
                        //0 as Godw_Code,
                        //0 as Comp_Code

                        DataTable dt = CreateDatatable.GenericListToDataTableNullAlowed(dataTable.AsEnumerable().Select(dr => new
                        {

                            Loccd = dr["Loccd"].ToString(),
                            StockTrfIssueNo = dr["StockTrfIssueNo"].ToString(),
                            StockTrfIssueDate = dr["StockTrfIssueDate"].ToString(),
                            StockReceiptNo = dr["StockReceiptNo"].ToString(),
                            StockReceiptDate = dr["StockReceiptDate"].ToString(),
                            Chassisnumber = dr["Chassisnumber"].ToString(),
                            Enginenumber = dr["Enginenumber"].ToString(),
                            Variantcode = dr["Variantcode"].ToString(),
                            VariantDescription = dr["VariantDescription"].ToString(),
                            Colorcode = dr["Colorcode"].ToString(),
                            ColorDescription = dr["ColorDescription"].ToString(),
                            Keynumber = dr["Keynumber"].ToString(),
                            FromLocationCode = dr["FromLocationCode"].ToString(),
                            ToLocationCode = dr["ToLocationCode"].ToString(),
                            NetDealerprice = dr["NetDealerprice"].ToString(),
                            Receivedby = dr["Receivedby"].ToString(),
                            Purchaseprice = dr["Purchaseprice"].ToString(),
                            Taxablevalue = dr["Taxablevalue"].ToString(),
                            Transportamount = dr["Transportamount"].ToString(),
                            Servicecharge = dr["Servicecharge"].ToString(),
                            Subtotalservice = dr["Subtotalservice"].ToString(),



                        }).ToList());
                        getdataTransctions(dt, "ImportUpdateSTI");

                    }





                    if (ImportFileType.SelectedValue.ConvertInt() == 41)
                    {
                        //0 as Godw_Code,
                        //0 as Comp_Code

                        DataTable dtgodwn = OtherSqlConn.FillDataTable("select NEWCAR_RCPT,DMS_HSN_Code from  godown_mst");
                        DataTable dt = CreateDatatable.GenericListToDataTableNullAlowed(dataTable.AsEnumerable().Select(p => new
                        {
                            InvoiceNum = (dtgodwn.AsEnumerable().ToList().Where(xpc => xpc["NEWCAR_RCPT"].ToString() == p["LocCode"].ToString()).FirstOrDefault()["DMS_HSN_Code"].ToString() + "/" + p["InvoiceNum"].ToString()),
                            MIDate = p["MIDate"].ToString(),

                        }).ToList());
                        getdataTransctions(dt, "ImportActualMIDateupdate");

                    }

                    if (ImportFileType.SelectedValue.ConvertInt() == 49)
                    {

                        getdataTransctions(dataTable, "SP_ImportLoyaltyCard");
                    }

                    if (ImportFileType.SelectedValue.ConvertInt() == 45 || ImportFileType.SelectedValue.ConvertInt() == 46 || ImportFileType.SelectedValue.ConvertInt() == 47)
                    {

                        DataTable dt = CreateDatatable.GenericListToDataTableNullAlowed(dataTable.AsEnumerable().Select(dr => new
                        {


                            DIALING_LIST_ID = dr["DIALING_LIST_ID"].ToString(),
                            CREATED_DATETIME = dr["CREATED_DATETIME"].ToString(),
                            SOURCE = dr["SOURCE"].ToString(),
                            CAMPAIGN_SFID = dr["CAMPAIGN_SFID"].ToString(),
                            CAMPAIGN_LCMID = dr["CAMPAIGN_LCMID"].ToString(),
                            SVOC_ID = dr["SVOC_ID"].ToString(),
                            CUST_SFID = dr["CUST_SFID"].ToString(),
                            CUST_NAME = dr["CUST_NAME"].ToString(),
                            CUST_NUMBER = dr["CUST_NUMBER"].ToString(),
                            CUST_EMAIL = dr["CUST_EMAIL"].ToString(),
                            DEALER_SFID = dr["DEALER_SFID"].ToString(),
                            RECORD_SFID = dr["RECORD_SFID"].ToString(),
                            DUE_DATETIME = dr["DUE_DATETIME"].ToString(),
                            SRV_TYPE = dr["SRV_TYPE"].ToString(),
                            SRV_NUMBER = dr["SRV_NUMBER"].ToString(),
                            AGENT_SFID = dr["AGENT_SFID"].ToString(),
                            CHANNEL = dr["CHANNEL"].ToString(),
                            PRIORITY = dr["PRIORITY"].ToString(),
                            DEALER_DPT_CODE = dr["DEALER_DPT_CODE"].ToString(),
                            STATUS = dr["STATUS"].ToString(),
                            UPDATED_TIME = dr["UPDATED_TIME"].ToString(),
                            FAILURE_REASON = dr["FAILURE_REASON"].ToString(),
                            SF_STATUS = dr["SF_STATUS"].ToString(),
                            DPS_STATUS = dr["DPS_STATUS"].ToString(),
                            CASE_SFID = dr["CASE_SFID"].ToString(),
                            PHONE_1 = dr["PHONE_1"].ToString(),
                            PHONE_2 = dr["PHONE_2"].ToString(),
                            PHONE_3 = dr["PHONE_3"].ToString(),
                            CAMPAIGN_NAME = dr["CAMPAIGN_NAME"].ToString(),
                            VEHICLE_REG_NUMBER = dr["VEHICLE_REG_NUMBER"].ToString(),
                            VIN = dr["VIN"].ToString(),
                            CUSTOMER_NAME = dr["CUSTOMER_NAME"].ToString(),
                            CUSTOMER_TYPE = dr["CUSTOMER_TYPE"].ToString(),
                            GENDER = dr["GENDER"].ToString(),
                            PREFERRED_PRIMARY_LANGUAGE = dr["PREFERRED_PRIMARY_LANGUAGE"].ToString(),
                            PREFERRED_SECONDARY_LANGUAGE = dr["PREFERRED_SECONDARY_LANGUAGE"].ToString(),
                            POLICY_NO = dr["POLICY_NO"].ToString(),
                            TRUE_VALUE_FLAG = dr["TRUE_VALUE_FLAG"].ToString(),
                            INVOICE_DATE = dr["INVOICE_DATE"].ToString(),
                            INVOICE_NUM = dr["INVOICE_NUM"].ToString(),
                            NEW_POLICY_ISSUE_DATE = dr["NEW_POLICY_ISSUE_DATE"].ToString(),
                            POLICY_START_DATE = dr["POLICY_START_DATE"].ToString(),
                            POLICY_END_DATE = dr["POLICY_END_DATE"].ToString(),
                            ENQUIRY_SFID = dr["ENQUIRY_SFID"].ToString(),
                            VEHICLE_SUBMODEL = dr["VEHICLE_SUBMODEL"].ToString(),
                            VEHICLE_COLOR = dr["VEHICLE_COLOR"].ToString(),
                            YEAR_OF_MANUFACTURING = dr["YEAR_OF_MANUFACTURING"].ToString(),
                            ENGINE_NO = dr["ENGINE_NO"].ToString(),
                            CHASSIS_NO = dr["CHASSIS_NO"].ToString(),
                            VEHICLE_SALE_DATE = dr["VEHICLE_SALE_DATE"].ToString(),
                            ODOMETER_READING = dr["ODOMETER_READING"].ToString(),
                            NEXT_SRV_DUE_DATE = dr["NEXT_SRV_DUE_DATE"].ToString(),
                            IS_CTI_FLAG = dr["IS_CTI_FLAG"].ToString(),
                            IS_ADHOC_CAMPAIGN_CALL = dr["IS_ADHOC_CAMPAIGN_CALL"].ToString(),
                            NONMI_POLICY_NO = dr["NONMI_POLICY_NO"].ToString(),
                            NONMI_INSURANCE_COMPANY = dr["NONMI_INSURANCE_COMPANY"].ToString(),
                            NONMI_POLICY_ISSUE_DATE = dr["NONMI_POLICY_ISSUE_DATE"].ToString(),
                            NONMI_NEW_POLICY_EXPRIY_DATE = dr["NONMI_NEW_POLICY_EXPRIY_DATE"].ToString(),
                            REASON_FOR_LOST = dr["REASON_FOR_LOST"].ToString(),
                            NEW_LOST_RENEWAL_LOST_FLAG = dr["NEW_LOST_RENEWAL_LOST_FLAG"].ToString(),
                            CAMPAIGN_TYPE = dr["CAMPAIGN_TYPE"].ToString(),
                            DEALER_NAME = dr["DEALER_NAME"].ToString(),
                            CASE_OWNER = dr["CASE_OWNER"].ToString(),
                            CASE_RECORD_TYPE = dr["CASE_RECORD_TYPE"].ToString(),
                            CONTACT_NAME = dr["CONTACT_NAME"].ToString(),
                            CREATED_BY = dr["CREATED_BY"].ToString(),
                            DATETIME_CLOSED = dr["DATETIME_CLOSED"].ToString(),
                            DATETIME_OPENED = dr["DATETIME_OPENED"].ToString(),
                            DESCRIPTION = dr["DESCRIPTION"].ToString(),
                            STATUS_MSG = dr["STATUS_MSG"].ToString(),
                            CALL_RESULT_DISPOSITION = dr["CALL_RESULT_DISPOSITION"].ToString(),
                            CALL_RESULT_CCE_REMARK = dr["CALL_RESULT_CCE_REMARK"].ToString(),
                            CALL_RESULT_DATE_TIME = dr["CALL_RESULT_DATE_TIME"].ToString(),
                            CALL_RESULT_CALLBACK_DATE_TIME = dr["CALL_RESULT_CALLBACK_DATE_TIME"].ToString(),
                            CALL_RESULT_FOLLOWUP_FLAG = dr["CALL_RESULT_FOLLOWUP_FLAG"].ToString(),
                            DIALER_STATUS = dr["DIALER_STATUS"].ToString(),
                            RECORD_LIST_ID = dr["RECORD_LIST_ID"].ToString(),
                            PROPENSITY = dr["PROPENSITY"].ToString(),
                            VEHICLE_SFID = dr["VEHICLE_SFID"].ToString(),
                            WORKSHOP_NAME = dr["WORKSHOP_NAME"].ToString(),
                            SERVICE_DUE_DATE = dr["SERVICE_DUE_DATE"].ToString(),
                            DNC_NUMBERS = dr["DNC_NUMBERS"].ToString(),
                            CROSS_SELL_OPPORTUNITY = dr["CROSS_SELL_OPPORTUNITY"].ToString(),
                            VEHICLE_MODEL = dr["VEHICLE_MODEL"].ToString(),
                            VEHICLE_FUEL = dr["VEHICLE_FUEL"].ToString(),
                            EW_EXPIRY_DATE = dr["EW_EXPIRY_DATE"].ToString(),
                            MCP_EXPIRY_DATE = dr["MCP_EXPIRY_DATE"].ToString(),
                            LAST_PSF_STATUS = dr["LAST_PSF_STATUS"].ToString(),
                            VEHICLE_SALEDATE = dr["VEHICLE_SALEDATE"].ToString(),
                            PROBABILITY_OF_CONVERSION = dr["PROBABILITY_OF_CONVERSION"].ToString(),
                            CRITICAL_CUSTOMER = dr["CRITICAL_CUSTOMER"].ToString(),
                            LAST_JC_OPEN_DATE = dr["LAST_JC_OPEN_DATE"].ToString(),
                            LAST_JC_NUMBER = dr["LAST_JC_NUMBER"].ToString(),
                            VEHICLE_ODOMETER = dr["VEHICLE_ODOMETER"].ToString(),
                            LOYALITY_POINTS = dr["LOYALITY_POINTS"].ToString(),
                            LOYALITY_CARD_NUMBER = dr["LOYALITY_CARD_NUMBER"].ToString(),
                            LAST_PICKUP_DATE = dr["LAST_PICKUP_DATE"].ToString(),
                            LAST_PICKUP_LOCATION = dr["LAST_PICKUP_LOCATION"].ToString(),
                            COMPLAINT_MODE = dr["COMPLAINT_MODE"].ToString(),
                            CONTACT_STATUS = dr["CONTACT_STATUS"].ToString(),
                            LAST_SCH_SERVICE = dr["LAST_SCH_SERVICE"].ToString(),
                            LAST_SCH_SERVICE_DATE = dr["LAST_SCH_SERVICE_DATE"].ToString(),
                            LAST_SCH_SERVICE_MILEAGE = dr["LAST_SCH_SERVICE_MILEAGE"].ToString(),
                            BILL_NUMBER = dr["BILL_NUMBER"].ToString(),
                            COMPLAINT_NUMBER = dr["COMPLAINT_NUMBER"].ToString(),
                            COMPLAINT_DESCRIPTION = dr["COMPLAINT_DESCRIPTION"].ToString(),
                            LAST_FOLLOWUP_REMARKS = dr["LAST_FOLLOWUP_REMARKS"].ToString(),
                            COMPLAINT_STATUS = dr["COMPLAINT_STATUS"].ToString(),
                            CUSTOMER_VOC = dr["CUSTOMER_VOC"].ToString(),
                            SERVICE_APPOINTMENT_NUMBER = dr["SERVICE_APPOINTMENT_NUMBER"].ToString(),
                            SERVICE_APPOINTMENT_DATE = dr["SERVICE_APPOINTMENT_DATE"].ToString(),
                            PREFERED_WORKSOPE_NAME = dr["PREFERED_WORKSOPE_NAME"].ToString(),
                            PREFERED_WORKSOPE_CODE = dr["PREFERED_WORKSOPE_CODE"].ToString(),
                            SERVICE_ADVISOR = dr["SERVICE_ADVISOR"].ToString(),
                            CALL_PRIORITY = dr["CALL_PRIORITY"].ToString(),
                            APPOINTMENT_WORKSHOP = dr["APPOINTMENT_WORKSHOP"].ToString(),
                            LAST_DROP_LOCATION = dr["LAST_DROP_LOCATION"].ToString(),
                            LAST_DROP_DATE = dr["LAST_DROP_DATE"].ToString(),
                            CAMPAIGN_SUBTYPE = dr["CAMPAIGN_SUBTYPE"].ToString(),
                            CROSS_SELL_OPPORTUNITY_SVOC = dr["CROSS_SELL_OPPORTUNITY_SVOC"].ToString(),
                            PRIORITY_NO = dr["PRIORITY_NO"].ToString(),
                            TECHNICIAN = dr["TECHNICIAN"].ToString(),
                            BILL_DATE = dr["BILL_DATE"].ToString(),
                            APPOINTMENT_TYPE = dr["APPOINTMENT_TYPE"].ToString(),
                            APPOINTMENT_SERVICE_TYPE = dr["APPOINTMENT_SERVICE_TYPE"].ToString(),
                            APPOINTMENT_PICKUP_TYPE = dr["APPOINTMENT_PICKUP_TYPE"].ToString(),
                            APPOINTMENT_PICKUP_LOCATION = dr["APPOINTMENT_PICKUP_LOCATION"].ToString(),
                            APPOINTMENT_PICKUP_DATE = dr["APPOINTMENT_PICKUP_DATE"].ToString(),
                            APPOINTMENT_PICKUP_DRIVER = dr["APPOINTMENT_PICKUP_DRIVER"].ToString(),
                            APPOINTMENT_DROP_LOCATION = dr["APPOINTMENT_DROP_LOCATION"].ToString(),
                            APPOINTMENT_DROP_DATE = dr["APPOINTMENT_DROP_DATE"].ToString(),
                            APPOINTMENT_DROP_DRIVER = dr["APPOINTMENT_DROP_DRIVER"].ToString(),
                            APPOINTMENT_SLOT = dr["APPOINTMENT_SLOT"].ToString(),
                            APPOINTMENT_SLOT_TIME = dr["APPOINTMENT_SLOT_TIME"].ToString(),
                            APPOINTMENT_REMARKS = dr["APPOINTMENT_REMARKS"].ToString(),
                            SA_CODE = dr["SA_CODE"].ToString(),
                            LAST_JC_SRVTYPE = dr["LAST_JC_SRVTYPE"].ToString(),
                            PARENT_GROUP = dr["PARENT_GROUP"].ToString(),
                            DEALER_MAP_CD = dr["DEALER_MAP_CD"].ToString(),
                            LOC_CD = dr["LOC_CD"].ToString(),
                            COMP_FA = dr["COMP_FA"].ToString(),
                            REF_RECORD_LIST_ID = dr["REF_RECORD_LIST_ID"].ToString(),
                            LAST_JC_BILL_DATE = dr["LAST_JC_BILL_DATE"].ToString(),
                            VEH_IN_WORKSHOP = dr["VEH_IN_WORKSHOP"].ToString(),
                            APPOINTMENT_TAKEN = dr["APPOINTMENT_TAKEN"].ToString(),
                            COMPLAINT_PENDING = dr["COMPLAINT_PENDING"].ToString(),
                            STAR_RATING = dr["STAR_RATING"].ToString(),
                            POLICY_TYPE = dr["POLICY_TYPE"].ToString(),
                            SECONDARY_POLICY_NO = dr["SECONDARY_POLICY_NO"].ToString(),
                            SECONDARY_POLICY_EXPIRY_DATE = dr["SECONDARY_POLICY_EXPIRY_DATE"].ToString(),
                            MI_OUTLET_CODE = dr["MI_OUTLET_CODE"].ToString(),
                            MI_OUTLET_NAME = dr["MI_OUTLET_NAME"].ToString(),


                        }).ToList());

                        if (ImportFileType.SelectedValue.ConvertInt() == 45)
                            {

                            getdataTransctions(dt, "SP_IMPORT__DPSDdata_SMR");
                        }






                        else if (ImportFileType.SelectedValue.ConvertInt() == 46)
                        {

                            getdataTransctions(dt, "SP_IMPORT__DPSDdata_MI");
                        }
                        else if (ImportFileType.SelectedValue.ConvertInt() == 47)
                        {

                            getdataTransctions(dt, "SP_IMPORT__DPSDdata_PSF");
                        }
                    }


                    if (ImportFileType.SelectedValue.ConvertInt() == 42)
                    {

                        DataTable dt = CreateDatatable.GenericListToDataTableNullAlowed(dataTable.AsEnumerable().Select(p => new
                        {
                            VINNO = p["VINNO"].ToString(),
                            YEAROFMANUFACTURE = p["YEAROFMANUFACTURE"].ToString(),
                        }).ToList());
                        getdataTransctions(dt, "ImportMFGYearupdate");

                    }
                    //< asp:ListItem Text = "Import DMS Live Master" Value = "35" ></ asp:ListItem >

                    //                          < asp:ListItem Text = "Import  DMS FSC Income" Value = "36" ></ asp:ListItem >

                    //                                 < asp:ListItem Text = "Import DMS FSC Expense" Value = "37" ></ asp:ListItem >

                    if (ImportFileType.SelectedValue.ConvertInt() == 31)
                    {
                        string MULInvoicenumber = string.Join(",", dataTable.AsEnumerable().GroupBy(p => p[13]).Select(p => "'" + p.Key.ToString() + "'").ToArray());
                        string VIN = string.Join(",", dataTable.AsEnumerable().GroupBy(p => p[40]).Select(p => "'" + p.Key.ToString() + "'").ToArray());
                        DataTable GETFilterTrans = OtherSqlConn.FillDataTable("select Max(UTD) as UTD, Trans_Ref_Num,vin from  gd_fdi_trans where Trans_Ref_Num in (" + MULInvoicenumber + ") and vin in (" + VIN + ")  and len(isnull(Trans_Ref_Num,''))>0 and len(isnull(vin,''))>0 and isnull(AutoVYN_Flag,'')='' and (trans_type='VP' or trans_type='VD') group by Trans_Ref_Num,vin");

                        var FilterDataDB = GETFilterTrans.AsEnumerable().Select(p => new GETFilterTrans() { UTD = Convert.ToInt32(p["UTD"]), vin = p["vin"].ToString(), Trans_Ref_Num = p["Trans_Ref_Num"].ToString() }).ToList();// Global.Context.ExecuteStoreQuery<GETFilterTrans>("select Max(UTD) as UTD, Trans_Ref_Num,vin from  gd_fdi_trans where Trans_Ref_Num in (" + MULInvoicenumber + ") and vin in (" + VIN + ")  and len(isnull(Trans_Ref_Num,''))>0 and len(isnull(vin,''))>0 and isnull(AutoVYN_Flag,'')='' and trans_type='VP' group by Trans_Ref_Num,vin").ToList();
                        var loop = Math.Ceiling(Convert.ToDecimal(FilterDataDB.Count) / 20m);
                        for (int i = 0; i < loop; i++)
                        {
                            var dtPage = FilterDataDB.Skip(i * 20).Take(20).ToList();
                            string strupdateData = "";
                            dtPage.ForEach(p =>
                            {

                            DataRow dr = dataTable.AsEnumerable().Where(xpc => xpc[13].ToString() == p.Trans_Ref_Num && xpc[40].ToString() == p.vin).FirstOrDefault();
                                if (Common.ConvertDecimal(dr[41].ToString()) > 0 && Common.ConvertDecimal(dr[32].ToString()) > 0)
                                {
                                    if (strupdateData.Length > 0)
                                    {
                                        strupdateData = strupdateData + ";update gd_fdi_trans set trans_id='" + dr[17].ToString() + "' , basic_price=" + dr[41].ToString() + " ,taxable_value=" + dr[32].ToString() + ", service_amount=" + dr[7].ToString() + ",AutoVYN_Flag='1' ,ge15=" + (dr[44].ToString().Length > 0 ? dr[44].ToString() : "0") + " where utd=" + p.UTD + "";
                                    }
                                    else
                                    {
                                        strupdateData = "update gd_fdi_trans set trans_id='" + dr[17].ToString() + "' ,basic_price=" + dr[41].ToString() + " ,taxable_value=" + dr[32].ToString() + ", service_amount=" + dr[7].ToString() + ",AutoVYN_Flag='1' ,ge15=" + Common.ConvertDecimal(dr[44]) + " where utd=" + p.UTD + "";
                                    }
                                    strupdateData = strupdateData + ";update gd_fdi_trans_charges set  Charge_AMT=" + Common.ConvertDecimal(dr[35]) + " ,Charge_Rate=28 where utd='" + p.UTD + "' and Charge_type='IGVA'";
                                    strupdateData = strupdateData + ";update gd_fdi_trans_charges set  Charge_AMT=" + Common.ConvertDecimal(dr[36]) + ",Charge_Rate=" + Common.ConvertDecimal(dr[39]) + "  where utd='" + p.UTD + "' and Charge_type='GCVA'";
                                    strupdateData = strupdateData + ";update gd_fdi_trans_charges set  Charge_AMT=" + Common.ConvertDecimal(dr[47]) + " ,Charge_Rate=28 where utd='" + p.UTD + "' and Charge_type='IGSA'";
                                    strupdateData = strupdateData + ";update gd_fdi_trans_charges set  Charge_AMT=" + Common.ConvertDecimal(dr[48]) + ",Charge_Rate=" + Common.ConvertDecimal(dr[39]) + "  where utd='" + p.UTD + "' and Charge_type='GCSA'";
                                    strupdateData = strupdateData + ";update gd_fdi_trans_charges set  Charge_AMT=" + Common.ConvertDecimal(dr[49]) + " ,Charge_Rate=0 where utd='" + p.UTD + "' and Charge_type='TCSA'";
                                    strupdateData = strupdateData + ";update gd_fdi_trans_charges set  Charge_AMT=" + Common.ConvertDecimal(dr[33]) + ",Charge_Rate=14 where utd='" + p.UTD + "' and Charge_type='CGVA'";
                                    strupdateData = strupdateData + ";update gd_fdi_trans_charges set  Charge_AMT=" + Common.ConvertDecimal(dr[34]) + ",Charge_Rate=14  where utd='" + p.UTD + "' and Charge_type='SGVA'";

                                    strupdateData = strupdateData + ";update gd_fdi_trans_charges set  Charge_AMT=" + Common.ConvertDecimal(dr[45]) + ",Charge_Rate=14 where utd='" + p.UTD + "' and Charge_type='CGSA'";
                                    strupdateData = strupdateData + ";update gd_fdi_trans_charges set  Charge_AMT=" + Common.ConvertDecimal(dr[46]) + ",Charge_Rate=14  where utd='" + p.UTD + "' and Charge_type='SGSA'";
                                    

                                    strupdateData = strupdateData + ";update gd_fdi_trans set taxable_value=" + (Common.ConvertDecimal(dr[32]) + Common.ConvertDecimal(dr[44])) + " where Trans_type in ('STO','STI') and Chassis_Num='" + dr[2].ToString() + "' and Engine_Num='" + dr[3].ToString() + "'";
                                }
                            });

                            if (strupdateData.Length > 0)
                            {


                                BulkEntryUpdate(strupdateData);



                            
                        }
                    }
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

        private void BulkEntryUpdate(string dtDetails)
{



    string constr = "Data Source=" + SiteSession.DatabaseIp + ";Initial Catalog=" + SiteSession.DatabaseName + ";persist security info=True;user id=" + SiteSession.DatabseUserName + ";password=" + SiteSession.DatabasePassword + ";multipleactiveresultsets=True;Timeout=30";



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

private void getdata(DataTable dtDetails, string Tran_type)
{

    string constr = "Data Source=" + SiteSession.DatabaseIp + ";Initial Catalog=" + SiteSession.DatabaseName + ";persist security info=True;user id=" + SiteSession.DatabseUserName + ";password=" + SiteSession.DatabasePassword + ";multipleactiveresultsets=True;Timeout=30"; ;

    using (SqlConnection con = new SqlConnection(constr))
    {
        con.Open();
        using (SqlCommand cmd = new SqlCommand(Tran_type))
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Details", dtDetails);
            cmd.Parameters.AddWithValue("@CompCode", SiteSession.Comp_MstSession.Comp_Code);
            cmd.ExecuteNonQuery();
        }
    }

}


private void getdataSameBD(DataTable dtDetails, string Tran_type)
{

    string constr = "Data Source=.;Initial Catalog=autovyneinvoice;persist security info=True;user id=sa;password=India@#5010;multipleactiveresultsets=True;Timeout=30000"; ;

    using (SqlConnection con = new SqlConnection(constr))
    {
        con.Open();
        using (SqlCommand cmd = new SqlCommand(Tran_type))
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Details", dtDetails);
            cmd.Parameters.AddWithValue("@CompCode", SiteSession.Comp_MstSession.Comp_Code);
            cmd.ExecuteNonQuery();
        }
    }

}

private void getdataTransctions(DataTable dtDetails, string Tran_type)
{

    string constr = "Data Source=" + SiteSession.DatabaseIp + ";Initial Catalog=" + SiteSession.DatabaseName + ";persist security info=True;user id=" + SiteSession.DatabseUserName + ";password=" + SiteSession.DatabasePassword + ";multipleactiveresultsets=True;Timeout=30"; ;

    using (SqlConnection con = new SqlConnection(constr))
    {
        con.Open();
        using (SqlCommand cmd = new SqlCommand(Tran_type))
        {
            cmd.CommandTimeout = int.MaxValue;
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Details", dtDetails);

            cmd.ExecuteNonQuery();
        }
    }

}






        private string ValuesStringsDPS(ICell cell, string str,string cellname="")
        {

            try
            {

                string[] Con = "CREATED_DATETIME,CALL_RESULT_DATE_TIME,CALL_RESULT_CALLBACK_DATE_TIME,LAST_CALL_DATETIME".Split(',');
                if (str.ToUpper() == "DATE")
                {
                    string DateTimes = "";
                    try
                    {

                        if (Con.Contains(cellname))
                        {
                            if (!string.IsNullOrWhiteSpace(cell.ToString()))
                            {
                                var Date = Common.DataForSQLwITHtIME(cell.ToString());
                                if (Date.Length > 0)
                                {
                                    DateTimes = Date;
                                }
                                else if (cell.DateCellValue.ToString("dd-MMM-yyyy") != "31-Dec-9999")
                                {

                                    DateTimes = cell.DateCellValue.ToString("dd-MMM-yyyy HH:mm");
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

                                    DateTimes = cell.DateCellValue.ToString("dd-MMM-yyyy HH:mm");
                                }
                                else
                                {
                                    DateTimes = "NULL";
                                }
                            }

                        }
                        else
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
                    }
                    catch
                    {
                        DateTimes = "NULL";
                    }
                    return DateTimes;

                }

                if (str.ToUpper() == "DATETIME")
                {
                    string DateTimes = "";
                    try
                    {
                        if (!string.IsNullOrWhiteSpace(cell.ToString()))
                        {
                            var Date = Common.DataForSQLwITHtIMEDPS(cell.ToString());
                            if (Date.Length > 0)
                            {
                                DateTimes = Date;
                            }
                            else if (cell.DateCellValue.ToString("dd-MMM-yyyy") != "31-Dec-9999")
                            {

                                DateTimes = cell.DateCellValue.ToString("dd-MMM-yyyy HH:mm");
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

                                DateTimes = cell.DateCellValue.ToString("dd-MMM-yyyy HH:mm");
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






        private string ValuesStrings(ICell cell, string str)
{

    try
    {

        if (str.ToUpper() == "DATE")
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


private string ValuesStringsTrans(ICell cell, string str)
{

    try
    {

        if (str.ToUpper() == "DATE")
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

                        DateTimes = cell.DateCellValue.ToString("yyyy-MM-dd");
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

                        DateTimes = cell.DateCellValue.ToString("yyyy-MM-dd"); ;
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
