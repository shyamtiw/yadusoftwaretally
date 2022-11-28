using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Business;
namespace WebApp.admin.ReportModal
{
    public class ConsolidateInsurancePaymentList
    {

        public static DataTable PaymentListAllData( string FromDate,string ToDate)
        {

            DataTable dtMain = new DataTable();
            dtMain = ConnModal.FillDataTable("select *,(PolicyAmt-ReceivedAmt) balance from  (select InsuranceIndividualId,PolicyNo,  (case when PolicyIssueDate IS NULL then '' else CONVERT(varchar(11), PolicyIssueDate, 103) end) PolicyIssueDate,InsuranceCompany,PolicyExpiryDate,PartAPremium,GrossTotalPremium,RenewalStatusMINONMI,MIRenewalBreakUp,AutoDebitStatus,CustomerName,SubModel,VehicleRegnNo,EngineNo,ChassisNo,YearofManufacture,DealersExecutive, convert(decimal(10,2),(convert(decimal(10,2), (case when len (isnull( PartAPremium,''))>0 then PartAPremium else '0.00' end ) )*15.00/100.00)) PROVISIONALPAYOUT, convert(decimal(10,2), (case when len (isnull( GrossTotalPremium,''))>0 then GrossTotalPremium else '0.00' end ) )  PolicyAmt,isnull((select sum(ReceiptAmount) from [Insuranceupdatepayment] where [Insuranceupdatepayment].InsuranceIndividualId=InsuranceIndividual.InsuranceIndividualId),0) as ReceivedAmt from InsuranceIndividual where PolicyIssueDate between '"+FromDate+ "' and '" + ToDate + "' and Comp_Code="+WebApp.LIBS.SiteSession.Comp_MstSession.Comp_Code+") as x");
            if (dtMain.Rows.Count > 0)
            {
                string strInsuranceIndividualId = string.Join(",", dtMain.AsEnumerable().Select(print => print["InsuranceIndividualId"].ToString()).ToArray());

                var SubGroupItem = Global.Context.ExecuteStoreQuery<SubGroupItemGeoup>("select InsuranceIndividualId,replace(Paymode,' ','')  PaymodeHeader,Branch,PayMode ,ReceiptNo,ReceiptDate,ReceiptAmount  from  (select  *,(select top 1 Godw_Name  from Godown_Mst where Godown_Mst.Comp_Code="+WebApp.LIBS.SiteSession.Comp_MstSession.Comp_Code+" and Godown_Mst.Godw_Code=[Insuranceupdatepayment].BranchId) as Branch,(select top 1 Name from [Master] where [Master].MasterId=[Insuranceupdatepayment].MasterId) as PayMode from [Insuranceupdatepayment]  where InsuranceIndividualId in (" + strInsuranceIndividualId + ")) as x ").ToList();



                var SumPayModeWithInsuranceIndividual = SubGroupItem.AsEnumerable().GroupBy(p => new { p.InsuranceIndividualId, p.PaymodeHeader }).Select(p => new { p.Key, ReceiptAmount = p.Sum(c => c.ReceiptAmount) }).ToList();

                var ModeLoop = SubGroupItem.GroupBy(p => p.PaymodeHeader).ToList();
                ModeLoop.ToList().ForEach(x =>
                {
                    DataColumn dc = new DataColumn(x.Key.ToString()) { DefaultValue = "", DataType = Type.GetType("System.String") };
                    dtMain.Columns.Add(dc);


                });

                int MaxCountData = SubGroupItem.GroupBy(p => p.InsuranceIndividualId).Select(p => new { Data = p.Count() }).ToList().Max(p => p.Data);
                for (int i = 0; i < MaxCountData; i++)
                {
                    if (i > 0)
                    {
                        DataColumn dcBranch = new DataColumn("Branch" + i.ToString()) { DefaultValue = "", DataType = Type.GetType("System.String") };
                        dtMain.Columns.Add(dcBranch);
                        DataColumn dcPayMode = new DataColumn("PayMode" + i.ToString()) { DefaultValue = "", DataType = Type.GetType("System.String") };
                        dtMain.Columns.Add(dcPayMode);
                        DataColumn dcReceiptNo = new DataColumn("ReceiptNo" + i.ToString()) { DefaultValue = "", DataType = Type.GetType("System.String") };
                        dtMain.Columns.Add(dcReceiptNo);

                        DataColumn dcReceiptDate = new DataColumn("ReceiptDate" + i.ToString()) { DefaultValue = "", DataType = Type.GetType("System.String") };
                        dtMain.Columns.Add(dcReceiptDate);

                        DataColumn dcReceiptAmount = new DataColumn("ReceiptAmount" + i.ToString()) { DefaultValue = "", DataType = Type.GetType("System.String") };
                        dtMain.Columns.Add(dcReceiptAmount);


                    }
                    else
                    {
                        DataColumn dcBranch = new DataColumn("Branch") { DefaultValue = "", DataType = Type.GetType("System.String") };
                        dtMain.Columns.Add(dcBranch);
                        DataColumn dcPayMode = new DataColumn("PayMode") { DefaultValue = "", DataType = Type.GetType("System.String") };
                        dtMain.Columns.Add(dcPayMode);
                        DataColumn dcReceiptNo = new DataColumn("ReceiptNo") { DefaultValue = "", DataType = Type.GetType("System.String") };
                        dtMain.Columns.Add(dcReceiptNo);

                        DataColumn dcReceiptDate = new DataColumn("ReceiptDate") { DefaultValue = "", DataType = Type.GetType("System.String") };
                        dtMain.Columns.Add(dcReceiptDate);

                        DataColumn dcReceiptAmount = new DataColumn("ReceiptAmount") { DefaultValue = "", DataType = Type.GetType("System.String") };
                        dtMain.Columns.Add(dcReceiptAmount);

                    }
                }


                foreach (DataRow dr in dtMain.Rows)
                {
                    var Item = SumPayModeWithInsuranceIndividual.Where(p => p.Key.InsuranceIndividualId == Convert.ToInt32(dr["InsuranceIndividualId"]));
                    if (Item.Count() > 0)
                    {
                        ModeLoop.ToList().ForEach(x =>
                        {

                            try
                            {
                                dr[x.Key] = Item.Where(p => p.Key.PaymodeHeader == x.Key).FirstOrDefault().ReceiptAmount.ToString();
                            }
                            catch { }
                        });

                        var objData = SubGroupItem.Where(p => p.InsuranceIndividualId == Convert.ToInt32(dr["InsuranceIndividualId"])).OrderBy(p => p.ReceiptDate).ToList();

                        for (int i = 0; i < MaxCountData; i++)
                        {
                            try
                            {
                                if (i > 0)
                                {

                                    dr["Branch" + i.ToString()] = objData[i].Branch;
                                    dr["PayMode" + i.ToString()] = objData[i].PayMode;
                                    dr["ReceiptNo" + i.ToString()] = objData[i].ReceiptNo;
                                    dr["ReceiptDate" + i.ToString()] = objData[i].ReceiptDate.ToString("dd/MM/yyyy");
                                    dr["ReceiptAmount" + i.ToString()] = objData[i].ReceiptAmount.ToString();


                                }
                                else
                                {
                                    dr["Branch"] = objData[i].Branch;
                                    dr["PayMode"] = objData[i].PayMode;
                                    dr["ReceiptNo"] = objData[i].ReceiptNo;
                                    dr["ReceiptDate"] = objData[i].ReceiptDate.ToString("dd/MM/yyyy");
                                    dr["ReceiptAmount"] = objData[i].ReceiptAmount.ToString();

                                }
                            }
                            catch { }
                        }
                    }


                }
            }

            return dtMain;
        }
    }
}


public partial class SubGroupItemGeoup
{

    public int InsuranceIndividualId { get; set; }
    public string PaymodeHeader { get; set; }
    public string Branch { get; set; }
    public string PayMode { get; set; }
    public string ReceiptNo { get; set; }
    public DateTime ReceiptDate { get; set; }
    public decimal ReceiptAmount { get; set; }
}
