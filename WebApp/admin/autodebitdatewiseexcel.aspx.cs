using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
using Business;
namespace WebApp.admin
{
    public partial class autodebitdatewiseexcel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    //x.TRANSACTIONOUTLET + "!" + FromDate.Text + "!" + ToDate.Text + "!" + x.OpenBalance.ToString()
                    string val = SiteSession.FilterKeyHolderResponce.Where(p => p.Key == Request.QueryString["id"].ToString()).FirstOrDefault().Value;


                    string str = "select REQUESTID,POLICYNO,TRANSACTIONID,CUSTOMERNAME,REGISTRATIONNO,TRANSACTIONOUTLET,TRANSACTIONTYPE,TRANSACTIONAMOUNT,DESCRIPTION,TRANSAMNTDEDUCTIONDATE from  AutoDebitImport  where AutoDebitImportId in (" + val + ")";

                    var ListItem = Global.Context.ExecuteStoreQuery<DateWiseAutoDebitReportExcel>(str).ToList();




                    string Table = "<table  style='width:100%' class='t02 t01'><tr><th>REQUEST ID</th><th>POLICY NO</th><th>TRANSACTIONID</th><th>CUSTOMER NAME</th><th>REGISTRATION NO</th><th>TRANSACTION OUTLET</th><th>TRANSACTION TYPE</th><th> AMOUNT</th><th>DESCRIPTION</th><th>Date</th></tr>";
                    ListItem.ForEach(sd =>
                    {

                        Table = Table + "<tr>" +

     "<td>"+ sd.REQUESTID+"</td>"+
"<td>"+ sd.POLICYNO+"</td>"+
"<td>"+ sd.TRANSACTIONID+"</td>"+
"<td>"+ sd.CUSTOMERNAME+"</td>"+
"<td>"+ sd.REGISTRATIONNO+"</td>"+
"<td>"+ sd.TRANSACTIONOUTLET+"</td>"+
"<td>"+ sd.TRANSACTIONTYPE+"</td>"+
"<td>"+ sd.TRANSACTIONAMOUNT+"</td>"+
"<td>"+ sd.DESCRIPTION+"</td>"+
"<td>"+ sd.TRANSAMNTDEDUCTIONDATE.ToString("dd-MM-yyyy")+"</td>"+
       "</tr>";
                    });



                    Table = Table + "</table>";

                    ShowData.Text = Table;

                }
            }
        }
    }
}


public class DateWiseAutoDebitReportExcel
{

    public string REQUESTID { get; set; }

    public string POLICYNO { get; set; }
    public DateTime TRANSAMNTDEDUCTIONDATE { get; set; }
    public string TRANSACTIONID { get; set; }
    public string CUSTOMERNAME { get; set; }

    public string REGISTRATIONNO { get; set; }
    public string TRANSACTIONOUTLET { get; set; }
    public string TRANSACTIONTYPE { get; set; }
    public decimal TRANSACTIONAMOUNT { get; set; }
    public string DESCRIPTION { get; set; }



}