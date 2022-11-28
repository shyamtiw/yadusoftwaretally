using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
using Business;

namespace WebApp.admin
{
    public partial class IndusvalinsuranceListAutoDebit : BasePageClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Common.BindControl(gvlocation, Global.Context.ExecuteStoreQuery<ListDataInduInsurance>("select *,(CONVERT(decimal(10,2), ISNULL(GrossTotalPremium,'0'))-ISNULL(ReceiptAmount,0)) as Balance from  (select InsuranceIndividualId,  ProposalNo,PolicyIssueDate,InsuranceCompany,FreshRenewal,YearofManufacture,EngineNo,SubModel,FinanceCompany,PolicyType,PolicyIssueTime,CompulsoryExcess,64VBVerifiedStatus,VehicleRegnNo,ChassisNo,MulVariant,DealersExecutive,PolicyNo,PolicyExpiryDate,GrossTotalPremium,(select  sum ( ReceiptAmount) from Insuranceupdatepayment  where Insuranceupdatepayment.InsuranceIndividualId=InsuranceIndividual.InsuranceIndividualId) as ReceiptAmount,CustomerName,VehicleType,VIN,MulColor,AutoDebitStatus from InsuranceIndividual where Comp_Code=" + SiteSession.Comp_MstSession.Comp_Code + " and  PolicyIssueDate between '" + Common.DateTimeNow().AddDays(-5).ToString("dd-MMM-yyyy") + "' and  '" + Common.DateTimeNow().ToString("dd-MMM-yyyy") + "') x  where ( CONVERT(decimal(10,2), ISNULL(GrossTotalPremium,'0'))-ISNULL(ReceiptAmount,0))>0 and  FreshRenewal='Renewal' and AutoDebitStatus='Auto Debit'").ToList());
            }
        }





        protected void GetData_Click(object sender, EventArgs e)
        {

            try
            {

                Common.BindControl(gvlocation, Global.Context.ExecuteStoreQuery<ListDataInduInsurance>("select *,(CONVERT(decimal(10,2), ISNULL(GrossTotalPremium,'0'))-ISNULL(ReceiptAmount,0)) as Balance from  (select InsuranceIndividualId,  ProposalNo,PolicyIssueDate,InsuranceCompany,FreshRenewal,YearofManufacture,EngineNo,SubModel,FinanceCompany,PolicyType,PolicyIssueTime,CompulsoryExcess,64VBVerifiedStatus,VehicleRegnNo,ChassisNo,MulVariant,DealersExecutive,PolicyNo,PolicyExpiryDate,GrossTotalPremium,(select  sum ( ReceiptAmount) from Insuranceupdatepayment  where Insuranceupdatepayment.InsuranceIndividualId=InsuranceIndividual.InsuranceIndividualId) as ReceiptAmount,CustomerName,VehicleType,VIN,MulColor,AutoDebitStatus from InsuranceIndividual where Comp_Code=" + SiteSession.Comp_MstSession.Comp_Code + " and  PolicyIssueDate between '" + FromDate.Text.DateConvert().ToString("dd-MMM-yyyy") + "' and  '" + ToDate.Text.DateConvert().ToString("dd-MMM-yyyy") + "') x  where ( CONVERT(decimal(10,2), ISNULL(GrossTotalPremium,'0'))-ISNULL(ReceiptAmount,0))>0 and  FreshRenewal='Renewal' and AutoDebitStatus='Auto Debit'").ToList());
            }
            catch { }
        }
    }
}