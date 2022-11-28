using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
using Business;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using WebApp.admin.ReportModal;
using System.IO;
using SelectPdf;
using Emailer;
using System.Threading;

namespace WebApp.admin
{
    public partial class DetailCouponList : BasePageClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {





                DataTable dt = FinancerOutstandingCS.DeatilCouponList();

                foreach (DataColumn dr in dt.Columns)
                {
                   
                        BoundField newColumnName = new BoundField();

                        newColumnName.DataField = dr.ColumnName;
                        newColumnName.HeaderText = Common.AddSpacesToSentence(dr.ColumnName);

                        gvlocation.Columns.Add(newColumnName);
                   


                }
                

                gvlocation.DataSource = dt;

                gvlocation.DataBind();
            }


        }
        
    }
}