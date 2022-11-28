using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApp.admin.ReportModal;

namespace WebApp.LIBS.MobileAppCS
{
    public class MobileSales
    {

        public static DataTable SalesDiscountApprovalList(string Multi_Loc)
        {
            string Str = "select  loc_code,Ledg_name,dms_inv,(select top 1 VARIANT_DESC from modl_mst,model_variant_master where item_code=2744 and model_variant_master.VARIANT_CD=modl_mst.modl_code) as modl_code,(select top 1 ECOLOR_DESC  from model_variant_master,misc_mst where misc_type=10 and misc_code=veh_clr and model_variant_master.ECOLOR_CD=misc_mst.Misc_Abbr) as Veh_Clr ,dms_dse,dms_tl,adnl_disc from icm_mst,(select distinct * from icm_dtl) as x where icm_mst.TRAN_ID=x.TRAN_ID  and adnl_disc>0 and loc_code in (" + Multi_Loc + ") and  isnull( Addnl_Disc_Approved,0)=0";
            return OtherSqlConn.FillDataTable(Str);

        }

        public static DataTable SalesDiscountRowData(string DMS_Inv, string Loc_Code)
        {
            string Str = "select top 1 Ledg_Name,Ledg_Add1 as father_Name,Ledg_Add2 as Address,(select top 1 misc_name from misc_mst where misc_type=1 and misc_code=teh_code) as City,(select misc_name from misc_mst where misc_type=3 and misc_code=Stat_code) as State,Ph1 as Mobile_No,Email_Id,case when drpCustType=0 then 'Individual Customer' 	when drpCustType=0 then 'CSD Customer'	when drpCustType=0 then 'BSF Customer' 	when drpCustType=0 then 'CPC Customer' 	end as Customer_Type,Pin_Code,Pan_No,GST_No,(select top 1 misc_name from misc_mst where misc_type=8 and misc_code=fin_Code) as Financer_Name,FPymt_Mode as Loan_Type,(select top 1 misc_name from misc_mst where misc_type=51 and misc_code=Br_Code) as Financer_Branch,Fin_Dono as Finance_Do_Number,DO_AMT as Finance_DO_Amount,PF_Charges as Finance_PF_Charges,PO_No as PO_Number,PO_Date as PO_Date,PO_Amt as PO_AMT,icm_mst.loc_code,Ledg_name,dms_inv,(select top 1 Model_Desc from modl_mst,model_variant_master where item_code=2744 and model_variant_master.VARIANT_CD=modl_mst.modl_code) as Vehicle_Group,(select top 1 VARIANT_CD from modl_mst,model_variant_master where item_code=2744 and model_variant_master.VARIANT_CD=modl_mst.modl_code) as Variant_Code,(select top 1 VARIANT_DESC from modl_mst,model_variant_master where item_code=2744 and model_variant_master.VARIANT_CD=modl_mst.modl_code) as Variant_Name,(select top 1 ECOLOR_CD from model_variant_master,misc_mst where misc_type=10 and misc_code=veh_clr and model_variant_master.ECOLOR_CD=misc_mst.Misc_Abbr) as Color_Code,(select top 1 ECOLOR_DESC  from model_variant_master,misc_mst where misc_type=10 and misc_code=veh_clr and model_variant_master.ECOLOR_CD=misc_mst.Misc_Abbr) as Color_Name,(select misc_name from misc_mst where misc_type=7 and misc_code=dms_dse) as DMS_DSE,(select misc_name from misc_mst where misc_type=7 and misc_code=dms_tl) as DMS_TL,(ADNL_DISC+MSIL_Disc) as ADNL_DISC,VIN,CHAS_NO as Chassis_Num,Engn_No as Engine_Num,MRP_Price as Ex_Showroom,Cons_Disc as Cons_offer,Corp_Disc as Corp_Offer,Exch_Disc as Exch_Offer,adnl_disc as Post_Sales_Disc,(MRP_Price-Cons_Disc-Corp_Disc-Exch_Disc) as Net_Selling_Price,case when drpInsu=0 then 'Zero Dep.' when drpInsu=1 then 'Normal' when drpInsu=2 then 'Commercial' when drpInsu=3 then 'Zero Dep NCB' when drpInsu=4 then 'Normal NCB' when drpInsu=5 then 'None'  when drpInsu=6 then 'LTCP' end as Insu_Type,Ins_Pric as Insu_Amt,case when drpEW =0 then 'Platinum (4th Yr)' when drpEW =1 then 'Gold (3rd Yr)' when drpEW =2 then 'Royal Platinum (5th Yr)' when drpEW =3 then 'Dealer EW' when drpEW =4 then 'None' end as EW_Type,EW_Pric as EW_Amt,case when drpRTO  =0 then 'Permanent' when drpRTO  =1 then 'Temporary' when drpRTO  =2 then 'Commercial' when drpRTO  =3 then 'RTO+TRC Both' when drpRTO  =4 then 'None' end as RTO_Type,RTO_Pric as RTO_Amt,MGA_Pric as MSGA_AMT,Nexa_Card as MSR_AMT,FasTag as Fastag_Amt,NonMGA_Chrgs as NonMGA_Amt,OnRoad_Price as On_Road_Price, OldRegno_1 as Veh_Regn_No,OldChasNo_1 as Veh_Chas_No,oldEngno_1 as Veh_Engn_No,(select EMPFIRSTNAME from EMPLOYEEMASTER where srno=TV_Evaluator_1) as Evaluator_Name,OldModel_1 as Model_Variant,OldMfgYr_1 as MFG_Year,OldKm_1 as KMS_Run,TV_PurcAmt_1 as Purc_Amt,Loan_Paid_1 as Loan_Paid,Thirdparty_InsuAmt_1 as Insurance_3P,TV_NetAmt_1 as Net_Amt,Refurb_Est_1 as Prop_RF,Refurb_Act_1 as Actual_RF,Notes_1 as Remarks,TV_NTV1 as Exch_Type from icm_mst,(select distinct * from exch_veh) y, (select distinct * from icm_dtl) as x where icm_mst.TRAN_ID=x.TRAN_ID and icm_mst.Chas_No=y.NewChasNo   and icm_mst.loc_code in (" + Loc_Code + ") and dms_inv='" + DMS_Inv + "' and  isnull( Addnl_Disc_Approved,0)=0";
            return OtherSqlConn.FillDataTable(Str);

        }

        public static DataTable BSCParameter(string Module, string Parameter)
        {
            string Str = "select  * from Bsc_Parameter where Module in ('" + Module + "') and  Parameter in ('" + Parameter + "')";
            return ConnModal.FillDataTable(Str);
        }

        public static DataTable WholeSale_Performance(string Region)
        {
            string Str = "select [month],sum(isnull([2020-21],0)) as [2020-21],sum(isnull([2021-22],0)) as [2021-22],(case when sum(isnull([2020-21],0))>0 and sum(isnull([2021-22],0))>0 then (sum(isnull([2021-22],0))/(sum(isnull([2020-21],0))*1.30)*100 ) else sum(isnull([2021-22],0))/1*100 end ) as ageAch from ( SELECT Region,Dealer_Code,Dealer_Channel,(Case when [month]='APR' then 1	 when [month]='MAY' then 2	 when [month]='JUN' then 3	 when [month]='JUL' then 4	 when [month]='AUG' then 5	 when [month]='SEP' then 6	 when [month]='OCT' then 7	 when [month]='NOV' then 8	 when [month]='DEC' then 9	 when [month]='JAN' then 10	 when [month]='FEB' then 11	 when [month]='MAR' then 12	 Else 0	 end) as MntPriority,[month],isnull([2020-21],0) as [2020-21],isnull([2021-22],0) as [2021-22] FROM (SELECT  Region,Dealer_Code,Dealer_Channel,[Year], [month],Wholesale_Net FROM bsc_data_1 where Region in ('" + Region + "')) Tab1 PIVOT  (  SUM(Wholesale_Net) FOR [Year] IN ([2020-21],[2021-22])) AS Tab2 ) as x group by MntPriority ,[month] order by MntPriority asc";
            return ConnModal.FillDataTable(Str);
        }
        public static DataTable BSC_Data_1(string SchemeName, string Region, string DealerCode = null)
        {
            string DealerFiler = DealerCode != null ? " and dealercode='" + DealerCode + "'" : "";
            string Str = "select DATENAME(MONTH, max(schememonth) ) as [Month],(case when Month(schememonth)= 4 then 1 when Month(schememonth)= 5 then 2 when Month(schememonth)= 6 then 3 when Month(schememonth)= 7 then 4 when Month(schememonth)= 8 then 5 when Month(schememonth)= 9 then 6 when Month(schememonth)= 10 then 7 when Month(schememonth)= 11 then 8 when Month(schememonth)= 12 then 9 when Month(schememonth)= 1 then 10 when Month(schememonth)= 2 then 11 when Month(schememonth)= 3 then 12 else 0 end ) as Priorty, sum(CONVERT(decimal(10, 2), (case when len(Incentive) > 0 then REPLACE(Incentive, ',', '') else '0' end ))) as Claim ,sum(CONVERT(decimal(10, 2), (case when len(CrAmt) > 0 then REPLACE(CrAmt, ',', '') else '0'end ))) as Recd,sum(CONVERT(decimal(10, 2), (case when len(Rejected) > 0 then REPLACE(Rejected, ',', '') else '0'end ))) as Reject,sum(CONVERT(decimal(10, 2), (case when len(Recovered) > 0 then REPLACE(Recovered, ',', '') else '0'end ))) as Recover,(sum(CONVERT(decimal(10, 2), (case when len(Incentive) > 0 then REPLACE(Incentive, ',', '') else '0' end )))-sum(CONVERT(decimal(10, 2), (case when len(CrAmt) > 0 then REPLACE(CrAmt, ',', '') else '0'end )))-sum(CONVERT(decimal(10, 2), (case when len(Rejected) > 0 then REPLACE(Rejected, ',', '') else '0'end )))-sum(CONVERT(decimal(10, 2), (case when len(Recovered) > 0 then REPLACE(Recovered, ',', '') else '0'end )))) as Bal from MSIL_Claim_Data where schememonth<'2021/04/01' and schemename  in ('" + SchemeName + "')and region in ('" + Region + "') " + DealerFiler + " group by Month(Schememonth) order by Priorty";
            return ConnModal.FillDataTable(Str);
        }

        public static DataTable DealerCode(string SchemeName, string Region)
        {
            string Str = "select distinct dealercode from MSIL_Claim_Data where Region in ('" + Region + "') and Schemename in ('" + SchemeName + "')";
            return ConnModal.FillDataTable(Str);
        }
        public static DataTable DealerCode()
        {
            string Str = "select distinct Region from MSIL_Claim_Data ";
            return ConnModal.FillDataTable(Str);
        }
        public static DataTable DealerCode1(string region = null)
        {

            string STR = "";
            String CompCode = "";
            region = !String.IsNullOrWhiteSpace(region) ? "  Range_name  like '" + region + "%'" : "";
            CompCode = SiteSession.LoginUser.Comp_Code != null ? " Compcode = '" + SiteSession.LoginUser.Comp_Code + "'" : "";

            STR = STR + (region.Length > 0 ? "and" + region : "");
            STR = STR + (STR.Length > 0 ? (region.Length > 0 ? " and " + region : "") : (region.Length > 0 ? region : ""));


            string Str = "select distinct Compcode,Dealer + '-' + FORCode as dealercode from PENDING_INDENT, godown_mst where Godown_Mst.BR_EXTRANET = Dealer + '-' + FORCode " + STR + "";
            return ConnModal.FillDataTable(Str);
        }
        public static DataTable DealerCode2(string region = null)
        {

            string STR = "";
            String CompCode = "";
            region = !String.IsNullOrWhiteSpace(region) ? "  Range_name  like '" + region + "%'" : "";
            CompCode = SiteSession.LoginUser.Comp_Code != null ? " Compcode = '" + SiteSession.LoginUser.Comp_Code + "'" : "";

            STR = STR + (region.Length > 0 ? "and" + region : "");
            STR = STR + (STR.Length > 0 ? (region.Length > 0 ? " and " + region : "") : (region.Length > 0 ? region : ""));


            string Str = "select distinct Locationcode as dealercode from new_Car_Sale_register, godown_mst where Godown_Mst.newcar_rcpt =locationcode " + STR + "";
            return ConnModal.FillDataTable(Str);
        }

        public static DataTable ExchangeDealerCode(string Region)
        {
            string Str = "select distinct dealercodeforcode from MSIL_Exchange_Claim where Region in ('" + Region + "') ";
            return ConnModal.FillDataTable(Str);
        }
        public static DataTable ISLRMKDealerCode(string Region)
        {
            string Str = "select distinct dealercodeforcode from MSIL_ISLRMK_Claim where Region in ('" + Region + "') ";
            return ConnModal.FillDataTable(Str);
        }

        public static DataTable Region()
        {
            string Str = "select distinct Region from MSIL_Claim_Data";
            return ConnModal.FillDataTable(Str);
        }

        public static DataTable ExchangeRegionCode()
        {
            string Str = "select distinct Region from MSIL_Exchange_Claim";
            return ConnModal.FillDataTable(Str);
        }
        public static DataTable ISLRMKRegionCode()
        {
            string Str = "select distinct Region from MSIL_ISLRMK_Claim";
            return ConnModal.FillDataTable(Str);
        }
        public static DataTable BSC_Data(string Region = null)
        {
            string DealerFiler = Region != null ? " where region='" + Region + "'" : "";
            string Str = "select SchemeName, sum(CONVERT(decimal(10, 2), (case when len(Incentive) > 0 then REPLACE(Incentive, ',', '') else '0'end))) as Claim ,sum(CONVERT(decimal(10,2),(case when len(CrAmt)>0 then REPLACE(CrAmt,',','') else '0'end ))) as Recd,sum(CONVERT(decimal(10,2),(case when len(Rejected)>0 then REPLACE(Rejected,',','') else '0'end ))) as Reject,sum(CONVERT(decimal(10,2),(case when len(Recovered)>0 then REPLACE(Recovered,',','') else '0'end ))) as Recover,(sum(CONVERT(decimal(10,2),(case when len((Incentive))>0 then REPLACE((Incentive),',','') else '0'end )))-sum(CONVERT(decimal(10, 2), (case when len((CrAmt)) > 0 then REPLACE((CrAmt), ',', '') else '0'end )))-      sum(CONVERT(decimal(10, 2), (case when len((Rejected)) > 0 then REPLACE((Rejected), ',', '') else '0'end )))-            sum(CONVERT(decimal(10, 2), (case when len((Recovered)) > 0 then REPLACE((Recovered), ',', '') else '0'end )))) as Bal  from MSIL_Claim_Data  " + DealerFiler + "  group by SchemeName order by Bal desc";
            return ConnModal.FillDataTable(Str);
        }

        public static DataTable Exchange_Summary(string Region = null, string DealerCode = null)
        {
            string STR = "";
            Region = !String.IsNullOrWhiteSpace(Region) ? " Where region='" + Region + "'" : "";
            DealerCode = !String.IsNullOrWhiteSpace(DealerCode) ? " dealercodeforcode='" + DealerCode + "'" : "";

            STR = STR + (Region.Length > 0 ? Region : "");
            STR = STR + (DealerCode.Length > 0 ? " and " + DealerCode : "");

            string Str = "Select Srno,Month,sum(CONVERT(decimal(10, 2), (case when len(time_barred) > 0 then REPLACE(time_barred, ',', '') else '0'end ))) as Time_Barred ,sum(CONVERT(decimal(10, 2), (case when len(Clarification_Req) > 0 then REPLACE(Clarification_Req, ',', '') else '0'end ))) as Clarification_Req  ,sum(CONVERT(decimal(10, 2), (case when len(Accept) > 0 then REPLACE(Accept, ',', '') else '0'end ))) as Accept  ,sum(CONVERT(decimal(10, 2), (case when len(Clarification_submit) > 0 then REPLACE(Clarification_submit, ',', '') else '0'end ))) as Clarification_submit  ,sum(CONVERT(decimal(10, 2), (case when len(reject) > 0 then REPLACE(reject, ',', '') else '0'end ))) as reject  ,sum(CONVERT(decimal(10, 2), (case when len(MSIL_Submitted) > 0 then REPLACE(MSIL_Submitted, ',', '') else '0'end ))) as MSIL_Submitted  ,sum(CONVERT(decimal(10, 2), (case when len(Pending_for_Submit) > 0 then REPLACE(Pending_for_Submit, ',', '') else '0'end ))) as Pending_for_Submit     from (select srno,Month,[Time Barred] as Time_Barred,[Clarification Required] as Clarification_Req,[Accepted] as Accept,[Clarification Submitted] as Clarification_Submit,[Rejected] as Reject,[Submitted and Pending with MSIL] as MSIL_Submitted,[Pending for Submission] as Pending_For_Submit from(SELECT Case when Region = 'C1' then 'CENTRAL 1' when Region = 'C2' then 'CENTRAL 2' when Region = 'C3' then 'CENTRAl 3' end as Region, [STATUS], Case when month(newcarinvoicedate) = 4 then 1  when month(newcarinvoicedate) = 5 then 2 when month(newcarinvoicedate) = 6 then 3 when month(newcarinvoicedate) = 7 then 4 when month(newcarinvoicedate) = 8 then 5 when month(newcarinvoicedate) = 9 then 6 when month(newcarinvoicedate) = 10 then 7 when month(newcarinvoicedate) = 11 then 8 when month(newcarinvoicedate) = 12 then 9 when month(newcarinvoicedate) = 1 then 10 when month(newcarinvoicedate) = 2 then 11 when month(newcarinvoicedate) = 3 then 12 end as Srno,Case when month(newcarinvoicedate) = 4 then 'APR'  when month(newcarinvoicedate) = 5 then 'MAY' when month(newcarinvoicedate) = 6 then 'JUN' when month(newcarinvoicedate) = 7 then 'JUL' when month(newcarinvoicedate) = 8 then 'AUG' when month(newcarinvoicedate) = 9 then 'SEP' when month(newcarinvoicedate) = 10 then 'OCT' when month(newcarinvoicedate) = 11 then 'NOV' when month(newcarinvoicedate) = 12 then 'DEC' when month(newcarinvoicedate) = 1 then 'JAN' when month(newcarinvoicedate) = 2 then 'FEB' when month(newcarinvoicedate) = 3 then 'MAR' end as Month, Dealercodeforcode, ((CONVERT(decimal(10,2),(case when len((MSILSHARE))>0 then REPLACE((MSILSHARE),',','') else '0'end )))) as Claim_AMT FROM MSIL_EXCHANGE_CLAIM " + STR + ")Tab1 PIVOT(sum(Claim_AMT) FOR [STATUS] IN ([Time Barred],[Clarification Required],[Accepted],[Clarification Submitted],[Rejected],[Submitted and Pending with MSIL],[Pending for Submission])) AS Tab2  ) a group by Month,Srno order by Srno  ";
            return ConnModal.FillDataTable(Str);
        }

        public static DataTable ISLRMK_Summary(string Region = null, string DealerCode = null)
        {
            string STR = "";
            Region = !String.IsNullOrWhiteSpace(Region) ? " Where newcarinvpocedate<='2021/03/31' and region='" + Region + "'" : "";
            DealerCode = !String.IsNullOrWhiteSpace(DealerCode) ? " dealercodeforcode='" + DealerCode + "'" : "";

            STR = STR + (Region.Length > 0 ? Region : "");
            STR = STR + (DealerCode.Length > 0 ? " and " + DealerCode : "");

            string Str = "Select Srno,Month,sum(CONVERT(decimal(10, 2), (case when len(time_barred) > 0 then REPLACE(time_barred, ',', '') else '0'end ))) as Time_Barred ,sum(CONVERT(decimal(10, 2), (case when len(Clarification_Req) > 0 then REPLACE(Clarification_Req, ',', '') else '0'end ))) as Clarification_Req  ,sum(CONVERT(decimal(10, 2), (case when len(Accept) > 0 then REPLACE(Accept, ',', '') else '0'end ))) as Accept  ,sum(CONVERT(decimal(10, 2), (case when len(Clarification_submit) > 0 then REPLACE(Clarification_submit, ',', '') else '0'end ))) as Clarification_submit  ,sum(CONVERT(decimal(10, 2), (case when len(reject) > 0 then REPLACE(reject, ',', '') else '0'end ))) as reject  ,sum(CONVERT(decimal(10, 2), (case when len(MSIL_Submitted) > 0 then REPLACE(MSIL_Submitted, ',', '') else '0'end ))) as MSIL_Submitted  ,sum(CONVERT(decimal(10, 2), (case when len(Pending_for_Submit) > 0 then REPLACE(Pending_for_Submit, ',', '') else '0'end ))) as Pending_for_Submit     from (select srno,Month,[Time Barred] as Time_Barred,[Clarification Required] as Clarification_Req,[Accepted] as Accept,[Clarification Submitted] as Clarification_Submit,[Rejected] as Reject,[Submitted and Pending with MSIL] as MSIL_Submitted,[Pending for Submission] as Pending_For_Submit from(SELECT Case when Region = 'C1' then 'CENTRAL 1' when Region = 'C2' then 'CENTRAL 2' when Region = 'C3' then 'CENTRAl 3' end as Region, [STATUS], Case when month(newcarinvoicedate) = 4 then 1  when month(newcarinvoicedate) = 5 then 2 when month(newcarinvoicedate) = 6 then 3 when month(newcarinvoicedate) = 7 then 4 when month(newcarinvoicedate) = 8 then 5 when month(newcarinvoicedate) = 9 then 6 when month(newcarinvoicedate) = 10 then 7 when month(newcarinvoicedate) = 11 then 8 when month(newcarinvoicedate) = 12 then 9 when month(newcarinvoicedate) = 1 then 10 when month(newcarinvoicedate) = 2 then 11 when month(newcarinvoicedate) = 3 then 12 end as Srno,Case when month(newcarinvoicedate) = 4 then 'APR'  when month(newcarinvoicedate) = 5 then 'MAY' when month(newcarinvoicedate) = 6 then 'JUN' when month(newcarinvoicedate) = 7 then 'JUL' when month(newcarinvoicedate) = 8 then 'AUG' when month(newcarinvoicedate) = 9 then 'SEP' when month(newcarinvoicedate) = 10 then 'OCT' when month(newcarinvoicedate) = 11 then 'NOV' when month(newcarinvoicedate) = 12 then 'DEC' when month(newcarinvoicedate) = 1 then 'JAN' when month(newcarinvoicedate) = 2 then 'FEB' when month(newcarinvoicedate) = 3 then 'MAR' end as Month, Dealercodeforcode, ((CONVERT(decimal(10,2),(case when len((MSILSHARE))>0 then REPLACE((MSILSHARE),',','') else '0'end )))) as Claim_AMT FROM MSIL_ISLRMK_CLAIM " + STR + ")Tab1 PIVOT(sum(Claim_AMT) FOR [STATUS] IN ([Time Barred],[Clarification Required],[Accepted],[Clarification Submitted],[Rejected],[Submitted and Pending with MSIL],[Pending for Submission])) AS Tab2  ) a group by Month,Srno order by Srno  ";
            return ConnModal.FillDataTable(Str);
        }

        public static DataTable ISLRMK_Detail(string Region = null, string DealerCode = null)
        {
            string STR = "";
            Region = !String.IsNullOrWhiteSpace(Region) ? " Where newcarinvoicedate<='2021/03/31' and region='" + Region + "'" : "";
            DealerCode = !String.IsNullOrWhiteSpace(DealerCode) ? " dealercodeforcode='" + DealerCode + "'" : "";

            STR = STR + (Region.Length > 0 ? Region : "");
            STR = STR + (DealerCode.Length > 0 ? " and " + DealerCode : "");

            string Str = "Select * from (select DealerCodeForCode,NewCarOwnerDMS,NewCarInvoiceNo,NewCarInvoiceDate,NewCarModel,NewCarVin,Status,DealerSubmissionDate,StatusUpdatedDate,ClaimType,case when LatestClarificationReqDate is not null then LatestClarificationsubmtdDate else IstClarificationReqDate end as ClarificationReqDate,Case when  LatestClarificationsubmtdDate is not null then LatestClarificationsubmtdDate else IstClarificationsubmtdDate end as ClarificationSubmitDate,SalesType,MSILShare, NewCarInsuranceReason as Reason,'NewCarInsuranceReason' as Reason_Type from MSIL_ISLRMK_CLAIM  union All select DealerCodeForCode,NewCarOwnerDMS,NewCarInvoiceNo,NewCarInvoiceDate,NewCarModel,NewCarVin,Status,DealerSubmissionDate,StatusUpdatedDate,ClaimType,case when LatestClarificationReqDate is not null then LatestClarificationsubmtdDate else IstClarificationReqDate end as ClarificationReqDate,Case when  LatestClarificationsubmtdDate is not null then LatestClarificationsubmtdDate else IstClarificationsubmtdDate end as ClarificationSubmitDate,SalesType,MSILShare, CustomerSchemeReason as Reason,'CustomerSchemeReason' as Reason_Type from MSIL_ISLRMK_CLAIM   union All select DealerCodeForCode,NewCarOwnerDMS,NewCarInvoiceNo,NewCarInvoiceDate,NewCarModel,NewCarVin,Status,DealerSubmissionDate,StatusUpdatedDate,ClaimType,case when LatestClarificationReqDate is not null then LatestClarificationsubmtdDate else IstClarificationReqDate end as ClarificationReqDate,Case when  LatestClarificationsubmtdDate is not null then LatestClarificationsubmtdDate else IstClarificationsubmtdDate end as ClarificationSubmitDate,SalesType,MSILShare, RelationshipProofReason as Reason,'RelationshipProofReason' as Reason_Type from MSIL_ISLRMK_CLAIM union All select DealerCodeForCode,NewCarOwnerDMS,NewCarInvoiceNo,NewCarInvoiceDate,NewCarModel,NewCarVin,Status,DealerSubmissionDate,StatusUpdatedDate,ClaimType,case when LatestClarificationReqDate is not null then LatestClarificationsubmtdDate else IstClarificationReqDate end as ClarificationReqDate,Case when  LatestClarificationsubmtdDate is not null then LatestClarificationsubmtdDate else IstClarificationsubmtdDate end as ClarificationSubmitDate,SalesType,MSILShare, KYCDocumentReason as Reason,'KYCDocumentReason' as Reason_Type from MSIL_ISLRMK_CLAIM union All select DealerCodeForCode,NewCarOwnerDMS,NewCarInvoiceNo,NewCarInvoiceDate,NewCarModel,NewCarVin,Status,DealerSubmissionDate,StatusUpdatedDate,ClaimType,case when LatestClarificationReqDate is not null then LatestClarificationsubmtdDate else IstClarificationReqDate end as ClarificationReqDate,Case when  LatestClarificationsubmtdDate is not null then LatestClarificationsubmtdDate else IstClarificationsubmtdDate end as ClarificationSubmitDate,SalesType,MSILShare, SalesCoveringLetterReason as Reason,'SalesCoveringLetterReason' as Reason_Type from MSIL_ISLRMK_CLAIM union All select DealerCodeForCode,NewCarOwnerDMS,NewCarInvoiceNo,NewCarInvoiceDate,NewCarModel,NewCarVin,Status,DealerSubmissionDate,StatusUpdatedDate,ClaimType,case when LatestClarificationReqDate is not null then LatestClarificationsubmtdDate else IstClarificationReqDate end as ClarificationReqDate,Case when  LatestClarificationsubmtdDate is not null then LatestClarificationsubmtdDate else IstClarificationsubmtdDate end as ClarificationSubmitDate,SalesType,MSILShare, NewCarInvoiceReason as Reason,'NewCarInvoiceReason' as Reason_Type from MSIL_ISLRMK_CLAIM ) a Where NewCarInvoiceDate<='2021/03/31'  and status='Clarification Required' and month(newcarinvoicedate)=5  and Reason<>'OK' and reason<>''";
            return ConnModal.FillDataTable(Str);

        }


        public static DataTable MSIL_Claim_Detail(string Status = "", string Region = null, string month = null, string Schemename = null, string Dealercode = null)
        {

            string STR = "";
            var Statusd = Status == "Claim" ? "((CONVERT(decimal(10,2),(case when len((Incentive))>0 then REPLACE((Incentive),',','') else '0'end ))))>0" : "";
            Statusd = Status == "Recd" ? "((CONVERT(decimal(10,2),(case when len((CrAmt))>0 then REPLACE((CrAmt),',','') else '0'end ))))>0" : Statusd;
            Statusd = Status == "Reject" ? "((CONVERT(decimal(10,2),(case when len((Rejected))>0 then REPLACE((Rejected),',','') else '0'end ))))>0" : Statusd;
            Statusd = Status == "Recover" ? "((CONVERT(decimal(10,2),(case when len((Recover))>0 then REPLACE((Recover),',','') else '0'end ))))>0" : Statusd;
            Statusd = Status == "Bal" ? "((CONVERT(decimal(10,2),(case when len((Incentive))>0 then REPLACE((Incentive),',','') else '0'end )))-(CONVERT(decimal(10,2),(case when len((CrAmt))>0 then REPLACE((CrAmt),',','') else '0'end )))-(CONVERT(decimal(10,2),(case when len((Rejected))>0 then REPLACE((Rejected),',','') else '0'end )))-(CONVERT(decimal(10,2),(case when len((Recovered))>0 then REPLACE((Recovered),',','') else '0'end ))))>0" : Statusd;
            STR = Statusd;
            Region = Region.Length > 0 ? " region='" + Region + "'" : "";
            month = month.Length > 0 ? " month(schememonth)=" + month + "" : "";
            Schemename = Schemename.Length > 0 ? " Schemename='" + Schemename + "'" : "";
            Dealercode = Dealercode.Length > 0 ? " Dealercode='" + Dealercode + "'" : "";

            STR = STR + (STR.Length > 0 && Region.Length > 0 ? " and " + Region : "");
            STR = STR + (STR.Length > 0 && month.Length > 0 ? " and " + month : "");
            STR = STR + (STR.Length > 0 && Schemename.Length > 0 ? " and " + Schemename : "");
            STR = STR + (STR.Length > 0 && Dealercode.Length > 0 ? " and " + Dealercode : "");





            string Str = "select MODELCODE,VIN, Schememonth,DealerCode,((CONVERT(decimal(10,2),(case when len((Incentive))>0 then REPLACE((Incentive),',','') else '0'end )))) as Claim,((CONVERT(decimal(10,2),(case when len((CrAmt))>0 then REPLACE((CrAmt),',','') else '0'end )))) as Recd,((CONVERT(decimal(10,2),(case when len((Rejected))>0 then REPLACE((Rejected),',','') else '0'end )))) as Reject,((CONVERT(decimal(10,2),(case when len((Recovered))>0 then REPLACE((Recovered),',','') else '0'end )))) " + STR + "";
            return ConnModal.FillDataTable(Str);
        }

        public static DataTable CashFlowData(string FromDate, string ToDate, string Day, string Multi_Loc)
        {

            DateTime dtdate = (ToDate.ToString()).DateConvertFormat("dd-MMM-yyyy");


            int Year = dtdate.Year;
            int[] Array = { 1, 2, 3 };
            if (Array.Contains(dtdate.Month))
            {
                Year = Year - 1;
            }

            return OtherSqlConn.FillDataTable("Select Ledg_Ac,Ledg_Name,BranchName,sum(openingbalance) as OpeningCash,sum(Contra_Receipt) as ContraReceipt,sum(dms_receipt) as DmsReceipt,sum(other_receipt) as OtherReceipt,sum(Bank_Deposit) BankDeposit,sum(dms_rcpt_cancelled) DmsRcptCancelled,sum(other_payment) as OtherPayment,(isnull( sum(openingbalance),0)+isnull( sum(Contra_Receipt),0)+isnull( sum(dms_receipt),0)+isnull( sum(other_receipt),0)+(isnull( sum(Bank_Deposit),0)+isnull( sum(dms_rcpt_cancelled),0)+isnull( sum(other_payment),0))) as ClosingCash, (SELECT  top 1 isnull(Date_" + Day + ",0) FROM  Cash_Bal where Cash_Bal.Cash_Code=Ledg_Ac and yr=" + Year + " and Mnth=month('" + ToDate + "')) as PhysicalCash,((isnull( sum(openingbalance),0)+isnull( sum(Contra_Receipt),0)+isnull( sum(dms_receipt),0)+isnull( sum(other_receipt),0)+(isnull( sum(Bank_Deposit),0)+isnull( sum(dms_rcpt_cancelled),0)+isnull( sum(other_payment),0)))-isnull((SELECT  top 1 isnull(Date_" + Day + ",0) FROM  Cash_Bal where Cash_Bal.Cash_Code=Ledg_Ac and yr=" + Year.ToString() + " and Mnth=month('" + ToDate + "')),0)) as [Difference] from (select Ledg_Ac,(select top 1 ledg_name from Ledg_Mst where Ledg_Code=Ledg_Ac) as Ledg_Name,Loc_Code,(select top 1 godw_Name from  godown_Mst where Export_Type<3 and godw_COde=x.loc_code) as BranchName,0 as OpeningBalance,sum(Contra_Receipt) as  Contra_Receipt, sum(DMS_Receipt) DMS_Receipt,sum(Other_Receipt) Other_Receipt,sum(Bank_Deposit) Bank_Deposit,sum(DMS_Rcpt_Cancelled) DMS_Rcpt_Cancelled,sum(Other_Payment) Other_Payment, 0 as closingbalance from   (Select Acnt_Id,acnt_date,Acnt_Post.Book_Code,Acnt_Post.Loc_Code,DMS_REF1, Ledg_Name as Ledger,Ledg_Ac,IIf(Amt_DrCr=1,Post_Amt,Post_Amt*-1) as Cl_Bal,Amt_DrCr,Acnt_Type,(case when Acnt_Type=4 and   Amt_DrCr=1 then  IIf(Amt_DrCr=1,Post_Amt,Post_Amt*-1)  else  0 end )  as Contra_Receipt, (case when Acnt_Type=1 and Amt_DrCr=1 and IsNull(DMS_REF1,'')<>'' then  IIf(Amt_DrCr=1,Post_Amt,Post_Amt*-1)  else  0 end )  as DMS_Receipt, (case when Acnt_Type<>4 and Amt_DrCr=1 and IsNull(DMS_REF1,'')='' then  IIf(Amt_DrCr=1,Post_Amt,Post_Amt*-1)  else  0 end )  as Other_Receipt, (case when Acnt_Type=4 and Amt_DrCr=2   then  IIf(Amt_DrCr=1,Post_Amt,Post_Amt*-1)  else  0 end )  as Bank_Deposit, (case when Acnt_Type<>4 and Acnt_Post.Book_Code=17 and Amt_DrCr=2  then  IIf(Amt_DrCr=1,Post_Amt,Post_Amt*-1)  else  0 end )  as DMS_Rcpt_Cancelled, (case when Acnt_Type<>4 and Acnt_Post.Book_Code<>17 and Amt_DrCr=2 then  IIf(Amt_DrCr=1,Post_Amt,Post_Amt*-1)  else  0 end )  as Other_Payment from Acnt_Post,Ledg_Mst where Ledg_Code=Ledg_Ac  AND IsNull(Cash_Flag,0)=1 and acnt_post.export_Type<5  and acnt_date between '" + FromDate + "' and '" + ToDate + "' and   Acnt_Post.loc_code in  (" + Multi_Loc + ")) as x group by x.Ledg_Ac,Loc_Code union all select ledg_Ac,ledg_name,loc_code,(select top 1 godw_Name from  godown_Mst where Export_Type<3 and godw_COde=x.loc_code) as BranchName,sum(Post_Amt) as OpeningBalance,0 as Contra_Receipt,0 as DMS_Receipt,0 as Other_Receipt,0 as Bank_Deposit,0 as DMS_Rcpt_Cancelled,0 as Other_Payment,0 as ClosingBalance from  (select ledg_Ac,ledg_name,Amt_Drcr,acnt_post.loc_code,(case when amt_drcr=1 then post_amt  else -1*post_amt end ) as Post_Amt from acnt_post,ledg_mst where ledg_mst.ledg_Code=Acnt_post.ledg_Ac and ledg_mst.Group_Code=24 and acnt_post.Export_Type<=4 and acnt_Date< '" + FromDate + "' and acnt_post.loc_code in (" + Multi_Loc + ")) as x group by ledg_Ac,ledg_name,loc_code ) as  a group by Ledg_Ac,Ledg_Name,Loc_Code,BranchName");

        }

        public static DataTable MarutiStatement(string Type = null, string Account = null, string CompCode = null)
        {
            string STR = "";
            Type = !String.IsNullOrWhiteSpace(Type) ? " Where  Location like '" + Type + "%'" : "";
            Account = !String.IsNullOrWhiteSpace(Account) ? " Account like '" + Account + "'" : "";
            CompCode = !String.IsNullOrWhiteSpace(CompCode) ? " Compcode = '" + CompCode + "'" : "";


            STR = STR + (Type.Length > 0 ? Type : "");
            STR = STR + (Account.Length > 0 ? Type.Length > 0 ? " and " + Account : " Where " + Account : "");
            STR = STR + (CompCode.Length > 0 ? Type.Length > 0 ? " and " + CompCode : " Where " + CompCode : "");


            string Str = "select Compcode,Location,Account,Sum(Opening) as Opening,Sum(Debit) as Debit,Sum(Credit) as Credit, Sum(Closing) as Closing from (select  Compcode,Location,Account,lag(closing,1,0) over (partition by Location,Account order by Account) opening, Debit, Credit, closing from ( select Compcode,Location,Account,  sum(DebitAmount) debit, sum(CreditAmount) credit, sum(sum(DebitAmount - CreditAmount)) over (partition by Location,Account order by Account) closing from MSIL_Statement  group by Location,Account,CompCode ) t union select compcode,Location,Account,sum(Debitamount-creditamount) as Opening,0 as Debit,0 as Credit,0 as Closing from MSIL_Statement where Type like 'Opening%' group by Location,Account,CompCode) a " + STR + " Group by Location,Account,Compcode";
            return ConnModal.FillDataTable(Str);
        }

        public static DataTable MarutiStatementLocation(string CompCode = null)
        {
            string STR = "";
            CompCode = !String.IsNullOrWhiteSpace(CompCode) ? " Compcode = '" + CompCode + "'" : "";

            STR = STR + (CompCode.Length > 0 ? CompCode : "");

            string Str = "select Distinct Substring(Location,4, Charindex('-', Location)-4) as Location from MSIL_Statement where CompCode='" + STR + "'";
            return ConnModal.FillDataTable(Str);
        }

        public static DataTable MarutiStatementType(string CompCode = null)
        {

            string STR = "";
            CompCode = !String.IsNullOrWhiteSpace(CompCode) ? " Where Compcode = '" + CompCode + "'" : "";

            STR = STR + (CompCode.Length > 0 ? CompCode : "");


            string Str = "select Distinct substring(location,1,3) as Type from MSIL_Statement " + STR + "";
            return ConnModal.FillDataTable(Str);
        }
        public static DataTable MarutiStatementAccount(string Type = null, string CompCode = null)
        {
            string STR = "";
            Type = !String.IsNullOrWhiteSpace(Type) ? " Where  Location like '" + Type + "%'" : "";
            CompCode = SiteSession.LoginUser.Comp_Code != null ? " Compcode = '" + SiteSession.LoginUser.Comp_Code + "'" : "";

            STR = STR + (Type.Length > 0 ? Type : "");
            STR = STR + (CompCode.Length > 0 ? Type.Length > 0 ? " and " + CompCode : " Where " + CompCode : "");

            string Str = "select Distinct Account from MSIL_Statement " + STR + "";
            return ConnModal.FillDataTable(Str);
        }

        public static DataTable MarutiStatementDetail(string Type = null, string Dealercode = null, string Account = null, string Trantype = null, string CompCode = null)
        {
            string STR = "";
            Type = !String.IsNullOrWhiteSpace(Type) ? "  Location like '" + Type + "%'" : "";
            Dealercode = !String.IsNullOrWhiteSpace(Dealercode) ? " Location like '" + Dealercode + "%'" : "";
            Account = !String.IsNullOrWhiteSpace(Account) ? "   Account like '" + Account + "%'" : "";
            Trantype = !String.IsNullOrWhiteSpace(Trantype) ? "   Type like '" + Trantype + "%'" : "";
            CompCode = !String.IsNullOrWhiteSpace(CompCode) ? "   Compcode like '" + CompCode + "%'" : "";


            STR = STR + (Type.Length > 0 ? Type : "");
            STR = STR + (STR.Length > 0 ? (Dealercode.Length > 0 ? " and " + Dealercode : "") : (Dealercode.Length > 0 ? Dealercode : ""));
            STR = STR + (Account.Length > 0 ? " and " + Account : "");
            STR = STR + (Trantype.Length > 0 ? " and " + Trantype : "");
            STR = STR + (CompCode.Length > 0 ? " and " + CompCode : "");
            STR = STR.Length > 0 ? " where " + STR : STR;
            string Str = "select * from MSIL_Statement " + STR + "";
            return ConnModal.FillDataTable(Str);
        }

        public static DataTable MarutiStatementTranType(string CompCode = null)
        {

            string STR = "";
            CompCode = !String.IsNullOrWhiteSpace(CompCode) ? " Where Compcode = '" + CompCode + "'" : "";

            STR = STR + (CompCode.Length > 0 ? CompCode : "");


            string Str = "select distinct type as TranType from MSIL_Statement " + STR + "";
            return ConnModal.FillDataTable(Str);
        }

        public static DataTable DSEBKGMASTER(int Status, string DSE = null, string Loc_Cd = null)
        {
            string STR = "";
            DSE = !String.IsNullOrWhiteSpace(DSE) ? " Where  Ge3='Booked' and Executive like '" + DSE + "%'" : "";
            Loc_Cd = !String.IsNullOrWhiteSpace(Loc_Cd) ? "  Godw_Code in (" + Loc_Cd + ")" : "";
            STR = STR + (DSE.Length > 0 ? DSE : "");
            STR = STR + (Loc_Cd.Length > 0 ? " and " + Loc_Cd : "");
            if (Status == 0)
            {
                string Str = "select * from  (select *,(select COUNT(*) from  BookingApprovalHistory where BookingApprovalHistory.BookingId=Booking.BookingId) as PendingApproval from Booking  " + STR + "  and   isnull(Additional_Discount,0)=0) as x where PendingApproval=0";
                return ConnModal.FillDataTable(Str);
            }
            else 
            {
                string Str = "select * from  (select *,(select top 1 stuff((select ',' + u.EmployeeName from  (select (select (EmployeeName+' ('+( Select Code from Master where Masterid=Designation)+')') as EmployeeName from Employeemaster where Employeemaster.User_Code=BookingApprovalHistory.User_Code) as EmployeeName from  BookingApprovalHistory where BookingApprovalHistory.BookingId=Booking.BookingId and  [Status]="+Status+ ") u for xml path('')),1,1,'')) as Approvername,(select top 1 stuff((select ',' + u.Remark from  (select Remark from  BookingApprovalHistory where BookingApprovalHistory.BookingId=Booking.BookingId and  [Status]=" + Status + ") u for xml path('')),1,1,'')) as ApproverRemark,(select top 1 stuff((select ',' + u.dates from  (select format(Date,'dd/MM/yyyy hh:mm tt') as  dates from  BookingApprovalHistory where BookingApprovalHistory.BookingId=Booking.BookingId and  [Status]=" + Status + ") u for xml path('')),1,1,'')) as ApproverDate,(select top 1 stuff((select ',' + u.EmployeeName from  (select (select (EmployeeName+' ('+( Select Code from Master where Masterid=Designation)+')') as EmployeeName from Employeemaster where Employeemaster.User_Code=BookingApprovalHistory.RequestSendTo) as EmployeeName from  BookingApprovalHistory where BookingApprovalHistory.BookingId=Booking.BookingId and  [Status]=" + Status+") u for xml path('')),1,1,'')) as RequestToname,(select top 1 stuff((select ',' + u.EmployeeName from  (select  convert(nvarchar(30),RequestAmount) as EmployeeName from  BookingApprovalHistory where BookingApprovalHistory.BookingId=Booking.BookingId and  [Status]=" + Status+") u for xml path('')),1,1,'')) as Amount,(select COUNT(*) from  BookingApprovalHistory where BookingApprovalHistory.BookingId=Booking.BookingId and  [Status]=" + Status+") as PendingApproval from Booking    " + STR + " ) as x where PendingApproval>0";
                return ConnModal.FillDataTable(Str);
            }
        }

        public static DataTable DSEBKGMASTERSingleRow(string BookingId)
        {
            string STR = "";
           

            string Str = "select * from Booking   where BookingId="+ BookingId + "";
            return ConnModal.FillDataTable(Str);
        }

        public static DataTable BankFinancerMaster()
        {
            string Str = "select Distinct Misc_name,Misc_code from misc_mst where misc_type=8";
            
            return ConnModal.FillDataTable(Str);
        }
        public static DataTable EWWKS(string Region = null)
        {
            string STR = "";
            Region = !String.IsNullOrWhiteSpace(Region) ? " Where  Range_Name like '" + Region + "'" : "";

            STR = STR + (Region.Length > 0 ? Region : "");

            string Str = "select * from (select Q1.Range_Name,Q1.Tran_month,((CONVERT(decimal(10,2),(case when len((Q1.Region_Retail))>0 then REPLACE((Q1.Region_Retail),',','') else '0'end )))) as Region_Retail, ((CONVERT(decimal(10,2),(case when len((Q1.EW70PERC))>0 then REPLACE((Q1.EW70PERC),',','') else '0'end )))) as EW70PERC, ((CONVERT(decimal(10,2),(case when len((Q1.EW80PERC))>0 then REPLACE((Q1.EW80PERC),',','') else '0'end )))) as EW80PERC, ((CONVERT(decimal(10,2),(case when len((Q2.Ew_Count))>0 then REPLACE((Q2.Ew_Count),',','') else '0'end )))) as EWWKS from (select p1.Range_Name,p1.Tran_month,p1.Retail as Region_Retail,p1.Ew_Count as EW70PERC,p2.Ew_Count as EW80PERC From (select t12.Range_Name,t11.Tran_Month,Sum(t11.Retail) as Retail ,sum(t11.EW_Count) as Ew_Count from (select t1.Loc_Cd,t1.Tran_month,t2.Retail,sum(t1.Ew_Count) as EW_Count from  (select loc_cd,month(CONVERT(datetime,trans_Date)) as Tran_month,ge9,sum(Qty) as EW_Count from ( select *,1 as Qty from gd_Fdi_trans where trans_type='EW' and model_cd not in  ('BA','XL','CI','IG','SS') and   CONVERT(datetime,trans_Date)>='2021/04/01' union All  select *,-1 as Qty from gd_Fdi_trans where trans_type='EWC' and ge9 in ('II','III') and model_cd not in ('BA','XL','CI','IG','SS') and CONVERT(datetime,trans_Date)>='2021/04/01' union all select *,-1 as Qty from gd_Fdi_trans where trans_type='EW' and ge9 in ('II','III') and model_cd not in ('BA','XL','CI','IG','SS') and CONVERT(datetime,trans_Date)>='2021/04/01' and  CONVERT(datetime,trans_Date)<='2021/04/30' and (CONVERT(datetime,trans_ref_date)  between '2020/06/30' and '2021/04/01'))  a group by LOC_CD,month(CONVERT(datetime,trans_Date)),ge9) t1 left join  (select Loc_Cd,month(CONVERT(datetime,trans_Date)) as Tran_month,'' as ge9,sum(Qty) as Retail,0 as EW_Count from (select *,1 as Qty from gd_Fdi_trans where trans_type='VS' and model_cd not in ('BA','XL','CI','IG','SS') and   CONVERT(datetime,trans_Date)>='2021/04/01' union All  select *,-1 as Qty from gd_Fdi_trans where trans_type='VC' and model_cd not in ('BA','XL','CI','IG','SS') and   CONVERT(datetime,trans_Date)>='2021/04/01' ) a group by Loc_Cd,month(CONVERT(datetime,trans_Date))) t2 on t1.LOC_CD=t2.LOC_CD and t1.Tran_month=t2.Tran_month group by  t1.Loc_Cd,t1.Tran_month,Retail ) t11 left join (Select newCar_rcpt,range_name from godown_mst where newcar_rcpt is not null) t12 on t11.LOC_CD=t12.NEWCAR_RCPT group by t12.Range_Name,t11.Tran_month ) P1 left Join (select t12.Range_Name,t11.Tran_Month,Sum(t11.Retail) as Retail ,sum(t11.EW_Count) as Ew_Count from (select t1.Loc_Cd,t1.Tran_month,t2.Retail,sum(t1.Ew_Count) as EW_Count from  (select loc_cd,month(CONVERT(datetime,trans_Date)) as Tran_month,ge9,sum(Qty) as EW_Count from ( select *,1 as Qty from gd_Fdi_trans where trans_type='EW' and  model_cd not in  ('BA','XL','CI','IG','SS') and   CONVERT(datetime,trans_Date)>='2021/04/01' union All  select *,-1 as Qty from gd_Fdi_trans where trans_type='EWC' and  ge9 in ('II','III') and model_cd not in ('BA','XL','CI','IG','SS') and CONVERT(datetime,trans_Date)>='2021/04/01' union all select *,-1 as Qty from gd_Fdi_trans where  trans_type='EW' and ge9 in ('II','III') and model_cd not in ('BA','XL','CI','IG','SS') and CONVERT(datetime,trans_Date)>='2021/04/01' and   CONVERT(datetime,trans_Date)<='2021/04/30' and loc_cd in (select distinct loc_cd from gd_Fdi_trans where trans_type='Wi') ) a group by LOC_CD, month(CONVERT(datetime,trans_Date)),ge9) t1 left join  (select Loc_Cd,month(CONVERT(datetime,trans_Date)) as Tran_month,'' as ge9,sum(Qty) as Retail,0 as EW_Count  from (select *,1 as Qty from gd_Fdi_trans where trans_type='VS' and model_cd not in ('BA','XL','CI','IG','SS') and   CONVERT(datetime,trans_Date)>='2021/04/01'  union All  select *,-1 as Qty from gd_Fdi_trans where trans_type='VC' and model_cd not in ('BA','XL','CI','IG','SS') and   CONVERT(datetime,trans_Date)>='2021/04/01' ) a  group by Loc_Cd,month(CONVERT(datetime,trans_Date))) t2 on t1.LOC_CD=t2.LOC_CD and t1.Tran_month=t2.Tran_month group by  t1.Loc_Cd,t1.Tran_month,Retail ) t11 left join  (Select newCar_rcpt,range_name from godown_mst where newcar_rcpt is not null) t12 on t11.LOC_CD=t12.NEWCAR_RCPT group by t12.Range_Name,t11.Tran_month ) P2 on p1.Range_Name=p2.Range_Name and p1.Tran_month=p2.Tran_month) Q1 left join (select t111.Range_Name,t111.Tran_month,t112.Retail,t111.Ew_Count from (select t12.Range_Name,t11.Tran_Month,sum(t11.EW_Count) as Ew_Count from (select loc_cd,month(CONVERT(datetime,trans_Date)) as Tran_month,ge9,sum(Qty) as EW_Count from ( select *,1 as Qty from gd_Fdi_trans where trans_type='EW' and  model_cd not  in  ('BA','XL','CI','IG','SS') and   CONVERT(datetime,trans_Date)>='2021/05/01' and CONVERT(datetime,TRANS_REF_DATE)<'2021/04/01' and loc_cd  in (Select distinct loc_cd from gd_Fdi_trans where trans_type='WI') union All   select *,-1 as Qty from gd_Fdi_trans where trans_type='EWC' and ge9 in ('II','III') and model_cd not in ('BA','XL','CI','IG','SS') and  CONVERT(datetime,trans_Date)>='2021/05/01' and CONVERT(datetime,TRANS_REF_DATE)<'2021/04/01' and  loc_cd  in (Select distinct loc_cd from gd_Fdi_trans where trans_type='WI') ) a group by LOC_CD,  month(CONVERT(datetime,trans_Date)),ge9 ) t11 left join   (Select newCar_rcpt,range_name from godown_mst where newcar_rcpt is not null) t12 on t11.LOC_CD=t12.NEWCAR_RCPT group by t12.Range_Name,t11.Tran_month ) t111 left join  (select t2.Range_name,t1.tran_month,Sum(t1.Retail) as Retail from (select Loc_Cd,month(CONVERT(datetime,trans_Date)) as Tran_month,sum(Qty) as Retail from ( select *,1 as Qty from gd_Fdi_trans where trans_type='VS' and model_cd not in ('BA','XL','CI','IG','SS') and   CONVERT(datetime,trans_Date)>='2021/05/01'  union All  select *,-1 as Qty from gd_Fdi_trans where trans_type='VC' and model_cd not in ('BA','XL','CI','IG','SS') and   CONVERT(datetime,trans_Date)>='2021/05/01' ) a  group by loc_cd,month(CONVERT(datetime,trans_Date)) ) t1 left join (Select newCar_rcpt,range_name from godown_mst where newcar_rcpt is not null) t2 on t1.LOC_CD=t2.NEWCAR_RCPT group by t2.Range_Name,t1.Tran_month) t112 on t111.Range_Name=t112.Range_Name and t111.Tran_month=t112.Tran_month) q2 on q1.Range_Name=q2.Range_Name and q1.Tran_month=q2.Tran_month ) e1" + STR + "";
            return OtherSqlConn.FillDataTable(Str);
        }
        public static DataTable BSC_SSRData(string Region = null)
        {
            string STR = "";
            Region = !String.IsNullOrWhiteSpace(Region) ? " Where Region like '" + Region + "'" : "";

            STR = STR + (Region.Length > 0 ? Region : "");

            string Str = "Select Region,Month,Base_Data,TGT055,TGT045,TGT035,PMS_DONE,BAL055,BAL045,BAL035 from (Select t1.srno,t1.Region,T1.Month,t1.Base_Data,convert(int,((CONVERT(decimal(10,2),(case when len(t1.Base_Data)>0 then REPLACE(t1.Base_Data,',','') else '0'end ))*0.55))) as TGT055, convert(int,((CONVERT(decimal(10,2),(case when len(t1.Base_Data)>0 then REPLACE(t1.Base_Data,',','') else '0'end ))*0.45))) as TGT045, convert(int,((CONVERT(decimal(10,2),(case when len(t1.Base_Data)>0 then REPLACE(t1.Base_Data,',','') else '0'end ))*0.35))) as TGT035, CONVERT(decimal(10,2),(case when len(T2.PMS_Count)>0 then REPLACE(T2.PMS_Count,',','') else '0'end )) as PMS_DONE, (convert(int,((CONVERT(decimal(10,2),(case when len(t1.Base_Data)>0 then REPLACE(t1.Base_Data,',','') else '0'end ))*0.55)))-CONVERT(decimal(10,2),(case when len(T2.PMS_Count)>0 then REPLACE(T2.PMS_Count,',','') else '0'end ))) as BAL055, (convert(int,((CONVERT(decimal(10,2),(case when len(t1.Base_Data)>0 then REPLACE(t1.Base_Data,',','') else '0'end ))*0.45)))-CONVERT(decimal(10,2),(case when len(T2.PMS_Count)>0 then REPLACE(T2.PMS_Count,',','') else '0'end ))) as BAL045, (convert(int,((CONVERT(decimal(10,2),(case when len(t1.Base_Data)>0 then REPLACE(t1.Base_Data,',','') else '0'end ))*0.35)))-CONVERT(decimal(10,2),(case when len(T2.PMS_Count)>0 then REPLACE(T2.PMS_Count,',','') else '0'end ))) as BAL035 from (select Outlet1 as Region, case when month(invdt)=4  then 1 	 when month(invdt)=5  then 2 	 when month(invdt)=6  then 3 	 when month(invdt)=7  then 4 	 when month(invdt)=8  then 5 	 when month(invdt)=9  then 6 	 when month(invdt)=10  then 7 	 when month(invdt)=11 then 8 	 when month(invdt)=12  then 9 	 when month(invdt)=1  then 10 	 when month(invdt)=2  then 11 	 when month(invdt)=3  then 12 end as SRNO, case when month(invdt)=4  then 'APR'  	 when month(invdt)=5  then 'MAY'  	 when month(invdt)=6  then 'JUN'  	 when month(invdt)=7  then 'JUL'  	 when month(invdt)=8  then 'AUG'  	 when month(invdt)=9  then 'SEP'  	 when month(invdt)=10  then 'OCT'  	 when month(invdt)=11 then 'NOV'  	 when month(invdt)=12  then 'DEC'  	 when month(invdt)=1  then 'JAN'  	 when month(invdt)=2  then 'FEB'  	 when month(invdt)=3  then 'MAR' end as Month,count(invdt) as Base_Data from BSC_Sale_BASE1219  where status='Invoiced' group by outlet1,month(invdt) ) t1 left join (select Region as Region,servicefinancialmonth as Month, sum(CONVERT(decimal(10,2),(case when len(bscbillvalue2000)>0 then REPLACE(bscbillvalue2000,',','') else '0'end ))) as PMS_Count   from service_Performance where  servicefinancialyear='2021-22' and Servicetypecode='PMS' group by region,servicefinancialmonth ) t2 on t1.Region=t2.Region and upper(t1.Month)=upper(t2.Month) ) T3 " + STR + " order by Region,srno";
            return ConnModal.FillDataTable(Str);
        }

        public static DataTable BSC_PMSGROWTH(string Region = null)
        {
            string STR = "";
            Region = !String.IsNullOrWhiteSpace(Region) ? " Where Region like '" + Region + "'" : "";

            STR = STR + (Region.Length > 0 ? Region : "");

            string Str = "select Region, sum(pms_count2021) as PMS_2021,sum(PMS_Count2122) as PMS_2122 from(select Region, convert(int, (sum(CONVERT(decimal(10,2),(case when len(Serviceload)>0 then REPLACE(Serviceload,',','') else '0'end ))))/8) as PMS_Count2021,0 as PMS_COUNT2122 from service_performance where servicefinancialyear='2020-21' and Servicetypecode = 'PMS' and Servicefinancialmonth in ('AUG','SEP','OCT','NOV','DEC','JAN''FEB','MAR') Group by Region union all select Region,0 as PMS_Count2021,convert(int, (sum(CONVERT(decimal(10,2),(case when len(Serviceload)>0 then REPLACE(Serviceload,',','') else '0'end )))/(select count(distinct servicefinancialmonth) from service_performance where servicefinancialyear='2021-22'))) as PMS_Count2122 from service_performance where servicefinancialyear='2021-22' and Servicetypecode = 'PMS'  Group by Region) t1 " + STR + " group by Region";
            return ConnModal.FillDataTable(Str);
        }


        public static DataTable Service_Performance(string Region = null, string DealerCode = null, string SerType = null)
        {
            string STR = "";
            string ServHold = "";

            if (SerType == "FREE")
            {
                ServHold = "'FR1','FR2','FR3','FR4'";
            }
            else if (SerType == "PAID")
            {
                ServHold = "'PMS'";
            }
            else if (SerType == "RUNNING")
            {
                ServHold = "'RR'";
            }
            else if (SerType == "OTHER")
            {
                ServHold = "'ACC',	'BDW',	'REFF',	'RJ',	'SC',	'TV1',	'TV2',	'TV3',	'WASH',	'WMOS'";
            }
            else if (SerType == "BODYSHOP")
            {
                ServHold = "'BANDP'";
            }

            Region = !String.IsNullOrWhiteSpace(Region) ? " Where Region like '" + Region + "'" : "";
            SerType = !String.IsNullOrWhiteSpace(ServHold) ? " ServiceTypeCode in (" + ServHold + ")" : "";
            DealerCode = !String.IsNullOrWhiteSpace(DealerCode) ? " LocationCode in ('" + DealerCode + "')" : "";



            STR = STR + (Region.Length > 0 ? Region : "");
            STR = STR + (SerType.Length > 0 ? " and " + SerType : "");
            STR = STR + (DealerCode.Length > 0 ? " and " + DealerCode : "");


            string Str = "select p11.srno, p11.month, p11.load1920, p11.Load2021,p11.Load2122, p12.LAB1920, p12.LAB2021, p12.LAB2122, p12.PART1920, p12.PART2021, p12.PART2122 from (select SRNO, MONTH, Load1920, Load2021, Load2122 from (SELECT case when servicefinancialmonth = 'APR' then 1 			when servicefinancialmonth = 'MAY' then 2 			when servicefinancialmonth = 'JUN' then 3 			when servicefinancialmonth = 'JUL' then 4 			when servicefinancialmonth = 'AUG' then 5 			when servicefinancialmonth = 'SEP' then 6 			when servicefinancialmonth = 'OCT' then 7 			when servicefinancialmonth = 'NOV' then 8 			when servicefinancialmonth = 'DEC' then 9 			when servicefinancialmonth = 'JAN' then 10 			when servicefinancialmonth = 'FEB' then 11 			when servicefinancialmonth = 'MAR' then 12 end as SRNO, servicefinancialmonth as Month, Convert(int, CONVERT(decimal(10,2),(case when len([2019-20])>0 then REPLACE([2019-20],',','') else '0'end ))) Load1920,  Convert(int, CONVERT(decimal(10,2),(case when len([2020-21])>0 then REPLACE([2020-21],',','') else '0'end ))) Load2021,  Convert(int, CONVERT(decimal(10,2),(case when len([2021-22])>0 then REPLACE([2021-22],',','') else '0'end ))) Load2122 FROM(SELECT servicefinancialmonth, Servicefinancialyear, Serviceload FROM service_performance " + STR + ") AS SourceTable    PIVOT(SUM(Serviceload) FOR Servicefinancialyear IN ([2019-20], [2020-21], [2021-22])   ) AS PivotTable ) t1 ) P11 left join(select t11.SRNO, t11.month, t11.LAB1920, t11.LAB2021, t11.LAB2122, t12.PART1920, t12.PART2021, t12.PART2122 from (select SRNO, MONTH, LAB1920, LAB2021, LAB2122 from (SELECT case when servicefinancialmonth = 'APR' then 1 			when servicefinancialmonth = 'MAY' then 2 			when servicefinancialmonth = 'JUN' then 3 			when servicefinancialmonth = 'JUL' then 4 			when servicefinancialmonth = 'AUG' then 5 			when servicefinancialmonth = 'SEP' then 6 			when servicefinancialmonth = 'OCT' then 7 			when servicefinancialmonth = 'NOV' then 8  			when servicefinancialmonth = 'DEC' then 9  			when servicefinancialmonth = 'JAN' then 10  			when servicefinancialmonth = 'FEB' then 11 			when servicefinancialmonth = 'MAR' then 12 end as SRNO, servicefinancialmonth as Month, Convert(int, CONVERT(decimal(10,2),(case when len([2019-20])>0 then REPLACE([2019-20],',','') else '0'end ))) LAB1920,   Convert(int, CONVERT(decimal(10,2),(case when len([2020-21])>0 then REPLACE([2020-21],',','') else '0'end ))) LAB2021,  Convert(int, CONVERT(decimal(10,2),(case when len([2021-22])>0 then REPLACE([2021-22],',','') else '0'end ))) LAB2122 FROM(SELECT servicefinancialmonth, Servicefinancialyear, labouramountwithoutgst FROM service_performance " + STR + ") AS SourceTable    PIVOT(SUM(labouramountwithoutgst) FOR Servicefinancialyear IN ([2019-20], [2020-21], [2021-22])   ) AS PivotTable ) t1 ) t11 left join(select SRNO, MONTH, PART1920, PART2021, PART2122 from (SELECT case when servicefinancialmonth = 'APR' then 1 			when servicefinancialmonth = 'MAY' then 2 			when servicefinancialmonth = 'JUN' then 3 			when servicefinancialmonth = 'JUL' then 4 			when servicefinancialmonth = 'AUG' then 5 			when servicefinancialmonth = 'SEP' then 6 			when servicefinancialmonth = 'OCT' then 7 			when servicefinancialmonth = 'NOV' then 8 			when servicefinancialmonth = 'DEC' then 9 			when servicefinancialmonth = 'JAN' then 10 			when servicefinancialmonth = 'FEB' then 11 			when servicefinancialmonth = 'MAR' then 12 end as SRNO, servicefinancialmonth as Month, Convert(int, CONVERT(decimal(10,2),(case when len([2019-20])>0 then REPLACE([2019-20],',','') else '0'end ))) PART1920, Convert(int, CONVERT(decimal(10,2),(case when len([2020-21])>0 then REPLACE([2020-21],',','') else '0'end ))) PART2021,  Convert(int, CONVERT(decimal(10,2),(case when len([2021-22])>0 then REPLACE([2021-22],',','') else '0'end ))) PART2122 FROM(SELECT servicefinancialmonth, Servicefinancialyear, TotalamountwithoutGST FROM service_performance " + STR + ") AS SourceTable   PIVOT(SUM(TotalamountwithoutGST) FOR Servicefinancialyear IN ([2019-20], [2020-21], [2021-22])    ) AS PivotTable ) t1 ) t12 on t11.month=t12.Month) p12 on p11.month=p12.month order by p11.srno";

            return ConnModal.FillDataTable(Str);
        }

        public static DataTable Service_Location(string Region = null)
        {
            string STR = "";
            Region = !String.IsNullOrWhiteSpace(Region) ? " Where Region like '" + Region + "'" : "";

            STR = STR + (Region.Length > 0 ? Region : "");

            string Str = "select Distinct Locationcode from service_performance " + STR + "";
            return ConnModal.FillDataTable(Str);
        }

        public static DataTable CashBack_Summary(string Region = null, string SchemeMonth = null)
        {
            string STR = "";
            Region = !String.IsNullOrWhiteSpace(Region) ? " Where Region like '" + Region + "'" : "";

            STR = STR + (Region.Length > 0 ? Region : "");

            string Str = "select t111.*, t112.NonOMS,0 as POS,0 as IIFN from (select t11.*, t12.FV, t12.FN, t12.UP from (select t2.*, t1.WS from (select CompCode, Region, Channel, sum(CONVERT(decimal(10, 2),MontTgt)) as WSTgt,  Ceiling((sum(CONVERT(decimal(10, 2),MontTgt))*Max(CONVERT(decimal(10, 2),Slab1)))/100) as Slab1, Ceiling((sum(CONVERT(decimal(10, 2),MontTgt))*Max(CONVERT(decimal(10, 2),Slab2)))/100) as Slab2, Ceiling((sum(CONVERT(decimal(10, 2),MontTgt))*Max(CONVERT(decimal(10, 2),Slab3)))/100) as Slab3, Ceiling((sum(CONVERT(decimal(10, 2),MontTgt))*Max(CONVERT(decimal(10, 2),Slab4)))/100) as Slab4 from Scheme_target where Schememonth='2021/05/01' and Schemename = 'CASH-BACK'  group by Region,Channel,CompCode) t2 left join(select CompCode, Godown_Mst.Range_name, Godown_Mst.Div_name, count(Delr) as WS from extranetdispatch, Godown_Mst where  BR_EXTRANET= (extranetdispatch.DELR + '-' + extranetdispatch.CITY) and INVOICEDATE>='2021/04/01'  group by Godown_Mst.Range_Name, Godown_Mst.Div_name, CompCode ) t1 on t1.Range_Name=t2.Region and t1.Div_Name=t2.channel) t11 left join(SELECT Compcode, Range_Name, Div_Name, [Funds Needed] as FN , [Under Planning] as UP, [Fund Validated] as FV FROM (select CompCode, Godown_Mst.Range_name, Godown_Mst.Div_name, pending_indent.Status, sum(convert(int, pending_indent.Quantity)) as Pending_Indent from pending_indent, Godown_Mst where  BR_EXTRANET= (pending_indent.DEALER+'-'+pending_indent.FORCODE) group by compcode,Godown_Mst.Range_name,Godown_Mst.Div_name,pending_indent.Status) a PIVOT(sum(Pending_indent) FOR Status IN ([Funds Needed],[Under Planning],[Fund Validated])  ) AS P1) t12 on t11.Region=t12.Range_Name and t11.Channel=t12.Div_Name) t111 left join(select CompCode, Godown_Mst.Range_name, Godown_Mst.Div_name, count(BKGDELR) as NonOMS from nonoms_indent, godown_mst where  BR_EXTRANET= (nonoms_indent.BKGDELR + '-' + nonoms_indent.BKGFOR) group by compcode, Godown_Mst.Range_name, Godown_Mst.Div_name) t112 on t111.Region=t112.Range_Name and t111.Channel=t112.Div_Name";
            return ConnModal.FillDataTable(Str);
        }

        public static DataTable Daily_Fund_Balance(string Type = null)
        {
            string STR = "";
            Type = !String.IsNullOrWhiteSpace(Type) ? " Where Location like '" + Type + "%'" : "";

            STR = STR + (Type.Length > 0 ? Type : "");

            string Str = "Select * from (select Location,sum([05D5516]) as [CASHS],Sum([05D5519]) as [CashF], sum([05D5516])+sum([05D5519]) as [TOTALSF] from (SELECT Location,[05D5516],[05D5519]  FROM (select t11.*,ISNULL(t12.Current_mont_balance, 0 ) as Current_Month_Balance,isnull(Convert(decimal(10,2),t11.closing_bal),0)+isnull(Convert(decimal(10,2),t12.Current_mont_balance),0) as Live_Closing_Bal from (Select t1.*,t2.Last_Statement_Date from (select Account,Location, sum(convert(decimal(10,2),Debitamount)-convert(decimal(10,2),Creditamount)) as Closing_Bal  from MSIL_Statement where account in ('05D5516','05D5519')  and Location Like'VCF%' Group by Location,Account) t1 Left Join  (select location,Max(Statementmonth) as Last_Statement_Date from MSIL_Statement  Group by Location) t2 on t1.Location=t2.Location ) t11 left join  (select 'VCF'+Delr+'-'+[For] as Location,Account as Account, sum(Convert(Decimal(10,2),AmountRs))  as Current_mont_balance  from MSIL_Dail_Sale_Statement group by Delr,[For],Account) t12 on t11.Location=t12.Location and t11.Account=t12.account)  a PIVOT  (   Sum(Closing_Bal)    FOR Account IN ([05D5516],[05D5519])  ) AS P1 ) a1 group by Location Union All select t11.Location,isnull(Convert(decimal(10,2),t11.closing_bal),0)+isnull(Convert(decimal(10,2),t12.Current_mont_balance),0) as CashS,0 as CashF,isnull(Convert(decimal(10,2),t11.closing_bal),0)+isnull(Convert(decimal(10,2),t12.Current_mont_balance),0) as TotalSF from (Select t1.*,t2.Last_Statement_Date from (select SUBSTRING(Location, 1, CHARINDEX('-', Location)-1) as Location,sum(convert(decimal(10,2),Debitamount)-convert(decimal(10,2),Creditamount)) as Closing_Bal  from MSIL_Statement where account in ('05D5508') and Location Like'DDL%' Group by Location) t1 Left Join  (select SUBSTRING(Location, 1, CHARINDEX('-', Location)-1) as Location,Max(Statementmonth) as Last_Statement_Date from MSIL_Statement Group by Location) t2 on t1.Location=t2.Location ) t11 left join  (select DealerCode as Location,(sum(Convert(Decimal(10,2),Debit))+sum(Convert(Decimal(10,2),Credit)))  as Current_mont_balance  from msil_daily_service_statement  group by DealerCode) t12 on t11.Location=t12.Location ) a " + STR + "";
            return ConnModal.FillDataTable(Str);
        }
        public static DataTable EmployeeKRA(string JobTitle = null)
        {
            string STR = "";
            String CompCode = "";
            JobTitle = !String.IsNullOrWhiteSpace(JobTitle) ? "  Jobtitle  like '" + JobTitle + "%'" : "";
            CompCode = SiteSession.LoginUser.Comp_Code != null ? " Compcode = '" + SiteSession.LoginUser.Comp_Code + "'" : "";

            STR = STR + (JobTitle.Length > 0 ? "Where" + JobTitle : "");
            STR = STR + (STR.Length > 0 ? (CompCode.Length > 0 ? " and " + CompCode : "") : "Where" + (CompCode.Length > 0 ? CompCode : ""));
            
            string Str = "select * from EmployeeKRA " + STR + "";
            return ConnModal.FillDataTable(Str);
        }

        public static DataTable FundRequirement(string Region = null, string dealercode = null)
        {
            string STR = "";
            String CompCode = "";
            Region = !String.IsNullOrWhiteSpace(Region) ? "  Region  like '" + Region + "%'" : "";
            dealercode = !String.IsNullOrWhiteSpace(dealercode) ? "  Q111.dealercode  like '" + dealercode + "%'" : "";

            CompCode = SiteSession.LoginUser.Comp_Code != null ? " Compcode = '" + SiteSession.LoginUser.Comp_Code + "'" : "";

            STR = STR + (Region.Length > 0 ? "Where" + Region : "");
            STR = STR + (STR.Length > 0 ? (CompCode.Length > 0 ? " and " + CompCode : "") : "Where" + (CompCode.Length > 0 ? CompCode : ""));
            STR = STR + (STR.Length > 0 ? (dealercode.Length > 0 ? " and " + dealercode : "") : "Where" + (dealercode.Length > 0 ? dealercode : ""));

            string Str = "select Q111.*,isnull(Q112.Sale_Since_Apr20, 0) as Sale_Since_Apr20 from(select p111.*, isnull(p112.Stock_Qty, 0) as Current_Stock from(select t111.Region, t111.compcode, t111.Dealercode, t111.Model, T111.Variant_Desc, T111.Color, T111.Ecolor_Desc, isnull(t112.Pending_Booking, 0) as Pending_booking, t111.Fund_Needed_Indent, t111.Fund_Requirement from(select p2.Region, p2.compcode, P2.Dealercode, p2.Model, p2.Color, p3.Variant_desc, p3.Ecolor_Desc, p2.Fund_Needed_Indent, p2.Fund_Requirement from(select Region, CompCode, Dealercode, Model, Color, Sum(convert(int, Quantity)) as Fund_Needed_Indent, Sum(convert(decimal(10, 2), Fund_Required)) as Fund_Requirement from(select t1.dEALER + '-' + t1.FORCODE AS Dealercode, t1.Model, T1.Color, T1.IndentDate, T1.IndentNumber, t1.Quantity, t1.Region, t1.CompCode, t2.Fund_Required from(select *, (select top 1 Range_name from godown_mst where BR_DMDT like Dealer + '%') as Region  from pending_indent where status = 'FUNDS NEEDED') t1 left join(select Delr, modelcode, max(invoicedate) as Last_Purchase_Date, max(invoiceamtrs) as Fund_Required from extranetdispatch group by Delr, modelcode) t2  on t1.dealer = t2.DELR and  t1.model = t2.MODELCODE) T11 group by Dealercode, Model, Color, CompCode, Region) p2 left join(select variant_cd + '00' as Model, Variant_desc, Ecolor_cd, Ecolor_Desc from model_variant_master) p3 on p2.model = p3.model  and p2.color = p3.ecolor_Cd) t111   left join(select  Dealercode, variantcode + '00' as Variantcode, (select top 1 ecolor_cd from model_variant_master where ecolor_desc = color) as Color_Cd, Color, count(variantcode) as Pending_Booking from BI_Pending_Booking_Register group by dealercode, variantcode, color) t112 on t111.dealercode = t112.DealerCode and t111.model = t112.Variantcode and t111.color = t112.Color_Cd) P111 left join(select dealercode, variantcode + '00' as variantcode, (select top 1 ecolor_cd from model_variant_master where ECOLOR_DESC = color) as Color_Cd,count(variantcode) as Stock_Qty from BI_NewCarStock  group by dealercode,variantcode,color) p112 on p111.Dealercode = p112.DealerCode and p111.Model = p112.variantcode and p111.Color = p112.Color_Cd) q111 left join(select dealercode, variantcode + '00' as Variantcode, ColorCode, count(variantcode) as Sale_Since_Apr20  from BI_New_Car_Sale_Register where STATUS <> 'C' and  invoicedate >= '2020/04/01'  group by dealercode, variantcode, ColorCode) q112 on q111.Dealercode = q112.DealerCode and q111.model = q112.Variantcode and q111.Color = q112.ColorCode " + STR + " order by Q111.Dealercode ";
            return ConnModal.FillDataTable(Str);
        }

        public static DataTable DiscountAnalysis(string Region = null, string dealercode = null)
        {
            string STR = "";
            String CompCode = "";
            Region = !String.IsNullOrWhiteSpace(Region) ? "  Region  like '" + Region + "%'" : "";
            dealercode = !String.IsNullOrWhiteSpace(dealercode) ? "  Locationcode  like '" + dealercode + "%'" : "";

            CompCode = SiteSession.LoginUser.Comp_Code != null ? " Compcode = '" + SiteSession.LoginUser.Comp_Code + "'" : "";

            STR = STR + (Region.Length > 0 ? "Where" + Region : "");
            STR = STR + (STR.Length > 0 ? (CompCode.Length > 0 ? " and " + CompCode : "") : "Where" + (CompCode.Length > 0 ? CompCode : ""));
            STR = STR + (STR.Length > 0 ? (dealercode.Length > 0 ? " and " + dealercode : "") : "Where" + (dealercode.Length > 0 ? dealercode : ""));

            string Str = "select Compcode, Region, Locationcode, Case when Month(invdt)= 4 then 'APR' when Month(invdt)= 5 then 'MAY'   when Month(invdt)= 6 then 'JUN'      when Month(invdt)= 7 then 'JUL'      when Month(invdt)= 8 then 'AUG'      when Month(invdt)= 9 then 'SEP'      when Month(invdt)= 10 then 'OCT'     when Month(invdt)= 11 then 'NOV'     when Month(invdt)= 12 then 'DEC'     when Month(invdt)= 1 then 'JAN'      when Month(invdt)= 2 then 'FEB'      when Month(invdt)= 3 then 'MAR' end as Sale_Month,Case when Month(invdt) = 4 then 1 when Month(invdt)= 5 then 2     when Month(invdt)= 6 then 3      when Month(invdt)= 7 then 4      when Month(invdt)= 8 then 5      when Month(invdt)= 9 then 6      when Month(invdt)= 10 then 7     when Month(invdt)= 11 then 8     when Month(invdt)= 12 then 9     when Month(invdt)= 1 then 10     when Month(invdt)= 2 then 11     when Month(invdt)= 3 then 12 end as SrNo,count(Locationcode) as Sale,sum(additional_Discount) as Additional_Discount,sum(additional_Discount) / count(Locationcode) as Per_Veh_Disc from(select Compcode, Region, Saletype, Locationcode, Customerid, CustomerName, DSE, TeamLead, MINAME, MIDATE, Variantcd, dateofmanufacturing, InvNo, Invdt, isnull(convert(int, (round(ExchangeLoyaltyBonusDiscount * ((CONVERT(decimal(10, 2), CESS) + CONVERT(decimal(10, 2), CGS) + CONVERT(decimal(10, 2), SGS) + CONVERT(decimal(10, 2), IGS) + 100) / 100), 0))), 0) as Exchange_Offer, isnull(convert(int, (round(DiscountforCorpInstitutionalCustomer * ((CONVERT(decimal(10, 2), CESS) + CONVERT(decimal(10, 2), CGS) + CONVERT(decimal(10, 2), SGS) + CONVERT(decimal(10, 2), IGS) + 100) / 100), 0))), 0) as Corporate_Offer, isnull(convert(int, (round(Discount * ((CONVERT(decimal(10, 2), CESS) + CONVERT(decimal(10, 2), CGS) + CONVERT(decimal(10, 2), SGS) + CONVERT(decimal(10, 2), IGS) + 100) / 100), 0))), 0) as Club_Consumer_Offer, isnull((select TOTDISC from CONS_DISC where OFFERTYPE = 0 and month(OFFERMONTH) = month(invdt) and MODELID = Variantcd and region = New_Car_Sale_Register.region), 0) as MSIL_Consumer_Offer,isnull((select TOTDISC from CONS_DISC where OFFERTYPE = 1 and month(OFFERMONTH) = month(invdt) and MODELID = Variantcd and region = New_Car_Sale_Register.region),0) as MSIL_RIPS1_Offer,isnull((select TOTDISC from CONS_DISC where OFFERTYPE = 2 and month(OFFERMONTH) = month(invdt) and MODELID = Variantcd and region = New_Car_Sale_Register.region),0) as MSIL_RIPS2_Offer,isnull((select TOTDISC from CONS_DISC where OFFERTYPE = 3 and month(OFFERMONTH) = month(invdt) and MODELID = Variantcd and region = New_Car_Sale_Register.region),0) as MSIL_RIPS3_Offer,isnull(convert(int, (round(MSSFdiscount * ((CONVERT(decimal(10, 2), CESS) + CONVERT(decimal(10, 2), CGS) + CONVERT(decimal(10, 2), SGS) + CONVERT(decimal(10, 2), IGS) + 100) / 100), 0))), 0) as MSSF_discount,isnull(convert(int, (round(SpecialSchemesDiscount * ((CONVERT(decimal(10, 2), CESS) + CONVERT(decimal(10, 2), CGS) + CONVERT(decimal(10, 2), SGS) + CONVERT(decimal(10, 2), IGS) + 100) / 100), 0))), 0) as Additional_discount,(isnull(convert(int, (round(Discount * ((CONVERT(decimal(10, 2), CESS) + CONVERT(decimal(10, 2), CGS) + CONVERT(decimal(10, 2), SGS) + CONVERT(decimal(10, 2), IGS) + 100) / 100), 0))), 0) - (isnull((select TOTDISC from CONS_DISC where OFFERTYPE = 0 and month(OFFERMONTH) = month(invdt) and MODELID = Variantcd and region = New_Car_Sale_Register.region), 0) + isnull((select TOTDISC from CONS_DISC where OFFERTYPE = 1 and month(OFFERMONTH) = month(invdt) and MODELID = Variantcd and region = New_Car_Sale_Register.region), 0)++isnull(convert(int, (round(MSSFdiscount * ((CONVERT(decimal(10, 2), CESS) + CONVERT(decimal(10, 2), CGS) + CONVERT(decimal(10, 2), SGS) + CONVERT(decimal(10, 2), IGS) + 100) / 100), 0))), 0) + isnull((select TOTDISC from CONS_DISC where OFFERTYPE = 2 and month(OFFERMONTH) = month(invdt) and MODELID = Variantcd and region = New_Car_Sale_Register.region),0)+isnull((select TOTDISC from CONS_DISC where OFFERTYPE = 3 and month(OFFERMONTH) = month(invdt) and MODELID = Variantcd and region = New_Car_Sale_Register.region),0))) as Offer_Difference from New_Car_Sale_Register where canceldate is null and cONVERT(decimal(10, 2), Discount) > 0 ) a " + STR + " group by  compcode,Month(invdt),Region,Locationcode order by region, locationcode, SrNo";
            return ConnModal.FillDataTable(Str);
        }


        public static DataTable Pending_Booking(string Region = null, string dealercode = null, string DSEMSPIN = null)
        {
            string STR = "";
            String CompCode = "";
            Region = !String.IsNullOrWhiteSpace(Region) ? "  Region  like '" + Region + "%'" : "";
            dealercode = !String.IsNullOrWhiteSpace(dealercode) ? "  Locationcode  like '" + dealercode + "%'" : "";
            DSEMSPIN = !String.IsNullOrWhiteSpace(DSEMSPIN) ? "  Executive  like '" + DSEMSPIN + "%'" : "";

            CompCode = SiteSession.LoginUser.Comp_Code != null ? " Compcode = '" + SiteSession.LoginUser.Comp_Code + "'" : "";

            STR = STR + (Region.Length > 0 ? "Where" + Region : "");
            STR = STR + (STR.Length > 0 ? (CompCode.Length > 0 ? " and " + CompCode : "") : "Where" + (CompCode.Length > 0 ? CompCode : ""));
            STR = STR + (STR.Length > 0 ? (dealercode.Length > 0 ? " and " + dealercode : "") : "Where" + (dealercode.Length > 0 ? dealercode : ""));
            STR = STR + (STR.Length > 0 ? (DSEMSPIN.Length > 0 ? " and " + DSEMSPIN : "") : "Where" + (DSEMSPIN.Length > 0 ? DSEMSPIN : ""));

            string Str = "select distinct * from(select* from (select t1.*, t2.TRANS_TYPE as Cancelled_Status from (select* from gd_Fdi_trans f where trans_type= 'ORDBK'  and not exists (select top 1 * from gd_Fdi_trans l where trans_type= 'ORDBA' and f.loc_cd = l.loc_cd and f.trans_id = l.trans_id)) t1 left join(select* from gd_Fdi_trans where trans_type= 'ORDBC') t2 on t1.LOC_CD=t2.LOC_CD and t1.TRANS_ID=t2.TRANS_ID ) a where Cancelled_Status is NULL union all select * from(select t1.*, t2.TRANS_TYPE as Cancelled_Status from (Select* from gd_Fdi_trans where trans_type = 'ORDBA') t1 left join(Select* from gd_Fdi_trans where trans_type= 'ORDBC') t2 on t1.LOC_CD=t2.LOC_CD and t1.TRANS_ID=t2.TRANS_ID ) a where Cancelled_Status is NULL) a ,gd_fdi_trans_customer where a.utd=gd_fdi_trans_customer.UTD";
            return ConnModal.FillDataTable(Str);
        }

        public static DataTable Discount_Offer_Difference(string invno = null)
        {
            string STR = "";
            String CompCode = "";
            invno = !String.IsNullOrWhiteSpace(invno) ? "  invno  like '" + invno + "%'" : "";
            CompCode = SiteSession.LoginUser.Comp_Code != null ? " Compcode = '" + SiteSession.LoginUser.Comp_Code + "'" : "";

            STR = STR + (CompCode.Length > 0 ? "Where" + CompCode : "");
            STR = STR + (STR.Length > 0 ? (invno.Length > 0 ? " and " + invno : "") : "Where" + (invno.Length > 0 ? invno : ""));
            string Str = "select* from (select Compcode,Region, Locationcode, InvNo, Invdt, saletype, Customerid, CustomerName, DSE, TeamLead, MINAME, Variantcd, variantDesc, dateofmanufacturing, HYPO, isnull(convert(int, (round(ExchangeLoyaltyBonusDiscount*((CONVERT(decimal(10, 2),CESS)+CONVERT(decimal(10, 2),CGS)+CONVERT(decimal(10, 2),SGS)+CONVERT(decimal(10, 2),IGS)+100)/100),0))),0) as Exchange_Offer,isnull(convert(int, (round(DiscountforCorpInstitutionalCustomer*((CONVERT(decimal(10, 2),CESS)+CONVERT(decimal(10, 2),CGS)+CONVERT(decimal(10, 2),SGS)+CONVERT(decimal(10, 2),IGS)+100)/100),0))),0) as Corporate_Offer,isnull(convert(int, (round(Discount*((CONVERT(decimal(10, 2),CESS)+CONVERT(decimal(10, 2),CGS)+CONVERT(decimal(10, 2),SGS)+CONVERT(decimal(10, 2),IGS)+100)/100),0))),0) as Club_Consumer_Offer,isnull(convert(int, (round(Msil_Employee*((CONVERT(decimal(10, 2),CESS)+CONVERT(decimal(10, 2),CGS)+CONVERT(decimal(10, 2),SGS)+CONVERT(decimal(10, 2),IGS)+100)/100),0))),0) as Msil_EMployee,isnull(MSIL_Consumer_Offer,0) as MSIL_Consumer_Offer,isnull(MSSFdiscount,0) as MSSFdiscount,isnull(Scross_Kit_difference,0) as Scross_Kit_difference,isnull(CSD_Price_Difference,0) as CSD_Price_Difference,isnull(Post_Sale_Discount,0) as Post_Sale_Discount,isnull(MSIL_RIPS1_Offer,0) as MSIL_RIPS1_Offer,isnull(MSIL_RIPS2_Offer,0) as MSIL_RIPS2_Offer,isnull(MSIL_RIPS3_Offer,0) as MSIL_RIPS3_Offer,convert(varchar(10),MIDATE,103) as midate,Rips1_MI_Due_Date,Rips2_MI_Due_Date,Rips3_MI_Due_Date,isnull(convert(int, (round(SpecialSchemesDiscount*((CONVERT(decimal(10, 2),CESS)+CONVERT(decimal(10, 2),CGS)+CONVERT(decimal(10, 2),SGS)+CONVERT(decimal(10, 2),IGS)+100)/100),0))),0) as Additional_discount,(isnull(convert(decimal(10,2),consumer_offer_given),0)-isnull(convert(decimal(10,2),CSD_Price_Difference),0)-isnull(convert(decimal(10,2),Scross_Kit_difference),0)-isnull(convert(int, (round(Msil_Employee*((CONVERT(decimal(10, 2),CESS)+CONVERT(decimal(10, 2),CGS)+CONVERT(decimal(10, 2),SGS)+CONVERT(decimal(10, 2),IGS)+100)/100),0))),0) -isnull(convert(decimal(10,2),MSIL_Consumer_Offer),0)-isnull(convert(decimal(10,2),MSSFdiscount),0)-isnull(convert(decimal(10,2),MSIL_RIPS1_Offer),0)-isnull(convert(decimal(10,2),MSIL_RIPS2_Offer),0)-isnull(convert(decimal(10,2),MSIL_RIPS3_Offer),0)-isnull(convert(decimal(10,2),Post_Sale_Discount),0)) as offer_difference from  New_Car_Sale_Register where canceldate is null and CONVERT(decimal(10, 2),Discount) >0 and CANCELDATE is NULL and Invdt>='2021/06/01' ) t1 " + STR +" and offer_difference<>0";
            return ConnModal.FillDataTable(Str);
        }

        public static DataTable LocationMaster(string Multi_Loc)
        {
            string Str = "select  Godw_Name,Godw_Code from Godown_Mst where  Godw_Code in (" + Multi_Loc + ") and Comp_Code=" + SiteSession.LoginUser.Comp_Code + "";
            return ConnModal.FillDataTable(Str);

        }
        public static DataTable DesignationMaster()
        {
            string Str = "select  Name,MasterId,Code from Master where MasterParentID=3";
            return ConnModal.FillDataTable(Str);

        }
        


        public static DataTable GetDMSBookingData()
        {
            return ConnModal.FillDataTable("Select  T1.UTD,T1.PARENT_GROUP,T1.DEALER_MAP_CD,T1.LOC_CD,T1.COMP_FA,T1.MUL_DEALER_CD,T1.OUTLET_CD,T1.TRANS_TYPE,T1.TRANS_DATE,T1.TRANS_ID,T1.TRANS_REF_NUM,T1.TRANS_REF_DATE,1.TRANS_QTY,T1.TRANS_SEGMENT,T1.VIN,T1.MODEL_CD,T1.VARIANT_CD,T1.ECOLOR_CD,T1.BASIC_PRICE,T1.DISCOUNT,T1.TAXABLE_VALUE,T1.SERVICE_AMOUNT,T1.GST_NO,T1.PLACE_OF_SUPPLY,T1.CUST_NAME,T1.EXECUTIVE,T1.TEAM_HEAD,T1.FINC_NAME,T1.PAYMENT_MODE,T1.DEPOSIT_BANK,T1.PAYMENT_FOR,T1.GE1,T1.GE2,T1.GE3,T1.GE4,T1.GE5,T1.GE6,T1.GE7,T1.GE8,T1.GE9,T1.GE10,T1.GE11,T1.GE12,T1.GE13,T1.GE14,T1.GE15,T1.GD_FDI_TRANS_ID,T1.created_date,T1.ENGINE_NUM,T1.CHASSIS_NUM,T1.CUST_ID,T1.HSN_NO,T1.AX_FLAG,T1.AutoVyn_Flag,T2.SALUTATION,T2.GENDER,T2.MARITAL_STATUS,T2.COMMUNICATE_TO,T2.RES_ADDRESS1,T2.RES_ADDRESS2,T2.RES_ADDRESS3,T2.RES_PIN_CD,T2.RES_CITY,T2.RES_PHONE,T2.OFF_ADDRESS1,T2.OFF_ADDRESS2,T2.OFF_ADDRESS3,T2.OFF_PIN_CD,T2.OFF_CITY,T2.OFF_PHONE,T2.MOBILE1,T2.MOBILE2,T2.EMAIL_ID,T2.PAN_NO,T2.STATE,T2.DISTRICT,T2.TEHSIL,T2.VILLAGE,T2.TIN,T2.UIN,T2.DOB,T2.DOA,T2.SHIP_ADDRESS1,T2.SHIP_ADDRESS2,T2.SHIP_ADDRESS3,T2.SHIP_PIN_CD,T2.SHIP_CITY,T2.SHIP_STATE,T2.SHIP_FULL_NAME,T2.SHIP_PAN,T2.SHIP_GST_NUM,T2.SHIP_UIN from (SELECT * FROM GD_fDI_TRANS where trans_type='ORDBK') T1 LEFT JOIN (SELECT * FROM GD_FDI_TRANS_CUSTOMER)  T2 ON T1.UTD=T2.UTD and isnull(t1.AutoVyn_Flag,0)=0 ");
       }

        public static DataTable CheckEmployee(string  EmployeeCode , string MSPIN , string Mobileno , string EmailId )
        {
            return ConnModal.FillDataTable("select(case when ISNULL(EmployeeCode, '') ='"+EmployeeCode+"' then 'Employee Code' when ISNULL(MSPIN, '') ='"+MSPIN+"' then 'MSPIN' when ISNULL(Mobileno, '')='"+Mobileno+ "' then 'Mobileno' when ISNULL(EmailId, '')='"+EmailId+"' then 'EmailId' else '' end ) CheckEmp from EmployeeMaster  where EmployeeCode = '" + EmployeeCode+ "' or MSPIN = '" + MSPIN + "' or Mobileno = '" + Mobileno + "' or EmailId = '" + EmailId + "'");
        }

        public static DataTable EmployeeFIll(string LocationCode)
        {
            return ConnModal.FillDataTable("select EmployeeName+' ('+( Select Code from Master where Masterid=Designation)+')' as EmployeeName,EmployeeId from Employeemaster where [Location] = " + LocationCode+" and comp_Code="+SiteSession.LoginUser.Comp_Code+ " and isnull(User_Code,0)=0");
        }

        public static DataTable EmployeeFIllEMpIDWise(string LocationCode)
        {
            return ConnModal.FillDataTable("select EmployeeName+' ('+( Select Code from Master where Masterid=Designation)+')' as EmployeeName,EmployeeId from Employeemaster where [EmployeeId] in ( " + LocationCode + ") and comp_Code=" + SiteSession.LoginUser.Comp_Code + " and isnull(User_Code,0)=0");
        }

        //public static DataTable FillReportigManager(string Designation)
        //{
        //    return ConnModal.FillDataTable("select User_Code as EmployeeId, EmployeeName+' ('+ (Select Code from Master where Masterid=Designation) +')' as Employeename from EmployeeMaster where designation in ("+ Designation + ") and Location  in ("+SiteSession.LoginUser.Multi_loc.se+") and comp_code ="+SiteSession.LoginUser.Comp_Code+"");
        //}


        public static DataTable FillReportigManager(string EmployeeId)
        {

            if (EmployeeId.Length > 0)
            {
                return ConnModal.FillDataTable("select User_Code as EmployeeId, EmployeeName+' ('+ (Select Code from Master where Masterid=Designation) +')' as Employeename from EmployeeMaster where EmployeeId in (" + EmployeeId + ")");
            }
            else

            {
                return new DataTable(); 
            }
        }

        public static DataTable FillReportigUplevel(int status)
        {
            if (status == 0)
            {
                return ConnModal.FillDataTable("select '' as RequestByRemark,'' as Requesterto,date as RequesterDate, Booking.*, Remark, BookingApprovalHistoryId, x.RequestAmount, [Date] as RequestDate, (select EmployeeName+' ('+ (Select Code from [Master] where[Master].Masterid= EmployeeMaster.Designation) +')' as Employeename from EmployeeMaster where  EmployeeMaster.User_Code=x.User_Code) as RequestBy from(select* from BookingApprovalHistory where RequestSendTo= " + SiteSession.LoginUser.User_Code + " and [Status]= 2) as x left join Booking on x.BookingId=Booking.BookingId where booking.ge3='Booked'");
            }
            else
            {
                if (SiteSession.EmployeeMaster.Designation == 19)
                {
                    return ConnModal.FillDataTable("select Booking.*, ((select Remark from(select MIN(BookingLogId) as id  from BookingLog where BookingLog.BookingApprovalHistoryId = x.BookingApprovalHistoryId) as m left join  BookingLog on m.id = BookingLog.BookingLogId))  as RequestByRemark , Remark, BookingApprovalHistoryId, x.RequestAmount, (select MIN(Date) as id  from BookingLog where BookingLog.BookingApprovalHistoryId = x.BookingApprovalHistoryId) as RequestDate, (select EmployeeName + ' (' + (Select Code from[Master] where[Master].Masterid = EmployeeMaster.Designation) +')' as Employeename from EmployeeMaster where EmployeeMaster.User_Code = ((select UserCode from(select MIN(BookingLogId) as id  from BookingLog where BookingLog.BookingApprovalHistoryId = x.BookingApprovalHistoryId) as m left join  BookingLog on m.id = BookingLog.BookingLogId) )) as RequestBy, (case when x.Status = 2  then(select EmployeeName + ' (' + (Select Code from[Master] where[Master].Masterid = EmployeeMaster.Designation) + ')' as Employeename from EmployeeMaster where EmployeeMaster.User_Code = (x.RequestSendTo) ) when x.Status = 3 or x.Status = 4 then(select EmployeeName + ' (' + (Select Code from[Master] where[Master].Masterid = EmployeeMaster.Designation) + ')' as Employeename from EmployeeMaster where EmployeeMaster.User_Code = (x.User_Code) ) else '' end ) as Requesterto,  (case when x.Status = 2  then(select Date from(select MIN(BookingLogId) as id  from BookingLog where BookingLog.BookingApprovalHistoryId = x.BookingApprovalHistoryId and  BookingLog.UserCode = x.User_Code) as m left join  BookingLog on m.id = BookingLog.BookingLogId) when x.Status = 3 or x.Status = 4 then(select Date from(select max(BookingLogId) as id  from BookingLog where BookingLog.BookingApprovalHistoryId = x.BookingApprovalHistoryId and  BookingLog.UserCode = x.User_Code) as m left join  BookingLog on m.id = BookingLog.BookingLogId)   end ) as RequesterDate from(select * from BookingApprovalHistory where User_Code = " + SiteSession.LoginUser.User_Code + " and [Status] = " + status + ") as x left join Booking on x.BookingId = Booking.BookingId where booking.ge3='Booked'");
                }
                else
                {
                    return ConnModal.FillDataTable("select Booking.*, ((select Remark from(select MIN(BookingLogId) as id  from BookingLog where BookingLog.BookingApprovalHistoryId = x.BookingApprovalHistoryId) as m left join  BookingLog on m.id = BookingLog.BookingLogId))  as RequestByRemark , Remark, BookingApprovalHistoryId, x.RequestAmount, (select MIN(Date) as id  from BookingLog where BookingLog.BookingApprovalHistoryId = x.BookingApprovalHistoryId) as RequestDate, (select EmployeeName + ' (' + (Select Code from[Master] where[Master].Masterid = EmployeeMaster.Designation) +')' as Employeename from EmployeeMaster where EmployeeMaster.User_Code = ((select UserCode from(select MIN(BookingLogId) as id  from BookingLog where BookingLog.BookingApprovalHistoryId = x.BookingApprovalHistoryId) as m left join  BookingLog on m.id = BookingLog.BookingLogId) )) as RequestBy, (case when x.Status = 2  then(select EmployeeName + ' (' + (Select Code from[Master] where[Master].Masterid = EmployeeMaster.Designation) + ')' as Employeename from EmployeeMaster where EmployeeMaster.User_Code = (x.RequestSendTo) ) when x.Status = 3 or x.Status = 4 then(select EmployeeName + ' (' + (Select Code from[Master] where[Master].Masterid = EmployeeMaster.Designation) + ')' as Employeename from EmployeeMaster where EmployeeMaster.User_Code = (x.User_Code) ) else '' end ) as Requesterto,  (case when x.Status = 2  then(select Date from(select MIN(BookingLogId) as id  from BookingLog where BookingLog.BookingApprovalHistoryId = x.BookingApprovalHistoryId and  BookingLog.UserCode = x.User_Code) as m left join  BookingLog on m.id = BookingLog.BookingLogId) when x.Status = 3 or x.Status = 4 then(select Date from(select max(BookingLogId) as id  from BookingLog where BookingLog.BookingApprovalHistoryId = x.BookingApprovalHistoryId and  BookingLog.UserCode = x.User_Code) as m left join  BookingLog on m.id = BookingLog.BookingLogId)   end ) as RequesterDate from(select * from BookingApprovalHistory where User_Code = " + SiteSession.LoginUser.User_Code + " and [Status] = " + status + ") as x left join Booking on x.BookingId = Booking.BookingId where booking.ge3='Booked'");
                }
            }
        }


        public static DataTable FillReportigUplevelSingleRow(string BookingApprovalHistoryId)
        {
            string STR = "";


             return ConnModal.FillDataTable("select Booking.*, Remark, BookingApprovalHistoryId, x.RequestAmount, x.Status, [Date] as RequestDate, (select EmployeeName + ' (' + (Select Code from[Master] where[Master].Masterid = EmployeeMaster.Designation) +')' as Employeename from EmployeeMaster where EmployeeMaster.User_Code = x.User_Code) as RequestBy from(select * from BookingApprovalHistory where  BookingApprovalHistoryId=" + BookingApprovalHistoryId + ") as x left join Booking on x.BookingId = Booking.BookingId");
            
        }
        public static DataTable BookingDashboarddata()
        {
            string STR = "";


            return ConnModal.FillDataTable(" select Sum(Pending_Booking) as Pending_Booking,sum(Pending_For_Approval) as Pending_For_Approval,sum(Discount_Rejected) as Discount_Rejected,sum(Discount_Approved) as Discount_Approved from(select Count(*) as Pending_Booking,0 as Pending_For_Approval,0 as Discount_Rejected, 0 as Discount_Approved from Booking where Ge3='Booked' and EXECUTIVE like '" + SiteSession.LoginUser.MSPIN + "%' and BookingId not in (Select distinct BookingId from BookingApprovalHistory) union all select 0 as Pending_Booking, Count(*) as Pending_For_Approval,0 as Discount_Rejected, 0 as Discount_Approved from Booking where ge3='Booked' and  EXECUTIVE like '" + SiteSession.LoginUser.MSPIN + "%' and BookingId  in (Select distinct BookingId from BookingApprovalHistory where Status = 2 ) union all select  0 as Pending_Booking,0 as Pending_For_Approval,Count(*) as Discount_Rejected, 0 as Discount_Approved from Booking where ge3='Booked' and EXECUTIVE like '" + SiteSession.LoginUser.MSPIN + "%' and BookingId  in (Select distinct BookingId from BookingApprovalHistory where Status = 3 ) union all select 0 as Pending_Booking,0 as Pending_For_Approval,0 as Discount_Rejected,Count(*) as Discount_Approved from Booking where ge3='Booked' and EXECUTIVE like '" + SiteSession.LoginUser.MSPIN + "%' and BookingId  in (Select distinct BookingId from BookingApprovalHistory where Status=4 )) a");

        }

        public static DataTable ApproverDashboardData()
        {
            string STR = "";


            return ConnModal.FillDataTable("select sum(Send_for_Recommendation) as Send_for_Recommendation, sum(Pending_For_Approval) as Pending_For_Approval, sum(Discount_Rejected) as Discount_Rejected, sum(Discount_Approved) as Discount_Approved from(Select Count(*) as Send_for_Recommendation, 0 as Pending_For_Approval, 0 as Discount_Rejected, 0 as Discount_Approved  from BookingApprovalHistory, booking where booking.bookingid = BookingApprovalHistory.bookingid and ge3 = 'Booked' and User_code = " + SiteSession.LoginUser.User_Code + " and BookingApprovalHistory.Status = '2' union all Select 0 as Send_for_Recommendation, Count(*) as Pending_For_Approval, 0 as Discount_Rejected, 0 as Discount_Approved from BookingApprovalHistory, Booking where BookingApprovalHistory.bookingid = booking.bookingid and ge3 = 'Booked' and RequestSendTo = " + SiteSession.LoginUser.User_Code + "  union all Select 0 as Send_for_Recommendation, 0 as Pending_For_Approval, Count(*) as Discount_Rejected, 0 as Discount_Approved from BookingApprovalHistory, booking where booking.bookingid = BookingApprovalHistory.bookingid and ge3 = 'Booked' and User_code = " + SiteSession.LoginUser.User_Code + " and BookingApprovalHistory.Status = '3' union all Select  0 as Send_for_Recommendation, 0 as Pending_For_Approval, 0 as Discount_Rejected, Count(*) as Discount_Approved from BookingApprovalHistory, booking where booking.bookingid = BookingApprovalHistory.bookingid and ge3 = 'Booked' and User_code = " + SiteSession.LoginUser.User_Code + " and BookingApprovalHistory.Status = '4')  a");
            
        }



    }
}