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
using System.Transactions;
using System.Data.SqlClient;

namespace WebApp.admin
{
    public partial class EntryTallyLedgergroupcategory : BasePageClass
    {
        public static DataTable dtCategory = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DataTable dt = OtherSqlConn.FillDataTable("select  distinct trim(replace(replace(parent,char(10),''),CHAR(13),'')) as  parent from ledgerGroup where CompanyId=" + SiteSession.LoginUser.Comp_Code + " and GodwnId in (" + SiteSession.GodownId + ")");
                Common.BindControldt(ParentId, dt, "parent", "parent", "Select");

                dtCategory = ConnModal.FillDataTable("select * from [Master] where MasterParentId=8");
                Common.BindControldt(Category1, dtCategory, "Name", "MasterId", "Select");
                Common.BindControldt(Category2, dtCategory, "Name", "MasterId", "Select");
                Common.BindControldt(Category3, dtCategory, "Name", "MasterId", "Select");

              


            }
        }

        protected void ParentId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ParentId.SelectedValue != "Select")
            {
                DataTable dt = OtherSqlConn.FillDataTable("select  distinct trim(replace(replace(ledgerGroupName,char(10),''),CHAR(13),'')) as ledgerGroupName from ledgerGroup where CompanyId=" + SiteSession.LoginUser.Comp_Code + " and GodwnId in (" + SiteSession.GodownId + ") and    trim(replace(replace(parent,char(10),''),CHAR(13),'')) like '%" + ParentId.SelectedValue + "%'");
                Common.BindControldt(GroupId, dt, "ledgerGroupName", "ledgerGroupName", "Select");
            }
            else
            {
                GroupId.Items.Clear();
            }

        }

        protected void Searchid_Click(object sender, EventArgs e)
        {
            if (GroupId.SelectedValue != "Select")
            {
                DataTable dt = OtherSqlConn.FillDataTable("select  top 1 *  from ledgerGroup where CompanyId=" + SiteSession.LoginUser.Comp_Code + " and GodwnId in (" + SiteSession.GodownId + ") and  trim(replace(replace(ledgerGroupName,char(10),''),CHAR(13),'')) like '%" + GroupId.SelectedValue + "%'");

                try
                {
                    try
                    {
                        Category1.SelectedValue = dt.Rows[0]["Category1"].ToString().Trim().Replace(" ", "");
                    }
                    catch { }
                    try
                    {
                        Category2.SelectedValue = dt.Rows[0]["Category2"].ToString().Trim().Trim().Replace(" ", "");
                    }
                    catch { }
                    try
                    {
                        Category3.SelectedValue = dt.Rows[0]["Category3"].ToString().Trim().Trim().Replace(" ", "");
                    }
                    catch(Exception ex) { }
                }
                catch { }
                try
                {

                    DataTable DtItem = OtherSqlConn.FillDataTable("select AutoId,ledgerName,ISNULL( Category1,0) as Category1,ISNULL( Category2,0) Category2,ISNULL( Category3,0) Category3  from ledger where  CompanyId=" + SiteSession.LoginUser.Comp_Code + " and GodwnId in (" + SiteSession.GodownId + ") and   trim(replace(replace(reservedName,char(10),''),CHAR(13),''))   like '%" + GroupId.SelectedValue + "%'");
                    Common.BindControldt(gvlocation, DtItem);
                }
                catch { }

            }
            else

            {
                GroupId.Items.Clear();
            }
        }

        protected void gvlocation_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList dllCategory1 = (e.Row.FindControl("dllCategory1") as DropDownList);
                DropDownList dllCategory2 = (e.Row.FindControl("dllCategory2") as DropDownList);
                DropDownList dllCategory3 = (e.Row.FindControl("dllCategory3") as DropDownList);

                
                HiddenField hfCategory1 = (e.Row.FindControl("Category1") as HiddenField);
                HiddenField hfCategory2 = (e.Row.FindControl("Category2") as HiddenField);
                HiddenField hfCategory3 = (e.Row.FindControl("Category3") as HiddenField);

                Common.BindControldt(dllCategory1, dtCategory, "Name", "MasterId", "Select");
                Common.BindControldt(dllCategory2, dtCategory, "Name", "MasterId", "Select");
                Common.BindControldt(dllCategory3, dtCategory, "Name", "MasterId", "Select");

                if (Common.ConvertInt(hfCategory1.Value) > 0)
                {
                    dllCategory1.Items.FindByValue(hfCategory1.Value.Trim().Replace(" ","")).Selected = true;
                }

                if (Common.ConvertInt(hfCategory2.Value) > 0)
                {
                    dllCategory2.Items.FindByValue(hfCategory2.Value.Trim().Replace(" ", "")).Selected = true;
                }

                if (Common.ConvertInt(hfCategory3.Value) > 0)
                {
                    dllCategory3.Items.FindByValue(hfCategory3.Value.Trim().Replace(" ", "")).Selected = true;
                }



            }
        }

        protected void savedata_Click(object sender, EventArgs e)
        {

            try
            {

                DataTable dtItems = new DataTable();
                dtItems.Columns.Add("AutoId", Type.GetType("System.Int32"));
                dtItems.Columns.Add("Category1", Type.GetType("System.Int32"));
                dtItems.Columns.Add("Category2", Type.GetType("System.Int32"));
                dtItems.Columns.Add("Category3", Type.GetType("System.Int32"));
                for (int x = 0; x < gvlocation.Rows.Count; x++)
                {
                    var AutoId = (gvlocation.Rows[x].FindControl("AutoId") as HiddenField).Value;
                    var dllCategory1 = (gvlocation.Rows[x].FindControl("dllCategory1") as DropDownList).SelectedValue.ConvertInt();
                    var dllCategory2 = (gvlocation.Rows[x].FindControl("dllCategory2") as DropDownList).SelectedValue.ConvertInt();
                    var dllCategory3 = (gvlocation.Rows[x].FindControl("dllCategory3") as DropDownList).SelectedValue.ConvertInt();
                    DataRow dr = dtItems.NewRow();
                    dr["AutoId"] = AutoId;
                    dr["Category1"] = dllCategory1;
                    dr["Category2"] = dllCategory2;
                    dr["Category3"] = dllCategory3;
                    dtItems.Rows.Add(dr);
                }

                using (TransactionScope trans = new TransactionScope())
                {
                    OtherSqlConn.ExequteQuey("update  ledgerGroup set Category1="+Category1.SelectedValue.ConvertInt()+ ",Category2=" + Category2.SelectedValue.ConvertInt() + ",Category3=" + Category3.SelectedValue.ConvertInt() + "  where CompanyId=" + SiteSession.LoginUser.Comp_Code + " and GodwnId in (" + SiteSession.GodownId + ") and    trim(replace(replace(ledgerGroupName,char(10),''),CHAR(13),'')) like '%" + GroupId.SelectedValue + "%'");


                
                        using (SqlCommand cmd = new SqlCommand("ImportEntryTallyLedgergroupcategory"))
                        {
                            cmd.Connection = OtherSqlConn.SqlConnection();
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@Details", dtItems);
                           
                            cmd.ExecuteNonQuery();

                        }
                    

                    trans.Complete();


                }


                //using (TransactionScope trans = new TransactionScope())
                //{
                //    getdata(dataTable);

                //    trans.Complete();
                //}


                MessageBox.ShowMessage("Success", "Successfully import data", SiteKey.MessageType.success);

               
            }
            catch (Exception ex)
            {
                String Message = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
              
                MessageBox.ShowMessage("Error", Message, SiteKey.MessageType.danger);
            }
        }
    }
}