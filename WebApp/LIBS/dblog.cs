using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.LIBS;
using Business;
namespace WebApp.LIBS
{
    public  static class dblogData
    {
       
        public static void CreateLog(string RecoredId, string Type)
        {

            string clientIp = (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ??
                    System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]).Split(',')[0].Trim();

            var objins = new Business.dblog();
            objins.PageName = System.Web.HttpContext.Current.Request.RawUrl;
            objins.RecoredId = RecoredId.ToString();
            objins.Userid = SiteSession.LoginUser.User_Code;
            objins.DateTime = Common.DateTimeNow();
            objins.Type = Type;
            objins.Comp_Code = SiteSession.Comp_MstSession.Comp_Code;
            objins.LocalIP = clientIp;
            objins.Save();
        }
             
    }
}