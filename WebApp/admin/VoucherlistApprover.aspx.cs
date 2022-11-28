using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
using Business;
using System.Data;
using WebApp.admin.ReportModal;

namespace WebApp.admin
{
    public partial class VoucherlistApprover :BasePageClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Str = "select InterbranchEntryId,[Status],CreatorUserId,'' as UserName,'' MobileNo,(select Godw_Name from godown_mst where  godown_mst.Godw_Code=InterbranchEntry.CreatorBranchId) as ReuestFromBranch,CreateDateTime,CreatorVocuherTotal as VocuherTotal,CreatorNarration from  InterbranchEntry  where [Status] in (1,3) and RequestToBranchId=" + SiteSession.GodownId+"";
                var objuser = Global.Context.User_Tbl.Where(p => p.Comp_Code == SiteSession.Comp_MstSession.Comp_Code).ToList();
                DataTable dt = OtherSqlConn.FillDataTable(Str);

                dt.AsEnumerable().ToList().ForEach(xc => {
                    try
                    {
                       var data= objuser.SingleOrDefault(p => p.User_Code == Convert.ToInt32(xc["CreatorUserId"]));

                        xc["UserName"] = data.User_Name;
                        xc["MobileNo"] = data.User_mob;
                    }
                    catch { }
                });
                Common.BindControldt(gvlocation, dt);
            }
        }
    }
}