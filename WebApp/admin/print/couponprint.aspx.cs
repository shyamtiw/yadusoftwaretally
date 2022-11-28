using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
using Business;

namespace WebApp.admin.print
{
    public partial class couponprint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                int Id = Request.QueryString["Id"].ConvertInt();
             var Coupon=   Global.Context.InsuranceCoupons.AsEnumerable().SingleOrDefault(p => p.InsuranceCouponId == Id);
                CustomerName.Text = Coupon.InsuranceIndividual.CustomerName;
                MobileNo.Text = Coupon.MobNo;
                ValidDate.Text = Coupon.InsuranceIndividual.PolicyExpiryDate.Value.ToString("dd/MM/yyyy");
                IssueDate.Text = Coupon.IssueDate.Value.ToString("dd/MM/yyyy");
                Code.Text = Coupon.Code;
                regNo.Text = Coupon.InsuranceIndividual.VehicleRegnNo;
                EngineNo.Text = Coupon.InsuranceIndividual.EngineNo;
                Chassis.Text = Coupon.InsuranceIndividual.ChassisNo;
                CouponName.Text = Coupon.Master.Name;
                CompName1.Text = Request.QueryString["CompName"].ToString();
                CompName2.Text = Request.QueryString["CompName"].ToString();
                CompName3.Text = Request.QueryString["CompName"].ToString();
                AdvisorName.Text = Coupon.InsuranceIndividual.DealersExecutive;
                CoupenDiscount.Text = Coupon.Master.Description;
            }
        }
    }
}