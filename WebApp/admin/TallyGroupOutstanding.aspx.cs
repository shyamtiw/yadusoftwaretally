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
using Class;

namespace WebApp.admin
{
    public partial class TallyGroupOutstanding : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                SiteSession.GetGodawanListSession.ToList().ForEach(x =>
                {

                    BranchId.Items.Add(new ListItem() { Text = x.Value, Value = x.Id.ToString() });

                });
                if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
                {
                    GroupNames.SelectedValue = Request.QueryString["id"].ToString();
                    

                    DIVGroupNames.Text = " <div class='col-md-2' style='display:none'>";
                    DIVISBillToBill.Text = " <div class='col-md-2'>";
                }
                else

                {
                    DIVGroupNames.Text = " <div class='col-md-2'>";
                    DIVISBillToBill.Text = " <div class='col-md-2' style='display:none'>";
                    ReportType.SelectedValue = "GroupWise";
                }
                

            }
        }

        protected void exportdata_Click(object sender, EventArgs e)
        {
            try
            {

                if (ReportType.SelectedValue == "GroupWise")
                {
                    string IDS = "";
                    foreach (ListItem listItem in BranchId.Items)
                    {
                        if (listItem.Selected)
                        {
                            IDS = IDS.Length > 0 ? IDS + "," + listItem.Value : listItem.Value;
                        }
                    }
                    DataTable dtLedgerGroup = OtherSqlConn.ExecuteSTORETallyFillAliasToGroup(IDS, GroupNames.SelectedValue);
                    DataTable dtLedger = OtherSqlConn.FillDataTable("select GodwnId,ledgerName,reservedName,isnull((select top 1 RecursivePath from ledgerGroup where ledgerGroup.GodwnId=ledger.GodwnId and ledgerGroup.guid=ledger.parentGuid),'') as RecursivePath from ledger where GodwnId in (" + IDS + ")");
                    DataTable dt = new DataTable();
                    dt.Columns.Add("BranchName", typeof(string));
                    dt.Columns.Add("GroupName", typeof(string));
                    dt.Columns.Add("FromDate", typeof(string));
                    dt.Columns.Add("ToDate", typeof(string));

                    dt.Columns.Add("LedgerName", typeof(string));
                    dt.Columns.Add("LedgerGroupName", typeof(string));
                    dt.Columns.Add("RecursivePath", typeof(string));
                    dt.Columns.Add("Opening", typeof(string));
                    dt.Columns.Add("Debit", typeof(string));
                    dt.Columns.Add("Credit", typeof(string));
                    dt.Columns.Add("Closing", typeof(string));
                    foreach (ListItem listItem in BranchId.Items)
                    {
                        if (listItem.Selected)
                        {
                            DataTable GroupNameList = new DataTable();
                            //IDS = IDS.Length > 0 ? IDS + "," + listItem.Value : listItem.Value;

                            try
                            {
                                GroupNameList = dtLedgerGroup.AsEnumerable().Where(xc => Convert.ToInt32(xc["GodwnId"]) == listItem.Value.ConvertInt()).CopyToDataTable();
                            }
                            catch { }

                            if (GroupNameList.Rows.Count > 0)
                            {

                                var TallyURL = SiteSession.GetGodawanListSession.Where(p => p.Id == listItem.Value.ConvertInt()).FirstOrDefault().TallyURL;
                                foreach (DataRow Item in GroupNameList.Rows)
                                {
                                    DataSet ds = Lib_TallyGroupOutstanding.GetDGetDataFromDataTableTally(FromDate.Text.DateConvertTextMatchCase(), Date.Text.DateConvertTextMatchCase(), listItem.Text, TallyURL, Item["ledgerName"].ToString());


                                    DataTable DtLedger = ds.Tables["DSPACCNAME"];
                                    for (int i = 0; i < DtLedger.Rows.Count; i++)
                                    {

                                        DataRow drLedger = null;
                                        try
                                        {
                                            var lname = Common.ReplaceChar(ds.Tables["DSPACCNAME"].Rows[i][0].ToString());


                                            try
                                            {
                                                drLedger = dtLedger.AsEnumerable().Where(xc => xc["ledgerName"].ToString() == lname && Convert.ToInt32(xc["GodwnId"]) == listItem.Value.ConvertInt()).FirstOrDefault();
                                            }
                                            catch { }

                                        }
                                        catch { }
                                        DataRow dr = dt.NewRow();
                                        int Infoid = i;
                                        dr["GroupName"] = GroupNames.SelectedValue;
                                        dr["BranchName"] = listItem.Text;
                                        if (drLedger != null)
                                        {
                                            dr["LedgerGroupName"] = drLedger["reservedName"].ToString();
                                            dr["RecursivePath"] = drLedger["RecursivePath"].ToString();
                                        }
                                        dr["FromDate"] = FromDate.Text;
                                        dr["ToDate"] = Date.Text;
                                        dr["LedgerName"] = ds.Tables["DSPACCNAME"].Rows[i][0].ToString();
                                        dr["Opening"] =(Common.ConvertDecimal(ds.Tables["DSPOPAMT"].Rows[i][0])*-1m).ToString();
                                        dr["Debit"] = (Common.ConvertDecimal(ds.Tables["DSPDRAMT"].Rows[i][0]) * -1m).ToString(); 
                                        dr["Credit"] = Common.ConvertDecimal(ds.Tables["DSPCRAMT"].Rows[i][0]).ToString();
                                        dr["Closing"] = (Common.ConvertDecimal(ds.Tables["DSPCLAMT"].Rows[i][0]) * -1m).ToString();
                                        dt.Rows.Add(dr);
                                    }
                                }
                            }


                        }
                    }
                    ExportExcel(dt);
                }
                else
                {
                    Bill2BillData();
                }
            }
              catch (Exception ex)
            { }
        }


        private void Bill2BillData()
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
                DataTable dtLedgerGroup = OtherSqlConn.ExecuteSTORETallyFillAliasToGroup(IDS, GroupNames.SelectedValue);
                DataTable dtLedger = OtherSqlConn.FillDataTable("select GodwnId,ledgerName,reservedName,isnull((select top 1 RecursivePath from ledgerGroup where ledgerGroup.GodwnId=ledger.GodwnId and ledgerGroup.guid=ledger.parentGuid),'') as RecursivePath from ledger where GodwnId in (" + IDS + ")");
                DataTable dt = new DataTable();
                dt.Columns.Add("BranchName", typeof(string));
                dt.Columns.Add("FromDate", typeof(string));
                dt.Columns.Add("ToDate", typeof(string));
                dt.Columns.Add("GroupName", typeof(string));
                dt.Columns.Add("LedgerName", typeof(string));
                dt.Columns.Add("LedgerGroupName", typeof(string));
                dt.Columns.Add("RecursivePath", typeof(string));
                dt.Columns.Add("BillNo", typeof(string));
                dt.Columns.Add("BillDate", typeof(string));
                dt.Columns.Add("Opening", typeof(string));
                dt.Columns.Add("Closing", typeof(string));
                dt.Columns.Add("BillDueDate", typeof(string));
                dt.Columns.Add("BillOverDue", typeof(string));
                foreach (ListItem listItem in BranchId.Items)
                {
                    if (listItem.Selected)
                    {
                        DataTable GroupNameList = new DataTable();
                        //IDS = IDS.Length > 0 ? IDS + "," + listItem.Value : listItem.Value;

                        try
                        {
                            GroupNameList = dtLedgerGroup.AsEnumerable().Where(xc => Convert.ToInt32(xc["GodwnId"]) == listItem.Value.ConvertInt()).CopyToDataTable();
                        }
                        catch { }

                        if (GroupNameList.Rows.Count > 0)
                        {

                            var TallyURL = SiteSession.GetGodawanListSession.Where(p => p.Id == listItem.Value.ConvertInt()).FirstOrDefault().TallyURL;
                            foreach (DataRow Item in GroupNameList.Rows)
                            {
                                DataSet ds = Lib_TallyGroupOutstanding.GetDGetDataFromDataTableTallyBillwise(FromDate.Text.DateConvertTextMatchCase(), Date.Text.DateConvertTextMatchCase(), listItem.Text, TallyURL, Item["ledgerName"].ToString());


                                DataTable DtLedger = ds.Tables["BILLFIXED"];
                                for (int i = 0; i < DtLedger.Rows.Count; i++)
                                {

                                    DataRow drLedger = null;
                                    try
                                    {
                                        var lname = Common.ReplaceChar(ds.Tables["BILLFIXED"].Rows[i]["BILLPARTY"].ToString());


                                        try
                                        {
                                            drLedger = dtLedger.AsEnumerable().Where(xc => xc["ledgerName"].ToString() == lname && Convert.ToInt32(xc["GodwnId"]) == listItem.Value.ConvertInt()).FirstOrDefault();
                                        }
                                        catch { }

                                    }
                                    catch { }
                                    DataRow dr = dt.NewRow();
                                    int Infoid = i;
                                    dr["GroupName"] = GroupNames.SelectedValue;
                                    dr["BranchName"] = listItem.Text;
                                    if (drLedger != null)
                                    {
                                        dr["LedgerGroupName"] = drLedger["reservedName"].ToString();
                                        dr["RecursivePath"] = drLedger["RecursivePath"].ToString();
                                    }
                                    dr["FromDate"] = FromDate.Text;
                                    dr["ToDate"] = Date.Text;

                                    dr["LedgerName"] = ds.Tables["BILLFIXED"].Rows[i]["BILLPARTY"].ToString();
                                    dr["BillNo"] = ds.Tables["BILLFIXED"].Rows[i]["BILLREF"].ToString();
                                    dr["BillDate"] = ds.Tables["BILLFIXED"].Rows[i]["BILLDATE"].ToString();
                                    dr["Opening"] = (Common.ConvertDecimal( ds.Tables["BILLOP"].Rows[i][0])*-1m).ToString();
                                    dr["Closing"] = (Common.ConvertDecimal(ds.Tables["BILLCL"].Rows[i][0]) * -1m).ToString();
                                    dr["BillDueDate"] = ds.Tables["BILLDUE"].Rows[i][0].ToString();
                                    dr["BILLOVERDUE"] = ds.Tables["BILLOVERDUE"].Rows[i][0].ToString();

                                    //dt.Columns.Add("BillNo", typeof(string));
                                    //dt.Columns.Add("BillDate", typeof(string));
                                    //dt.Columns.Add("Opening", typeof(string));
                                    //dt.Columns.Add("Closing", typeof(string));
                                    //dt.Columns.Add("BillDueDate", typeof(string));
                                    //dt.Columns.Add("BillOverDue", typeof(string));
                                    dt.Rows.Add(dr);
                                }
                            }
                        }


                    }
                }
                ExportExcelBillToBill(dt);

            }
            catch (Exception ex) 
            { 
            
            
            }
        }
        private void ExportExcel(DataTable dt)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "GroupOut");

                wb.Worksheet("GroupOut").Column(8).CellsUsed(c => c.WorksheetRow().RowNumber() != 1).DataType = XLDataType.Number;
                wb.Worksheet("GroupOut").Column(9).CellsUsed(c => c.WorksheetRow().RowNumber() != 1).DataType = XLDataType.Number;
                wb.Worksheet("GroupOut").Column(10).CellsUsed(c => c.WorksheetRow().RowNumber() != 1).DataType = XLDataType.Number;
                wb.Worksheet("GroupOut").Column(11).CellsUsed(c => c.WorksheetRow().RowNumber() != 1).DataType = XLDataType.Number;

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

        private void ExportExcelBillToBill(DataTable dt)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "GroupOut");
                wb.Worksheet("GroupOut").Column(10).CellsUsed(c => c.WorksheetRow().RowNumber() != 1).DataType = XLDataType.Number;
                wb.Worksheet("GroupOut").Column(11).CellsUsed(c => c.WorksheetRow().RowNumber() != 1).DataType = XLDataType.Number;

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