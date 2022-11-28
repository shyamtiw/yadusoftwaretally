using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.LIBS;
using Business;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace WebApp.LIBS
{
    public class JsonToExportDataExcel
    {

        public static DataTable CreateDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("SupplyTypeCode");
            dataTable.Columns.Add("ReverseCharge");
            dataTable.Columns.Add("EComGSTN");
            dataTable.Columns.Add("IGSTIntra");
            dataTable.Columns.Add("DocumentType");
            dataTable.Columns.Add("DocumentNo");
            dataTable.Columns.Add("DocumentDate");




            dataTable.Columns.Add("SellerGSTN");
            dataTable.Columns.Add("SellerLegalName");
            dataTable.Columns.Add("SellerTradeName");
            dataTable.Columns.Add("SellerPOS");
            dataTable.Columns.Add("SellerAddr1");
            dataTable.Columns.Add("SellerAddr2");
            dataTable.Columns.Add("SellerLocation");
            dataTable.Columns.Add("SellerPINCode");
            dataTable.Columns.Add("SellerState");
            dataTable.Columns.Add("SellerPhoneNumber");
            dataTable.Columns.Add("SellerEmailID");




            dataTable.Columns.Add("BuyerGSTN");
            dataTable.Columns.Add("BuyerLegalName");
            dataTable.Columns.Add("BuyerTradeName");
            dataTable.Columns.Add("BuyerPOS");
            dataTable.Columns.Add("BuyerAddr1");
            dataTable.Columns.Add("BuyerAddr2");
            dataTable.Columns.Add("BuyerLocation");
            dataTable.Columns.Add("BuyerPINCode");
            dataTable.Columns.Add("BuyerState");
            dataTable.Columns.Add("BuyerPhoneNumber");
            dataTable.Columns.Add("BuyerEmailID");
            dataTable.Columns.Add("DispatchName");
            dataTable.Columns.Add("DispatchAddr1");
            dataTable.Columns.Add("DispatchAddr2");
            dataTable.Columns.Add("DispatchLocation");
            dataTable.Columns.Add("DispatchPINCode");
            dataTable.Columns.Add("DispatchState");
            dataTable.Columns.Add("ShippingGSTN");
            dataTable.Columns.Add("ShippingLegalName");
            dataTable.Columns.Add("ShippingTradeName");
            dataTable.Columns.Add("ShippingAddr1");
            dataTable.Columns.Add("ShippingAddr2");
            dataTable.Columns.Add("ShippingLocation");
            dataTable.Columns.Add("ShippingPINCode");
            dataTable.Columns.Add("ShippingState");
            dataTable.Columns.Add("SlNo");
            dataTable.Columns.Add("ProductDescription");
            dataTable.Columns.Add("Is_Service");
            dataTable.Columns.Add("HSNCode");
            dataTable.Columns.Add("BarCode");
            dataTable.Columns.Add("Quantity");
            dataTable.Columns.Add("FreeQuantity");
            dataTable.Columns.Add("Unit");
            dataTable.Columns.Add("UnitPrice");
            dataTable.Columns.Add("GrossAmount");
            dataTable.Columns.Add("Discount");
            dataTable.Columns.Add("PreTaxValue");
            dataTable.Columns.Add("TaxableValue");
            dataTable.Columns.Add("GSTRate");
            dataTable.Columns.Add("SGSTAmt");
            dataTable.Columns.Add("CGSTAmt");
            dataTable.Columns.Add("IGSTAmt");
            dataTable.Columns.Add("CessRate");
            dataTable.Columns.Add("CessAmtAdval");
            dataTable.Columns.Add("CessNonAdvalAmt");
            dataTable.Columns.Add("StateCessRate");
            dataTable.Columns.Add("StateCessAdvalAmt");
            dataTable.Columns.Add("StateCessNonAdvalAmt");
            dataTable.Columns.Add("OtherCharges");
            dataTable.Columns.Add("ItemTotal");
            dataTable.Columns.Add("OrderLineReference");
            dataTable.Columns.Add("OriginCountry");
            dataTable.Columns.Add("UniqueItemSlNo");
            dataTable.Columns.Add("BatchName");
            dataTable.Columns.Add("BatchExpiryDate");
            dataTable.Columns.Add("WarrantyDate");
            dataTable.Columns.Add("AttributeDetailsoftheItems");
            dataTable.Columns.Add("AttributeValuesoftheItems");
            dataTable.Columns.Add("TotalTaxableValue");
            dataTable.Columns.Add("SGSTAmt1");
            dataTable.Columns.Add("CGSTAmt1");
            dataTable.Columns.Add("IGSTAmt1");
            dataTable.Columns.Add("CessAmount");
            dataTable.Columns.Add("StateCessAmount");
            dataTable.Columns.Add("Discount1");
            dataTable.Columns.Add("OtherCharges1");
            dataTable.Columns.Add("RoundOff");
            dataTable.Columns.Add("TotalInvoiceValue");
            dataTable.Columns.Add("TotalInvoiceValueinAdditionalCurrency");
            dataTable.Columns.Add("ShippingBillNo");
            dataTable.Columns.Add("ShippingBillDate");
            dataTable.Columns.Add("Port");
            dataTable.Columns.Add("SupplierRefund");
            dataTable.Columns.Add("ForeignCurrency");
            dataTable.Columns.Add("CountryCode");
            dataTable.Columns.Add("ExportDutyAmount");
            dataTable.Columns.Add("TransID");
            dataTable.Columns.Add("TransName");
            dataTable.Columns.Add("TransMode");
            dataTable.Columns.Add("Distance");
            dataTable.Columns.Add("TransDocNo");
            dataTable.Columns.Add("TransDocDate");
            dataTable.Columns.Add("VehicleNo");
            dataTable.Columns.Add("VehicleType");
            dataTable.Columns.Add("PayeeName");
            dataTable.Columns.Add("AccountNumber");
            dataTable.Columns.Add("Mode");
            dataTable.Columns.Add("BranchIFSCCode");
            dataTable.Columns.Add("TermofPayment");
            dataTable.Columns.Add("PaymentInstuction");
            dataTable.Columns.Add("CreditTransfer");
            dataTable.Columns.Add("DirectDebit");
            dataTable.Columns.Add("CreditDays");
            dataTable.Columns.Add("PaidedAmount");
            dataTable.Columns.Add("DueAmount");
            dataTable.Columns.Add("Remarks");
            dataTable.Columns.Add("InvoicePeriodStartDate");
            dataTable.Columns.Add("InvoicePeriodEndDate");
            dataTable.Columns.Add("OriginalInvoice");
            dataTable.Columns.Add("PreceedingInvoiceDate");
            dataTable.Columns.Add("OtherReference");
            dataTable.Columns.Add("ReceiptAdviceNumber");
            dataTable.Columns.Add("DateofReceiptAdvice");
            dataTable.Columns.Add("LotBatchReferenceNumber");
            dataTable.Columns.Add("ContractReferenceNumber");
            dataTable.Columns.Add("AnyOtherReference");
            dataTable.Columns.Add("ProjectReferenceNumber");
            dataTable.Columns.Add("VendorPOReferenceNumber");
            dataTable.Columns.Add("VendorPOReferenceDate");
            dataTable.Columns.Add("SupportingDocURL");
            dataTable.Columns.Add("SupportingDocinBase64Format");
            dataTable.Columns.Add("AnyAdditionalInformation");
            return dataTable;

        }


        public static DataTable DataCreate(string  GodwnId,string FromDate, string ToDate)
        {
            DataTable dataTable = new DataTable();
            dataTable = CreateDataTable();
            var TableData= getdata(SiteSession.Comp_MstSession.Comp_Code.Value, GodwnId, FromDate, ToDate);

            foreach (DataRow dr in TableData.Rows)
            {
                
                
                var Items = JsonConvert.DeserializeObject<List<Item>>(dr["Itemjson"].ToString());
                Items.ForEach(p => {

                    DataRow NewRow = dataTable.NewRow();



                    NewRow["SupplyTypeCode"] = dr["SupplyTypeCode"];
                    NewRow["ReverseCharge"] = dr["ReverseCharge"];
                    NewRow["EComGSTN"] = dr["EComGSTN"];
                    NewRow["IGSTIntra"] = dr["IGSTIntra"];
                    NewRow["DocumentType"] = dr["DocumentType"];
                    NewRow["DocumentNo"] = dr["DocumentNo"];
                    NewRow["DocumentDate"] = Convert.ToDateTime(dr["DocumentDate"]).ToString("dd/MM/yyyy");
                    NewRow["SellerGSTN"] = dr["SellerGSTN"];
                    NewRow["SellerLegalName"] = dr["SellerLegalName"];
                    NewRow["BuyerTradeName"] = dr["BuyerTradeName"];
                    NewRow["SellerTradeName"] = dr["SellerTradeName"];
                    NewRow["SellerPOS"] = dr["SellerPOS"];
                    NewRow["SellerAddr1"] = dr["SellerAddr1"];
                    NewRow["SellerAddr2"] = dr["SellerAddr2"];
                    NewRow["SellerLocation"] = dr["SellerLocation"];
                    NewRow["SellerPINCode"] = dr["SellerPINCode"];
                    NewRow["BuyerPhoneNumber"] = dr["BuyerPhoneNumber"];
                    NewRow["SellerState"] = dr["SellerState"];
                    NewRow["SellerPhoneNumber"] = dr["SellerPhoneNumber"];
                    NewRow["SellerEmailID"] = dr["SellerEmailID"];
                    NewRow["BuyerGSTN"] = dr["BuyerGSTN"];
                    NewRow["BuyerLegalName"] = dr["BuyerLegalName"];
                    NewRow["BuyerTradeName"] = dr["BuyerTradeName"];
                    NewRow["BuyerPOS"] = dr["BuyerPOS"];
                    NewRow["BuyerAddr1"] = dr["BuyerAddr1"];
                    NewRow["BuyerAddr2"] = dr["BuyerAddr2"];
                    NewRow["BuyerLocation"] = dr["BuyerLocation"];
                    NewRow["BuyerPINCode"] = dr["BuyerPINCode"];
                    NewRow["BuyerState"] = dr["BuyerState"];
                    NewRow["BuyerPhoneNumber"] = dr["BuyerPhoneNumber"];
                    NewRow["BuyerEmailID"] = dr["BuyerEmailID"];
                    NewRow["DispatchName"] = dr["DispatchName"];
                    NewRow["DispatchAddr1"] = dr["DispatchAddr1"];
                    NewRow["DispatchAddr2"] = dr["DispatchAddr2"];
                    NewRow["DispatchLocation"] = dr["DispatchLocation"];
                    NewRow["DispatchPINCode"] = dr["DispatchPINCode"];
                    NewRow["DispatchState"] = dr["DispatchState"];
                    NewRow["ShippingGSTN"] = dr["ShippingGSTN"];
                    NewRow["ShippingLegalName"] = dr["ShippingLegalName"];
                    NewRow["ShippingTradeName"] = dr["ShippingTradeName"];
                    NewRow["ShippingAddr1"] = dr["ShippingAddr1"];
                    NewRow["ShippingAddr2"] = dr["ShippingAddr2"];
                    NewRow["ShippingLocation"] = dr["ShippingLocation"];
                    NewRow["ShippingPINCode"] = dr["ShippingPINCode"];
                    NewRow["ShippingState"] = dr["ShippingState"];
                    NewRow["TotalTaxableValue"] = dr["TotalTaxableValue"];
                    NewRow["SGSTAmt1"] = dr["SGSTAmt1"];
                    NewRow["CGSTAmt1"] = dr["CGSTAmt1"];
                    NewRow["IGSTAmt1"] = dr["IGSTAmt1"];
                    NewRow["CessAmount"] = dr["CessAmount"];
                    NewRow["StateCessAmount"] = dr["StateCessAmount"];
                    NewRow["Discount1"] = dr["Discount1"];
                    NewRow["OtherCharges1"] = dr["OtherCharges1"];
                    NewRow["RoundOff"] = dr["RoundOff"];
                    NewRow["TotalInvoiceValue"] = dr["TotalInvoiceValue"];
                    NewRow["TotalInvoiceValueinAdditionalCurrency"] = dr["TotalInvoiceValueinAdditionalCurrency"];
                    NewRow["ShippingBillNo"] = dr["ShippingBillNo"];
                    NewRow["ShippingBillDate"] = dr["ShippingBillDate"];
                    NewRow["Port"] = dr["Port"];
                    NewRow["SupplierRefund"] = dr["SupplierRefund"];
                    NewRow["ForeignCurrency"] = dr["ForeignCurrency"];
                    NewRow["CountryCode"] = dr["CountryCode"];
                    NewRow["ExportDutyAmount"] = dr["ExportDutyAmount"];
                    NewRow["TransID"] = dr["TransID"];
                    NewRow["TransName"] = dr["TransName"];
                    NewRow["TransMode"] = dr["TransMode"];
                    NewRow["Distance"] = dr["Distance"];
                    NewRow["TransDocNo"] = dr["TransDocNo"];
                    NewRow["TransDocDate"] = dr["TransDocDate"];
                    NewRow["VehicleNo"] = dr["VehicleNo"];
                    NewRow["VehicleType"] = dr["VehicleType"];
                    NewRow["PayeeName"] = dr["PayeeName"];
                    NewRow["AccountNumber"] = dr["AccountNumber"];
                    NewRow["Mode"] = dr["Mode"];
                    NewRow["BranchIFSCCode"] = dr["BranchIFSCCode"];
                    NewRow["TermofPayment"] = dr["TermofPayment"];
                    NewRow["PaymentInstuction"] = dr["PaymentInstuction"];
                    NewRow["CreditTransfer"] = dr["CreditTransfer"];
                    NewRow["DirectDebit"] = dr["DirectDebit"];
                    NewRow["CreditDays"] = dr["CreditDays"];
                    NewRow["PaidedAmount"] = dr["PaidedAmount"];
                    NewRow["DueAmount"] = dr["DueAmount"];
                    NewRow["Remarks"] = dr["Remarks"];
                    NewRow["InvoicePeriodStartDate"] = dr["InvoicePeriodStartDate"];
                    NewRow["InvoicePeriodEndDate"] = dr["InvoicePeriodEndDate"];
                    NewRow["OriginalInvoice"] = dr["OriginalInvoice"];
                    NewRow["PreceedingInvoiceDate"] = dr["PreceedingInvoiceDate"];
                    NewRow["OtherReference"] = dr["OtherReference"];
                    NewRow["ReceiptAdviceNumber"] = dr["ReceiptAdviceNumber"];
                    NewRow["DateofReceiptAdvice"] = dr["DateofReceiptAdvice"];
                    NewRow["LotBatchReferenceNumber"] = dr["LotBatchReferenceNumber"];
                    NewRow["ContractReferenceNumber"] = dr["ContractReferenceNumber"];
                    NewRow["AnyOtherReference"] = dr["AnyOtherReference"];
                    NewRow["ProjectReferenceNumber"] = dr["ProjectReferenceNumber"];
                    NewRow["VendorPOReferenceNumber"] = dr["VendorPOReferenceNumber"];
                    NewRow["VendorPOReferenceDate"] = dr["VendorPOReferenceDate"];
                    NewRow["SupportingDocURL"] = dr["SupportingDocURL"];
                    NewRow["SupportingDocinBase64Format"] = dr["SupportingDocinBase64Format"];
                    NewRow["AnyAdditionalInformation"] = dr["AnyAdditionalInformation"];

                  

                    NewRow["SlNo"] = p.SlNo.ToString();
                    NewRow["ProductDescription"] = p.PrdDesc.ToString();
                    NewRow["Is_Service"] = p.IsServc.ToString();
                    NewRow["HSNCode"] = p.HsnCd.ToString();
                    NewRow["BarCode"] = p.Barcde.ToString();
                    NewRow["Quantity"] = p.Qty.ToString();
                    NewRow["FreeQuantity"] = p.FreeQty.ToString();
                    NewRow["Unit"] = p.Unit.ToString();
                    NewRow["UnitPrice"] = p.UnitPrice.ToString();
                    NewRow["GrossAmount"] = p.TotAmt.ToString();
                    NewRow["Discount"] = p.Discount.ToString();
                    NewRow["PreTaxValue"] = p.PreTaxVal.ToString();
                    NewRow["TaxableValue"] = p.AssAmt.ToString();
                    NewRow["GSTRate"] = p.GstRt.ToString();
                    NewRow["IGSTAmt"] = p.IgstAmt.ToString();
                    NewRow["CGSTAmt"] = p.CgstAmt.ToString();
                    NewRow["SGSTAmt"] = p.SgstAmt.ToString();
                    NewRow["CessRate"] = p.CesRt.ToString();
                    NewRow["CessAmtAdval"] = p.CesAmt.ToString();
                    NewRow["CessNonAdvalAmt"] = p.CesNonAdvlAmt.ToString();
                    NewRow["StateCessRate"] = p.StateCesRt.ToString();
                    NewRow["StateCessAdvalAmt"] = p.StateCesAmt.ToString();
                    NewRow["StateCessNonAdvalAmt"] = p.StateCesNonAdvlAmt.ToString();
                    NewRow["OtherCharges"] = p.OthChrg.ToString();
                    NewRow["ItemTotal"] = p.TotItemVal.ToString();
                    NewRow["OrderLineReference"] = p.OrdLineRef.ToString();
                    NewRow["OriginCountry"] = p.OrgCntry.ToString();
                    NewRow["UniqueItemSlNo"] = p.PrdSlNo.ToString();

                    dataTable.Rows.Add(NewRow);

                });

            }

            return dataTable;

        }


        private static DataTable getdata(int CompCode,string Godwn,  string FromDate, string ToDate)
        {

            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SpExportExcel"))
                {
                    cmd.Connection = con;
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.Parameters.AddWithValue("@Comp_code", CompCode);
                        cmd.Parameters.AddWithValue("@Godwn_code", Godwn);
                        cmd.Parameters.AddWithValue("@FromDate", FromDate);
                        cmd.Parameters.AddWithValue("@Toate", ToDate);
                        cmd.CommandType = CommandType.StoredProcedure;
                        da.Fill(dt);
                    }

                }
            }

            return dt;
        }


    }
}