using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
using Business;
using WebApp.admin.ReportModal;
using System.Data;

namespace WebApp.admin.print
{
    public partial class E_MultipalSendUsingWithoutLinq : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                

                DataTable Coupon = ConnModal.FillDataTable("select x.Code,Name,IssueDate,PolicyExpiryDate,CustomerName,MobNo,VehicleRegnNo,DealersExecutive,'' ChassisNo,'' EngineNo,[Description]  from (select * from E_InsuranceCoupon where InsuranceCouponId in (" + Request.QueryString["Id"].ToString() + ")) as x left join [Master] on x.MasterId=[Master].MasterId left join ECoupanEntry on x.InsuranceIndividualId=ECoupanEntry.ECoupanEntryId");
                Common.BindControldt(itemloop, Coupon);






            }
        }
    }
}