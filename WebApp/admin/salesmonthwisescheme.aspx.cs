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
    public partial class salesmonthwisescheme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                SiteSession.FilterKeyHolder = new List<FilterKeyHolder>();
                string Scheme = Request.QueryString["Scheme"].ToString();
                string Channel = Request.QueryString["Channel"].ToString();

                int GodownId = Request.QueryString["GodownId"].ToString() != "All" ? Common.ConvertInt(Request.QueryString["GodownId"]) : 0 ;

                string str = "  DealerCode in (" + string.Join(",", SiteSession.GetGodawanListSession.Where(p => p.DlrCode.Length > 0).Select(x => "'" + x.DlrCode + "'").ToArray()) + ") and  SchemeName='"+Scheme+ "' and Channel='" + Channel + "'";
                string InnerFilter = "  b.DealerCode in (" + string.Join(",", SiteSession.GetGodawanListSession.Where(p => p.DlrCode.Length > 0).Select(x => "'" + x.DlrCode + "'").ToArray()) + ") and  b.SchemeName='" + Scheme + "' and b.Channel='" + Channel + "'";

                if (GodownId>0)
                {
                    str = str + " and b.Godw_Code="+GodownId+"";
                }

              

                var GetData = Global.Context.ExecuteStoreQuery<SalesGetAllDataMonthWise>("select x.*,'<a style=''color: black;''href=''#'' onclick= \"showLeter(''showsaleexceldata.aspx?id='+x.AllId+''')\">'+SchemeMonth+'</a>' as ShowName,(TotalClaim-(TotalCredit+Recovered+Rejected)) as Balance from  (select SchemeMonth,SchemeName,SUM((Case when len(ISNULL(Incentive,''))>0 then CONVERT(decimal(10,2),Incentive) else CONVERT(decimal(10,2),0.00)  end )) as Incentive,SUM((Case when len(ISNULL(GSTAmt,''))>0 then CONVERT(decimal(10,2),GSTAmt) else CONVERT(decimal(10,2),0.00)  end )) as GSTAmt,(SUM((Case when len(ISNULL(Incentive,''))>0 then CONVERT(decimal(10,2),Incentive) else CONVERT(decimal(10,2),0.00)  end ))+SUM((Case when len(ISNULL(GSTAmt,''))>0 then CONVERT(decimal(10,2),GSTAmt) else CONVERT(decimal(10,2),0.00)  end )) ) as TotalClaim,SUM((Case when len(ISNULL(TotalCredit,''))>0 then CONVERT(decimal(10,2),TotalCredit) else CONVERT(decimal(10,2),0.00)  end )) as TotalCredit, SUM((Case when len(ISNULL(Recovered,''))>0 then CONVERT(decimal(10,2),Recovered) else CONVERT(decimal(10,2),0.00)  end )) as Recovered, SUM((Case when len(ISNULL(Rejected,''))>0 then CONVERT(decimal(10,2),Rejected) else CONVERT(decimal(10,2),0.00) end )) as Rejected, AllId=  STUFF((SELECT ', ' + CONVERT(nvarchar(150), ImportExcelId) FROM [ImportExcel] b  WHERE b.SchemeMonth = [ImportExcel].SchemeMonth and b.SchemeName = [ImportExcel].SchemeName     and "+ InnerFilter + "  FOR XML PATH('')), 1, 2, '') from [ImportExcel]  where "+str+"   group by SchemeMonth,SchemeName)  as x  order by  CONVERT(date,('01-'+SchemeMonth)) asc").ToList();

                var Challnel = GetData.GroupBy(p => p.SchemeName).Select(p => new { SchemeName = p.Key }).ToList();
                string Table = "<table  style='width:100%' class='t02 t01'><tr><th>Scheme Month</th><th>Incentive</th><th>GSTAmt</th><th>TotalClaim</th><th>TotalCredit</th><th>Rejected</th><th>Recovered</th><th>Balance</th></tr>";
                Challnel.ForEach(ch =>
                {

                    Table = Table + "<tr style='background-color: navy;    color: white;'><td><h4>" + ch.SchemeName + "</h4></td><td colspan='7'></td></tr>";
                    var SchemeData = GetData.Where(c => c.SchemeName == ch.SchemeName).ToList();
                    SchemeData.ForEach(sd =>
                    {
                        var Ids = Guid.NewGuid().ToString() + DateTime.Now.Ticks.ToString();
                        SiteSession.FilterKeyHolder.Add(new FilterKeyHolder() { Key=Ids, Value=sd.AllId });
                     Table = Table + "<tr>" +
    "<td>" + "<a style='color: black;' href='#' onclick= \"showLeter('showsaleexceldata.aspx?id="+ Ids + "')\">"+sd.SchemeMonth+"</a>" + "</td>" +
    "<td>" + sd.Incentive + " </td>" +
    "<td>" + sd.GSTAmt + " </td>" +
    "<td>" + sd.TotalClaim + "</td>" +
    "<td>" + sd.TotalCredit + "</td>" +
    "<td>" + sd.Rejected + "</td>" +
    "<td>" + sd.Recovered + "</td>" +
    "<td>" + sd.Balance + "</td>" +
    "</tr>";

                    });

                    Table = Table + "<tr  style = 'background-color: red;color: white;'>" +
    "<td><b>Total</b></td>" +
    "<td><b>" + SchemeData.Sum(vb => vb.Incentive).ToString() + " </b></td>" +
    "<td><b>" + SchemeData.Sum(vb => vb.GSTAmt).ToString() + " </b></td>" +
    "<td><b>" + SchemeData.Sum(vb => vb.TotalClaim).ToString() + " </b></td>" +
    "<td><b>" + SchemeData.Sum(vb => vb.TotalCredit).ToString() + " </b></td>" +
    "<td><b>" + SchemeData.Sum(vb => vb.Rejected).ToString() + " </b></td>" +
    "<td><b>" + SchemeData.Sum(vb => vb.Recovered).ToString() + " </b></td>" +
    "<td><b>" + SchemeData.Sum(vb => vb.Balance).ToString() + " </b></td>" +
    "</tr>";


                });



                Table = Table + "</table>";

                ShowData.Text = Table;
            }
        }
    }
}



public partial class SalesGetAllDataMonthWise
{
    public string SchemeMonth { get; set; }
    public string SchemeName { get; set; }
    public string AllId { get; set; }
    public string ShowName { get; set; }
    public decimal Incentive { get; set; }
    public decimal GSTAmt { get; set; }
    public decimal TotalClaim { get; set; }
    public decimal TotalCredit { get; set; }
    public decimal Recovered { get; set; }
    public decimal Rejected { get; set; }
    public decimal Balance { get; set; }

}

public class FilterKeyHolder {
public string Key { get; set; }
    public string Value { get; set; }
}