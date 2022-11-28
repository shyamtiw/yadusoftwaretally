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
    public partial class E_IndusvalinsuranceList : BasePageClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Common.BindControl(gvlocation, Global.Context.ExecuteStoreQuery<ListDataEInduInsurance>("select * from ECoupanEntry where CompId=" + SiteSession.Comp_MstSession.Comp_Code + " and CreateDate between '" + Common.DateTimeNow().AddDays(-5).ToString("dd-MMM-yyyy") + "' and  '" + Common.DateTimeNow().ToString("dd-MMM-yyyy") + "'").ToList());
            }
        }


        protected void GetData_Click(object sender, EventArgs e)
        {

            try
            {

                Common.BindControl(gvlocation, Global.Context.ExecuteStoreQuery<ListDataEInduInsurance>("select * from ECoupanEntry where CompId=" + SiteSession.Comp_MstSession.Comp_Code + " and CreateDate between '" + FromDate.Text.DateConvertTextMatchCase().ToString("dd-MMM-yyyy") + "' and  '" + ToDate.Text.DateConvertTextMatchCase().ToString("dd-MMM-yyyy") + "' ").ToList());
            }
            catch { }
        }
    }
}

public partial class ListDataEInduInsurance
{
    public int ECoupanEntryId { get; set; }

    public string CustomerName { get; set; }
    public DateTime? CreateDate { get; set; }
    public string CustomerMobileNo { get; set; }
    public string VehicleRegnNo { get; set; }
   

}