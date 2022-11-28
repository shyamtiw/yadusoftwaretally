using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.admin.ReportModal;
using WebApp.LIBS;
using Business;
using System.Data;

namespace WebApp.admin
{
    public partial class CashFlowList :  BasePageClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    FromDate.Text = Common.DateTimeNow().ToString("dd/MM/yyyy");
                    ToDate.Text = Common.DateTimeNow().ToString("dd/MM/yyyy");

                    Common.BindControl(GodownId, SiteSession.GetGodawanListSession.ToList(), "Value", "Id", "All");
                    DataTable dt = FinancerOutstandingCS.CashFlowData(FromDate.Text.DateConvertTextMatchCase().ToString("dd-MMM-yyyy"), ToDate.Text.DateConvertTextMatchCase().ToString("dd-MMM-yyyy"), ToDate.Text.DateConvertTextMatchCase().ToString("dd"), string.Join(",", SiteSession.GetGodawanListSession.Select(x => x.Id.ToString()).ToArray()));
                    
                    //foreach (DataColumn dr in dt.Columns)
                    //{
                    //    if (!"Ledg_Ac".Split(',').Contains(dr.ColumnName))
                    //    {
                    //        BoundField newColumnName = new BoundField();

                    //        newColumnName.DataField = dr.ColumnName;
                    //        newColumnName.HeaderText = Common.AddSpacesToSentence(dr.ColumnName);

                    //        gvlocation.Columns.Add(newColumnName);
                    //    }


                    //}



                    gvlocation.DataSource = dt;

                    gvlocation.DataBind();
                    InfoReport.Text = "Cash Flow Report Form " + FromDate.Text + " To " + ToDate.Text + "";
                }
                catch { }
            }
        }

        protected void GetData_Click(object sender, EventArgs e)
        {
            FillTable();
        }
        

        private void FillTable()

        {

            try
            {
                string str = "";
                if (GodownId.SelectedValue != "All")
                {
                    str =  GodownId.SelectedValue;
                }
                else
                {
                    str = str + string.Join(",", SiteSession.GetGodawanListSession.Select(x => x.Id.ToString()).ToArray());
                }



                DataTable dt = FinancerOutstandingCS.CashFlowData(FromDate.Text.DateConvertTextMatchCase().ToString("dd-MMM-yyyy"), ToDate.Text.DateConvertTextMatchCase().ToString("dd-MMM-yyyy"), ToDate.Text.DateConvertTextMatchCase().ToString("dd"), str);


                InfoReport.Text = "Cash Flow Report Form "+FromDate.Text+" To "+ToDate.Text+"";

                gvlocation.DataSource = dt;

                gvlocation.DataBind();
            }
            catch { }
        }

    }
}