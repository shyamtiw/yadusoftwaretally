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
    public partial class MultipalSendUsingWithoutLinq : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                

                DataTable Coupon = ConnModal.FillDataTable("select x.Code,Name,IssueDate,PolicyExpiryDate,CustomerName,MobNo,VehicleRegnNo,DealersExecutive,ChassisNo,EngineNo,[Description] from (select * from InsuranceCoupon where InsuranceCouponId in ("+ Request.QueryString["Id"].ToString() + ")) as x left join [Master] on x.MasterId=[Master].MasterId left join InsuranceIndividual on x.InsuranceIndividualId=InsuranceIndividual.InsuranceIndividualId");
                Common.BindControldt(itemloop, Coupon);






            }
        }
    }
}