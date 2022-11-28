using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.admin.ReportModal;
using WebApp.LIBS;

namespace WebApp.admin
{
    public partial class voucherpreview : BasePageClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable CReatoreData = OtherSqlConn.FillDataTable("select (select Godw_Name from godown_mst where godown_mst.Godw_Code=InterbranchEntry.CreatorBranchId) as Branch,CreatorVocuherType as  VocherType ,CreatorVocherNo as VoucherNo,CreatorVocuherDate as VoucherDate,CreatorInterBranch  as Ledger,(case  when isnull(CreatorVocuherTotal,0)>=0 then isnull(CreatorVocuherTotal,0) else 0 end ) as Dr,(case  when isnull(CreatorVocuherTotal,0)<0 then isnull(CreatorVocuherTotal,0) else 0 end ) as Cr,CreatorNarration as Narration,VocherJsonCreatore as [Json] from InterbranchEntry  where InterbranchEntry.InterbranchEntryId=" + Request.QueryString["InterbranchEntryId"] + "");

                var CreatPaymentList = JsonConvert.DeserializeObject<List<EntryJson>>( CReatoreData.Rows[0]["Json"].ToString());

                CreatPaymentList.ForEach(x => {
                    DataRow dr = CReatoreData.NewRow();
                    dr["Ledger"] = x.Ledger;
                    dr["Dr"] = Common.ConvertDecimal(x.DrAmt);
                    dr["Cr"] = Common.ConvertDecimal(x.CrAmt);
                    CReatoreData.Rows.Add(dr);

                });

                

                DataTable RequesterData = OtherSqlConn.FillDataTable("select (select Godw_Name from godown_mst where godown_mst.Godw_Code=InterbranchEntry.RequestToBranchId) as Branch,ApproverVocuherType as  VocherType ,VocherNo as VoucherNo,VocuherDate as VoucherDate,(select Godw_Name from godown_mst where godown_mst.Godw_Code=InterbranchEntry.CreatorBranchId)  as Ledger,(case  when isnull(ApproverVoucherTotal,0)>=0 then isnull(ApproverVoucherTotal,0) else 0 end ) as Dr,(case  when isnull(ApproverVoucherTotal,0)<0 then isnull(ApproverVoucherTotal,0) else 0 end ) as Cr,ApproverNarration as Narration,VocherJsonApprover as [Json] from InterbranchEntry  where InterbranchEntry.InterbranchEntryId="+Request.QueryString["InterbranchEntryId"] +"");

                var RequesterPaymentList = JsonConvert.DeserializeObject<List<EntryJson>>(RequesterData.Rows[0]["Json"].ToString());

                RequesterPaymentList.ForEach(x => {
                    DataRow dr = RequesterData.NewRow();
                    dr["Ledger"] = x.Ledger;
                    dr["Dr"] = Common.ConvertDecimal(x.DrAmt);
                    dr["Cr"] = Common.ConvertDecimal(x.CrAmt);
                    RequesterData.Rows.Add(dr);

                });
                Common.BindControldt(gvcreator, CReatoreData);
                Common.BindControldt(gvapprover, RequesterData);
            }
        }
    }
}