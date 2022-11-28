using Business;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Services;
using System.Web.UI.WebControls;
using WebApp.admin.ReportModal;
using WebApp.LIBS;
using static WebApp.admin.DiscountUpdate;

namespace WebApp.admin
{
    public partial class DiscountManageList : BasePageClass
    {
        private static int PageSize = 10;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (!string.IsNullOrWhiteSpace(SiteSession.LoginUser.Multi_loc))
                {

                    Common.BindControl(BranchId, SiteSession.GetGodawanListSession.ToList(), "Value", "Id", "All");

                    //var obj = Global.Context.ExecuteStoreQuery<reciptdata>("select ReceiptId,RecNo,RecptDate,(substitute+CustomerName) as CustomerName,Amount from Receipt where Comp_code=" + SiteSession.Compnay.Comp_Code + " and godw_code in(" + SiteSession.LoginUser.Godw_code + ")  and  DepartmentId  in(" + SiteSession.LoginUser.DepartmentId + ")").ToList();
                    //Common.BindControl(gvlocation, obj);
                }
                try
                {

                    string ConStr = "Data Source=" + SiteSession.DatabaseIp + ";Initial Catalog=" + SiteSession.DatabaseName + ";persist security info=True;user id=" + SiteSession.DatabseUserName + ";password=" + SiteSession.DatabasePassword + ";multipleactiveresultsets=True;Timeout=60";
                    FillfinaceData(ConStr);


                    //Thread ThFinanceFillData = new Thread(() => FillfinaceData(ConStr));
                    //ThFinanceFillData.IsBackground = true;
                    //ThFinanceFillData.Start();
                    PleaseWait.Visible = false;

                }
                catch { }
            }

        }

        private void FillfinaceData(string ConStr)
        {

            try
            {//Fill Discount Entry
                OtherSqlConn.ExequteQuey1("DECLARE @tempTable TABLE ( ID int );insert into @tempTable select utd from DiscountManage; insert into DiscountManage select x.Discount_Head as Head,0,x.OfferGiven as OfferValue,0 as [Difference] ,x.Beforetax,x.MSIL_SHARE as MSILShare,x.DLR_SHARE as DealerShare,'' as SchemeDetails,null ValidFrom,null ValidUpto,null MIDueDate,'' Remarks,x.LOC_CD,TRANS_ID,utd,FinanceId from (select convert( int,Godw_Code) as GodwnId,x.Discount_Head,CHARGE_CD,CHARGE_AMT as BeforeTax,convert(decimal(18,0),CHARGE_AMT+(CHARGE_AMT*TaxRate)/100.00) as OfferGiven, MSIL_SHARE, DLR_SHARE, LOC_CD,TRANS_ID,y.TaxRate,x.Utd from  (select  DMS_Charge_Master.Discount_Head as Discount_Head,max(gd_fdi_trans_charges.CHARGE_CD) CHARGE_CD,SUM( CHARGE_AMT) as CHARGE_AMT,SUM(  MSIL_SHARE) as MSIL_SHARE,SUM(  DLR_SHARE) DLR_SHARE,x.LOC_CD,TRANS_ID, MAX(x.utd) as utd from  gd_fdi_trans_charges left join (select max(utd) as utd, LOC_CD,TRANS_ID,TRANS_TYPE from gd_fdi_trans where TRANS_TYPE='VS'  group by  LOC_CD,TRANS_ID,TRANS_TYPE  ) x on  gd_fdi_trans_charges.UTD=x.utd left join DMS_Charge_Master on gd_fdi_trans_charges.CHARGE_CD=DMS_Charge_Master.Charge_Cd where TRANS_TYPE='VS' and  x.UTD not in (select  Id from @tempTable) and   DMS_Charge_Master.Charge_Type=1    group by DMS_Charge_Master.Discount_Head,x.LOC_CD,TRANS_ID) as x left join (select  UTD,sum(CHARGE_RATE) as TaxRate from gd_fdi_trans_charges,DMS_Charge_Master where UTD in (select  utd from gd_fdi_trans where TRANS_TYPE='VS' ) and DMS_Charge_Master.Charge_Cd=gd_fdi_trans_charges.CHARGE_CD and DMS_Charge_Master.Charge_Type=0 group by UTD) as y on  x.utd=y.UTD left join godown_mst on x.LOC_CD=godown_mst.NEWCAR_RCPT) as x left join Finance on x.GodwnId=Finance.BranchId and x.TRANS_ID=Finance.DMSINVNo where FinanceId is not null", ConStr);
            }
            catch { }

        }



        [WebMethod]
        public static string GetCustomers(int pageIndex, string name, string FromDate, string ToDate, string BranchId, string Status)
        {
            BranchId = BranchId == "All" ? SiteSession.LoginUser.Multi_loc : BranchId;
            Status = Status == "All" ? "Complete,Pending" : Status;





            string f = "", t = "";
            if (FromDate.Length > 0)
            {
                f = FromDate.DateConvertTextMatchCaseyyyymmddd().ToString("dd-MMM-yyyy");
            }
            if (ToDate.Length > 0)
            {
                t = ToDate.DateConvertTextMatchCaseyyyymmddd().ToString("dd-MMM-yyyy");
            }


            string query = "[DiscountListSearch]";
            SqlCommand cmd = new SqlCommand(query);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SearchTerm", name);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
            cmd.Parameters.AddWithValue("@PageSize", PageSize);
            cmd.Parameters.AddWithValue("@GodwnId", BranchId);
            cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@FromDate", f);
            cmd.Parameters.AddWithValue("@ToDate", t);

            return GetData(cmd, pageIndex).GetXml();
        }

        private static DataSet GetData(SqlCommand cmd, int pageIndex)
        {
            string strConnString = "Data Source=" + SiteSession.DatabaseIp + ";Initial Catalog=" + SiteSession.DatabaseName + ";persist security info=True;user id=" + SiteSession.DatabseUserName + ";password=" + SiteSession.DatabasePassword + ";multipleactiveresultsets=True;Timeout=60";
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataSet ds = new DataSet())
                    {
                        sda.Fill(ds, "Customers");
                        DataTable dt = new DataTable("Pager");
                        dt.Columns.Add("PageIndex");
                        dt.Columns.Add("PageSize");
                        dt.Columns.Add("RecordCount");
                        dt.Rows.Add();
                        dt.Rows[0]["PageIndex"] = pageIndex;
                        dt.Rows[0]["PageSize"] = PageSize;
                        dt.Rows[0]["RecordCount"] = cmd.Parameters["@RecordCount"].Value;
                        ds.Tables.Add(dt);
                        return ds;
                    }
                }
            }
        }

        protected void refreshData_Click(object sender, EventArgs e)
        {
            string ConStr = "Data Source=" + SiteSession.DatabaseIp + ";Initial Catalog=" + SiteSession.DatabaseName + ";persist security info=True;user id=" + SiteSession.DatabseUserName + ";password=" + SiteSession.DatabasePassword + ";multipleactiveresultsets=True;Timeout=60";

            PleaseWait.Visible = true;
            try
            {
                OtherSqlConn.ExequteQuey1("insert into Finance SELECT  x.*,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null FROM Finance right JOIN (select distinct CONVERT(nvarchar(200), TRANS_id) as DMSINVNo, convert(datetime,TRANS_DATE) as DelvOn,CONVERT(nvarchar(200), CUST_NAME) as CustomerName,isnull( (select top 1 CONVERT(nvarchar(200), UPPER(MODEL_DESC) ) from model_variant_master where  model_variant_master.VARIANT_CD=gd_fdi_trans.VARIANT_CD),'') as ModelName,CONVERT(nvarchar(200), CHASSIS_NUM ) as ChasNo,CONVERT(nvarchar(200), EXECUTIVE ) as ErpExecutive,CONVERT(nvarchar(200), CUST_ID) CustId, convert (int, (select top 1 Godw_code from godown_mst where godown_mst.NEWCAR_RCPT=LOC_CD) ) as BranchId,VARIANT_CD,VIN from gd_fdi_trans where TRANS_TYPE='VS') AS X  on Finance.BranchId=x.BranchId and Finance.DMSINVNo=x.DMSINVNo where isnull(FinanceId,0)=0", ConStr);
            }
            catch { }

            FillfinaceData(ConStr);

            PleaseWait.Visible = false;


        }

        protected void updatependingdata_Click(object sender, EventArgs e)
        {
            UpdatePending();
        }


        private void UpdatePending()
        {
            string ErrorMsg = "";

            try
            {
                string f = "", t = "";
                if (FromDate.Text.Length > 0)
                {
                    f = FromDate.Text.DateConvertTextMatchCaseyyyymmddd().ToString("dd-MMM-yyyy");
                }
                if (ToDate.Text.Length > 0)
                {
                    t = ToDate.Text.DateConvertTextMatchCaseyyyymmddd().ToString("dd-MMM-yyyy");
                }
                // string PenId = "451,459,482,483,484,486,487,490,491,492,494,496,498,500,503,505,506,507,508,510,511,514,516,521,522,524,528,530,531,532,534,539,559,654,655,656,666,668,669,673,674,676,677,678,679,795,796,798,799,800,801,804,805,806,809,810,811,814,815,823,824,826,827,828,829,830,831,836,839,841,844,846,847,849,1140,1142,1143,1144,1145,1146,1147,1148,1149,1150,1152,1153,1154,1155,1156,1157,1160,1162,1163,1167,1170,1171,1173,1176,1177,1178,1179,1181,1184,1188,1191,1193,1194,1195,1205,1206,1207,1208,1209,1211,1215,1218,1221,1222,1225,1226,1227,1228,1229,1231,1233,1234,1237,1240,1241,1245,1246,1247,1248,1249,1250,1251,1252,1253,1254,2017,2018,2023,2024,2026,2028,2029,2030,2031,2033,2034,2035,2038,2039,2040,2041,2043,2044,2045,2046,2047,2048,2049,2050,2051,2054,2056,2057,2064,2065,2066,2067,2068,2072,2075,2077,2078,2079,2082,2089,2090,2091,2094,2095,2099,2100,2103,2104,2105,2106,2107,2108,2110,2111,2112,2114,2117,2118,2121,2122,2123,2124,2125,2126,2127,2128,2129,2130,2131,2132,2133,2134,2135,2136,2137,2139,2141,2142,2145,2146,2147,2148,2149,2150,2151,2155,2158,2161,2162,2167,2168,2169,2170,2171,2172,2175,2177,2180,2185,2192,2193,2194,2197,2199,2200,2202,2204,2205,2212,2216,2217,2225,2229,2230,2233,2234,2237,2240,2241,2242,2244,2250,2285,2286,2287,2288,2291,2292,2968,2969,2970,2971,2972,2973,2974,2975,2978,2980,2984,2988,2990,2995,3002,3003,3004,3006,3012,3023,3026,3027,3028,3029,3030,3035,3038,3042,3045,3057,3059,3064,3065,3066,3068,3069,3073,3075,3077,3080,3083,3085,3086,3087,3089,3091,3092,3096,3097,3099,3100,3102,3103,3108,3109,3111,3112,3115,3116,3117,3121,3123,3124,3127,3137,3138,3140,3147,3148,3149,3153,3158,3159,3160,3161,3164,3170,3173,3174,3177,3178,3184,3188,3189,3192,3195,3196,3199,3201,3203,3204,3210,3213,3229,3231,3232,3325,3326,3328,3331,3332,3334,3336,3337,3338,3339,3340,3342,3345,3346,3347,3348,3446,3447,3448,3450,3453,3454,3455,3457,3460,3461,3462,3463,3464,3466,3467,3471";
                DataTable AllData = OtherSqlConn.FillDataTable("select * from Finance where (select COUNT(*) from DiscountManage where DiscountManage.FinanceId=Finance.FinanceId)>0 and  CONVERT(date, DelvOn) between '" + f + "' and '" + t + "' and   DiscountUserId is null");
                var FinanceIdstring = string.Join(",", (AllData.AsEnumerable().Select(p => p["FinanceId"].ToString()).ToArray()));
                DataTable AllOptionDiscount = OtherSqlConn.FillDataTable("select AutoId,Head,AsperMSIL,OfferValue,Difference,Beforetax,MSILShare,DealerShare,SchemeDetails,(case  when ValidFrom  is not null then  CONVERT(varchar(10),ValidFrom,103) else '' end )  as ValidFrom,(case  when ValidUpto  is not null then  CONVERT(varchar(10),ValidUpto,103) else '' end )  as ValidUpto,(case  when MIDueDate  is not null then  CONVERT(varchar(10),MIDueDate,103) else '' end )  as MIDueDate,Remarks,LOC_CD,TRANS_ID,utd,FinanceId from  DiscountManage where   FinanceId in ("+ FinanceIdstring + ")  and Head !='Consumer Offer' union all select AutoId,Head,AsperMSIL,OfferValue,Difference,Beforetax,MSILShare,DealerShare,SchemeDetails,(case  when ValidFrom  is not null then  CONVERT(varchar(10),ValidFrom,103) else '' end )  as ValidFrom,(case  when ValidUpto  is not null then  CONVERT(varchar(10),ValidUpto,103) else '' end )  as ValidUpto,(case  when MIDueDate  is not null then  CONVERT(varchar(10),MIDueDate,103) else '' end )  as MIDueDate,Remarks,LOC_CD,TRANS_ID,utd,FinanceId from  DiscountManage where   FinanceId in (" + FinanceIdstring + ")  and Head ='Consumer Offer'");
                var SchemeData = Global.Context.ExecuteStoreQuery<conscheme>("select * from cons_disc").ToList();

                foreach (DataRow FianceData in AllData.Rows)
                {
                    //string RegionList = string.Join(",", SiteSession.GetGodawanListSession.Select(p => "'"+p.Region+"'").ToArray());
                    var DataArray = SiteSession.GetGodawanListSession.Where(xc => xc.Id == Convert.ToInt32(FianceData["BranchId"])).FirstOrDefault().Region;
                    string Variant_CD = FianceData["Variant_CD"].ToString();
                    DateTime DelvOn = Convert.ToDateTime(FianceData["DelvOn"]);
                    var dtConStr = SchemeData.Where(xc => xc.REGION == DataArray &&  xc.MODELID == Variant_CD && DelvOn.Date >= xc.VALIDFROM.Value.Date && DelvOn.Date <= xc.VALIDUPTO.Value.Date).ToList();

                    int InSt = 0;


                    DataTable dt = AllOptionDiscount.AsEnumerable().Where(pc => pc["FinanceId"].ToString() == FianceData["FinanceId"].ToString()).CopyToDataTable();
                    dt.Columns.Add(new DataColumn("Calc") { DefaultValue = 0, DataType = typeof(int) });
                    if (dt.Rows.Count > 0)
                    {

                        if (dt.AsEnumerable().Where(p => p["Head"].ToString() == "Consumer Offer").Count() > 0)
                        {
                            InSt = dt.AsEnumerable().Count() - 1;
                            dt.AsEnumerable().Where(p => p["Head"].ToString() == "Consumer Offer").FirstOrDefault()["Calc"] = 2;
                        }
                        else
                        {
                            InSt = -1;
                        }
                        var NewDr = dt.Rows[0];


                        if (dt.AsEnumerable().Where(p => p["Head"].ToString() == "Basic Consumer Offer").Count() == 0)
                        {
                            DataRow dr = dt.NewRow();


                            dr["Calc"] = 1;
                            dr["AutoId"] = 0; dr["Head"] = "Basic Consumer Offer";

                            try { dr["AsperMSIL"] = dtConStr.Where(p => p.OFFERTYPE == 0).FirstOrDefault().TOTDISC.Value; } catch { dr["AsperMSIL"] = 0; }
                            try { dr["OfferValue"] = dtConStr.Where(p => p.OFFERTYPE == 0).FirstOrDefault().TOTDISC.Value; } catch { dr["OfferValue"] = 0; }
                            try { dr["Beforetax"] = dtConStr.Where(p => p.OFFERTYPE == 0).FirstOrDefault().DISCWITHOUTGST.Value; } catch { dr["Beforetax"] = 0; }
                            try { dr["MSILShare"] = dtConStr.Where(p => p.OFFERTYPE == 0).FirstOrDefault().ISLDISC.Value; } catch { dr["MSILShare"] = 0; }
                            try { dr["DealerShare"] = dtConStr.Where(p => p.OFFERTYPE == 0).FirstOrDefault().DLRDISC.Value; } catch { dr["DealerShare"] = 0; }
                            try { dr["ValidFrom"] = dtConStr.Where(p => p.OFFERTYPE == 0).FirstOrDefault().VALIDFROM.Value.ToString("dd/MM/yyyy"); } catch { dr["ValidFrom"] = ""; }
                            try { dr["ValidUpto"] = dtConStr.Where(p => p.OFFERTYPE == 0).FirstOrDefault().VALIDUPTO.Value.ToString("dd/MM/yyyy"); } catch { dr["ValidUpto"] = ""; }
                            try { dr["MIDueDate"] = dtConStr.Where(p => p.OFFERTYPE == 0).FirstOrDefault().MIDUEDATE.Value.ToString("dd/MM/yyyy"); } catch { dr["MIDueDate"] = ""; }
                            try { dr["SchemeDetails"] = dtConStr.Where(p => p.OFFERTYPE == 0).FirstOrDefault().OFFERDESC; } catch { dr["SchemeDetails"] = ""; }




                            dr["Difference"] = 0; dr["Remarks"] = ""; dr["LOC_CD"] = NewDr["LOC_CD"].ToString(); dr["TRANS_ID"] = NewDr["TRANS_ID"].ToString(); dr["utd"] = NewDr["utd"].ToString(); dr["FinanceId"] = NewDr["FinanceId"]; dt.Rows.Add(dr);
                        }
                        else
                        {
                            dt.AsEnumerable().Where(p => p["Head"].ToString() == "Basic Consumer Offer").FirstOrDefault()["Calc"] = 1;
                        }



                        if (dt.AsEnumerable().Where(p => p["Head"].ToString() == "RIPS Support 1").Count() == 0)
                        {
                            DataRow dr = dt.NewRow();


                            dr["Calc"] = 1;
                            dr["AutoId"] = 0; dr["Head"] = "RIPS Support 1"; dr["AsperMSIL"] = 0; dr["OfferValue"] = 0; dr["Difference"] = 0; dr["Beforetax"] = 0; dr["MSILShare"] = 0; dr["DealerShare"] = 0; dr["SchemeDetails"] = ""; dr["ValidFrom"] = ""; dr["ValidUpto"] = ""; dr["MIDueDate"] = ""; dr["Remarks"] = ""; dr["LOC_CD"] = NewDr["LOC_CD"].ToString(); dr["TRANS_ID"] = NewDr["TRANS_ID"].ToString(); dr["utd"] = NewDr["utd"].ToString(); dr["FinanceId"] = NewDr["FinanceId"];


                            try { dr["AsperMSIL"] = dtConStr.Where(p => p.OFFERTYPE == 1).FirstOrDefault().TOTDISC.Value; } catch { dr["AsperMSIL"] = 0; }
                            try { dr["OfferValue"] = dtConStr.Where(p => p.OFFERTYPE == 1).FirstOrDefault().TOTDISC.Value; } catch { dr["OfferValue"] = 0; }
                            try { dr["Beforetax"] = dtConStr.Where(p => p.OFFERTYPE == 1).FirstOrDefault().DISCWITHOUTGST.Value; } catch { dr["Beforetax"] = 0; }
                            try { dr["MSILShare"] = dtConStr.Where(p => p.OFFERTYPE == 1).FirstOrDefault().ISLDISC.Value; } catch { dr["MSILShare"] = 0; }
                            try { dr["DealerShare"] = dtConStr.Where(p => p.OFFERTYPE == 1).FirstOrDefault().DLRDISC.Value; } catch { dr["DealerShare"] = 0; }
                            try { dr["ValidFrom"] = dtConStr.Where(p => p.OFFERTYPE == 1).FirstOrDefault().VALIDFROM.Value.ToString("dd/MM/yyyy"); } catch { dr["ValidFrom"] = ""; }
                            try { dr["ValidUpto"] = dtConStr.Where(p => p.OFFERTYPE == 1).FirstOrDefault().VALIDUPTO.Value.ToString("dd/MM/yyyy"); } catch { dr["ValidUpto"] = ""; }
                            try { dr["MIDueDate"] = dtConStr.Where(p => p.OFFERTYPE == 1).FirstOrDefault().MIDUEDATE.Value.ToString("dd/MM/yyyy"); } catch { dr["MIDueDate"] = ""; }
                            try { dr["SchemeDetails"] = dtConStr.Where(p => p.OFFERTYPE == 1).FirstOrDefault().OFFERDESC; } catch { dr["SchemeDetails"] = ""; }




                            dt.Rows.Add(dr);


                        }
                        else
                        {
                            dt.AsEnumerable().Where(p => p["Head"].ToString() == "RIPS Support 1").FirstOrDefault()["Calc"] = 1;
                        }

                        if (dt.AsEnumerable().Where(p => p["Head"].ToString() == "RIPS Support 2").Count() == 0)
                        {







                            DataRow dr = dt.NewRow(); dr["Calc"] = 1; dr["AutoId"] = 0; dr["Head"] = "RIPS Support 2"; dr["AsperMSIL"] = 0; dr["OfferValue"] = 0; dr["Difference"] = 0; dr["Beforetax"] = 0; dr["MSILShare"] = 0; dr["DealerShare"] = 0; dr["SchemeDetails"] = ""; dr["ValidFrom"] = ""; dr["ValidUpto"] = ""; dr["MIDueDate"] = ""; dr["Remarks"] = ""; dr["LOC_CD"] = NewDr["LOC_CD"].ToString(); dr["TRANS_ID"] = NewDr["TRANS_ID"].ToString(); dr["utd"] = NewDr["utd"].ToString(); dr["FinanceId"] = NewDr["FinanceId"];

                            try { dr["AsperMSIL"] = dtConStr.Where(p => p.OFFERTYPE == 2).FirstOrDefault().TOTDISC.Value; } catch { dr["AsperMSIL"] = 0; }
                            try { dr["OfferValue"] = dtConStr.Where(p => p.OFFERTYPE == 2).FirstOrDefault().TOTDISC.Value; } catch { dr["OfferValue"] = 0; }
                            try { dr["Beforetax"] = dtConStr.Where(p => p.OFFERTYPE == 2).FirstOrDefault().DISCWITHOUTGST.Value; } catch { dr["Beforetax"] = 0; }
                            try { dr["MSILShare"] = dtConStr.Where(p => p.OFFERTYPE == 2).FirstOrDefault().ISLDISC.Value; } catch { dr["MSILShare"] = 0; }
                            try { dr["DealerShare"] = dtConStr.Where(p => p.OFFERTYPE == 2).FirstOrDefault().DLRDISC.Value; } catch { dr["DealerShare"] = 0; }
                            try { dr["ValidFrom"] = dtConStr.Where(p => p.OFFERTYPE == 2).FirstOrDefault().VALIDFROM.Value.ToString("dd/MM/yyyy"); } catch { dr["ValidFrom"] = ""; }
                            try { dr["ValidUpto"] = dtConStr.Where(p => p.OFFERTYPE == 2).FirstOrDefault().VALIDUPTO.Value.ToString("dd/MM/yyyy"); } catch { dr["ValidUpto"] = ""; }
                            try { dr["MIDueDate"] = dtConStr.Where(p => p.OFFERTYPE == 2).FirstOrDefault().MIDUEDATE.Value.ToString("dd/MM/yyyy"); } catch { dr["MIDueDate"] = ""; }
                            try { dr["SchemeDetails"] = dtConStr.Where(p => p.OFFERTYPE == 2).FirstOrDefault().OFFERDESC; } catch { dr["SchemeDetails"] = ""; }



                            dt.Rows.Add(dr);
                        }
                        else
                        {
                            dt.AsEnumerable().Where(p => p["Head"].ToString() == "RIPS Support 2").FirstOrDefault()["Calc"] = 1;
                        }



                        if (dt.AsEnumerable().Where(p => p["Head"].ToString() == "RIPS Support 3").Count() == 0)
                        {
                            DataRow dr = dt.NewRow(); dr["AutoId"] = 0; dr["Calc"] = 1; dr["Head"] = "RIPS Support 3"; dr["AsperMSIL"] = 0; dr["OfferValue"] = 0; dr["Difference"] = 0; dr["Beforetax"] = 0; dr["MSILShare"] = 0; dr["DealerShare"] = 0; dr["SchemeDetails"] = ""; dr["ValidFrom"] = ""; dr["ValidUpto"] = ""; dr["MIDueDate"] = ""; dr["Remarks"] = ""; dr["LOC_CD"] = NewDr["LOC_CD"].ToString(); dr["TRANS_ID"] = NewDr["TRANS_ID"].ToString(); dr["utd"] = NewDr["utd"].ToString(); dr["FinanceId"] = NewDr["FinanceId"];

                            try { dr["AsperMSIL"] = dtConStr.Where(p => p.OFFERTYPE == 3).FirstOrDefault().TOTDISC.Value; } catch { dr["AsperMSIL"] = 0; }
                            try { dr["OfferValue"] = dtConStr.Where(p => p.OFFERTYPE == 3).FirstOrDefault().TOTDISC.Value; } catch { dr["OfferValue"] = 0; }
                            try { dr["Beforetax"] = dtConStr.Where(p => p.OFFERTYPE == 3).FirstOrDefault().DISCWITHOUTGST.Value; } catch { dr["Beforetax"] = 0; }
                            try { dr["MSILShare"] = dtConStr.Where(p => p.OFFERTYPE == 3).FirstOrDefault().ISLDISC.Value; } catch { dr["MSILShare"] = 0; }
                            try { dr["DealerShare"] = dtConStr.Where(p => p.OFFERTYPE == 3).FirstOrDefault().DLRDISC.Value; } catch { dr["DealerShare"] = 0; }
                            try { dr["ValidFrom"] = dtConStr.Where(p => p.OFFERTYPE == 3).FirstOrDefault().VALIDFROM.Value.ToString("dd/MM/yyyy"); } catch { dr["ValidFrom"] = ""; }
                            try { dr["ValidUpto"] = dtConStr.Where(p => p.OFFERTYPE == 3).FirstOrDefault().VALIDUPTO.Value.ToString("dd/MM/yyyy"); } catch { dr["ValidUpto"] = ""; }
                            try { dr["MIDueDate"] = dtConStr.Where(p => p.OFFERTYPE == 3).FirstOrDefault().MIDUEDATE.Value.ToString("dd/MM/yyyy"); } catch { dr["MIDueDate"] = ""; }
                            try { dr["SchemeDetails"] = dtConStr.Where(p => p.OFFERTYPE == 3).FirstOrDefault().OFFERDESC; } catch { dr["SchemeDetails"] = ""; }



                            dt.Rows.Add(dr);
                        }
                        else
                        {
                            dt.AsEnumerable().Where(p => p["Head"].ToString() == "RIPS Support 3").FirstOrDefault()["Calc"] = 1;
                        }




                        if (dt.AsEnumerable().Where(p => p["Head"].ToString() == "MSIL Employee").Count() == 0)
                        {
                            DataRow dr = dt.NewRow(); dr["AutoId"] = 0; dr["Calc"] = 1; dr["Head"] = "MSIL Employee"; dr["AsperMSIL"] = 0; dr["OfferValue"] = 0; dr["Difference"] = 0; dr["Beforetax"] = 0; dr["MSILShare"] = 0; dr["DealerShare"] = 0; dr["SchemeDetails"] = ""; dr["ValidFrom"] = ""; dr["ValidUpto"] = ""; dr["MIDueDate"] = ""; dr["Remarks"] = ""; dr["LOC_CD"] = NewDr["LOC_CD"].ToString(); dr["TRANS_ID"] = NewDr["TRANS_ID"].ToString(); dr["utd"] = NewDr["utd"].ToString(); dr["FinanceId"] = NewDr["FinanceId"]; dt.Rows.Add(dr);
                        }


                        else
                        {
                            dt.AsEnumerable().Where(p => p["Head"].ToString() == "MSIL Employee").FirstOrDefault()["Calc"] = 1;
                        }

                        if (dt.AsEnumerable().Where(p => p["Head"].ToString() == "Buffer Discount").Count() == 0)
                        {
                            DataRow dr = dt.NewRow(); dr["AutoId"] = 0; dr["Calc"] = 1; dr["Head"] = "Buffer Discount"; dr["AsperMSIL"] = 0; dr["OfferValue"] = 0; dr["Difference"] = 0; dr["Beforetax"] = 0; dr["MSILShare"] = 0; dr["DealerShare"] = 0; dr["SchemeDetails"] = ""; dr["ValidFrom"] = ""; dr["ValidUpto"] = ""; dr["MIDueDate"] = ""; dr["Remarks"] = ""; dr["LOC_CD"] = NewDr["LOC_CD"].ToString(); dr["TRANS_ID"] = NewDr["TRANS_ID"].ToString(); dr["utd"] = NewDr["utd"].ToString(); dr["FinanceId"] = NewDr["FinanceId"]; dt.Rows.Add(dr);
                        }

                        else
                        {
                            dt.AsEnumerable().Where(p => p["Head"].ToString() == "Buffer Discount").FirstOrDefault()["Calc"] = 1;
                        }


                        DataTable MSCLRepiter = dt.AsEnumerable().Where(drx => drx["Calc"].ToString() == "0" || drx["Calc"].ToString() == "2").CopyToDataTable();
                        DataTable RipRepiter = dt.AsEnumerable().Where(drx => drx["Calc"].ToString() == "1").CopyToDataTable();
                        var responce = SavePendingData(MSCLRepiter, RipRepiter, FianceData["FinanceId"].ToString());
                        if (responce != "Suc")
                        {
                            ErrorMsg = ErrorMsg.Length > 0 ? ErrorMsg + "<br/>" + FianceData["DMSINVNo"].ToString() +"="+responce : FianceData["DMSINVNo"].ToString() + "="+responce;
                        }
                    }
                }

                if (ErrorMsg.Length > 0)
                {
                    MessageBox.ShowMessage("Saving Time Error", ErrorMsg, SiteKey.MessageType.danger);
                }
                else

                {
                    MessageBox.ShowMessage("Success", "successfully data Saved", SiteKey.MessageType.success);

                }
            }
            catch (Exception ex)
            {
                String Message = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                if (Message.Contains("UNIQUE KEY")) { Message = "Record/Username already exists. Please choose another."; }
                MessageBox.ShowMessage("Update Pending Function Error", Message, SiteKey.MessageType.danger);
            }
        }

            private string  SavePendingData(DataTable MSCLRepiterTable, DataTable RipRepiterTable,string ReciptId)
        {

            try
            {
                string UpdateStrMainGrid = "";
                foreach (DataRow MSCLRepiter in MSCLRepiterTable.Rows)
                {
                    var AutoId = MSCLRepiter["AutoId"].ToString();
                    var AsperMSIL = MSCLRepiter["AsperMSIL"].ToString();
                    var OfferValue = MSCLRepiter["OfferValue"].ToString();
                    var Difference = MSCLRepiter["Difference"].ToString();
                    var Beforetax = MSCLRepiter["Beforetax"].ToString();
                    var MSILShare = MSCLRepiter["MSILShare"].ToString();
                    var DealerShare = MSCLRepiter["DealerShare"].ToString();

                    var SchemeDetails = MSCLRepiter["SchemeDetails"].ToString();
                    var ValidFrom = (MSCLRepiter["ValidFrom"].ToString().Length > 0 ? "'" + MSCLRepiter["ValidFrom"].ToString().DateConvertTextMatchCase().ToString("dd-MMM-yyyy") + "'" : "null");
                    var ValidUpto = (MSCLRepiter["ValidUpto"].ToString().Length > 0 ? "'" + MSCLRepiter["ValidUpto"].ToString().DateConvertTextMatchCase().ToString("dd-MMM-yyyy") + "'" : "null");
                    var MIDueDate = (MSCLRepiter["MIDueDate"].ToString().Length > 0 ? "'" + MSCLRepiter["MIDueDate"].ToString().DateConvertTextMatchCase().ToString("dd-MMM-yyyy") + "'" : "null");
                    var Remarks = MSCLRepiter["Remarks"].ToString();
                    UpdateStrMainGrid = UpdateStrMainGrid + ";update DiscountManage set AsperMSIL=" + AsperMSIL + "," +
                        "OfferValue = " + OfferValue + "," +
                        "Difference = " + Difference + "," +
                        "Beforetax = " + Beforetax + "," +
                        "MSILShare = " + MSILShare + "," +
                        "DealerShare = " + DealerShare + "," +
                        "SchemeDetails = '" + SchemeDetails.Replace("'", "'") + "'," +
                        "ValidFrom = " + ValidFrom + "," +
                        "ValidUpto = " + ValidUpto + "," +
                        "MIDueDate = " + MIDueDate + "," +
                        "Remarks = '" + Remarks.Replace("'", "''") + "' " + " " +
                        "where AutoId = " + AutoId + "";
                }
                OtherSqlConn.ExequteQuey(UpdateStrMainGrid);
                UpdateStrMainGrid = "";
                foreach (DataRow RipRepiter in RipRepiterTable.Rows)
                {

                    var AutoId = RipRepiter["AutoId"].ToString();
                    var FinanceId = RipRepiter["FinanceId"].ToString();
                    var Head = RipRepiter["Head"].ToString();
                    var LOC_CD = RipRepiter["LOC_CD"].ToString();
                    var TRANS_ID = RipRepiter["TRANS_ID"].ToString();
                    var utd = RipRepiter["utd"].ToString();
                    var AsperMSIL = RipRepiter["AsperMSIL"].ToString();
                    var OfferValue = RipRepiter["OfferValue"].ToString();
                    var Difference = RipRepiter["Difference"].ToString();
                    var Beforetax = RipRepiter["Beforetax"].ToString();
                    var MSILShare = RipRepiter["MSILShare"].ToString();
                    var DealerShare = RipRepiter["DealerShare"].ToString(); ;

                    var SchemeDetails =RipRepiter["SchemeDetails"].ToString(); 
                    var ValidFrom = (RipRepiter["ValidFrom"].ToString().Length > 0 ? "'" + RipRepiter["ValidFrom"].ToString().DateConvertTextMatchCase().ToString("dd-MMM-yyyy") + "'" : "null");
                    var ValidUpto = (RipRepiter["ValidUpto"].ToString().Length > 0 ? "'" + RipRepiter["ValidUpto"].ToString().DateConvertTextMatchCase().ToString("dd-MMM-yyyy") + "'" : "null");
                    var MIDueDate = (RipRepiter["MIDueDate"].ToString().Length > 0 ? "'" + RipRepiter["MIDueDate"].ToString().DateConvertTextMatchCase().ToString("dd-MMM-yyyy") + "'" : "null");
                    var Remarks = RipRepiter["Remarks"].ToString();

                    if (Common.ConvertInt(AutoId) > 0)
                    {
                        UpdateStrMainGrid = UpdateStrMainGrid + ";update DiscountManage set AsperMSIL=" + AsperMSIL + "," +
                 "OfferValue = " + OfferValue + "," +
                 "Difference = " + Difference + "," +
                 "Beforetax = " + Beforetax + "," +
                 "MSILShare = " + MSILShare + "," +
                 "DealerShare = " + DealerShare + "," +
                 "SchemeDetails = '" + SchemeDetails.Replace("'", "''") + "'," +
                 "ValidFrom = " + ValidFrom + "," +
                 "ValidUpto = " + ValidUpto + "," +
                 "MIDueDate = " + MIDueDate + "," +
                 "Remarks = '" + Remarks.Replace("'", "''") + "' " + " " +
                 "where AutoId = " + AutoId + "";
                    }
                    else
                    {

                        UpdateStrMainGrid = UpdateStrMainGrid + ";insert into DiscountManage (" +
                            "Head,AsperMSIL,OfferValue,Difference,Beforetax,MSILShare,DealerShare,SchemeDetails,ValidFrom,ValidUpto,MIDueDate,Remarks,LOC_CD,TRANS_ID,utd,FinanceId)" +
                            "values (" +
                            "'" + Head + "'," +
                                 "" + AsperMSIL + "," +
                            "" + OfferValue + "," +

                            "" + Difference + "," +
                            "" + Beforetax + "," +
                            "" + MSILShare + "," +
                            "" + DealerShare + "," +
                            "'" + SchemeDetails.Replace("'", "''") + "'," +
                            "" + ValidFrom + "," +
                            "" + ValidUpto + "," +
                            "" + MIDueDate + "," +
                            "'" + Remarks.Replace("'", "''") + "'," +
                            "'" + LOC_CD + "'," +
                            "'" + TRANS_ID + "'," +
                            "" + utd + "," +
                            "" + FinanceId + "" + ")";
                    }
                }

                OtherSqlConn.ExequteQuey(UpdateStrMainGrid);
                OtherSqlConn.ExequteQuey("Update Finance set DiscountUserId=" + SiteSession.LoginUser.User_Code + "  where   FinanceId=" + ReciptId + "");

                return "Suc";
             

            }
            catch (Exception ex)
            {
                String Message = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                return Message;
            }
        }
    }
}
