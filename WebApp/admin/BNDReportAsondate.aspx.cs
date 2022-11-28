using ClosedXML.Excel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web.Services;
using System.Web.UI.WebControls;
using WebApp.admin.ReportModal;
using WebApp.LIBS;
namespace WebApp.admin
{
    public partial class BNDReportAsondate : BasePageClass
    {
        public static DataTable DtData = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DtData = new DataTable();
                DtData = OtherSqlConn.FillDataTable("DECLARE @tempGDFDICalcel TABLE (   TRANS_ID nvarchar(200)) insert into  @tempGDFDICalcel select distinct TRANS_REF_NUM from gd_fdi_trans where TRANS_TYPE='VC' DECLARE @tempGDFDI TABLE (   TRANS_ID nvarchar(200),  GE7  nvarchar(200),LOC_CD  nvarchar(200), BranchId int ,ENGINE_NUM  nvarchar(200),VIN  nvarchar(200),TEAM_HEAD  nvarchar(200),FINC_NAME  nvarchar(200), MulInvDate date  );    DECLARE @tempTableMulDate TABLE ( TRANS_DATE nvarchar(200),VIN nvarchar(200));  insert into @tempTableMulDate select distinct TRANS_DATE,VIN from gd_fdi_trans sc where sc.TRANS_TYPE='VD' insert into  @tempGDFDI select xc.*,xcv.TRANS_DATE as MulInvDate from (select distinct TRANS_ID,GE7,LOC_CD,(select Godw_Code from godown_mst where NEWCAR_RCPT=LOC_CD) as BranchId, ENGINE_NUM,VIN,TEAM_HEAD,FINC_NAME from gd_fdi_trans where TRANS_TYPE='VS'  and TRANS_ID not in (select * from @tempGDFDICalcel)) as xc left join   @tempTableMulDate as xcv on xc.VIN=xcv.VIN    DECLARE @tempTable2 TABLE ( FinanceId int ,[Status] nvarchar(200),    BranchName  nvarchar(200),   Region  nvarchar(200), Branch_Code   nvarchar(200),DMSINVNo  nvarchar(200),DMSINVDate   date,Variant_CD  nvarchar(200),ModelName  nvarchar(200),Fuel_Type  nvarchar(200),VARIANT  nvarchar(200) ,ChasNo  nvarchar(200),ENGINE_NUM  nvarchar(200),VIN  nvarchar(200),MulInvDate  nvarchar(200),CustId  nvarchar(200),CustomerName  nvarchar(200),TEAM_HEAD  nvarchar(200),ErpExecutive   nvarchar(200),FINC_NAME  nvarchar(200));insert into @tempTable2 select   FinanceId, (case when ISNULL(DiscountUserId,0)>0 then 'Complete' else 'Pending' end ) as [Status],     (select Godw_Name from godown_mst where Godw_Code=Finance.BranchId) as BranchId,    (select Br_Region from godown_mst where Godw_Code=Finance.BranchId) as Region,  LOC_CD,DMSINVNo, DelvOn,Variant_CD,ModelName,GE7 as Fuel_Type, (select top 1 VARIANT_DESC from model_variant_master where model_variant_master.VARIANT_CD=Finance.Variant_CD) as VARIANT  ,ChasNo,ENGINE_NUM,VIN,MulInvDate,CustId,CustomerName,TEAM_HEAD,ErpExecutive ,FINC_NAME from (select * from  Finance where DeliveryDate is null and  BranchId in ( "+SiteSession.LoginUser.Multi_loc+ ") ) as Finance left join  @tempGDFDI as tmpgd  on  Finance.DMSINVNo=tmpgd.TRANS_ID and Finance.BranchId=tmpgd.BranchId; SELECT     [Status],BranchName,Region,Branch_Code ,DMSINVNo,convert(varchar, DMSINVDate, 103) as DMSINVDate,Variant_CD,ModelName,Fuel_Type,VARIANT,ChasNo,ENGINE_NUM,VIN,MulInvDate,CustId,CustomerName,TEAM_HEAD,ErpExecutive,FINC_NAME,DATEDIFF(DAY,DMSINVDate,getdate()) as Ageing FROM (select y.* from  (select * from  @tempTable2) as y left join    @tempGDFDICalcel as  x  on y.DMSINVNo=x.TRANS_ID where x.TRANS_ID Is Null ) as xc order by DATEDIFF(DAY,DMSINVDate,getdate())  desc");
                Common.BindControldt(gvlocation, DtData);
                

            }
        }

        protected void exportdata_Click(object sender, EventArgs e)
        {
            try
            {
                ExportExcel(DtData);
            }
            catch { }
        }


        private void ExportExcel(DataTable dt)
        {
            try
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt, "BND Report As on date");

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=BND Data List.xlsx");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
            }
            catch { }
        }
        
    }
}