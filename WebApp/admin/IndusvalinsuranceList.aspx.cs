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
    public partial class IndusvalinsuranceList :BasePageClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Common.BindControl(gvlocation, Global.Context.ExecuteStoreQuery<ListDataInduInsurance>("select InsuranceIndividualId,  ProposalNo,PolicyIssueDate,InsuranceCompany,FreshRenewal,YearofManufacture,EngineNo,SubModel,FinanceCompany,PolicyType,PolicyIssueTime,CompulsoryExcess,64VBVerifiedStatus,VehicleRegnNo,ChassisNo,MulVariant,DealersExecutive,PolicyNo,PolicyExpiryDate,GrossTotalPremium,CustomerName,VehicleType,VIN,MulColor,AutoDebitStatus from InsuranceIndividual where Comp_Code=" + SiteSession.Comp_MstSession.Comp_Code+ " and PolicyIssueDate between '" + Common.DateTimeNow().AddDays(-5).ToString("dd-MMM-yyyy") + "' and  '" + Common.DateTimeNow().ToString("dd-MMM-yyyy") + "'").ToList());
            }
        }


        protected void GetData_Click(object sender, EventArgs e)
        {

            try
            {
               
                Common.BindControl(gvlocation, Global.Context.ExecuteStoreQuery<ListDataInduInsurance>("select InsuranceIndividualId,  ProposalNo,PolicyIssueDate,InsuranceCompany,FreshRenewal,YearofManufacture,EngineNo,SubModel,FinanceCompany,PolicyType,PolicyIssueTime,CompulsoryExcess,64VBVerifiedStatus,VehicleRegnNo,ChassisNo,MulVariant,DealersExecutive,PolicyNo,PolicyExpiryDate,GrossTotalPremium,CustomerName,VehicleType,VIN,MulColor,AutoDebitStatus from InsuranceIndividual where Comp_Code=" + SiteSession.Comp_MstSession.Comp_Code + " and PolicyIssueDate between '" + FromDate.Text.DateConvertTextMatchCase().ToString("dd-MMM-yyyy") + "' and  '" + ToDate.Text.DateConvertTextMatchCase().ToString("dd-MMM-yyyy") + "' ").ToList());
            }
            catch { }
        }
    }
}

public partial class ListDataInduInsurance
{
    public int InsuranceIndividualId { get; set; }
    
    public string ProposalNo { get; set; }
    public DateTime ?PolicyIssueDate { get; set; }
    public string InsuranceCompany { get; set; }
    public string FreshRenewal { get; set; }
    public string YearofManufacture { get; set; }
    public string EngineNo { get; set; }
    public string SubModel { get; set; }
    public string FinanceCompany { get; set; }
    public string PolicyType { get; set; }
    public string PolicyIssueTime { get; set; }
    public string CompulsoryExcess { get; set; }
    public string sixtyfourVBVerifiedStatus { get; set; }
    public string VehicleRegnNo { get; set; }
    public string ChassisNo { get; set; }
    public string MulVariant { get; set; }
    public string DealersExecutive { get; set; }
    public string PolicyNo { get; set; }
    public DateTime ?PolicyExpiryDate { get; set; }
    public string GrossTotalPremium { get; set; }
    public decimal ?ReceiptAmount { get; set; }
    public decimal ?Balance { get; set; }

    public string CustomerName { get; set; }
    public string VehicleType { get; set; }
    public string VIN { get; set; }
    public string MulColor { get; set; }
    public string AutoDebitStatus { get; set; }

}