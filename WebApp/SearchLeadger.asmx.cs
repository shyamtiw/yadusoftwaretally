using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApp
{
    /// <summary>
    /// Summary description for SearchLeadger
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.   
    [System.Web.Script.Services.ScriptService]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SearchLeadger : System.Web.Services.WebService
    {

        [WebMethod]
        public List<string> GetCountryNames(string term)
       {
            if (WebApp.admin.InsterBranchEntry.LeaderList.Rows.Count > 0)
            {
                DataView dv = new DataView(WebApp.admin.InsterBranchEntry.LeaderList);
                dv.RowFilter = "LedgerName LIKE '%" + term + "%'";

                List<string> gh = dv.ToTable().AsEnumerable().OrderBy(k => k[0].ToString()).Select(k => k[0].ToString()).ToList().Take(30).ToList();
                return gh;
            }
            else
            {
                DataView dv = new DataView(WebApp.admin.approvoucher.LeaderList);
                dv.RowFilter = "LedgerName LIKE '%" + term + "%'";

                List<string> gh = dv.ToTable().AsEnumerable().OrderBy(k => k[0].ToString()).Select(k => k[0].ToString()).ToList().Take(30).ToList();
                return gh;
            }
        }
    }

}
