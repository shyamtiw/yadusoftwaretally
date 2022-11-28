using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
using Business;
using WebApp.LIBS.MobileAppCS;
using System.Data;

namespace WebApp.mobile
{
    public partial class CashStatusReport : BasePageClassMobile
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            DateTime dateForButton = DateTime.Now;
            dateForButton = dateForButton.AddDays(-1);

            var Fromdate = "";
            var ToDate = "";
            if (Request.QueryString["Date"].ToString() == "1" && !string.IsNullOrWhiteSpace(Request.QueryString["Date"]))
            {
                Fromdate = Common.DateTimeNow().AddDays(0).ToString("dd/MM/yyyy");
                ToDate = Common.DateTimeNow().AddDays(0).ToString("dd/mm/yyyy");
            }
            else if (Request.QueryString["Date"].ToString() == "2" && !string.IsNullOrWhiteSpace(Request.QueryString["Date"]))
            {
                Fromdate = Common.DateTimeNow().AddDays(1).ToString("dd/mm/yyyy");
                ToDate = Common.DateTimeNow().AddDays(1).ToString("dd/mm/yyyy");
            }
            else if (Request.QueryString["Date"].ToString() == "3" && !string.IsNullOrWhiteSpace(Request.QueryString["Date"]))
            {
                Fromdate = Common.DateTimeNow().AddDays(2).ToString("dd/mm/yyyy");
                ToDate = Common.DateTimeNow().AddDays(2).ToString("dd/mm/yyyy");
            }
            else if (Request.QueryString["Date"].ToString() == "4" && !string.IsNullOrWhiteSpace(Request.QueryString["Date"]))
            {
                Fromdate = Common.DateTimeNow().AddDays(3).ToString("dd/mm/yyyy");
                ToDate = Common.DateTimeNow().AddDays(3).ToString("dd/mm/yyyy");
            }
            else if (Request.QueryString["Date"].ToString() == "5" && !string.IsNullOrWhiteSpace(Request.QueryString["Date"]))
            {
                Fromdate = Common.DateTimeNow().AddDays(4).ToString("dd/mm/yyyy");
                ToDate = Common.DateTimeNow().AddDays(4).ToString("dd/mm/yyyy");
            }
            else if (Request.QueryString["Date"].ToString() == "6" && !string.IsNullOrWhiteSpace(Request.QueryString["Date"]))
            {
                Fromdate = Common.DateTimeNow().AddDays(5).ToString("dd/mm/yyyy");
                ToDate = Common.DateTimeNow().AddDays(5).ToString("dd/mm/yyyy");
            }
            else
            {
                Fromdate = Common.DateTimeNow().ToString("dd/MM/yyyy");
                ToDate = Common.DateTimeNow().ToString("dd/MM/yyyy");
            }

            DataTable dt = MobileSales.CashFlowData(Fromdate.DateConvertTextMatchCase().ToString("dd-MMM-yyyy"), ToDate.DateConvertTextMatchCase().ToString("dd-MMM-yyyy"), ToDate.DateConvertTextMatchCase().ToString("dd"), string.Join(",", SiteSession.GetGodawanListSession.Select(x => x.Id.ToString()).ToArray()));
            Common.BindControldt(Cash_Status_Report, dt);


            decimal TotOpeningCash = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["OpeningCash"]));
            decimal TotContraReceipt = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["ContraReceipt"]));
            decimal TotDMSReceipt = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["DMSReceipt"]));
            decimal TotOtherReceipt = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["OtherReceipt"]));
            decimal TotBankDeposit = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["BankDeposit"]));
            decimal TotDMSRcptCancelled = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["DMSRcptCancelled"]));
            decimal TotOtherPayment = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["OtherPayment"]));
            decimal TotClosingCash = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["ClosingCash"]));
            //decimal TotPhysicalcash = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["PhysicalCash"]));
            decimal TotCashDifference = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["Difference"]));

            OpeningCash.Text = String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}", TotOpeningCash).ToString();
            ContraReceipt.Text = String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}", TotContraReceipt).ToString();
            DMSReceipt.Text = String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}", TotDMSReceipt).ToString();
            OtherReceipt.Text = String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}", TotOtherReceipt).ToString();
            BankDeposit.Text = String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}", TotBankDeposit).ToString();
            DMSRcptCancelled.Text = String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}", TotDMSRcptCancelled).ToString();
            OtherPayment.Text = String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}", TotOtherPayment).ToString();
            ClosingCash.Text = String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}", TotClosingCash).ToString();
            //PhysicalCash.Text = String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}", TotPhysicalcash).ToString();
            ClosingCash.Text = String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}", TotClosingCash).ToString();
            CashDifference.Text = String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}", TotCashDifference).ToString();

        }
    }
}