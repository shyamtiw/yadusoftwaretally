using Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace WebApp.LIBS
{
    public class SiteSession
    {
        public static bool IsLoggedIn
        {
            get { return HttpContext.Current.Session["IsLoggedIn"] == null ? false : (bool)HttpContext.Current.Session["IsLoggedIn"]; }
            set { HttpContext.Current.Session["IsLoggedIn"] = value; }
        }


        public static bool IsLoggedInMobile
        {
            get { return HttpContext.Current.Session["IsLoggedInMobile"] == null ? false : (bool)HttpContext.Current.Session["IsLoggedInMobile"]; }
            set { HttpContext.Current.Session["IsLoggedInMobile"] = value; }
        }



        public static List<AllotOption> AllotOption
        {
            get { return HttpContext.Current.Session["AllotOption"] == null ? null : (List<AllotOption>)HttpContext.Current.Session["AllotOption"]; }
            set { HttpContext.Current.Session["AllotOption"] = value; }
        }

        public static DataTable FinanceOutstandingSession
        {
            get { return HttpContext.Current.Session["FinanceOutstandingSession"] == null ? null : (DataTable)HttpContext.Current.Session["FinanceOutstandingSession"]; }
            set { HttpContext.Current.Session["FinanceOutstandingSession"] = value; }
        }



        public static Business.User_Tbl LoginUser
        {
            get { return HttpContext.Current.Session["UserLogin"] == null ? null : (Business.User_Tbl)HttpContext.Current.Session["UserLogin"]; }
            set { HttpContext.Current.Session["UserLogin"] = value; }
        }

        public static Business.EmployeeMaster EmployeeMaster
        {
            get { return HttpContext.Current.Session["EmployeeMaster"] == null ? null : (Business.EmployeeMaster)HttpContext.Current.Session["EmployeeMaster"]; }
            set { HttpContext.Current.Session["EmployeeMaster"] = value; }
        }

        public static int DesignationId
        {
            get { return HttpContext.Current.Session["DesignationId"] == null ? 0 : (int)HttpContext.Current.Session["DesignationId"]; }
            set { HttpContext.Current.Session["DesignationId"] = value; }
        }
        public static  int  GodownId
        {
            get { return HttpContext.Current.Session["GodownId"] == null ? 0 : (int)HttpContext.Current.Session["GodownId"]; }
            set { HttpContext.Current.Session["GodownId"] = value; }
        }


        public static int PendingBookingMSGCode
        {
            get { return HttpContext.Current.Session["PendingBookingMSGCode"] == null ? 0 : (int)HttpContext.Current.Session["PendingBookingMSGCode"]; }
            set { HttpContext.Current.Session["PendingBookingMSGCode"] = value; }
        }
        public static string PendingBookingMSG
        {
            get { return HttpContext.Current.Session["PendingBookingMSG"] == null ? "" : (string)HttpContext.Current.Session["PendingBookingMSG"]; }
            set { HttpContext.Current.Session["PendingBookingMSG"] = value; }
        }

        public static List<Item> ItemArray
        {
            get { return HttpContext.Current.Session["ItemArray"] == null ? null : (List<Item>)HttpContext.Current.Session["ItemArray"]; }
            set { HttpContext.Current.Session["ItemArray"] = value; }
        }
        public static string OTP
        {
            get { return HttpContext.Current.Session["OTP"] == null ? "" : (string)HttpContext.Current.Session["OTP"]; }
            set { HttpContext.Current.Session["OTP"] = value; }
        }

        public static string CheckErrorMessage
        {
            get { return HttpContext.Current.Session["CheckErrorMessage"] == null ? "" : (string)HttpContext.Current.Session["CheckErrorMessage"]; }
            set { HttpContext.Current.Session["CheckErrorMessage"] = value; }
        }
        public static string DatabseUserName
        {
            get { return HttpContext.Current.Session["DatabseUserName"] == null ? "" : (string)HttpContext.Current.Session["DatabseUserName"]; }
            set { HttpContext.Current.Session["DatabseUserName"] = value; }
        }
        public static string DatabasePassword
        {
            get { return HttpContext.Current.Session["DatabasePassword"] == null ? "" : (string)HttpContext.Current.Session["DatabasePassword"]; }
            set { HttpContext.Current.Session["DatabasePassword"] = value; }
        }
        public static string SMSURL
        {
            get { return HttpContext.Current.Session["SMSURL"] == null ? "" : (string)HttpContext.Current.Session["SMSURL"]; }
            set { HttpContext.Current.Session["SMSURL"] = value; }
        }

        public static string DatabaseIp
        {
            get { return HttpContext.Current.Session["DatabaseIp"] == null ? "" : (string)HttpContext.Current.Session["DatabaseIp"]; }
            set { HttpContext.Current.Session["DatabaseIp"] = value; }
        }
        public static string DatabaseName
        {
            get { return HttpContext.Current.Session["DatabaseName"] == null ? "" : (string)HttpContext.Current.Session["DatabaseName"]; }
            set { HttpContext.Current.Session["DatabaseName"] = value; }
        }




        public static string StringUserName
        {
            get { return HttpContext.Current.Session["StringUserName"] == null ? "Default" : (string)HttpContext.Current.Session["StringUserName"]; }
            set { HttpContext.Current.Session["StringUserName"] = value; }
        }

        
              public static List<FilterKeyHolder> FilterKeyHolder
        {
            get { return HttpContext.Current.Session["FilterKeyHolder"] == null ? null : (List<FilterKeyHolder>)HttpContext.Current.Session["FilterKeyHolder"]; }
            set { HttpContext.Current.Session["FilterKeyHolder"] = value; }
        }


        public static List<FilterKeyHolder> FilterKeyHolderResponce
        {
            get { return HttpContext.Current.Session["FilterKeyHolderResponce"] == null ? null : (List<FilterKeyHolder>)HttpContext.Current.Session["FilterKeyHolderResponce"]; }
            set { HttpContext.Current.Session["FilterKeyHolderResponce"] = value; }
        }

        public static List<Business.GroupMasterReport> GroupMasterReport
        {
            get { return HttpContext.Current.Session["GroupMasterReport"] == null ? null : (List<GroupMasterReport>)HttpContext.Current.Session["GroupMasterReport"]; }
            set { HttpContext.Current.Session["GroupMasterReport"] = value; }
        }


        public static DataTable  SalesDataTable
        {
            get { return HttpContext.Current.Session["SalesDataTable"] == null ? null : (DataTable)HttpContext.Current.Session["SalesDataTable"]; }
            set { HttpContext.Current.Session["SalesDataTable"] = value; }
        }



        public static List<GodawnList> GetGodawanListSession
        {
            get { return HttpContext.Current.Session["GetGodawanListSession"] == null ? null : (List<GodawnList>)HttpContext.Current.Session["GetGodawanListSession"]; }
            set { HttpContext.Current.Session["GetGodawanListSession"] = value; }
        }



        //public static List<GetBankCashReport> SessionGetBankCashReport
        //{
        //    get { return HttpContext.Current.Session["SessionGetBankCashReport"] == null ? null : (List<GetBankCashReport>)HttpContext.Current.Session["SessionGetBankCashReport"]; }
        //    set { HttpContext.Current.Session["SessionGetBankCashReport"] = value; }
        //}



        
        public static Comp_Mst Comp_MstSession
        {
            get { return HttpContext.Current.Session["Comp_MstSession"] == null ? null : (Comp_Mst)HttpContext.Current.Session["Comp_MstSession"]; }
            set { HttpContext.Current.Session["Comp_MstSession"] = value; }
        }



    



        public static int Year
        {
            get { return HttpContext.Current.Session["Year"] == null ? 0 : (int)HttpContext.Current.Session["Year"]; }
            set { HttpContext.Current.Session["Year"] = value; }
        }
        public static DateTime DateGet
        {
            get { return HttpContext.Current.Session["DateGet"] == null ? Common.DateTimeNow() : (DateTime)HttpContext.Current.Session["DateGet"]; }
            set { HttpContext.Current.Session["DateGet"] = value; }
        }
        public static int SchoolId
        {
            get { return HttpContext.Current.Session["SchoolId"] == null ? 0 : (int)HttpContext.Current.Session["SchoolId"]; }
            set { HttpContext.Current.Session["SchoolId"] = value; }
        }


        public static List<ParentMenu_Result> ParentMenu
        {
            get { return HttpContext.Current.Session["ParentMenu"] == null ? null : (List<ParentMenu_Result>)HttpContext.Current.Session["ParentMenu"]; }
            set { HttpContext.Current.Session["ParentMenu"] = value; }
        }


        public static List<EmployeeMaster> EmployeeMasterSessionList
        {
            get { return HttpContext.Current.Session["EmployeeMasterSessionList"] == null ? null : (List<EmployeeMaster>)HttpContext.Current.Session["EmployeeMasterSessionList"]; }
            set { HttpContext.Current.Session["EmployeeMasterSessionList"] = value; }
        }
        public static List<SubMenu_Result> SubMenu
        {
            get { return HttpContext.Current.Session["SubMenu"] == null ? null : (List<SubMenu_Result>)HttpContext.Current.Session["SubMenu"]; }
            set { HttpContext.Current.Session["SubMenu"] = value; }
        }



    }
}