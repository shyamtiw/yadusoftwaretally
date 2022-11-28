using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
using Business;
using WebApp.admin.ReportModal;
using System.Data;
using DevExpress.Web.ASPxTreeList;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxTreeList.Internal;
using System.Text.RegularExpressions;
using System.Globalization;

namespace WebApp.admin
{
    public partial class TrialBalanceReport : BasePageClass
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Common.BindControl(LocationId, SiteSession.GetGodawanListSession.ToList(), "Value", "Id", "Select");
            }
        }

        void InitTreeList(int LocationId)
        {
            try
            {
                if (LocationId > 0)
                {
                    DataTable CompData = OtherSqlConn.FillDataTable("select ledgerGroupName from ledgerGroup where  parent='#4; Primary' and  companyId=" + SiteSession.Comp_MstSession.Comp_Code + " and GodwnId=" + LocationId + "");
                    DataTable Main = new DataTable();

                    foreach (DataRow dr in CompData.Rows)
                    {
                        DataTable Dt1 = OtherSqlConn.SPtrialBalance(LocationId, dr["ledgerGroupName"].ToString());
                        if (Main.Rows.Count > 0)
                        {
                            Main = Main.AsEnumerable().Union(Dt1.AsEnumerable()).CopyToDataTable();
                        }
                        else
                        {
                            Main = Dt1;
                        }

                    }

                    DataTable Dt1Alon = OtherSqlConn.SPtrialBalanceAlonLedger(LocationId);
                    var strarray = Main.AsEnumerable().Select(p => p["parent"].ToString() == "#4; Primary" ? " <tr data-tt-id='" + p["ledgerGroupName"].ToString() + "' ><td>" + p["ledgerGroupName"].ToString().Replace("amp;", "&") + "</td><td>" + (p["balance"].ToString().Contains("-") ? p["balance"].ToString().Replace("-", "").ToString().ConvertDecimal().ToString("N", new CultureInfo("en-US")) + " Dr." : p["balance"].ToString().ConvertDecimal().ToString("N", new CultureInfo("en-US")) + " Cr.") + "</td></tr>" : " <tr data-tt-id='" + p["ledgerGroupName"].ToString() + "' data-tt-parent-id='" + p["parent"].ToString().ToString() + "'><td>" + p["ledgerGroupName"].ToString().Replace("amp;", "&") + "</td><td>" + (p["balance"].ToString().Contains("-") ? p["balance"].ToString().Replace("-", "").ToString().ConvertDecimal().ToString("N", new CultureInfo("en-US")) + " Dr." : p["balance"].ToString().ConvertDecimal().ToString("N", new CultureInfo("en-US")) + " Cr.") + "</td></tr>").ToArray();

                    var strarrayAlon = Dt1Alon.AsEnumerable().Select(p => p["parent"].ToString() == "#4; Primary" ? " <tr data-tt-id='" + p["ledgerGroupName"].ToString() + "' ><td>" + p["ledgerGroupName"].ToString().Replace("amp;","&") + "</td><td>" + (p["balance"].ToString().Contains("-") ? p["balance"].ToString().Replace("-", "").ToString().ConvertDecimal().ToString("N", new CultureInfo("en-US")) + " Dr." : p["balance"].ToString().ConvertDecimal().ToString("N", new CultureInfo("en-US")) + " Cr.") + "</td></tr>" : " <tr data-tt-id='" + p["ledgerGroupName"].ToString() + "' data-tt-parent-id='" + p["parent"].ToString().ToString() + "'><td>" + p["ledgerGroupName"].ToString().Replace("amp;", "&") + "</td><td>" + (p["balance"].ToString().Contains("-") ? p["balance"].ToString().Replace("-", "").ToString().ConvertDecimal().ToString("N", new CultureInfo("en-US")) + " Dr." : p["balance"].ToString().ConvertDecimal().ToString("N", new CultureInfo("en-US")) + " Cr.") + "</td></tr>").ToArray();

                    //var strarray = Main.AsEnumerable().OrderBy(p => p["parent"].ToString()).Select(p => p["parent"].ToString() == "#4; Primary" ? " <tr data-tt-id='" + AddColFromLetter((new String(p["ledgerGroupName"].ToString().Where(c => Char.IsLetter(c)).ToArray()))) + "' data-tt-parent-id='0'><td>" + p["ledgerGroupName"] + "</td><td>" + p["balance"].ToString() + "</td></tr>" : " <tr data-tt-id='" + AddColFromLetter(new String(p["ledgerGroupName"].ToString().Where(c => Char.IsLetter(c)).ToArray())) + "' data-tt-parent-id='" + AddColFromLetter(new String(p["parent"].ToString().Where(c => Char.IsLetter(c)).ToArray())) + "'><td>" + p["ledgerGroupName"] + "</td><td>" + p["balance"].ToString() + "</td></tr>").ToArray();
                    Data.Text = string.Join(" ", strarray);
                    Data.Text = Data.Text + string.Join(" ", strarrayAlon);

                    try
                    {
                        ToDate.Text = Convert.ToDateTime(OtherSqlConn.FillDataTable("select top 1 syncDate from  LedgerBalance where   companyId="+SiteSession.Comp_MstSession.Comp_Code+" and GodwnId="+LocationId+"").Rows[0][0]).ToString("dd/MM/yyyy");
                    }
                    catch { }
                 
                }
                else

                {
                    MessageBox.ShowMessage("Error", "Please  select Location", SiteKey.MessageType.danger);
                }

            }
            catch(Exception ex) {
                MessageBox.ShowMessage("Error", ex.Message, SiteKey.MessageType.danger);
            }
        }
        
        private void SingleSelectTreeListEditor_HtmlRowPrepared(object sender, TreeListHtmlRowEventArgs e)
        {
            TreeListSelectionCell selCell = e.Row.Cells.OfType<TreeListSelectionCell>().FirstOrDefault();
            if (selCell != null) { selCell.Visible = false; }
        }

        public int AddColFromLetter(string s)
        {
            int column = 0;
            int iter = 1;
            foreach (char c in s)
            {
                int index = char.ToUpper(c) - 64;//Ahmed KRAIEM
                                                 //int index = (int)c % 32;//Valdimir
                if (iter == 1)
                    column += index;
                if (iter > 1)
                    column += 25 + index;
                iter++;
            }
            return column;
        }

        protected void btnsearchdata_Click(object sender, EventArgs e)
        {
            if (LocationId.SelectedValue != "Select")
            {
                InitTreeList(LocationId.SelectedValue.ConvertInt());
                AmountTh.Text = LocationId.SelectedItem.Text;
            }
            else

            {
                Data.Text = "";
                AmountTh.Text = "";
            }
        }
    }
}