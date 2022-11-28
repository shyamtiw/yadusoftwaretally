using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApp.LIBS;
using Business;
namespace WebApp.admin.ReportModal
{
    public class FinancerOutstandingCS
    {

        public static DataTable SaleReportOutstandingData(string Multi_Loc,int GroupCOde)
        {
            return OtherSqlConn.FillDataTableStoredProcedureCorporateGroupCodeWise("Sp_CorporateCustomerOutStanding", Multi_Loc, GroupCOde);

        }

        public static DataTable SaleReportOutstandingData129(string Multi_Loc)
        {
            return OtherSqlConn.FillDataTableStoredProcedureCorporateGroupCodeWise("Sp_CorporateCustomerOutStanding", Multi_Loc, 129);

        }

        public static DataTable SaleReportOutstandingData63(string Multi_Loc)
        {
            
            return OtherSqlConn.FillDataTableStoredProcedureCorporateGroupCodeWise("Sp_CorporateCustomerOutStanding", Multi_Loc,63);

        }

        public static DataTable SaleReportOutstandingData52(string Multi_Loc)
        {

            return OtherSqlConn.FillDataTableStoredProcedureCorporateGroupCodeWise("Sp_CorporateCustomerOutStanding", Multi_Loc, 52);

        }

        public static DataTable SaleReportOutstandingData57(string Multi_Loc)
        {

            return OtherSqlConn.FillDataTableStoredProcedureCorporateGroupCodeWise("Sp_CorporateCustomerOutStanding", Multi_Loc, 57);

        }


        public static DataTable CashFlowData(string FromDate,string ToDate,string Day,string Multi_Loc)
        {

            DateTime dtdate = (ToDate.ToString()).DateConvertFormat("dd-MMM-yyyy");
            int Year = dtdate.Year;
            int[] Array = { 1, 2, 3 };
            if (Array.Contains(dtdate.Month))
            {
                Year = Year - 1;
            }

            return OtherSqlConn.FillDataTable("Select Ledg_Ac,Ledg_Name,BranchName,sum(openingbalance) as OpeningCash,sum(Contra_Receipt) as ContraReceipt,sum(dms_receipt) as DmsReceipt,sum(other_receipt) as OtherReceipt,sum(Bank_Deposit) BankDeposit,sum(dms_rcpt_cancelled) DmsRcptCancelled,sum(other_payment) as OtherPayment,(isnull( sum(openingbalance),0)+isnull( sum(Contra_Receipt),0)+isnull( sum(dms_receipt),0)+isnull( sum(other_receipt),0)+(isnull( sum(Bank_Deposit),0)+isnull( sum(dms_rcpt_cancelled),0)+isnull( sum(other_payment),0))) as ClosingCash, (SELECT  top 1 isnull(Date_" + Day + ",0) FROM  Cash_Bal where Cash_Bal.Cash_Code=Ledg_Ac and yr="+ Year + " and Mnth=month('" + ToDate + "')) as PhysicalCash,((isnull( sum(openingbalance),0)+isnull( sum(Contra_Receipt),0)+isnull( sum(dms_receipt),0)+isnull( sum(other_receipt),0)+(isnull( sum(Bank_Deposit),0)+isnull( sum(dms_rcpt_cancelled),0)+isnull( sum(other_payment),0)))-isnull((SELECT  top 1 isnull(Date_" + Day + ",0) FROM  Cash_Bal where Cash_Bal.Cash_Code=Ledg_Ac and yr="+ Year.ToString() + " and Mnth=month('" + ToDate + "')),0)) as [Difference] from (select Ledg_Ac,(select top 1 ledg_name from Ledg_Mst where Ledg_Code=Ledg_Ac) as Ledg_Name,Loc_Code,(select top 1 godw_Name from  godown_Mst where Export_Type<3 and godw_COde=x.loc_code) as BranchName,0 as OpeningBalance,sum(Contra_Receipt) as  Contra_Receipt, sum(DMS_Receipt) DMS_Receipt,sum(Other_Receipt) Other_Receipt,sum(Bank_Deposit) Bank_Deposit,sum(DMS_Rcpt_Cancelled) DMS_Rcpt_Cancelled,sum(Other_Payment) Other_Payment, 0 as closingbalance from   (Select Acnt_Id,acnt_date,Acnt_Post.Book_Code,Acnt_Post.Loc_Code,DMS_REF1, Ledg_Name as Ledger,Ledg_Ac,IIf(Amt_DrCr=1,Post_Amt,Post_Amt*-1) as Cl_Bal,Amt_DrCr,Acnt_Type,(case when Acnt_Type=4 and   Amt_DrCr=1 then  IIf(Amt_DrCr=1,Post_Amt,Post_Amt*-1)  else  0 end )  as Contra_Receipt, (case when Acnt_Type=1 and Amt_DrCr=1 and IsNull(DMS_REF1,'')<>'' then  IIf(Amt_DrCr=1,Post_Amt,Post_Amt*-1)  else  0 end )  as DMS_Receipt, (case when Acnt_Type<>4 and Amt_DrCr=1 and IsNull(DMS_REF1,'')='' then  IIf(Amt_DrCr=1,Post_Amt,Post_Amt*-1)  else  0 end )  as Other_Receipt, (case when Acnt_Type=4 and Amt_DrCr=2   then  IIf(Amt_DrCr=1,Post_Amt,Post_Amt*-1)  else  0 end )  as Bank_Deposit, (case when Acnt_Type<>4 and Acnt_Post.Book_Code=17 and Amt_DrCr=2  then  IIf(Amt_DrCr=1,Post_Amt,Post_Amt*-1)  else  0 end )  as DMS_Rcpt_Cancelled, (case when Acnt_Type<>4 and Acnt_Post.Book_Code<>17 and Amt_DrCr=2 then  IIf(Amt_DrCr=1,Post_Amt,Post_Amt*-1)  else  0 end )  as Other_Payment from Acnt_Post,Ledg_Mst where Ledg_Code=Ledg_Ac  AND IsNull(Cash_Flag,0)=1 and acnt_post.export_Type<5  and acnt_date between '" + FromDate + "' and '" + ToDate + "' and   Acnt_Post.loc_code in  (" + Multi_Loc + ")) as x group by x.Ledg_Ac,Loc_Code union all select ledg_Ac,ledg_name,loc_code,(select top 1 godw_Name from  godown_Mst where Export_Type<3 and godw_COde=x.loc_code) as BranchName,sum(Post_Amt) as OpeningBalance,0 as Contra_Receipt,0 as DMS_Receipt,0 as Other_Receipt,0 as Bank_Deposit,0 as DMS_Rcpt_Cancelled,0 as Other_Payment,0 as ClosingBalance from  (select ledg_Ac,ledg_name,Amt_Drcr,acnt_post.loc_code,(case when amt_drcr=1 then post_amt  else -1*post_amt end ) as Post_Amt from acnt_post,ledg_mst where ledg_mst.ledg_Code=Acnt_post.ledg_Ac and ledg_mst.Group_Code=24 and acnt_post.Export_Type<=4 and acnt_Date< '" + FromDate + "' and acnt_post.loc_code in (" + Multi_Loc + ")) as x group by ledg_Ac,ledg_name,loc_code ) as  a group by Ledg_Ac,Ledg_Name,Loc_Code,BranchName");

        }

        public static DataTable DeatilCouponList()
        {

            return ConnModal.FillDataTable("select CustomerName,PolicyNo,ProposalNo,(case when PolicyIssueDate IS NULL then '' else CONVERT(varchar(11), PolicyIssueDate,103) end) PolicyIssueDate,SubModel,VehicleRegnNo,Code,EmailId,MobNo,(case when IssueDate IS NULL then '' else CONVERT(varchar(11), IssueDate,103) end) IssueDate,(case when PolicyExpiryDate IS NULL then '' else CONVERT(varchar(11), PolicyExpiryDate,103) end) PolicyExpiryDate,CompulsoryExcess,[Master],CreatedBy,(Case when isnull(IsApprove,0)=1  then  ApproveBy else '' end ) as ApproveBy,(case when ApproveDate IS NULL then '' else CONVERT(varchar(11), ApproveDate,103) end) as ApproveDate, (Case when isnull(IsRedeem,0)=1  then  RedeemBy else '' end ) as RedeemBy, (case when RedeemDate IS NULL then '' else CONVERT(varchar(11), RedeemDate,103) end) as RedeemDate from  (select Code,EmailId,MobNo,IssueDate,InsuranceIndividualId,(select Name from [Master] where [Master].MasterId=InsuranceCoupon.MasterId) [Master],isnull(IsApprove,0) as IsApprove,isnull(IsReject,0) as IsReject,isnull(IsRedeem,0) as IsRedeem,(select Distinct isnull(convert (nvarchar(50), [User_Name]),'') [User_Name] from User_Tbl where  User_Tbl.User_Code =InsuranceCoupon.CreatedBy) as CreatedBy,(select Distinct isnull(convert (nvarchar(50), [User_Name]),'') [User_Name] from User_Tbl where  User_Tbl.User_Code =InsuranceCoupon.ApproveBy) as ApproveBy,(select Distinct isnull(convert (nvarchar(50), [User_Name]),'') [User_Name] from User_Tbl where  User_Tbl.User_Code =InsuranceCoupon.RedeemBy) as RedeemBy,ApproveDate,redeemDate ,InsuranceCouponId from InsuranceCoupon  where len(isnull(Code,''))>0) as x  left join InsuranceIndividual on x.InsuranceIndividualId=InsuranceIndividual.InsuranceIndividualId where Comp_Code=" + WebApp.LIBS.SiteSession.Comp_MstSession.Comp_Code+"");

        }



        public static DataTable BankrecoReport()
        {
            string MultiLoc= string.Join(",", SiteSession.GetGodawanListSession.Select(x => x.Id.ToString()).ToArray());
            return OtherSqlConn.FillDataTable("select x.*,y.Navy-GEN_Bank_Bal, isnull(dbo.Fuc_GetDateValueBankReco(x.Last_Reco_Date, x.Ledg_Code),0) as ActualBankBalance from  (select x.*,y.Navy-GEN_Reco_Bal from (select ledg_code,ledg_name3 as Bank_Ac_No,ledg_name as Bank_Name,ledg_ph1 as Account_Type,(select godw_name from godown_mst where godw_code=loc_code and export_type<3) as Accounting_Branch, Reco_Date as Last_Reco_Date from ledg_mst where brs_flag=1 and Loc_Code in (" + MultiLoc + ")) as x left join (select ledg_ac,sum(post_amt) as  Navy-GEN_Reco_Bal from (select ledg_Ac , iif(amt_drcr=1, post_amt,-1*post_amt) as post_amt from acnt_post,ledg_mst where  brs_flag=1 and ledg_Ac=ledg_code and acnt_post.Loc_Code in (" + MultiLoc + ") and  acnt_post.export_type<5 and bank_date<=(select  reco_Date from Ledg_mst where Ledg_Code=ledg_ac)) a group by ledg_Ac) as  y  on x.ledg_code=y.ledg_ac    ) as x left join  (select ledg_ac,sum(post_amt) as Navy-GEN_Bank_Bal from ( select ledg_Ac , iif(amt_drcr=1, post_amt,-1*post_amt) as post_amt from acnt_post ,ledg_mst where  brs_flag=1 and ledg_Ac=ledg_code and    acnt_post.Loc_Code in (" + MultiLoc + ") and  acnt_post.export_type<5 and acnt_date<=(select  reco_Date from Ledg_mst where Ledg_Code=ledg_ac )) a group by ledg_Ac) as y on x.ledg_code=y.ledg_ac");

        }





    }
}