using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
using Business;
using System.Drawing;
using System.Text;
using System.Data;
using Newtonsoft.Json;
using Jitbit.Utils;

namespace WebApp.admin
{
    public partial class AutoDebitStatementMain : BasePageClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Common.BindControl(GodownId, SiteSession.GetGodawanListSession.ToList(), "Value", "Id", "All");
           
            }
        }

        private void filterdata()
        {

            string str = "  where Comp_Code=" + SiteSession.Comp_MstSession.Comp_Code.Value.ToString() + " ";
            string PriviusDate = "";
            SiteSession.FilterKeyHolderResponce = new List<FilterKeyHolder>();
            if (GodownId.SelectedValue != "All")
            {
                str = str + " and  Godw_Code=" + GodownId.SelectedValue + "";
            }
            else
            {
                str = str + " and  Godw_Code in (" + string.Join(",", SiteSession.GetGodawanListSession.Select(x => x.Id.ToString()).ToArray()) + ")";
            }


            if (FromDate.Text.Length > 0 && ToDate.Text.Length > 0)
            {
                str = str + " and CONVERT(Date,TRANSAMNTDEDUCTIONDATE)  between '" + FromDate.Text.DateConvertText().ToString("dd-MMM-yyyy") + "' and '" + ToDate.Text.DateConvertText().ToString("dd-MMM-yyyy") + "' ";
                PriviusDate = " and CONVERT(Date,TRANSAMNTDEDUCTIONDATE)  between '31-Dec-2010' and '" + FromDate.Text.DateConvertText().AddDays(-1).Date.ToString("dd-MMM-yyyy") + "'";
            }
           
            string strtript = "select TRANSACTIONOUTLET,DebitAmount,CreditAmount,ReversalAmount,isnull(Opening,0.00) as OpenBalance,((isnull(CreditAmount,0.00)+isnull(ReversalAmount,0.00)+isnull(Opening,0.00))-DebitAmount) as CloseBalance from (select TRANSACTIONOUTLET ,(select  (ISNULL( Sum((Case when Upper(isnull(TRANSACTIONTYPE,''))=upper('CREDIT/Credit/Adjust') then TRANSACTIONAMOUNT else 0.00 end )),0.00) +isnull(Sum( (Case when Upper(isnull(TRANSACTIONTYPE,''))=upper('Credit/Deposit')then TRANSACTIONAMOUNT else 0.00 end )),0.00))-isnull(Sum( (Case when Upper(isnull(TRANSACTIONTYPE,''))=upper('DEBIT/Debit/Invoice') then TRANSACTIONAMOUNT*-01 else 0.00 end )),0.00) as DebitAmount  from [AutoDebitImport] where [AutoDebitImport].TRANSACTIONOUTLET=x.TRANSACTIONOUTLET "+PriviusDate+" ) as Opening, Sum( (Case when Upper(isnull(TRANSACTIONTYPE,''))=upper('CREDIT/Credit/Adjust') then TRANSACTIONAMOUNT else 0.00 end )) as ReversalAmount,Sum( (Case when Upper(isnull(TRANSACTIONTYPE,''))=upper('Credit/Deposit')then TRANSACTIONAMOUNT else 0.00 end )) as CreditAmount,Sum( (Case when Upper(isnull(TRANSACTIONTYPE,''))=upper('DEBIT/Debit/Invoice') then TRANSACTIONAMOUNT*-01 else 0.00 end )) as DebitAmount from  (select * from  [AutoDebitImport] "+str+") as x group by TRANSACTIONOUTLET  ) as x";

            var obj = Global.Context.ExecuteStoreQuery<AutoDebitEntry>(strtript).ToList();

          
            obj.ForEach(x =>
            {
                string Key = Guid.NewGuid().ToString() + DateTime.Now.Ticks.ToString();
                SiteSession.FilterKeyHolderResponce.Add(new FilterKeyHolder() { Key = Key, Value =(x.TRANSACTIONOUTLET+"!"+FromDate.Text+"!"+ToDate.Text+"!"+x.OpenBalance.ToString()) });
                x.Key = "<a style='color: navy;' href='#' onclick= \"showLeter('autodebitdatewise.aspx?id=" + Key + "')\">View</a>";
            });


            Common.BindControl(gvlocation, obj.ToList());

        }
        protected void GetData_Click(object sender, EventArgs e)
        {
            filterdata();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
    }
}


public partial class AutoDebitEntry
{
 
    public string TRANSACTIONOUTLET { get; set; }
    public decimal DebitAmount { get; set; }
    public decimal CreditAmount { get; set; }
    public decimal ReversalAmount { get; set; }
    public decimal OpenBalance { get; set; }
    public decimal CloseBalance { get; set; }
  
    public string Key { get; set; }
  
}
