using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.admin.ReportModal;
using Business;
using WebApp.LIBS;
namespace WebApp.admin
{
    public partial class DiscountUpdate : System.Web.UI.Page
    {
        public static int InSt = -1;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString != null && !string.IsNullOrEmpty(Convert.ToString(Request.QueryString["ReciptId"])))
                {
                    FillTables();
                }
            }

        }


        private void FillTables()
        {
             DataRow FianceData = OtherSqlConn.FillDataTable("select * from Finance where   FinanceId=" + Request.QueryString["ReciptId"].ToString() + "").AsEnumerable().FirstOrDefault();

            //string RegionList = string.Join(",", SiteSession.GetGodawanListSession.Select(p => "'"+p.Region+"'").ToArray());
            var DataArray = SiteSession.GetGodawanListSession.Where(xc => xc.Id == Convert.ToInt32(FianceData["BranchId"])).FirstOrDefault().Region;
            string Variant_CD = FianceData["Variant_CD"].ToString();
            DateTime DelvOn = Convert.ToDateTime(FianceData["DelvOn"]);
            //  var  dtConStr = Global.Context.cons_disc.AsEnumerable().Where(xc => xc.REGION== DataArray && xc.MODELID == Variant_CD && DelvOn >= xc.VALIDFROM && DelvOn <= xc.VALIDUPTO).ToList();

            var dtConStr = Global.Context.ExecuteStoreQuery<conscheme>("select * from cons_disc where REGION='" + DataArray + "' and MODELID ='" + Variant_CD + "' and '" + DelvOn.ToString("dd-MMM-yyyy") + "' >= VALIDFROM and '" + DelvOn.ToString("dd-MMM-yyyy") + "' <= VALIDUPTO").ToList();
            

            DataTable dt = OtherSqlConn.FillDataTable("select AutoId,Head,AsperMSIL,OfferValue,Difference,Beforetax,MSILShare,DealerShare,SchemeDetails,(case  when ValidFrom  is not null then  CONVERT(varchar(10),ValidFrom,103) else '' end )  as ValidFrom,(case  when ValidUpto  is not null then  CONVERT(varchar(10),ValidUpto,103) else '' end )  as ValidUpto,(case  when MIDueDate  is not null then  CONVERT(varchar(10),MIDueDate,103) else '' end )  as MIDueDate,Remarks,LOC_CD,TRANS_ID,utd,FinanceId from  DiscountManage where   FinanceId=" + Request.QueryString["ReciptId"].ToString() + "  and Head !='Consumer Offer' union all select AutoId,Head,AsperMSIL,OfferValue,Difference,Beforetax,MSILShare,DealerShare,SchemeDetails,(case  when ValidFrom  is not null then  CONVERT(varchar(10),ValidFrom,103) else '' end )  as ValidFrom,(case  when ValidUpto  is not null then  CONVERT(varchar(10),ValidUpto,103) else '' end )  as ValidUpto,(case  when MIDueDate  is not null then  CONVERT(varchar(10),MIDueDate,103) else '' end )  as MIDueDate,Remarks,LOC_CD,TRANS_ID,utd,FinanceId from  DiscountManage where   FinanceId=" + Request.QueryString["ReciptId"].ToString() + "  and Head ='Consumer Offer'");
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

                    try{ dr["AsperMSIL"] = dtConStr.Where(p=> p.OFFERTYPE==0).FirstOrDefault().TOTDISC.Value;   } catch { dr["AsperMSIL"] = 0; }
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

                Common.BindControldt(MSCLRepiter, dt.AsEnumerable().Where(drx => drx["Calc"].ToString() == "0" || drx["Calc"].ToString() == "2").CopyToDataTable());
                Common.BindControldt(RipRepiter, dt.AsEnumerable().Where(drx => drx["Calc"].ToString() == "1").CopyToDataTable());

                try
                {
                    if (dt.AsEnumerable().Where(p => p["Head"].ToString() == "Consumer Offer").Count() > 0)
                    {
                        Breackup.Text = dt.AsEnumerable().Where(drx => drx["Calc"].ToString() == "2").FirstOrDefault()["OfferValue"].ToString();
                        BreackuphideData.Value = Breackup.Text;
                    }
                }
                catch { }
            }
        }

        protected void sendemail_Click(object sender, EventArgs e)
        {

            try
            {
                string UpdateStrMainGrid = "";
                for (int i = 0; i < MSCLRepiter.Items.Count; i++)
                {
                    var AutoId = (MSCLRepiter.Items[i].FindControl("AutoId") as HiddenField).Value;
                    var AsperMSIL = (MSCLRepiter.Items[i].FindControl("AsperMSIL") as TextBox).Text;
                    var OfferValue = (MSCLRepiter.Items[i].FindControl("OfferValue") as TextBox).Text;
                    var Difference = (MSCLRepiter.Items[i].FindControl("Difference") as TextBox).Text;
                    var Beforetax = (MSCLRepiter.Items[i].FindControl("Beforetax") as TextBox).Text;
                    var MSILShare = (MSCLRepiter.Items[i].FindControl("MSILShare") as TextBox).Text;
                    var DealerShare = (MSCLRepiter.Items[i].FindControl("DealerShare") as TextBox).Text;

                    var SchemeDetails = (MSCLRepiter.Items[i].FindControl("SchemeDetails") as TextBox).Text;
                    var ValidFrom = (MSCLRepiter.Items[i].FindControl("ValidFrom") as TextBox).Text.Length > 0 ? "'"+(MSCLRepiter.Items[i].FindControl("ValidFrom") as TextBox).Text.DateConvertTextMatchCase().ToString("dd-MMM-yyyy")+"'" : "null";
                    var ValidUpto = (MSCLRepiter.Items[i].FindControl("ValidUpto") as TextBox).Text.Length > 0 ? "'" + (MSCLRepiter.Items[i].FindControl("ValidUpto") as TextBox).Text.DateConvertTextMatchCase().ToString("dd-MMM-yyyy")+"'" : "null";
                    var MIDueDate = (MSCLRepiter.Items[i].FindControl("MIDueDate") as TextBox).Text.Length > 0 ? "'" + (MSCLRepiter.Items[i].FindControl("MIDueDate") as TextBox).Text.DateConvertTextMatchCase().ToString("dd-MMM-yyyy")+"'" : "null";
                    var Remarks = (MSCLRepiter.Items[i].FindControl("Remarks") as TextBox).Text;
                    UpdateStrMainGrid = UpdateStrMainGrid + ";update DiscountManage set AsperMSIL=" + AsperMSIL + "," +
                        "OfferValue = " + OfferValue + "," +
                        "Difference = " + Difference + "," +
                        "Beforetax = " + Beforetax + "," +
                        "MSILShare = " + MSILShare + "," +
                        "DealerShare = " + DealerShare + "," +
                        "SchemeDetails = '" + SchemeDetails.Replace("'","'") + "'," +
                        "ValidFrom = " + ValidFrom + "," +
                        "ValidUpto = " + ValidUpto + "," +
                        "MIDueDate = " + MIDueDate + "," +
                        "Remarks = '" + Remarks.Replace("'","''") + "' " + " " +
                        "where AutoId = " + AutoId + "";
                }
                OtherSqlConn.ExequteQuey(UpdateStrMainGrid);
                UpdateStrMainGrid = "";
                for (int i = 0; i < RipRepiter.Items.Count; i++)
                {

                    var AutoId = (RipRepiter.Items[i].FindControl("AutoId") as HiddenField).Value;
                    var FinanceId = (RipRepiter.Items[i].FindControl("FinanceId") as HiddenField).Value;
                    var Head = (RipRepiter.Items[i].FindControl("Head") as Label).Text;
                    var LOC_CD = (RipRepiter.Items[i].FindControl("LOC_CD") as HiddenField).Value;
                    var TRANS_ID = (RipRepiter.Items[i].FindControl("TRANS_ID") as HiddenField).Value;
                    var utd = (RipRepiter.Items[i].FindControl("utd") as HiddenField).Value;
                    var AsperMSIL = (RipRepiter.Items[i].FindControl("AsperMSIL") as TextBox).Text;
                    var OfferValue = (RipRepiter.Items[i].FindControl("OfferValue") as TextBox).Text;
                    var Difference = (RipRepiter.Items[i].FindControl("Difference") as TextBox).Text;
                    var Beforetax = (RipRepiter.Items[i].FindControl("Beforetax") as TextBox).Text;
                    var MSILShare = (RipRepiter.Items[i].FindControl("MSILShare") as TextBox).Text;
                    var DealerShare = (RipRepiter.Items[i].FindControl("DealerShare") as TextBox).Text;

                    var SchemeDetails = (RipRepiter.Items[i].FindControl("SchemeDetails") as TextBox).Text;
                    var ValidFrom = (RipRepiter.Items[i].FindControl("ValidFrom") as TextBox).Text.Length > 0 ? "'" + (RipRepiter.Items[i].FindControl("ValidFrom") as TextBox).Text.DateConvertTextMatchCase().ToString("dd-MMM-yyyy") + "'" : "null";
                    var ValidUpto = (RipRepiter.Items[i].FindControl("ValidUpto") as TextBox).Text.Length > 0 ? "'" + (RipRepiter.Items[i].FindControl("ValidUpto") as TextBox).Text.DateConvertTextMatchCase().ToString("dd-MMM-yyyy") + "'" : "null";
                    var MIDueDate = (RipRepiter.Items[i].FindControl("MIDueDate") as TextBox).Text.Length > 0 ? "'" + (RipRepiter.Items[i].FindControl("MIDueDate") as TextBox).Text.DateConvertTextMatchCase().ToString("dd-MMM-yyyy") + "'" : "null";
                    var Remarks = (RipRepiter.Items[i].FindControl("Remarks") as TextBox).Text;

                    if (Common.ConvertInt(AutoId) > 0)
                    {
                        UpdateStrMainGrid = UpdateStrMainGrid + ";update DiscountManage set AsperMSIL=" + AsperMSIL + "," +
                 "OfferValue = " + OfferValue + "," +
                 "Difference = " + Difference + "," +
                 "Beforetax = " + Beforetax + "," +
                 "MSILShare = " + MSILShare + "," +
                 "DealerShare = " + DealerShare + "," +
                 "SchemeDetails = '" + SchemeDetails.Replace("'","''") + "'," +
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
                            "'" + SchemeDetails.Replace("'","''") + "'," +
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
                OtherSqlConn.ExequteQuey("Update Finance set DiscountUserId="+SiteSession.LoginUser.User_Code+"  where   FinanceId="+Request.QueryString["ReciptId"].ToString() +"");

                FillTables();

                MessageBox.ShowMessage("Success", "successfully data Saved", SiteKey.MessageType.success);

            }
            catch (Exception ex)
            {
                String Message = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                if (Message.Contains("UNIQUE KEY")) { Message = "Record/Username already exists. Please choose another."; }
                MessageBox.ShowMessage("Error", Message, SiteKey.MessageType.danger);
            }

        }
        public class conscheme {


            public int ConsOfferId { get; set; }
            public DateTime? OFFERMONTH { get; set; }
            public string MODELID { get; set; }
            public decimal? TOTDISC { get; set; }
            public decimal? DISCWITHOUTGST { get; set; }
            public decimal? ISLDISC { get; set; }
            public decimal? DLRDISC { get; set; }
            public DateTime? VALIDFROM { get; set; }
            public DateTime? VALIDUPTO { get; set; }
            public string OFFERDESC { get; set; }
            public int? OFFERTYPE { get; set; }
            public DateTime? MIDUEDATE { get; set; }
            public string REGION { get; set; }
            public string COMPCODE { get; set; }
            public string MFGAPPLY { get; set; }

        }
    }
}