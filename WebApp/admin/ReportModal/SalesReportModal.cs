using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApp.LIBS;
namespace WebApp.admin.ReportModal
{
    public class SalesReportModal
    {

        public static DataTable SaleReportOutstandingData(string Multi_Loc)
        {
            string Str = "select  * from ( select Org_Loc,(select Godw_Name from godown_mst where org_loc=Godw_Code) as Invoice_Location,ledg_Ac,Ledg_Name,Pending_amt,Dms_Inv,(case when Inv_Date IS NULL then '' else CONVERT(varchar(11), Inv_Date,103) end) as Inv_Date,(case when Delv_Date IS NULL then '' else CONVERT(varchar(11), Delv_Date,103) end) as Delv_Date ,firstset.Cust_id,Del_CustId,Chas_no,modl_code,(select empcode+'-'+Empfirstname+' '+emplastname from employeemaster where erp_Dse=srno) as ERP_DSE,(select empcode+'-'+Empfirstname+' '+emplastname from employeemaster where erp_tl=srno) as ERP_TL,(select top 1 misc_name from misc_mst where misc_type=7 and DMS_DSE=Misc_Code) as DMS_DSE,(select top 1 misc_name from misc_mst where misc_type=7 and DMS_TL=Misc_Code) as DMS_TL, Cust_Type,os_type,(select Misc_Name from Misc_Mst where Fin_Code=misc_code and misc_type=8) as Financer_Name,Invoice_Ageing, (select Godw_Name from godown_mst where Loc_Code=Godw_Code) as Delivery_Location from (select * from (select Ledg_ac,Loc_Code as Org_Loc,ledg_Add6 as Cust_id,ledg_name as Ledg_Name,sum(post_amt) as Pending_Amt from (select acnt_post.loc_code,ledg_Ac,ledg_Add6,ledg_name,(select group_name from grup_mst where group_code=ledg_mst.group_code) as Group_Name,case when amt_drcr=1 then sum(post_amt) else -1*sum(post_amt) end as post_amt from acnt_post,ledg_mst where acnt_post.export_type<3 and acnt_post.ledg_Ac=ledg_code and group_code=53 group by ledg_Ac,ledg_name,amt_Drcr,group_code,ledg_Add6,acnt_post.loc_code ) a group by ledg_Ac,ledg_name,group_name,ledg_Add6,loc_code having sum(post_amt)>0  ) a ) as firstset full join (select * from (select Dms_Inv,Inv_Date,Delv_Date,Cust_id,Del_Custid,Chas_No,Modl_Code,ERP_DSE,ERP_TL,DMS_DSE,DMS_TL,'' as Cust_Type,'' as OS_type,Fin_Code,Datediff(day,Inv_Date,getdate()) as Invoice_Ageing,loc_code from icm_mst where cust_id in (select ledg_Add6 from ( select ledg_Ac,ledg_Add6,ledg_name,(select group_name from grup_mst where group_code=ledg_mst.group_code) as Group_Name,case when amt_drcr=1 then sum(post_amt) else -1*sum(post_amt) end as post_amt from acnt_post,ledg_mst where acnt_post.export_type<3 and acnt_post.ledg_Ac=ledg_code  and group_code=53 group by ledg_Ac,ledg_name,amt_Drcr,group_code,ledg_Add6 ) a group by ledg_Ac,ledg_name,group_name,ledg_Add6 having sum(post_amt)>0  ) ) b ) as secondset on firstset.cust_id=secondset.cust_id ) as x where  Org_Loc in (" + Multi_Loc + ")  order by Invoice_Ageing desc";
            return OtherSqlConn.FillDataTable(Str);

        }
    }
}