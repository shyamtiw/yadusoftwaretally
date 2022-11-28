using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using WebApp.admin.ReportModal;
using WebApp.LIBS;
namespace WebApp.admin
{
    public partial class blankpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (SiteSession.LoginUser.User_Name != "crm")
                {

                    SiteSession.GetGodawanListSession.ToList().ForEach(x =>
                    {

                        BranchId.Items.Add(new ListItem() { Text = x.Value, Value = x.Id.ToString() });

                    });

                    DataSet ParaData = OtherSqlConn.FillDataSet("select stuff((select ',' + convert(nvarchar(50),u.Godw_Code) from godown_mst u where   Godw_Code in (" + SiteSession.LoginUser.Multi_loc + ") and  u.Br_Region = godown_mst.Br_Region for xml path('')),1,1,'') as Godw_Code,isnull( Br_Region,'') as Br_Region from  godown_mst where  Godw_Code in (" + SiteSession.LoginUser.Multi_loc + ") group by Br_Region;select stuff((select ',' + convert(nvarchar(50),u.Godw_Code) from godown_mst  u where  Godw_Code in (" + SiteSession.LoginUser.Multi_loc + ") and  u.Br_Segment = godown_mst.Br_Segment for xml path('')),1,1,'') as Godw_Code,isnull( Br_Segment,'') as Br_Segment from  godown_mst  where  Godw_Code in (" + SiteSession.LoginUser.Multi_loc + ")  group by Br_Segment;select stuff((select ',' + convert(nvarchar(50),u.Godw_Code) from godown_mst u where  Godw_Code in (" + SiteSession.LoginUser.Multi_loc + ") and  u.Br_Location = godown_mst.Br_Location for xml path('')),1,1,'') as Godw_Code,isnull( Br_Location,'') as Br_Location from  godown_mst  where  Godw_Code in (" + SiteSession.LoginUser.Multi_loc + ")  group by Br_Location");


                    ParaData.Tables[0].AsEnumerable().ToList().ForEach(xc =>
                    {

                        Region.Items.Add(new ListItem() { Text = xc["Br_Region"].ToString(), Value = xc["Godw_Code"].ToString() });
                    });

                    ParaData.Tables[1].AsEnumerable().ToList().ForEach(xc =>
                    {

                        Chanel.Items.Add(new ListItem() { Text = xc["Br_Segment"].ToString(), Value = xc["Godw_Code"].ToString() });
                    });

                }
            }


        }

        protected void MTD_Click(object sender, EventArgs e)
        {


            var NowDate= Common.DateTimeNow();
            int  MonthLast=  DateTime.DaysInMonth(NowDate.Year, NowDate.Month);
            string FromDate = new DateTime(NowDate.Year, NowDate.Month, 1).ToString("dd-MMM-yyyy");
            string ToDate = NowDate.ToString("dd-MMM-yyyy");
            var Godwn = BranchSelection();
            string str = "select  'Retail' as [Name],(select COUNT(*) from Finance where  BranchId in (" + Godwn + ")  and  DelvOn between '" + FromDate + "' and '" + ToDate + "' ) as Retail union all  select  'In-House'  as [Name]  , (select COUNT(*) from Finance where  BranchId in (" + Godwn + ") and LoanType='In-House'  and  DelvOn between '" + FromDate + "' and '" + ToDate + "'  and DMSINVNo not in (Select distinct Trans_Ref_num from gd_fdi_trans where trans_type='VC')) as InHouse union all  select 'Self'  as [Name], (select COUNT(*) from Finance where  BranchId in (" + Godwn + ") and LoanType='Self'  and  DelvOn between '" + FromDate + "' and '" + ToDate + "' and DMSINVNo not in (Select distinct Trans_Ref_num from gd_fdi_trans where trans_type='VC') ) as [Self] union all  select 'Cash'  as [Name] ,(select COUNT(*) from Finance where  BranchId in (" + Godwn + ") and LoanType='Cash'  and  DelvOn between '" + FromDate + "' and '" + ToDate + "' and DMSINVNo not in (Select distinct Trans_Ref_num from gd_fdi_trans where trans_type='VC')) as Cash union all select 'Cancel_Retail'  as [Name], Count(Trans_ref_num) from (select distinct trans_ref_num from gd_fdi_trans,godown_mst where godown_mst.NEWCAR_RCPT=gd_fdi_trans.LOC_CD and Godw_Code in (" + Godwn + ") and  trans_type='VC' and   CONVERT(date, trans_date) between '" + FromDate + "' and '" + ToDate + "') as Cancel_Retail ";
            DataTable dt  =   OtherSqlConn.FillDataTable(str);


            Retail.Text = dt.AsEnumerable().Where(xc => xc["Name"].ToString() == "Retail").FirstOrDefault()["Retail"].ToString();
            InHouseFinance.Text = "0";// dt.AsEnumerable().Where(xc => xc["Name"].ToString() == "In-House").FirstOrDefault()["Retail"].ToString();
            SelfFinance.Text = "0";// dt.AsEnumerable().Where(xc => xc["Name"].ToString() == "Self").FirstOrDefault()["Retail"].ToString();
            CashRetail.Text = "0";// dt.AsEnumerable().Where(xc => xc["Name"].ToString() == "Cash").FirstOrDefault()["Retail"].ToString();
            RTLCancel.Text = dt.AsEnumerable().Where(xc => xc["Name"].ToString() == "Cancel_Retail").FirstOrDefault()["Retail"].ToString();

            Netretail.Text = (Retail.Text.ConvertInt() - RTLCancel.Text.ConvertInt()).ToString();


            HeadFinance.Text = "Retail Performance (MTD)";
        }

        protected void Ytd_Click(object sender, EventArgs e)
        {
            var NowDate = Common.DateTimeNow();
            

            string FromDate = new DateTime(Common.FinYear(NowDate), 4, 1).ToString("dd-MMM-yyyy");
            string ToDate = NowDate.ToString("dd-MMM-yyyy");

            var Godwn = BranchSelection();
            string str = "select  'Retail' as [Name],(select COUNT(*) from Finance where  BranchId in (" + Godwn + ")  and  DelvOn between '" + FromDate + "' and '" + ToDate + "' ) as Retail union all  select  'In-House'  as [Name]  , (select COUNT(*) from Finance where  BranchId in (" + Godwn + ") and LoanType='In-House'  and  DelvOn between '" + FromDate + "' and '" + ToDate + "'  and DMSINVNo not in (Select distinct Trans_Ref_num from gd_fdi_trans where trans_type='VC')) as InHouse union all  select 'Self'  as [Name], (select COUNT(*) from Finance where  BranchId in (" + Godwn + ") and LoanType='Self'  and  DelvOn between '" + FromDate + "' and '" + ToDate + "' and DMSINVNo not in (Select distinct Trans_Ref_num from gd_fdi_trans where trans_type='VC') ) as [Self] union all  select 'Cash'  as [Name] ,(select COUNT(*) from Finance where  BranchId in (" + Godwn + ") and LoanType='Cash'  and  DelvOn between '" + FromDate + "' and '" + ToDate + "' and DMSINVNo not in (Select distinct Trans_Ref_num from gd_fdi_trans where trans_type='VC')) as Cash union all select 'Cancel_Retail'  as [Name], Count(Trans_ref_num) from (select distinct trans_ref_num from gd_fdi_trans,godown_mst where godown_mst.NEWCAR_RCPT=gd_fdi_trans.LOC_CD and Godw_Code in (" + Godwn + ") and  trans_type='VC' and   CONVERT(date, trans_date) between '" + FromDate + "' and '" + ToDate + "') as Cancel_Retail ";
            DataTable dt = OtherSqlConn.FillDataTable(str);


            Retail.Text = dt.AsEnumerable().Where(xc => xc["Name"].ToString() == "Retail").FirstOrDefault()["Retail"].ToString();
            InHouseFinance.Text  = "0";//dt.AsEnumerable().Where(xc => xc["Name"].ToString() == "In-House").FirstOrDefault()["Retail"].ToString();
            SelfFinance.Text = "0";//dt.AsEnumerable().Where(xc => xc["Name"].ToString() == "Self").FirstOrDefault()["Retail"].ToString();
            CashRetail.Text = "0";//dt.AsEnumerable().Where(xc => xc["Name"].ToString() == "Cash").FirstOrDefault()["Retail"].ToString();
            RTLCancel.Text = dt.AsEnumerable().Where(xc => xc["Name"].ToString() == "Cancel_Retail").FirstOrDefault()["Retail"].ToString();

            Netretail.Text = (Retail.Text.ConvertInt() - RTLCancel.Text.ConvertInt()).ToString();
            HeadFinance.Text = "Retail Performance (YTD)";
        }

        protected void MTD_Finance_Click(object sender, EventArgs e)
        {
            var NowDate = Common.DateTimeNow();
            int MonthLast = DateTime.DaysInMonth(NowDate.Year, NowDate.Month);


            string FromDate = new DateTime(NowDate.Year, NowDate.Month, 1).ToString("dd-MMM-yyyy");
            string ToDate = NowDate.ToString("dd-MMM-yyyy");


            var Godwn = BranchSelection();
            string str = "declare  @typeinv  TABLE (Id nvarchar(300)) insert into @typeinv Select distinct Trans_Ref_num from gd_fdi_trans,godown_mst where  gd_fdi_trans.LOC_CD=godown_mst.NEWCAR_RCPT and Godw_Code in (" + Godwn + ") and trans_type='VC' select 'Delivered'  as [Name],[Data] from  (select COUNT(*) as [Data] from Finance where DeliveryDate  between '" + FromDate + "' and '" + ToDate + "' and  BranchId in (" + Godwn + ") and   DMSINVNo not in (select Id from @typeinv)) as Delivered union all  select 'BND'  as [Name],[Data] from  (select COUNT(*) as [Data] from Finance where DeliveryDate is null and  BranchId in (" + Godwn + ") and   DMSINVNo not in (select Id from @typeinv)) as BND union all  select 'In-House'  as [Name],[Data] from  (select COUNT(*) as [Data] from Finance where  DeliveryDate  between '" + FromDate + "' and '" + ToDate + "'  and LoanType='In-House' and    BranchId in (" + Godwn + ") and   DMSINVNo not in (select Id from @typeinv)) as InHouse  union all  select 'Self'  as [Name],[Data] from  (select COUNT(*) as [Data] from Finance where  DeliveryDate  between '" + FromDate + "' and '" + ToDate + "'  and LoanType='Self' and    BranchId in (" + Godwn + ") and   DMSINVNo not in (select Id from @typeinv)) as [Self] union all  select 'Cash'  as [Name],[Data] from  (select COUNT(*) as [Data] from Finance where  DeliveryDate  between '" + FromDate + "' and '" + ToDate + "'  and LoanType='Cash' and    BranchId in (" + Godwn + ") and   DMSINVNo not in (select Id from @typeinv)) as Cash  union all select 'DSA'  as [Name],[Data] from  (select COUNT(*) as [Data] from Finance where  DeliveryDate  between '" + FromDate + "' and '" + ToDate + "'  and LoanType='Bank Source' and    BranchId in (" + Godwn + ") and   DMSINVNo not in (select Id from @typeinv)) as BankSource ";
            DataTable dt = OtherSqlConn.FillDataTable(str);


            BND_Finance.Text = dt.AsEnumerable().Where(xc => xc["Name"].ToString() == "BND").FirstOrDefault()["Data"].ToString();

            Delivered_Finance.Text = dt.AsEnumerable().Where(xc => xc["Name"].ToString() == "Delivered").FirstOrDefault()["Data"].ToString();

            InHouse_Finance.Text = dt.AsEnumerable().Where(xc => xc["Name"].ToString() == "In-House").FirstOrDefault()["Data"].ToString();
            SelfFinance_Finance.Text = dt.AsEnumerable().Where(xc => xc["Name"].ToString() == "Self").FirstOrDefault()["Data"].ToString();
            CashRetail_Finance.Text = dt.AsEnumerable().Where(xc => xc["Name"].ToString() == "Cash").FirstOrDefault()["Data"].ToString();
            DSA_Finance.Text = dt.AsEnumerable().Where(xc => xc["Name"].ToString() == "DSA").FirstOrDefault()["Data"].ToString();


            Finance_Performance.Text = "Finance Performance (MTD)";
        }

        protected void Ytd_Finance_Click(object sender, EventArgs e)
        {
            var NowDate = Common.DateTimeNow();


            string FromDate = new DateTime(Common.FinYear(NowDate), 4, 1).ToString("dd-MMM-yyyy");
            string ToDate = NowDate.ToString("dd-MMM-yyyy");

            var Godwn = BranchSelection();
            string str = "declare  @typeinv  TABLE (Id nvarchar(300)) insert into @typeinv Select distinct Trans_Ref_num from gd_fdi_trans,godown_mst where  gd_fdi_trans.LOC_CD=godown_mst.NEWCAR_RCPT and Godw_Code in (" + Godwn + ") and trans_type='VC' select 'Delivered'  as [Name],[Data] from  (select COUNT(*) as [Data] from Finance where DeliveryDate  between '" + FromDate + "' and '" + ToDate + "' and  BranchId in (" + Godwn + ") and   DMSINVNo not in (select Id from @typeinv)) as Delivered union all  select 'BND'  as [Name],[Data] from  (select COUNT(*) as [Data] from Finance where DeliveryDate is null and  BranchId in (" + Godwn + ") and   DMSINVNo not in (select Id from @typeinv)) as BND union all  select 'In-House'  as [Name],[Data] from  (select COUNT(*) as [Data] from Finance where  DeliveryDate  between '" + FromDate + "' and '" + ToDate + "'  and LoanType='In-House' and    BranchId in (" + Godwn + ") and   DMSINVNo not in (select Id from @typeinv)) as InHouse  union all  select 'Self'  as [Name],[Data] from  (select COUNT(*) as [Data] from Finance where  DeliveryDate  between '" + FromDate + "' and '" + ToDate + "'  and LoanType='Self' and    BranchId in (" + Godwn + ") and   DMSINVNo not in (select Id from @typeinv)) as [Self] union all  select 'Cash'  as [Name],[Data] from  (select COUNT(*) as [Data] from Finance where  DeliveryDate  between '" + FromDate + "' and '" + ToDate + "'  and LoanType='Cash' and    BranchId in (" + Godwn + ") and   DMSINVNo not in (select Id from @typeinv)) as Cash  union all select 'DSA'  as [Name],[Data] from  (select COUNT(*) as [Data] from Finance where  DeliveryDate  between '" + FromDate + "' and '" + ToDate + "'  and LoanType='Bank Source' and    BranchId in (" + Godwn + ") and   DMSINVNo not in (select Id from @typeinv)) as BankSource ";
            DataTable dt = OtherSqlConn.FillDataTable(str);


            BND_Finance.Text = dt.AsEnumerable().Where(xc => xc["Name"].ToString() == "BND").FirstOrDefault()["Data"].ToString();

            Delivered_Finance.Text = dt.AsEnumerable().Where(xc => xc["Name"].ToString() == "Delivered").FirstOrDefault()["Data"].ToString();

            InHouse_Finance.Text = dt.AsEnumerable().Where(xc => xc["Name"].ToString() == "In-House").FirstOrDefault()["Data"].ToString();
            SelfFinance_Finance.Text = dt.AsEnumerable().Where(xc => xc["Name"].ToString() == "Self").FirstOrDefault()["Data"].ToString();
            CashRetail_Finance.Text = dt.AsEnumerable().Where(xc => xc["Name"].ToString() == "Cash").FirstOrDefault()["Data"].ToString();
            DSA_Finance.Text = dt.AsEnumerable().Where(xc => xc["Name"].ToString() == "DSA").FirstOrDefault()["Data"].ToString();


            Finance_Performance.Text = "Finance Performance (YTD)";
        }

        protected void MTD_Enabler_Click(object sender, EventArgs e)
        {
            var NowDate = Common.DateTimeNow();
            int MonthLast = DateTime.DaysInMonth(NowDate.Year, NowDate.Month);


            string FromDate = new DateTime(NowDate.Year, NowDate.Month, 1).ToString("dd-MMM-yyyy");
            string ToDate = NowDate.ToString("dd-MMM-yyyy");

            var Godwn = BranchSelection();
            string str = "select  'Retail' as [Name],(select COUNT(*) from Finance where  BranchId in (" + Godwn + ")  and  DelvOn between '" + FromDate + "' and '" + ToDate + "' ) as Retail union all  select  'In-House'  as [Name]  , (select COUNT(*) from Finance where  BranchId in (" + Godwn + ") and LoanType='In-House'  and  DelvOn between '" + FromDate + "' and '" + ToDate + "'  and DMSINVNo not in (Select distinct Trans_Ref_num from gd_fdi_trans where trans_type='VC')) as InHouse union all  select 'Self'  as [Name], (select COUNT(*) from Finance where  BranchId in (" + Godwn + ") and LoanType='Self'  and  DelvOn between '" + FromDate + "' and '" + ToDate + "' and DMSINVNo not in (Select distinct Trans_Ref_num from gd_fdi_trans where trans_type='VC') ) as [Self] union all  select 'Cash'  as [Name] ,(select COUNT(*) from Finance where  BranchId in (" + Godwn + ") and LoanType='Cash'  and  DelvOn between '" + FromDate + "' and '" + ToDate + "' and DMSINVNo not in (Select distinct Trans_Ref_num from gd_fdi_trans where trans_type='VC')) as Cash union all select 'Cancel_Retail'  as [Name], Count(Trans_ref_num) from (select distinct trans_ref_num from gd_fdi_trans,godown_mst where godown_mst.NEWCAR_RCPT=gd_fdi_trans.LOC_CD and Godw_Code in (" + Godwn + ") and  trans_type='VC' and   CONVERT(date, trans_date) between '" + FromDate + "' and '" + ToDate + "') as Cancel_Retail ";
            DataTable dt = OtherSqlConn.FillDataTable(str);


            Retail_Enabler.Text = dt.AsEnumerable().Where(xc => xc["Name"].ToString() == "Retail").FirstOrDefault()["Retail"].ToString();
            Ew_Enabler.Text = "0";// dt.AsEnumerable().Where(xc => xc["Name"].ToString() == "In-House").FirstOrDefault()["Retail"].ToString();
           MI_Enabler.Text = "0";// dt.AsEnumerable().Where(xc => xc["Name"].ToString() == "Self").FirstOrDefault()["Retail"].ToString();
            MGA_Enabler.Text = "0";// dt.AsEnumerable().Where(xc => xc["Name"].ToString() == "Cash").FirstOrDefault()["Retail"].ToString();
            RTLCancel_Enabler.Text = dt.AsEnumerable().Where(xc => xc["Name"].ToString() == "Cancel_Retail").FirstOrDefault()["Retail"].ToString();

            NetRetail_Enabler.Text = (Retail_Enabler.Text.ConvertInt() - RTLCancel_Enabler.Text.ConvertInt()).ToString();
            Enabler_Performance.Text = "Enabler Performance (MTD)";

        }

        protected void Ytd_Enabler_Click(object sender, EventArgs e)
        {
            var NowDate = Common.DateTimeNow();


            string FromDate = new DateTime(Common.FinYear(NowDate), 4, 1).ToString("dd-MMM-yyyy");
            string ToDate = NowDate.ToString("dd-MMM-yyyy");

            var Godwn = BranchSelection();


            string str = "select  'Retail' as [Name],(select COUNT(*) from Finance where  BranchId in (" + Godwn + ")  and  DelvOn between '" + FromDate + "' and '" + ToDate + "' ) as Retail union all  select  'In-House'  as [Name]  , (select COUNT(*) from Finance where  BranchId in (" + Godwn + ") and LoanType='In-House'  and  DelvOn between '" + FromDate + "' and '" + ToDate + "'  and DMSINVNo not in (Select distinct Trans_Ref_num from gd_fdi_trans where trans_type='VC')) as InHouse union all  select 'Self'  as [Name], (select COUNT(*) from Finance where  BranchId in (" + Godwn + ") and LoanType='Self'  and  DelvOn between '" + FromDate + "' and '" + ToDate + "' and DMSINVNo not in (Select distinct Trans_Ref_num from gd_fdi_trans where trans_type='VC') ) as [Self] union all  select 'Cash'  as [Name] ,(select COUNT(*) from Finance where  BranchId in (" + Godwn + ") and LoanType='Cash'  and  DelvOn between '" + FromDate + "' and '" + ToDate + "' and DMSINVNo not in (Select distinct Trans_Ref_num from gd_fdi_trans where trans_type='VC')) as Cash union all select 'Cancel_Retail'  as [Name], Count(Trans_ref_num) from (select distinct trans_ref_num from gd_fdi_trans,godown_mst where godown_mst.NEWCAR_RCPT=gd_fdi_trans.LOC_CD and Godw_Code in (" + Godwn + ") and  trans_type='VC' and   CONVERT(date, trans_date) between '" + FromDate + "' and '" + ToDate + "') as Cancel_Retail ";
            DataTable dt = OtherSqlConn.FillDataTable(str);


            Retail_Enabler.Text = dt.AsEnumerable().Where(xc => xc["Name"].ToString() == "Retail").FirstOrDefault()["Retail"].ToString();
            Ew_Enabler.Text = "0";// dt.AsEnumerable().Where(xc => xc["Name"].ToString() == "In-House").FirstOrDefault()["Retail"].ToString();
            MI_Enabler.Text = "0";// dt.AsEnumerable().Where(xc => xc["Name"].ToString() == "Self").FirstOrDefault()["Retail"].ToString();
            MGA_Enabler.Text = "0";// dt.AsEnumerable().Where(xc => xc["Name"].ToString() == "Cash").FirstOrDefault()["Retail"].ToString();
            RTLCancel_Enabler.Text = dt.AsEnumerable().Where(xc => xc["Name"].ToString() == "Cancel_Retail").FirstOrDefault()["Retail"].ToString();

            NetRetail_Enabler.Text = (Retail_Enabler.Text.ConvertInt() - RTLCancel_Enabler.Text.ConvertInt()).ToString();
            Enabler_Performance.Text = "Enabler Performance (YTD)";

        }


        private  string  BranchSelection()
        {
            string Godwn = "";

            

            string GodwnSelect = "";
            foreach (ListItem listItem in BranchId.Items)
            {
                if (listItem.Selected)
                {
                    GodwnSelect = GodwnSelect.Length > 0 ? GodwnSelect + "," + listItem.Value : listItem.Value;
                }
            }
            string ChanelSelection = "";
            foreach (ListItem listItem in Chanel.Items)
            {
                if (listItem.Selected)
                {
                    ChanelSelection = ChanelSelection.Length > 0 ? ChanelSelection + "," + listItem.Value : listItem.Value;
                }
            }

            string RegionSelecton = "";
            foreach (ListItem listItem in Region.Items)
            {
                if (listItem.Selected)
                {
                    RegionSelecton = RegionSelecton.Length > 0 ? RegionSelecton + "," + listItem.Value : listItem.Value;
                }
            }


            if (GodwnSelect.Length > 0)
            {
                Godwn = GodwnSelect;
            }
            else if (ChanelSelection.Length > 0)
            {
                Godwn = ChanelSelection;
            }
            else if (RegionSelecton.Length > 0)
            {
                Godwn = RegionSelecton;
            }
            else
            {
                Godwn = string.Join(",", (SiteSession.GetGodawanListSession.Select(xc => xc.Id.ToString()).ToArray()));
            }
            return Godwn;
        }

        protected void Region_SelectedIndexChanged(object sender, EventArgs e)
        {
            string RegionSelecton = "";
            foreach (ListItem listItem in Region.Items)
            {
                if (listItem.Selected)
                {
                    RegionSelecton = RegionSelecton.Length > 0 ? RegionSelecton + "," + listItem.Value : listItem.Value;
                }
            }

            DataSet ParaData = OtherSqlConn.FillDataSet("select stuff((select ',' + convert(nvarchar(50),u.Godw_Code) from godown_mst  u where  Godw_Code in (" + RegionSelecton + ") and  u.Br_Segment = godown_mst.Br_Segment for xml path('')),1,1,'') as Godw_Code,isnull( Br_Segment,'') as Br_Segment from  godown_mst  where  Godw_Code in (" + RegionSelecton + ")  group by Br_Segment");

            ParaData.Tables[0].AsEnumerable().ToList().ForEach(xc => {

                Chanel.Items.Add(new ListItem() { Text = xc["Br_Segment"].ToString(), Value = xc["Godw_Code"].ToString() });
            });


            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#ParameterSelectionModal').modal('show')", true);
        }

        protected void Chanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#ParameterSelectionModal').modal('show')", true);
        }
    }
}