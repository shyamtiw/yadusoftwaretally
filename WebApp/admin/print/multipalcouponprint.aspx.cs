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
    public partial class multipalcouponprint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int[] ID = Request.QueryString["Id"].Split(',').Select(p => Convert.ToInt32(p)).ToArray();
                
                var Coupon = Global.Context.InsuranceCoupons.AsEnumerable().Where(p => ID.Contains( p.InsuranceCouponId)).ToList();
                Common.BindControl(itemloop, Coupon);
               
                
            }
        }
    }
}