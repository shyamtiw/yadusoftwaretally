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
    public partial class showsaleexceldata : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
                {
                    
                    var obj = Global.Context.ExecuteStoreQuery<GetDataShowSalesExcel>("select DealerCode,MODELCODE,INVOICEDATE,Vin,Incentive,GSTAmt,TotalClaim,TrxID,CrNoted,CrDate,CrAmt,CrTax,TotalCredit, Recovered,Rejected,Balance=TotalClaim-(TotalCredit+Recovered+Rejected),Channel,City1,SchemeName,SchemeMonth from ( select DealerCode,MODELCODE,INVOICEDATE,Vin,TrxID,CrNoted,(Case when len(ISNULL(Incentive,''))>0 then CONVERT(decimal(10,2),Incentive) else CONVERT(decimal(10,2),0.00)  end ) as Incentive,(Case when len(ISNULL(GSTAmt,''))>0 then CONVERT(decimal(10,2),GSTAmt) else CONVERT(decimal(10,2),0.00)  end ) as GSTAmt,((Case when len(ISNULL(Incentive,''))>0 then CONVERT(decimal(10,2),Incentive) else CONVERT(decimal(10,2),0.00)  end )+(Case when len(ISNULL(GSTAmt,''))>0 then CONVERT(decimal(10,2),GSTAmt) else CONVERT(decimal(10,2),0.00)  end ) ) as TotalClaim,CrDate,(Case when len(ISNULL(CrAmt,''))>0 then CONVERT(decimal(10,2),CrAmt) else CONVERT(decimal(10,2),0.00)  end ) as CrAmt,(Case when len(ISNULL(CrTax,''))>0 then CONVERT(decimal(10,2),CrTax) else CONVERT(decimal(10,2),0.00)  end ) as CrTax,(Case when len(ISNULL(TotalCredit,''))>0 then CONVERT(decimal(10,2),TotalCredit) else CONVERT(decimal(10,2),0.00)  end ) as TotalCredit, (Case when len(ISNULL(Recovered,''))>0 then CONVERT(decimal(10,2),Recovered) else CONVERT(decimal(10,2),0.00)  end ) as Recovered, (Case when len(ISNULL(Rejected,''))>0 then CONVERT(decimal(10,2),Rejected) else CONVERT(decimal(10,2),0.00) end ) as Rejected,Channel , City1, SchemeName, SchemeMonth from ImportExcel where ImportExcelId in (" + SiteSession.FilterKeyHolder.Where(p => p.Key == Request.QueryString["id"].ToString()).FirstOrDefault().Value + ") ) as x order by  INVOICEDATE asc").ToList();


                    string Table = "<table  style='width:100%' class='t02 t01'><tr><th>Dealer Code</th><th>Model Code</th><th>Invoice Date</th><th>VIN</th><th>Incentive</th><th>GST Amt.</th><th>Total Claim</th><th>TrxID</th><th>Cr. Noted</th><th>Cr. Date</th><th>Cr. Amt.</th><th>Cr. Tax</th><th>Total Credit</th><th>Recovered</th><th>Rejected</th><th>Balance</th><th>Channel</th><th>Scheme Name</th><th>Scheme Month</th></tr>";


                    obj.ForEach(sd =>
                    {
                        Table = Table + "<tr>" +
   "<td>" + sd.DealerCode + "</td>" +
"<td>" + sd.MODELCODE + " </td>" +
"<td>" + sd.INVOICEDATE.ToString("dd-MM-yyyy") + " </td>" +
"<td>" + sd.Vin + "</td>" +
"<td>" + sd.Incentive + "</td>" +
"<td>" + sd.GSTAmt + "</td>" +
"<td>" + sd.TotalClaim + "</td>" +
"<td>" + sd.TrxID + "</td>" +
"<td>" + sd.CrNoted + "</td>" +
"<td>" + sd.CrDate.ToString("dd-MM-yyyy") + "</td>" +
"<td>" + sd.CrAmt + "</td>" +
"<td>" + sd.CrTax + "</td>" +
"<td>" + sd.TotalCredit + "</td>" +
"<td>" + sd.Recovered + "</td>" +
"<td>" + sd.Rejected + "</td>" +
"<td>" + sd.Balance + "</td>" +
"<td>" + sd.Channel + "</td>" +

"<td>" + sd.SchemeName + "</td>" +
"<td>" + sd.SchemeMonth + "</td>" +
    "</tr>";

                    });
                   

                    Table = Table + "<tr style='background-color: red;color: white'>" +
   "<td colspan=4   style=' text-align: right'><b>Summery : </b></td>" +

"<td><b>" + obj.Sum(p => p.Incentive).ToString() + "</b></td>" +
"<td><b>" + obj.Sum(p => p.GSTAmt).ToString() + "</b></td>" +
"<td><b>" + obj.Sum(p => p.TotalClaim).ToString() + "</b></td>" +
"<td> </td>" +
"<td> </td>" +
"<td> </td>" +
"<td><b>" + obj.Sum(p => p.CrAmt).ToString() + "</b></td>" +
"<td><b>" + obj.Sum(p => p.CrTax).ToString() + "</b></td>" +
"<td><b>" + obj.Sum(p => p.TotalCredit).ToString() + "</b></td>" +
"<td><b>" + obj.Sum(p => p.Recovered).ToString() + "</b></td>" +
"<td><b>" + obj.Sum(p => p.Rejected).ToString() + "</b></td>" +
"<td><b>" + obj.Sum(p => p.Balance).ToString() + "</b></td>" +
"<td> </td>" +
"<td> </td>" +

"<td> </td>" +
    "</tr></table>";

                    ShowData.Text = Table;


                }
            }
        }
    }
}

public partial class GetDataShowSalesExcel
{
    public string DealerCode { get; set; }
    public string MODELCODE { get; set; }
    public DateTime INVOICEDATE { get; set; }
    public string Vin { get; set; }
    public decimal Incentive { get; set; }
    public decimal GSTAmt { get; set; }
    public decimal TotalClaim { get; set; }
    public string TrxID { get; set; }
    public string CrNoted { get; set; }
    public DateTime CrDate { get; set; }
    public decimal CrAmt { get; set; }
    public decimal CrTax { get; set; }
    public decimal TotalCredit { get; set; }
    public decimal Recovered { get; set; }
    public decimal Rejected { get; set; }
    public decimal Balance { get; set; }


    public string Channel { get; set; }
    public string City1 { get; set; }
    public string SchemeName { get; set; }
    public string SchemeMonth { get; set; }
}