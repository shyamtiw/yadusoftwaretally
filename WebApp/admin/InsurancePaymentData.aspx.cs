using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
using Business;
using System.Data;
using WebApp.admin.ReportModal;

namespace WebApp.admin
{
    public partial class InsurancePaymentData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void GetData_Click(object sender, EventArgs e)
        {
            DataTable dt = ConsolidateInsurancePaymentList.PaymentListAllData(FromDate.Text.DateConvertTextMatchCase().ToString("dd-MMM-yyyy"), ToDate.Text.DateConvertTextMatchCase().ToString("dd-MMM-yyyy"));
            foreach (DataColumn dr in dt.Columns)
            {
                if (!"InsuranceIndividualId".Split(',').Contains(dr.ColumnName))
                {
                    BoundField newColumnName = new BoundField();

                    newColumnName.DataField = dr.ColumnName;
                    newColumnName.HeaderText = Common.AddSpacesToSentence(dr.ColumnName);

                    gvlocation.Columns.Add(newColumnName);
                }


            }

            //HiddenField lnkView = new HiddenField();
            //lnkView.ID = "lnkView";
            //lnkView.Text = "View";
            //lnkView.Click += ViewDetails;
            //lnkView.CommandArgument = (e.Row.DataItem as DataRowView).Row["Id"].ToString();
            //e.Row.Cells[2].Controls.Add(lnkView);



            gvlocation.DataSource = dt;

            gvlocation.DataBind();
        }
    }
}