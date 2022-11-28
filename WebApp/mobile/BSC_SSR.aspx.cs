using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
using Business;
using WebApp.LIBS.MobileAppCS;
using System.Data;
namespace WebApp.mobile
{
    public partial class BSC_SSR : BasePageClassMobile
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                var Region = Request.QueryString["Region"].ToString();
                DataTable dt = MobileSales.BSC_SSRData(Region);
                Common.BindControldt(SSRPerformance, dt);
                
                DataTable dt1 = MobileSales.BSC_PMSGROWTH(Region);
               
                decimal PMS2021 = dt1.AsEnumerable().Sum(p => Convert.ToDecimal(p["PMS_2021"]));
                decimal PMS2122 = dt1.AsEnumerable().Sum(p => Convert.ToDecimal(p["PMS_2122"]));
                decimal PMSGROWTH = (PMS2122 - PMS2021) / PMS2021*100;


                decimal TotBase_Data = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["Base_Data"]));
                decimal TotTGt055 = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["TGT055"]));
                decimal TotTGt045 = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["TGT045"]));
                decimal TotTGt035 = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["TGT035"]));
                decimal TotPMSDONE = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["PMS_DONE"]));
                decimal TotBAL055 = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["BAL055"]));
                decimal TotBAL045 = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["BAL045"]));
                decimal TotBAL035 = dt.AsEnumerable().Sum(p => Convert.ToDecimal(p["BAL035"]));

                Base_Data.Text = ((int)System.Math.Ceiling(TotBase_Data)).ToString();
                TGT055.Text = ((int)System.Math.Ceiling(TotTGt055)).ToString();
                TGT045.Text = ((int)System.Math.Ceiling(TotTGt045)).ToString();
                TGT035.Text = ((int)System.Math.Ceiling(TotTGt035)).ToString();
                PMS_DONE.Text = ((int)System.Math.Ceiling(TotPMSDONE)).ToString();
                BAL055.Text = ((int)System.Math.Ceiling(TotBAL055)).ToString();
                BAL045.Text = ((int)System.Math.Ceiling(TotBAL045)).ToString();
                BAL035.Text = ((int)System.Math.Ceiling(TotBAL035)).ToString();
               pmsgrowth.Text= ((double)System.Math.Ceiling(PMSGROWTH)).ToString();
                pms2021.Text= ((int)System.Math.Ceiling(PMS2021)).ToString();
                pms2122.Text = ((int)System.Math.Ceiling(PMS2122)).ToString();
            }

        }
    }
}