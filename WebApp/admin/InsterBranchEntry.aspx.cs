using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
using Business;
using WebApp.admin.ReportModal;
using System.Web.Script.Services;
using System.Web.Services;
using System.Data;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace WebApp.admin
{
    public partial class InsterBranchEntry : BasePageClass
    {
        public static DataTable LeaderList = new DataTable();
        public static DataTable RefrenceTypeList = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefrenceTypeList = new DataTable();

                RefrenceTypeList.Columns.Add("BillType");
                RefrenceTypeList.Rows.Add("Advance");
                RefrenceTypeList.Rows.Add("AgstReference");
                RefrenceTypeList.Rows.Add("NewReferece");
                RefrenceTypeList.Rows.Add("OnAccount");
                Common.BindControldt(CreatorInterBranch, OtherSqlConn.FillDataTable("select Godw_Code,dms_bt_code from godown_mst where Comp_Code="+SiteSession.LoginUser.Comp_Code+"  and  Godw_Code<>"+SiteSession.GodownId+""), "dms_bt_code", "Godw_Code", "Select");
                Common.BindControldt(CreatorVocuherType, OtherSqlConn.FillDataTable("select VoucherTypeName from VoucherType  where companyId=" + SiteSession.Comp_MstSession.Comp_Code + ""), "VoucherTypeName", "VoucherTypeName", "Select");
                LeaderList = OtherSqlConn.FillDataTable("SELECT    LedgerName FROM [ledger] where companyId=" + SiteSession.Comp_MstSession.Comp_Code + " and reservedName not like 'Branch / Divisions%'");


            }
        }



        [WebMethod]
        public List<string> GetCountryNames(string term)
        {
            DataView dv = new DataView(WebApp.admin.InsterBranchEntry.LeaderList);
            dv.RowFilter = "LedgerName LIKE '%" + term + "%'";

            List<string> gh = dv.ToTable().AsEnumerable().Select(k => k[0].ToString()).ToList();
            return gh;
        }

        protected void addnew_Click(object sender, EventArgs e)
        {
            try
            {
                var Item = new List<EntryJson>();
                for (int i = 0; i < loopitem.Items.Count; i++)
                {
                    var row = new EntryJson();


                    row.Ledger = (loopitem.Items[i].FindControl("Ledger") as TextBox).Text.ToString();
                    row.RefrenceType = (loopitem.Items[i].FindControl("RefrenceType") as DropDownList).SelectedValue.ToString();
                    row.RefrenceNo = (loopitem.Items[i].FindControl("RefrenceNo") as TextBox).Text.ToString();
                    row.RefrenceAmount = (loopitem.Items[i].FindControl("RefrenceAmount") as TextBox).Text.ToString();
                    row.DrAmt = (loopitem.Items[i].FindControl("DrAmt") as TextBox).Text.ToString();
                    row.CrAmt = (loopitem.Items[i].FindControl("CrAmt") as TextBox).Text.ToString();
                    Item.Add(row);
                }
                Item.Add(new EntryJson() { CrAmt = "", DrAmt = "", Ledger = "", LedgerGroup = "", RefrenceAmount = "", RefrenceNo = "", RefrenceType = "" });
                Common.BindControl(loopitem, Item.ToList());
            }
            catch { }

        }

        protected void loopitem_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //  DropDownList Ledger = (e.Item.FindControl("Ledger") as DropDownList);
                DropDownList RefrenceType = (e.Item.FindControl("RefrenceType") as DropDownList);
                HiddenField hfRefrenceType = (e.Item.FindControl("RefrenceTypeid") as HiddenField);
                // Common.BindControldt(Ledger, LeaderList, "LedgerName", "LedgerName", "Select");
                Common.BindControldt(RefrenceType, RefrenceTypeList, "BillType", "BillType", "Select");
                if (Common.Convertstring(hfRefrenceType.Value).Length > 0)
                {
                    RefrenceType.Items.FindByValue(hfRefrenceType.Value).Selected = true;
                }

            }
        }

        protected void savedata_Click(object sender, EventArgs e)
        {
            try
            {
                var Item = new List<EntryJson>();
                for (int i = 0; i < loopitem.Items.Count; i++)
                {
                    var row = new EntryJson();


                    row.Ledger = (loopitem.Items[i].FindControl("Ledger") as TextBox).Text.ToString();
                    row.RefrenceType = (loopitem.Items[i].FindControl("RefrenceType") as DropDownList).SelectedValue.ToString();
                    row.RefrenceNo = (loopitem.Items[i].FindControl("RefrenceNo") as TextBox).Text.ToString();
                    row.RefrenceAmount = (loopitem.Items[i].FindControl("RefrenceAmount") as TextBox).Text.ToString();
                    row.DrAmt = (loopitem.Items[i].FindControl("DrAmt") as TextBox).Text.ToString();
                    row.CrAmt = (loopitem.Items[i].FindControl("CrAmt") as TextBox).Text.ToString();

                    Item.Add(row);
                }

                var TotalCr = Item.Sum(p => Common.ConvertDecimal(p.CrAmt));
                var Totaldr = Item.Sum(p => Common.ConvertDecimal(p.DrAmt));
                var json = JsonConvert.SerializeObject(Item);
                if (Request.QueryString[""].ConvertInt() > 0)
                {


                    string stmt = "update  [InterbranchEntry] set [CreatorInterBranch]=@CreatorInterBranch,[Status]=@Status,[CreatorVocherNo]=@CreatorVocherNo,[CreatorVocuherDate]=@CreatorVocuherDate,[VocherJsonCreatore]=@VocherJsonCreatore,[CreatorVocuherType]=@CreatorVocuherType,CreatorNarration=@CreatorNarration,CreatorVocuherTotal=@CreatorVocuherTotal,RequestToBranchId=@RequestToBranchId where InterbranchEntryId=@InterbranchEntryId";
                    

                    SqlCommand cmd = new SqlCommand(stmt, OtherSqlConn.SqlConnection());
                    
                    cmd.Parameters.Add("@CreatorInterBranch", SqlDbType.NVarChar, 500);
                    cmd.Parameters.Add("@RequestToBranchId", SqlDbType.Int);
                    cmd.Parameters.Add("@Status", SqlDbType.Int);
                    cmd.Parameters.Add("@InterbranchEntryId", SqlDbType.Int);
                    
                    cmd.Parameters.Add("@CreatorVocherNo", SqlDbType.NVarChar, 500);
                    cmd.Parameters.Add("@CreatorVocuherDate", SqlDbType.Date);
                    cmd.Parameters.Add("@VocherJsonCreatore", SqlDbType.NVarChar, int.MaxValue);
                    cmd.Parameters.Add("@CreatorVocuherType", SqlDbType.NVarChar, 500);
                    cmd.Parameters.Add("@CreatorNarration", SqlDbType.NVarChar, int.MaxValue);
                    cmd.Parameters.Add("@CreatorVocuherTotal", SqlDbType.Decimal);
                    cmd.Parameters["@CreatorUserId"].Value = SiteSession.LoginUser.User_Code;
                    cmd.Parameters["@CreatorInterBranch"].Value = CreatorInterBranch.SelectedItem.Text;

                    cmd.Parameters["@Status"].Value = 1;
                    cmd.Parameters["@InterbranchEntryId"].Value = Request.QueryString[""].ConvertInt();
                    cmd.Parameters["@CreatorVocherNo"].Value = CreatorVocherNo.Text;
                    cmd.Parameters["@CreatorVocuherDate"].Value = CreatorVocuherDate.Text.DateConvertTextMatchCase();
                    cmd.Parameters["@VocherJsonCreatore"].Value = json;
                    cmd.Parameters["@CreatorVocuherType"].Value = CreatorVocuherType.SelectedValue.ToString();
                    cmd.Parameters["@CreatorNarration"].Value = "";
                    cmd.Parameters["@CreatorVocuherTotal"].Value = (Totaldr-TotalCr);
                    cmd.Parameters["@RequestToBranchId"].Value = CreatorInterBranch.SelectedValue.ConvertInt();
                    cmd.ExecuteNonQuery();

                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Successfully", "alert('Entry Successfully Save');window.location='InsterBranchEntry.aspx'", true);
                }
                else
                {
                    string stmt = "insert into [InterbranchEntry] ([CreatorUserId],[CreatorInterBranch],[CreateDateTime],[Status],[CreatorVocherNo],[CreatorVocuherDate],[VocherJsonCreatore],[CreatorVocuherType],CreatorNarration,CreatorVocuherTotal,CreatorBranchId,RequestToBranchId) values(" +
                            "@CreatorUserId,@CreatorInterBranch,@CreateDateTime,@Status,@CreatorVocherNo,@CreatorVocuherDate,@VocherJsonCreatore,@CreatorVocuherType,@CreatorNarration,@CreatorVocuherTotal,@CreatorBranchId,@RequestToBranchId)";

                    SqlCommand cmd = new SqlCommand(stmt, OtherSqlConn.SqlConnection());
                    cmd.Parameters.Add("@CreatorUserId", SqlDbType.Int);
                    cmd.Parameters.Add("@RequestToBranchId", SqlDbType.Int);
                    cmd.Parameters.Add("@CreatorBranchId", SqlDbType.Int);
                    cmd.Parameters.Add("@CreatorInterBranch", SqlDbType.NVarChar, 500);
                    cmd.Parameters.Add("@CreateDateTime", SqlDbType.DateTime);
                    cmd.Parameters.Add("@Status", SqlDbType.Int);
                    cmd.Parameters.Add("@CreatorVocherNo", SqlDbType.NVarChar, 500);
                    cmd.Parameters.Add("@CreatorVocuherDate", SqlDbType.Date);
                    cmd.Parameters.Add("@VocherJsonCreatore", SqlDbType.NVarChar, int.MaxValue);
                    cmd.Parameters.Add("@CreatorVocuherType", SqlDbType.NVarChar, 500);
                    cmd.Parameters.Add("@CreatorNarration", SqlDbType.NVarChar, int.MaxValue);
                    cmd.Parameters.Add("@CreatorVocuherTotal", SqlDbType.Decimal);
                    cmd.Parameters["@CreatorUserId"].Value = SiteSession.LoginUser.User_Code;
                    cmd.Parameters["@CreatorInterBranch"].Value = CreatorInterBranch.SelectedItem.Text;
                    cmd.Parameters["@CreateDateTime"].Value = Common.DateTimeNow();
                    cmd.Parameters["@Status"].Value = 1;
                    cmd.Parameters["@CreatorVocherNo"].Value = CreatorVocherNo.Text;
                    cmd.Parameters["@CreatorVocuherDate"].Value = CreatorVocuherDate.Text.DateConvertTextMatchCase();
                    cmd.Parameters["@VocherJsonCreatore"].Value = json;
                    cmd.Parameters["@CreatorVocuherType"].Value = CreatorVocuherType.SelectedValue.ToString();
                    cmd.Parameters["@CreatorNarration"].Value = "";
                    cmd.Parameters["@CreatorVocuherTotal"].Value = (Totaldr - TotalCr);
                    cmd.Parameters["@RequestToBranchId"].Value = CreatorInterBranch.SelectedValue.ConvertInt();
                    cmd.Parameters["@CreatorBranchId"].Value = SiteSession.GodownId;
                    
                    cmd.ExecuteNonQuery();

                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Successfully", "alert('Entry Successfully Save');window.location='InsterBranchEntry.aspx'", true);
                }
            }
            catch (Exception ex)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "alert('" + ex.Message + "');", true);
            }

        }
    }


    public class EntryJson
    {
        public string Ledger { get; set; }
        public string LedgerGroup { get; set; }
        public string RefrenceNo { get; set; }
        public string RefrenceAmount { get; set; }
        public string RefrenceType { get; set; }
        public string DrAmt { get; set; }
        public string CrAmt { get; set; }
    }

    public enum BILLTYPES
    {
        // Token: 0x04000242 RID: 578
        Advance,
        // Token: 0x04000243 RID: 579
        AgstReference,
        // Token: 0x04000244 RID: 580
        NewReferece,
        // Token: 0x04000245 RID: 581
        OnAccount
    }


}