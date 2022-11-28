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
    public partial class autodebitdatewise : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    //x.TRANSACTIONOUTLET + "!" + FromDate.Text + "!" + ToDate.Text + "!" + x.OpenBalance.ToString()
                    string[] val = SiteSession.FilterKeyHolderResponce.Where(p => p.Key == Request.QueryString["id"].ToString()).FirstOrDefault().Value.Split('!');
                    var TRANSACTIONOUTLET = val[0].ToString();
                    var FromDate = val[1].ToString().DateConvertTextMatchCase();
                    var ToDate = val[2].ToString().DateConvertTextMatchCase();
                    var OpenBalance = val[3].ToString().ConvertDecimal();

                    string str = "select  [Key]=   STUFF((SELECT ', ' + CONVERT(varchar(10),b.AutoDebitImportId) FROM [AutoDebitImport] b WHERE  CONVERT(Date,b.TRANSAMNTDEDUCTIONDATE) = CONVERT(Date,a.TRANSAMNTDEDUCTIONDATE) and b.TRANSACTIONOUTLET=" + TRANSACTIONOUTLET + "  FOR XML PATH('')), 1, 2, '') ,MAX(TRANSACTIONOUTLET) as TRANSACTIONOUTLET, CONVERT(Date,TRANSAMNTDEDUCTIONDATE) [Date],Sum( (Case when Upper(isnull(TRANSACTIONTYPE,''))=upper('CREDIT/Credit/Adjust') then TRANSACTIONAMOUNT else 0.00 end )) as ReversalAmount,Sum( (Case when Upper(isnull(TRANSACTIONTYPE,''))=upper('Credit/Deposit')then TRANSACTIONAMOUNT else 0.00 end )) as CreditAmount,Sum( (Case when Upper(isnull(TRANSACTIONTYPE,''))=upper('DEBIT/Debit/Invoice') then TRANSACTIONAMOUNT*-01 else 0.00 end )) as DebitAmount from  [AutoDebitImport] as a   where TRANSACTIONOUTLET=" + TRANSACTIONOUTLET + "   and  CONVERT(Date,TRANSAMNTDEDUCTIONDATE) between '" + FromDate.ToString("dd-MMM-yyyy") + "' and '" + ToDate.ToString("dd-MMM-yyyy") + "'  group by CONVERT(Date,TRANSAMNTDEDUCTIONDATE)";
                    bool First = true;
                    var Obj = Global.Context.ExecuteStoreQuery<DateWiseAutoDebitReport>(str).ToList();


                    var dates = new List<DateTime>();
                    var ListItem = new List<DateWiseAutoDebitReport>();
                    for (var dt = FromDate; dt <= ToDate; dt = dt.AddDays(1))
                    {
                        dates.Add(dt);
                    }
                    decimal lastOpening = 0m;
                    dates.ForEach(x =>
                    {
                        var item = new DateWiseAutoDebitReport();
                        item.Date = x.Date;
                        if (First)
                        {
                            item.OpenBalance = OpenBalance;
                            First = false;
                            lastOpening = OpenBalance;
                        }
                        else
                        {
                            item.OpenBalance = lastOpening;
                        }

                        if (Obj.Where(p => p.Date.Date == x.Date).Count() > 0)
                        {
                            item.CreditAmount = Obj.Where(p => p.Date.Date == x.Date).FirstOrDefault().CreditAmount;
                            item.DebitAmount = Obj.Where(p => p.Date.Date == x.Date).FirstOrDefault().DebitAmount;
                            item.ReversalAmount = Obj.Where(p => p.Date.Date == x.Date).FirstOrDefault().ReversalAmount;
                            var Ids = Guid.NewGuid().ToString() + DateTime.Now.Ticks.ToString();
                            item.Key = Ids;
                         
                            SiteSession.FilterKeyHolderResponce.Add(new  FilterKeyHolder() { Key = Ids, Value = Obj.Where(p => p.Date.Date == x.Date).FirstOrDefault().Key });

                        }
                        else
                        {

                            item.CreditAmount = 0m;
                            item.DebitAmount = 0m;
                            item.ReversalAmount = 0m;

                            item.Key = "";
                        }


                        item.CloseBalance = ((item.CreditAmount + item.ReversalAmount + item.OpenBalance) - item.DebitAmount).Value;

                        lastOpening = item.CloseBalance.Value;
                        ListItem.Add(item);
                    });

                    string Table = "<table  style='width:100%' class='t02 t01'><tr><th>Date</th><th>Debit Amount</th><th>Credit Amount</th><th>Reversal Amount</th><th>Open Balance</th><th>Close Balance</th><th>View</th></tr>";
                    ListItem.ForEach(sd =>
                    {
                      
                        Table = Table + "<tr>" +

       "<td>" + sd.Date.ToString("dd-MM-yyyy") + " </td>" +
       "<td>" + sd.DebitAmount + " </td>" +
       "<td>" + sd.CreditAmount + "</td>" +
       "<td>" + sd.ReversalAmount + "</td>" +
       "<td>" + sd.OpenBalance + "</td>" +
       "<td>" + sd.CloseBalance + "</td>" +

                            "<td>" + (sd.Key.Length > 0 ? "<a style='color: navy;' href='#' onclick= \"showLeter('autodebitdatewiseexcel.aspx?id=" + sd.Key + "')\">View</a>" : "") + "</td>" +

       "</tr>";
                    });



                    Table = Table + "</table>";

                    ShowData.Text = Table;

                }
            }
        }



    }
}

public class DateWiseAutoDebitReport
{

    public string TRANSACTIONOUTLET { get; set; }

    public string Key { get; set; }
    public DateTime Date { get; set; }
    public decimal? DebitAmount { get; set; }
    public decimal? CreditAmount { get; set; }
    public decimal? ReversalAmount { get; set; }
    public decimal? OpenBalance { get; set; }
    public decimal? CloseBalance { get; set; }


}