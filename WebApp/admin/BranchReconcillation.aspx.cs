using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using WebApp.admin.ReportModal;
using WebApp.LIBS;
using WebApp.TallyData;
using ClosedXML.Excel;
using System.IO;
namespace WebApp.admin
{
    public partial class BranchReconcillation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var TallyURL = SiteSession.GetGodawanListSession.FirstOrDefault().TallyURL;

                var data = TrialBalanceWithGUID.GetCompnay(TallyURL);
                if (data.Count > 0)
                {
                    string[] array = data.Select(p => p).ToArray();
                    SiteSession.GetGodawanListSession.Where(p => array.Contains(p.Value)).ToList().ForEach(x =>
                    {

                        BranchId.Items.Add(new ListItem() { Text = x.Value, Value = x.Id.ToString() });

                    });
                }
            }
        }

        protected void btnsearchdata_Click(object sender, EventArgs e)
        {
            string IDS = "";
            foreach (ListItem listItem in BranchId.Items)
            {
                if (listItem.Selected)
                {
                    IDS = IDS.Length > 0 ? IDS + "," + listItem.Value : listItem.Value;
                }

            }

            string IDs = "";
            foreach (ListItem listItem in BranchId.Items)
            {
                IDs = IDs.Length > 0 ? IDs + "," + listItem.Value : listItem.Value;
            }
            // OtherSqlConn.ExequteQuey("delete  from TRIALBALANCE where GodwnId in (" + IDs + ") ");

            foreach (ListItem listItem in BranchId.Items)
            {
                if (listItem.Selected)
                {
                    DataTable dt = new DataTable();
                    var TallyURL = SiteSession.GetGodawanListSession.Where(p => p.Id == listItem.Value.ConvertInt()).FirstOrDefault().TallyURL;
                    DataTable Data = TrialBalanceWithGUID.readPTallyBalanceSheet(listItem.Text, TallyURL, FromDate.Text.DateConvertTextMatchCase().ToString("yyyyMMdd"), Date.Text.DateConvertTextMatchCase().ToString("yyyyMMdd"), SiteSession.Comp_MstSession.Comp_Code.Value, listItem.Value.ConvertInt(), " where $Parent='Branch / Divisions'");
                    if (Data.Rows.Count > 0)
                    {
                        using (SqlCommand cmd = new SqlCommand("ImportledgerBalance", OtherSqlConn.SqlConnection()))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Details", Data);
                            cmd.Parameters.AddWithValue("@Godw_Name", listItem.Text);
                            cmd.CommandTimeout = int.MaxValue;
                            cmd.ExecuteNonQuery();
                        }

                    }

                }


            }
            try
            {
                ExportExcel(OtherSqlConn.FillDataTable("DECLARE @tempTable TABLE ( GodwnId int ,GodwnName varchar(200) ,InterBranch varchar(200),InterBranchGodwId tinyint ,closingBalance decimal(18,3) );insert into @tempTable select * from (select LedgerBalance.GodwnId, LedgerBalance.GodwnName,case when len(aliasNames)>3 then  (select Godw_Name from godown_mst where godown_mst.NEWCAR_RCPT=(SUBSTRING(aliasNames,CHARINDEX('!',aliasNames)+1, CHARINDEX('!',aliasNames,CHARINDEX('!',aliasNames)+1) -CHARINDEX('!',aliasNames)-1))) else '' end as InterBranch,case when len(aliasNames)>3 then   (select Godw_Code from godown_mst where godown_mst.NEWCAR_RCPT=(SUBSTRING(aliasNames,CHARINDEX('!',aliasNames)+1, CHARINDEX('!',aliasNames,CHARINDEX('!',aliasNames)+1) -CHARINDEX('!',aliasNames)-1))) else '' end  as InterBranchGodwId,LedgerBalance.closingBalance from (select  * from  LedgerBalance  where   GodwnId in (" + IDS + ")) as LedgerBalance  left join (select * from ledger   where   GodwnId in  (" + IDS + ")) as  ledger on LedgerBalance.guid=ledger.guid and LedgerBalance.GodwnId=ledger.GodwnId where ISNULL (aliasNames,'') like '%!%') as Datax;select GodwnName  as Branch,replace(replace(replace(replace(InterBranch,char(10),''),char(9),''),char(13),''),'\n','') as InterBranch ,closingBalance ,isnull((select closingBalance  from @tempTable as x where x.GodwnId=data.InterBranchGodwId and x.InterBranchGodwId=data.GodwnId ),0) as InterBranchBalance,(isnull(closingBalance,0) +isnull((select closingBalance  from @tempTable as x where x.GodwnId=data.InterBranchGodwId and x.InterBranchGodwId=data.GodwnId ),0)) as  [Difference] from (select * from  @tempTable) as data"));
            }
            catch (Exception ex) { }

        }


        private void ExportExcel(DataTable dt)
        {
            using (XLWorkbook
                wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "BranchReconcillation");

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=SqlExport.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }

    }
}


