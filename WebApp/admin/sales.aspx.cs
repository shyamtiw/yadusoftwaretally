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
    public partial class sales : BasePageClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                var SchemeData = Global.Context.ExecuteStoreQuery<KeyValues>("select Valuess from  (select SchemeName as Valuess   from [ImportExcel] group by SchemeName ) as x   order by Valuess asc");
                Common.BindControl(Scheme, SchemeData.ToList(), "Valuess", "Valuess", "All");

                var ChannelList = Global.Context.ExecuteStoreQuery<KeyValues>("select Valuess from  (select Channel as Valuess   from [ImportExcel] group by Channel ) as x   order by Valuess asc");
                Common.BindControl(Channel, ChannelList.ToList(), "Valuess", "Valuess", "All");


                Common.BindControl(GodownId, SiteSession.GetGodawanListSession.ToList(), "Value", "Id", "All");

            }
        }

        protected void savecompnay_Click(object sender, EventArgs e)
        {
            
            string str = " where DealerCode in ("+ string.Join(",", SiteSession.GetGodawanListSession.Where(p => p.DlrCode.Length > 0).Select(x => "'" + x.DlrCode + "'").ToArray())+")";
            if (Scheme.SelectedValue != "All")
            {
                str = str + "and SchemeName='" + Scheme.SelectedValue + "'";
            }

            if (Channel.SelectedValue != "All")
            {
                str = str + "and Channel='" + Channel.SelectedValue + "'";
            }

            if (Channel.SelectedValue != "All")
            {
                str = str + "and Channel='" + Channel.SelectedValue + "'";
            }

            if (GodownId.SelectedValue != "All")
            {
                str = str + "and Godw_Code=" + GodownId.SelectedValue + "";
            }

            var GetData = Global.Context.ExecuteStoreQuery<GetAllData>("select x.*,'<a style=''color: black;'' href=''#'' onclick= \"showLeter(''salesmonthwisescheme.aspx?Channel='+x.Channel+'&&Scheme='+SchemeName+'&&GodownId=" + GodownId.SelectedValue + "'')\">'+SchemeName+'</a>' as ShowName,(TotalClaim-(TotalCredit+Recovered+Rejected)) as Balance from  (select Channel,SchemeName,SUM((Case when len(ISNULL(Incentive,''))>0 then CONVERT(decimal(10,2),Incentive) else CONVERT(decimal(10,2),0.00)  end )) as Incentive,SUM((Case when len(ISNULL(GSTAmt,''))>0 then CONVERT(decimal(10,2),GSTAmt) else CONVERT(decimal(10,2),0.00)  end )) as GSTAmt,(SUM((Case when len(ISNULL(Incentive,''))>0 then CONVERT(decimal(10,2),Incentive) else CONVERT(decimal(10,2),0.00)  end ))+SUM((Case when len(ISNULL(GSTAmt,''))>0 then CONVERT(decimal(10,2),GSTAmt) else CONVERT(decimal(10,2),0.00)  end )) ) as TotalClaim,SUM((Case when len(ISNULL(TotalCredit,''))>0 then CONVERT(decimal(10,2),TotalCredit) else CONVERT(decimal(10,2),0.00)  end )) as TotalCredit, SUM((Case when len(ISNULL(Recovered,''))>0 then CONVERT(decimal(10,2),Recovered) else CONVERT(decimal(10,2),0.00)  end )) as Recovered, SUM((Case when len(ISNULL(Rejected,''))>0 then CONVERT(decimal(10,2),Rejected) else CONVERT(decimal(10,2),0.00) end )) as Rejected from [ImportExcel]  " + str + " group by Channel,SchemeName)  as x").ToList();

            var Challnel = GetData.GroupBy(p => p.Channel).Select(p => new { Channel = p.Key }).ToList();
            string Table = "<table  style='width:100%' class='t02 t01'><tr><th>Channel</th><th>Incentive</th><th>GSTAmt</th><th>TotalClaim</th><th>TotalCredit</th><th>Rejected</th><th>Recovered</th><th>Balance</th></tr>";
            Challnel.ForEach(ch =>
            {

                Table = Table + "<tr style='background-color: navy;    color: white;'><td><h4>" + ch.Channel + "</h4></td><td colspan='7'></td></tr>";
                var SchemeData = GetData.Where(c => c.Channel == ch.Channel).ToList();
                SchemeData.ForEach(sd =>
                {
                    Table = Table + "<tr>" +
"<td>" + sd.ShowName + "</td>" +

"<td "+(Common.IsNegative(sd.Incentive)? "style='background-color: #dfe94a;'":"") + " >" + sd.Incentive + " </td>" +
"<td " + (Common.IsNegative(sd.GSTAmt) ? "style='background-color: #dfe94a;'" : "") + ">" + sd.GSTAmt + " </td>" +
"<td " + (Common.IsNegative(sd.TotalClaim) ? "style='background-color: #dfe94a;'" : "") + ">" + sd.TotalClaim + "</td>" +
"<td " + (Common.IsNegative(sd.TotalCredit) ? "style='background-color: #dfe94a;'" : "") + ">" + sd.TotalCredit + "</td>" +
"<td " + (Common.IsNegative(sd.Rejected) ? "style='background-color: #dfe94a;'" : "") + ">" + sd.Rejected + "</td>" +
"<td " + (Common.IsNegative(sd.Recovered) ? "style='background-color: #dfe94a;'" : "") + ">" + sd.Recovered + "</td>" +
"<td " + (Common.IsNegative(sd.Balance) ? "style='background-color: #dfe94a;'" : "") + ">" + sd.Balance + "</td>" +
"</tr>";

                });

                Table = Table + "<tr>" +
"<td><b>Total</b></td>" +
"<td  " + (Common.IsNegative(SchemeData.Sum(vb => vb.Incentive)) ? "style='background-color: #dfe94a;'" : "") + "><b>" + SchemeData.Sum(vb => vb.Incentive).ToString() + " </b></td>" +
"<td  " + (Common.IsNegative(SchemeData.Sum(vb => vb.Incentive)) ? "style='background-color: #dfe94a;'" : "") + "><b>" + SchemeData.Sum(vb => vb.GSTAmt).ToString() + " </b></td>" +
"<td  " + (Common.IsNegative(SchemeData.Sum(vb => vb.Incentive)) ? "style='background-color: #dfe94a;'" : "") + "><b>" + SchemeData.Sum(vb => vb.TotalClaim).ToString() + " </b></td>" +
"<td  " + (Common.IsNegative(SchemeData.Sum(vb => vb.Incentive)) ? "style='background-color: #dfe94a;'" : "") + "><b>" + SchemeData.Sum(vb => vb.TotalCredit).ToString() + " </b></td>" +
"<td  " + (Common.IsNegative(SchemeData.Sum(vb => vb.Incentive)) ? "style='background-color: #dfe94a;'" : "") + "><b>" + SchemeData.Sum(vb => vb.Rejected).ToString() + " </b></td>" +
"<td  " + (Common.IsNegative(SchemeData.Sum(vb => vb.Incentive)) ? "style='background-color: #dfe94a;'" : "") + "><b>" + SchemeData.Sum(vb => vb.Recovered).ToString() + " </b></td>" +
"<td  " + (Common.IsNegative(SchemeData.Sum(vb => vb.Incentive)) ? "style='background-color: #dfe94a;'" : "") + "><b>" + SchemeData.Sum(vb => vb.Balance).ToString() + " </b></td>" +
"</tr>";


            });

            if (GetData.Count > 0)
            {

                Table = Table + "<tr style='background-color: red;color: white;'>" +
    "<td><b>Grand Total</b></td>" +
    "<td><b>" + GetData.Sum(vb => vb.Incentive).ToString() + " </b></td>" +
    "<td><b>" + GetData.Sum(vb => vb.GSTAmt).ToString() + " </b></td>" +
    "<td><b>" + GetData.Sum(vb => vb.TotalClaim).ToString() + " </b></td>" +
    "<td><b>" + GetData.Sum(vb => vb.TotalCredit).ToString() + " </b></td>" +
    "<td><b>" + GetData.Sum(vb => vb.Rejected).ToString() + " </b></td>" +
    "<td><b>" + GetData.Sum(vb => vb.Recovered).ToString() + " </b></td>" +
    "<td><b>" + GetData.Sum(vb => vb.Balance).ToString() + " </b></td>" +
    "</tr>";
            }


            Table = Table + "</table>";

            ShowData.Text = Table;

        }
    }
}


public partial class GetAllData
{
    public string Channel { get; set; }
    public string SchemeName { get; set; }
    public string ShowName { get; set; }
    public decimal Incentive { get; set; }
    public decimal GSTAmt { get; set; }
    public decimal TotalClaim { get; set; }
    public decimal TotalCredit { get; set; }
    public decimal Recovered { get; set; }
    public decimal Rejected { get; set; }
    public decimal Balance { get; set; }

}

public partial class KeyValues
{
    public string Valuess { get; set; }
}


