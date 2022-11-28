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
    public partial class TallyReconciliationReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

              
                    SiteSession.GetGodawanListSession.ToList().ForEach(x =>
                    {

                        BranchId.Items.Add(new ListItem() { Text = x.Value, Value = x.Id.ToString() });

                    });
                
            }
        }

        protected void exportdata_Click(object sender, EventArgs e)
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
                List<voucherRecoData> Listdata = DataMangementJsonTwoData.GetDGetData(FromDate.Text.DateConvertTextMatchCase(), Date.Text.DateConvertTextMatchCase(), IDS.ConvertInt());
             var DTX= CreateDatatable.Create(Listdata.ToList());
                ExportExcel(DTX);
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
    }
}