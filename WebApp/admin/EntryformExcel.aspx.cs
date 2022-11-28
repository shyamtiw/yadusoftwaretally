using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using WebApp.LIBS;
using Newtonsoft.Json;
namespace WebApp.admin
{
    public partial class EntryformExcel : BasePageClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                SiteSession.ItemArray = new List<Item>();
                if (Request.QueryString["EInvoiceDataExcelId"].ConvertInt() > 0)
                {
                    int Id = Request.QueryString["EInvoiceDataExcelId"].ConvertInt();
                    BindData(Id);

                }
                else
                {
                    DefaultEntry(SiteSession.GodownId);
                }



            }
        }

        private void DefaultEntry(int GodownId)
        {



            SellerLegalName.Text = SiteSession.Comp_MstSession.Comp_Name;
            SellerTradeName.Text = SiteSession.Comp_MstSession.Comp_Name;
            var obj = Business.UserLogin.GodwwnListGetUserWise(SiteSession.Comp_MstSession.Comp_Code.Value, GodownId).FirstOrDefault();
            SellerGSTN.Text = obj.GST_No;
            SellerPOS.Text = obj.City;
            SellerAddr1.Text = obj.Godw_Add1;
            SellerAddr2.Text = obj.Godw_Add2;
            SellerLocation.Text = obj.State;
            SellerPINCode.Text = obj.Pin_Code;
            SellerState.Text = obj.State_Code.ToString();
            SellerPhoneNumber.Text = obj.Mob_No;
            SellerEmailID.Text = obj.Com_Add3;

        }




        private void AddNewRowToGrid()

        {
            var dtCurrentTable = SiteSession.ItemArray;

            if (dtCurrentTable.Count > 0)

            {

                for (int i = 0; i < gvlocation.Rows.Count; i++)

                {
                    SiteSession.ItemArray[i].SlNo = ((TextBox)gvlocation.Rows[i].FindControl("SlNo")).Text;
                    SiteSession.ItemArray[i].PrdDesc = ((TextBox)gvlocation.Rows[i].FindControl("PrdDesc")).Text;
                    SiteSession.ItemArray[i].IsServc = ((TextBox)gvlocation.Rows[i].FindControl("IsServc")).Text;
                    SiteSession.ItemArray[i].HsnCd = ((TextBox)gvlocation.Rows[i].FindControl("HsnCd")).Text;
                    SiteSession.ItemArray[i].Barcde = ((TextBox)gvlocation.Rows[i].FindControl("Barcde")).Text;
                    SiteSession.ItemArray[i].Qty = ((TextBox)gvlocation.Rows[i].FindControl("Qty")).Text.ConvertDecimal();
                    SiteSession.ItemArray[i].FreeQty = ((TextBox)gvlocation.Rows[i].FindControl("FreeQty")).Text.ConvertDecimal();
                    SiteSession.ItemArray[i].Unit = ((TextBox)gvlocation.Rows[i].FindControl("Unit")).Text;
                    SiteSession.ItemArray[i].UnitPrice = ((TextBox)gvlocation.Rows[i].FindControl("UnitPrice")).Text.Convertdouble();
                    SiteSession.ItemArray[i].TotAmt = ((TextBox)gvlocation.Rows[i].FindControl("TotAmt")).Text.Convertdouble(); ;
                    SiteSession.ItemArray[i].Discount = ((TextBox)gvlocation.Rows[i].FindControl("Discount")).Text.Convertdouble(); ;
                    SiteSession.ItemArray[i].PreTaxVal = ((TextBox)gvlocation.Rows[i].FindControl("PreTaxVal")).Text.Convertdouble(); ;
                    SiteSession.ItemArray[i].AssAmt = ((TextBox)gvlocation.Rows[i].FindControl("AssAmt")).Text.Convertdouble();
                    SiteSession.ItemArray[i].GstRt = ((TextBox)gvlocation.Rows[i].FindControl("GstRt")).Text.Convertdouble();
                    SiteSession.ItemArray[i].IgstAmt = ((TextBox)gvlocation.Rows[i].FindControl("IgstAmt")).Text.Convertdouble();
                    SiteSession.ItemArray[i].CgstAmt = ((TextBox)gvlocation.Rows[i].FindControl("CgstAmt")).Text.Convertdouble();
                    SiteSession.ItemArray[i].SgstAmt = ((TextBox)gvlocation.Rows[i].FindControl("SgstAmt")).Text.Convertdouble();
                    SiteSession.ItemArray[i].CesRt = ((TextBox)gvlocation.Rows[i].FindControl("CesRt")).Text.Convertdouble();
                    SiteSession.ItemArray[i].CesAmt = ((TextBox)gvlocation.Rows[i].FindControl("CesAmt")).Text.Convertdouble();
                    SiteSession.ItemArray[i].CesNonAdvlAmt = ((TextBox)gvlocation.Rows[i].FindControl("CesNonAdvlAmt")).Text.Convertdouble();
                    SiteSession.ItemArray[i].StateCesRt = ((TextBox)gvlocation.Rows[i].FindControl("StateCesRt")).Text.Convertdouble();
                    SiteSession.ItemArray[i].StateCesAmt = ((TextBox)gvlocation.Rows[i].FindControl("StateCesAmt")).Text.Convertdouble();
                    SiteSession.ItemArray[i].StateCesNonAdvlAmt = ((TextBox)gvlocation.Rows[i].FindControl("StateCesNonAdvlAmt")).Text.Convertdouble();
                    SiteSession.ItemArray[i].OthChrg = ((TextBox)gvlocation.Rows[i].FindControl("OthChrg")).Text.Convertdouble();
                    SiteSession.ItemArray[i].TotItemVal = ((TextBox)gvlocation.Rows[i].FindControl("TotItemVal")).Text.Convertdouble();
                    SiteSession.ItemArray[i].OrdLineRef = ((TextBox)gvlocation.Rows[i].FindControl("OrdLineRef")).Text;
                    SiteSession.ItemArray[i].OrdLineRef = ((TextBox)gvlocation.Rows[i].FindControl("OrdLineRef")).Text;
                    SiteSession.ItemArray[i].OrgCntry = ((TextBox)gvlocation.Rows[i].FindControl("OrgCntry")).Text;
                    SiteSession.ItemArray[i].PrdSlNo = ((TextBox)gvlocation.Rows[i].FindControl("PrdSlNo")).Text;
                }

                SiteSession.ItemArray.Add(new Item() { SlNo = (SiteSession.ItemArray.Count() + 1).ToString(),
                  
                    PrdDesc = "",
                    IsServc = "",
                    HsnCd = "",
                    Barcde = "",
                    Qty = 0,
                    FreeQty = 0,
                    Unit = "",
                    UnitPrice = 0,
                    TotAmt = 0,
                    Discount = 0,
                    PreTaxVal = 0,
                    AssAmt = 0,
                    GstRt = 0,
                    IgstAmt = 0,
                    CgstAmt = 0,
                    SgstAmt =0,
                    CesRt = 0,
                    CesAmt = 0,
                    CesNonAdvlAmt = 0,
                    StateCesRt = 0,
                    StateCesAmt = 0,
                    StateCesNonAdvlAmt = 0,
                    OthChrg = 0,
                    TotItemVal = 0,
                    OrdLineRef = "",
                    
                    OrgCntry = "IN",
                    PrdSlNo = ""

                   



                });
                gvlocation.DataSource = dtCurrentTable;
                gvlocation.DataBind();

            }
            else
            {
                SiteSession.ItemArray.Add(new Item() { SlNo = (SiteSession.ItemArray.Count() + 1).ToString() });

                gvlocation.DataSource = dtCurrentTable;

                gvlocation.DataBind();
            }

        }





        private void BindData(int Id)
        {
            var obj = Global.Context.EInvoiceDataExcels.SingleOrDefault(p => p.EInvoiceDataExcelId == Id);

            DefaultEntry(obj.GodownCode.Value);

            var JsonStr = "[" + obj.Itemjson + "]";

            var Items = JsonConvert.DeserializeObject<List<Item>>(JsonStr);
            SiteSession.ItemArray = Items;
            Common.BindControl(gvlocation, SiteSession.ItemArray.ToList());

            SupplyTypeCode.Text = obj.SupplyTypeCode;
            ReverseCharge.Text = obj.ReverseCharge;

            DocumentType.Text = obj.DocumentType;
            DocumentNo.Text = obj.DocumentNo;
            DocumentDate.Text = obj.DocumentDate.Value.ToString("dd/MM/yyyy");
            BuyerGSTN.Text = obj.BuyerGSTN;
            BuyerLegalName.Text = obj.BuyerLegalName;
            BuyerTradeName.Text = obj.BuyerTradeName;
            BuyerPOS.Text = obj.BuyerPOS;
            BuyerAddr1.Text = obj.BuyerAddr1;
            BuyerAddr2.Text = obj.BuyerAddr2;
            BuyerLocation.Text = obj.BuyerLocation;
            BuyerPINCode.Text = obj.BuyerPINCode;
            BuyerState.Text = obj.BuyerState;
            BuyerPhoneNumber.Text = obj.BuyerPhoneNumber;
            BuyerEmailID.Text = obj.BuyerEmailID;
            DispatchName.Text = obj.DispatchName;
            DispatchAddr1.Text = obj.DispatchAddr1;
            DispatchAddr2.Text = obj.DispatchAddr2;
            DispatchLocation.Text = obj.DispatchLocation;
            DispatchPINCode.Text = obj.DispatchPINCode;
            DispatchState.Text = obj.DispatchState;
            ShippingGSTN.Text = obj.ShippingGSTN;
            ShippingLegalName.Text = obj.ShippingLegalName;
            ShippingTradeName.Text = obj.ShippingTradeName;
            ShippingAddr1.Text = obj.ShippingAddr1;
            ShippingAddr2.Text = obj.ShippingAddr2;
            ShippingLocation.Text = obj.ShippingLocation;
            ShippingPINCode.Text = obj.ShippingPINCode;
            ShippingState.Text = obj.ShippingState;

            TotalTaxableValue.Text = obj.TotalTaxableValue;
            SGSTAmt1.Text = obj.SGSTAmt1;
            CGSTAmt1.Text = obj.CGSTAmt1;
            IGSTAmt1.Text = obj.IGSTAmt1;
            CessAmount.Text = obj.CessAmount;
            StateCessAmount.Text = obj.StateCessAmount;
            Discount1.Text = obj.Discount1;
            OtherCharges1.Text = obj.OtherCharges1;
            RoundOff.Text = obj.RoundOff;
            TotalInvoiceValue.Text = obj.TotalInvoiceValue;
            TotalInvoiceValueinAdditionalCurrency.Text = obj.TotalInvoiceValueinAdditionalCurrency;


            PayeeName.Text = obj.PayeeName;
            AccountNumber.Text = obj.AccountNumber;
            Mode.Text = obj.Mode;
            BranchIFSCCode.Text = obj.BranchIFSCCode;
            TermofPayment.Text = obj.TermofPayment;
            PaymentInstuction.Text = obj.PaymentInstuction;
            CreditTransfer.Text = obj.CreditTransfer;
            DirectDebit.Text = obj.DirectDebit;
            CreditDays.Text = obj.CreditDays;
            PaidedAmount.Text = obj.PaidedAmount;
            DueAmount.Text = obj.DueAmount;
            Remarks.Text = obj.Remarks;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }

        protected void saveAccountHead_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["EInvoiceDataExcelId"].ConvertInt() > 0)
                {

                    int Id = Request.QueryString["EInvoiceDataExcelId"].ConvertInt();
                    UpdateItemForJson();
                    var obj = Global.Context.EInvoiceDataExcels.SingleOrDefault(p => p.EInvoiceDataExcelId == Id);

                    obj.SupplyTypeCode = SupplyTypeCode.Text;
                    obj.ReverseCharge = ReverseCharge.Text;
                    obj.DocumentType = DocumentType.Text;
                    obj.DocumentNo = DocumentNo.Text;
                    obj.DocumentDate = DocumentDate.Text.DateConvertTextMatchCase();
                    obj.BuyerGSTN = BuyerGSTN.Text;
                    obj.BuyerLegalName = BuyerLegalName.Text;
                    obj.BuyerTradeName = BuyerTradeName.Text;
                    obj.BuyerPOS = BuyerPOS.Text;
                    obj.BuyerAddr1 = BuyerAddr1.Text;
                    obj.BuyerAddr2 = BuyerAddr2.Text;
                    obj.BuyerLocation = BuyerLocation.Text;
                    obj.BuyerPINCode = BuyerPINCode.Text;
                    obj.BuyerState = BuyerState.Text;
                    obj.BuyerPhoneNumber = BuyerPhoneNumber.Text;
                    obj.BuyerEmailID = BuyerEmailID.Text;
                    obj.DispatchName = DispatchName.Text;
                    obj.DispatchAddr1 = DispatchAddr1.Text;
                    obj.DispatchAddr2 = DispatchAddr2.Text;
                    obj.DispatchLocation = DispatchLocation.Text;
                    obj.DispatchPINCode = DispatchPINCode.Text;
                    obj.DispatchState = DispatchState.Text;
                    obj.ShippingGSTN = ShippingGSTN.Text;
                    obj.ShippingLegalName = ShippingLegalName.Text;
                    obj.ShippingTradeName = ShippingTradeName.Text;
                    obj.ShippingAddr1 = ShippingAddr1.Text;
                    obj.ShippingAddr2 = ShippingAddr2.Text;
                    obj.ShippingLocation = ShippingLocation.Text;
                    obj.ShippingPINCode = ShippingPINCode.Text;
                    obj.ShippingState = ShippingState.Text;
                    obj.TotalTaxableValue = TotalTaxableValue.Text;
                    obj.SGSTAmt1 = SGSTAmt1.Text;
                    obj.CGSTAmt1 = CGSTAmt1.Text;
                    obj.IGSTAmt1 = IGSTAmt1.Text;
                    obj.CessAmount = CessAmount.Text;
                    obj.StateCessAmount = StateCessAmount.Text;
                    obj.Discount1 = Discount1.Text;
                    obj.OtherCharges1 = OtherCharges1.Text;
                    obj.RoundOff = RoundOff.Text;
                    obj.TotalInvoiceValue = TotalInvoiceValue.Text;
                    obj.TotalInvoiceValueinAdditionalCurrency = TotalInvoiceValueinAdditionalCurrency.Text;
                    obj.PayeeName = PayeeName.Text;
                    obj.AccountNumber = AccountNumber.Text;
                    obj.Mode = Mode.Text;
                    obj.BranchIFSCCode = BranchIFSCCode.Text;
                    obj.TermofPayment = TermofPayment.Text;
                    obj.PaymentInstuction = PaymentInstuction.Text;
                    obj.CreditTransfer = CreditTransfer.Text;
                    obj.DirectDebit = DirectDebit.Text;
                    obj.CreditDays = CreditDays.Text;
                    obj.PaidedAmount = PaidedAmount.Text;
                    obj.DueAmount = DueAmount.Text;
                    obj.Remarks = Remarks.Text;
                    obj.Itemjson = JsonConvert.SerializeObject(SiteSession.ItemArray.ToList()).Replace("[", "").Replace("]", "");
                    obj.Comp_Code = SiteSession.Comp_MstSession.Comp_Code.Value;
                    obj.Save();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Successfully", "alert('Entry Successfully Save');window.location='EntryformExcel.aspx'", true);
                }

                else

                {
                    UpdateItemForJson();
                    var obj = new Business.EInvoiceDataExcel();

                    obj.SupplyTypeCode = SupplyTypeCode.Text;
                    obj.ReverseCharge = ReverseCharge.Text;
                    obj.DocumentType = DocumentType.Text;
                    obj.DocumentNo = DocumentNo.Text;
                    obj.DocumentDate = DocumentDate.Text.DateConvertText();
                    obj.BuyerGSTN = BuyerGSTN.Text;
                    obj.BuyerLegalName = BuyerLegalName.Text;
                    obj.BuyerTradeName = BuyerTradeName.Text;
                    obj.BuyerPOS = BuyerPOS.Text;
                    obj.BuyerAddr1 = BuyerAddr1.Text;
                    obj.BuyerAddr2 = BuyerAddr2.Text;
                    obj.BuyerLocation = BuyerLocation.Text;
                    obj.BuyerPINCode = BuyerPINCode.Text;
                    obj.BuyerState = BuyerState.Text;
                    obj.BuyerPhoneNumber = BuyerPhoneNumber.Text;
                    obj.BuyerEmailID = BuyerEmailID.Text;
                    obj.DispatchName = DispatchName.Text;
                    obj.DispatchAddr1 = DispatchAddr1.Text;
                    obj.DispatchAddr2 = DispatchAddr2.Text;
                    obj.DispatchLocation = DispatchLocation.Text;
                    obj.DispatchPINCode = DispatchPINCode.Text;
                    obj.DispatchState = DispatchState.Text;
                    obj.ShippingGSTN = ShippingGSTN.Text;
                    obj.ShippingLegalName = ShippingLegalName.Text;
                    obj.ShippingTradeName = ShippingTradeName.Text;
                    obj.ShippingAddr1 = ShippingAddr1.Text;
                    obj.ShippingAddr2 = ShippingAddr2.Text;
                    obj.ShippingLocation = ShippingLocation.Text;
                    obj.ShippingPINCode = ShippingPINCode.Text;
                    obj.ShippingState = ShippingState.Text;
                    obj.TotalTaxableValue = TotalTaxableValue.Text;
                    obj.SGSTAmt1 = SGSTAmt1.Text;
                    obj.CGSTAmt1 = CGSTAmt1.Text;
                    obj.IGSTAmt1 = IGSTAmt1.Text;
                    obj.CessAmount = CessAmount.Text;
                    obj.StateCessAmount = StateCessAmount.Text;
                    obj.Discount1 = Discount1.Text;
                    obj.OtherCharges1 = OtherCharges1.Text;
                    obj.RoundOff = RoundOff.Text;
                    obj.TotalInvoiceValue = TotalInvoiceValue.Text;
                    obj.TotalInvoiceValueinAdditionalCurrency = TotalInvoiceValueinAdditionalCurrency.Text;
                    obj.PayeeName = PayeeName.Text;
                    obj.AccountNumber = AccountNumber.Text;
                    obj.Mode = Mode.Text;
                    obj.BranchIFSCCode = BranchIFSCCode.Text;
                    obj.TermofPayment = TermofPayment.Text;
                    obj.PaymentInstuction = PaymentInstuction.Text;
                    obj.CreditTransfer = CreditTransfer.Text;
                    obj.DirectDebit = DirectDebit.Text;
                    obj.CreditDays = CreditDays.Text;
                    obj.PaidedAmount = PaidedAmount.Text;
                    obj.DueAmount = DueAmount.Text;
                    obj.Remarks = Remarks.Text;
                    obj.Itemjson = JsonConvert.SerializeObject(SiteSession.ItemArray.ToList()).Replace("[", "").Replace("]", "");
                    obj.Comp_Code = SiteSession.Comp_MstSession.Comp_Code.Value;
                    obj.GodownCode = Convert.ToByte( SiteSession.GodownId);
                    obj.EComGSTN = "";
                    obj.IGSTIntra = "No";
                    obj.Save();

                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Successfully", "alert('Entry Successfully Save');window.location='EntryformExcel.aspx'", true);
                }
            }
            catch (Exception ex)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "alert('" + ex.Message + "');", true);
            }
        }





        private void UpdateItemForJson()

        {


            for (int i = 0; i < gvlocation.Rows.Count; i++)

            {
                SiteSession.ItemArray[i].SlNo = ((TextBox)gvlocation.Rows[i].FindControl("SlNo")).Text;
                SiteSession.ItemArray[i].PrdDesc = ((TextBox)gvlocation.Rows[i].FindControl("PrdDesc")).Text;
                SiteSession.ItemArray[i].IsServc = ((TextBox)gvlocation.Rows[i].FindControl("IsServc")).Text;
                SiteSession.ItemArray[i].HsnCd = ((TextBox)gvlocation.Rows[i].FindControl("HsnCd")).Text;
                SiteSession.ItemArray[i].Barcde = ((TextBox)gvlocation.Rows[i].FindControl("Barcde")).Text;
                SiteSession.ItemArray[i].Qty = ((TextBox)gvlocation.Rows[i].FindControl("Qty")).Text.ConvertDecimal();
                SiteSession.ItemArray[i].FreeQty = ((TextBox)gvlocation.Rows[i].FindControl("FreeQty")).Text.ConvertDecimal();
                SiteSession.ItemArray[i].Unit = ((TextBox)gvlocation.Rows[i].FindControl("Unit")).Text;
                SiteSession.ItemArray[i].UnitPrice = ((TextBox)gvlocation.Rows[i].FindControl("UnitPrice")).Text.Convertdouble();
                SiteSession.ItemArray[i].TotAmt = ((TextBox)gvlocation.Rows[i].FindControl("TotAmt")).Text.Convertdouble(); ;
                SiteSession.ItemArray[i].Discount = ((TextBox)gvlocation.Rows[i].FindControl("Discount")).Text.Convertdouble(); ;
                SiteSession.ItemArray[i].PreTaxVal = ((TextBox)gvlocation.Rows[i].FindControl("PreTaxVal")).Text.Convertdouble(); ;
                SiteSession.ItemArray[i].AssAmt = ((TextBox)gvlocation.Rows[i].FindControl("AssAmt")).Text.Convertdouble();
                SiteSession.ItemArray[i].GstRt = ((TextBox)gvlocation.Rows[i].FindControl("GstRt")).Text.Convertdouble();
                SiteSession.ItemArray[i].IgstAmt = ((TextBox)gvlocation.Rows[i].FindControl("IgstAmt")).Text.Convertdouble();
                SiteSession.ItemArray[i].CgstAmt = ((TextBox)gvlocation.Rows[i].FindControl("CgstAmt")).Text.Convertdouble();
                SiteSession.ItemArray[i].SgstAmt = ((TextBox)gvlocation.Rows[i].FindControl("SgstAmt")).Text.Convertdouble();
                SiteSession.ItemArray[i].CesRt = ((TextBox)gvlocation.Rows[i].FindControl("CesRt")).Text.Convertdouble();
                SiteSession.ItemArray[i].CesAmt = ((TextBox)gvlocation.Rows[i].FindControl("CesAmt")).Text.Convertdouble();
                SiteSession.ItemArray[i].CesNonAdvlAmt = ((TextBox)gvlocation.Rows[i].FindControl("CesNonAdvlAmt")).Text.Convertdouble();
                SiteSession.ItemArray[i].StateCesRt = ((TextBox)gvlocation.Rows[i].FindControl("StateCesRt")).Text.Convertdouble();
                SiteSession.ItemArray[i].StateCesAmt = ((TextBox)gvlocation.Rows[i].FindControl("StateCesAmt")).Text.Convertdouble();
                SiteSession.ItemArray[i].StateCesNonAdvlAmt = ((TextBox)gvlocation.Rows[i].FindControl("StateCesNonAdvlAmt")).Text.Convertdouble();
                SiteSession.ItemArray[i].OthChrg = ((TextBox)gvlocation.Rows[i].FindControl("OthChrg")).Text.Convertdouble();
                SiteSession.ItemArray[i].TotItemVal = ((TextBox)gvlocation.Rows[i].FindControl("TotItemVal")).Text.Convertdouble();
                SiteSession.ItemArray[i].OrdLineRef = ((TextBox)gvlocation.Rows[i].FindControl("OrdLineRef")).Text;
                SiteSession.ItemArray[i].OrdLineRef = ((TextBox)gvlocation.Rows[i].FindControl("OrdLineRef")).Text;
                SiteSession.ItemArray[i].OrgCntry = ((TextBox)gvlocation.Rows[i].FindControl("OrgCntry")).Text;
                SiteSession.ItemArray[i].PrdSlNo = ((TextBox)gvlocation.Rows[i].FindControl("PrdSlNo")).Text;
            }


        }




    }
}
public class Item
{
    public string SlNo { get; set; }
    public string PrdDesc { get; set; }
    public string IsServc { get; set; }
    public string HsnCd { get; set; }
    public string Barcde { get; set; }
    public decimal Qty { get; set; }
    public decimal FreeQty { get; set; }
    public string Unit { get; set; }
    public double UnitPrice { get; set; }
    public double TotAmt { get; set; }
    public double Discount { get; set; }
    public double PreTaxVal { get; set; }
    public double AssAmt { get; set; }
    public double GstRt { get; set; }
    public double IgstAmt { get; set; }
    public double CgstAmt { get; set; }
    public double SgstAmt { get; set; }
    public double CesRt { get; set; }
    public double CesAmt { get; set; }
    public double CesNonAdvlAmt { get; set; }
    public double StateCesRt { get; set; }
    public double StateCesAmt { get; set; }
    public double StateCesNonAdvlAmt { get; set; }
    public double OthChrg { get; set; }
    public double TotItemVal { get; set; }
    public string OrdLineRef { get; set; }
    public string OrgCntry { get; set; }
    public string PrdSlNo { get; set; }
}
