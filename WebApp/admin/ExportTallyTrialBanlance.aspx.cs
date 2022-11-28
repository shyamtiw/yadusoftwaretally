using Class;
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
using WebApp.TallyData;
using Business;
namespace WebApp.admin
{
    public partial class ExportTallyTrialBanlance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SiteSession.GetGodawanListSession.ForEach(x =>
                {

                    BranchId.Items.Add(new ListItem() { Text = x.Value, Value = x.Id.ToString() });

                });
            }
        }

        protected void btnsearchdata_Click(object sender, EventArgs e)
        {
            string IDs = "";
            foreach (ListItem listItem in BranchId.Items)
            {
                IDs = IDs.Length > 0 ? IDs + "," + listItem.Value : listItem.Value;
            }
            OtherSqlConn.ExequteQuey("delete  from TRIALBALANCE where GodwnId in (" + IDs + ") ");

                foreach (ListItem listItem in BranchId.Items)
            {
                if (listItem.Selected)
                {
                    DataTable dt = new DataTable();
                    var  TallyURL =SiteSession.GetGodawanListSession.Where(p => p.Id == listItem.Value.ConvertInt()).FirstOrDefault().TallyURL;
                    var Data = TrialBalanceFinalWithRecurcive.readPTallyBalanceSheet(listItem.Text, TallyURL, FromDate.Text.DateConvertTextMatchCase().ToString("yyyyMMdd"), Date.Text.DateConvertTextMatchCase().ToString("yyyyMMdd"), SiteSession.Comp_MstSession.Comp_Code.Value, listItem.Value.ConvertInt());
                    if (Data.Count > 0)
                    {
                        dt = CreateDatatable.GenericListToDataTableNullAlowed(Data.ToList());
                    }
                    try
                    {
                        getdata(dt, listItem.Value.ConvertInt());
                        Common.BindControldt(gvlocation, OtherSqlConn.FillDataTable("select (select Godw_Name from  godown_mst where godown_mst.Godw_Code=TRIALBALANCE.GodwnId) as Branch,COUNT(*) as Counts,sum((case when len(OPENINGBALANCE)>0 then convert(decimal(18,2),OPENINGBALANCE)else 0.00 end )) as OPENINGBALANCE,sum((case when len(DEBITBALANCE)>0 then convert(decimal(18,2),DEBITBALANCE)else 0.00 end )) as DEBITBALANCE,sum((case when len(CREDITBALANCE)>0 then convert(decimal(18,2),CREDITBALANCE)else 0.00 end )) as CREDITBALANCE,sum((case when len(CLOSINGBALANCE)>0 then convert(decimal(18,2),CLOSINGBALANCE)else 0.00 end )) as CLOSINGBALANCE from TRIALBALANCE where GodwnId in ("+ IDs + ") group by GodwnId "));
                    }
                    catch(Exception ex) { }
                }
                if (gvlocation.Rows.Count > 0)
                { 
                
                }
            }

        }


        private void getdata(DataTable dtDetails, int CompCode)
        {

            string constr = "Data Source="+SiteSession.DatabaseIp+";Initial Catalog="+SiteSession.DatabaseName+";persist security info=True;user id="+SiteSession.DatabseUserName+";password="+SiteSession.DatabasePassword+";multipleactiveresultsets=True;Timeout=30";;

            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("ImportTrialbalance"))
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Details", dtDetails);
                    cmd.Parameters.AddWithValue("@CompId", SiteSession.Comp_MstSession.Comp_Code);
                    cmd.Parameters.AddWithValue("@GodwnId", CompCode);
                    cmd.ExecuteNonQuery();
                }
            }

        }

    }
}