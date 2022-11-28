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
    public partial class branchwiseledgerdata : System.Web.UI.Page
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
                    SiteSession.GetGodawanListSession.Where(p=> array.Contains(p.Value)).ToList().ForEach(x =>
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
                    DataTable Data = TrialBalanceWithGUID.readPTallyBalanceSheet(listItem.Text, TallyURL, FromDate.Text.DateConvertTextMatchCase().ToString("yyyyMMdd"), Date.Text.DateConvertTextMatchCase().ToString("yyyyMMdd"), SiteSession.Comp_MstSession.Comp_Code.Value, listItem.Value.ConvertInt());
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
                ExportExcel(OtherSqlConn.FillDataTable("select ledgerBalanceId,x.guid,(select Godw_Name from godown_mst where godown_mst.Godw_Code=x.GodwnId) as Branch,replace(replace(replace(replace(ledgerName,char(10),''),char(9),''),char(13),''),'\n','') as ledgerName,(x.openingBalance*-1) as openingBalance,(x.closingBalance*-1) closingBalance,replace(replace(replace(replace([Group],char(10),''),char(9),''),char(13),''),'\n','') [Group],replace(replace(replace(replace((case when len( isnull(GroupPath,''))>5 then substring(isnull(GroupPath,''),3,len(isnull(GroupPath,''))-1) else isnull(GroupPath,'') end ) ,char(10),''),char(9),''),char(13),''),'\n','')as [Path],syncDate,synctime  from (select * from LedgerBalance where   GodwnId in (" + IDS + ")  and (closingBalance !=0.00 or openingBalance!=0.00 )) as x left join  (select guid,reservedName as [Group],(select RecursivePath from ledgerGroup where ledgerGroup.guid=ledger.parentGuid and ledgerGroup.GodwnId=ledger.GodwnId) as GroupPath,GodwnId from  ledger  where  GodwnId in (" + IDS + ") )  as ledger on x.guid=ledger.guid and  x.GodwnId=ledger.GodwnId "));
            }
            catch (Exception ex) { }

        }


        private void ExportExcel(DataTable dt)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Trialbalance");

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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string IDS = "";
                foreach (ListItem listItem in BranchId.Items)
                {
                    if (listItem.Selected)
                    {
                        IDS = IDS.Length > 0 ? IDS + "," + listItem.Value : listItem.Value;
                    }

                }

                ExportExcel(OtherSqlConn.FillDataTable("select guid,(select Godw_Name from godown_mst where godown_mst.Godw_Code=LedgerCheck.GodwnId) as Branch,ledgerName,ledgerGroup,ledgerGroupTree as GroupPath,NewledgerName,NewledgerGroup,NewledgerGroupTree as NewGroupPath,syncDate from LedgerCheck where   GodwnId in (" + IDS + ")"));
            }
            catch (Exception ex) { }

        }
    }
}


