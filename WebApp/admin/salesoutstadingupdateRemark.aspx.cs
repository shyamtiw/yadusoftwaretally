using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.admin.ReportModal;
using WebApp.LIBS;
namespace WebApp.admin
{
    public partial class salesoutstadingupdateRemark : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillTable();
               


            }
            #region Location
            if (Request.QueryString != null && !string.IsNullOrEmpty(Convert.ToString(Request.QueryString["SalesOutstatingRemarkID"])) && LIBS.Common.ConvertInt(savelocation.CommandArgument) == 0)
            {
                savelocation.CommandArgument = Convert.ToString(Request.QueryString["SalesOutstatingRemarkID"]);
                BindLocation(LIBS.Common.ConvertInt(savelocation.CommandArgument));
            }
            if (Request.QueryString["SalesOutstatingRemarkID"].ConvertInt() > 0)
            {
                if (Request.QueryString != null && !string.IsNullOrEmpty(Convert.ToString(Request.QueryString["SalesOutstatingRemarkID"])) && LIBS.Common.ConvertInt(savelocation.CommandArgument) != Request.QueryString["SalesOutstatingRemarkID"].ConvertInt())
                {
                    savelocation.CommandArgument = Convert.ToString(Request.QueryString["SalesOutstatingRemarkID"]);
                }
            }
            #endregion
        }


        #region LocationData
        private void FillTable()
        {
            try
            {
                
                var  Tot= OtherSqlConn.FillDataTable("select * from [SalesOutstatingRemark] where Ledg_Ac=" + Request.QueryString["Ledg_Ac"] + "");
                
            
                LIBS.Common.BindControldt(gvlocation, Tot);

            }
            catch { }


        }


        private void BindLocation(int v)
        {
        var obj=    OtherSqlConn.FillDataTable("select * from [SalesOutstatingRemark] where  SalesOutstatingRemarkID=" + Request.QueryString["SalesOutstatingRemarkID"] + "").Rows[0];
            {



                Remark.Text = obj["Remark"].ToString();

             

            }
        }



        protected void Upload(object sender, EventArgs e)
        {
            try
            {

                if (Page.IsValid)
                {
                    string Ledg_Ac = Request.QueryString["Ledg_Ac"].ToString();
                    string PendingAmt = Request.QueryString["PendingAmt"].ToString();
                    string clientIp = (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ??
                System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]).Split(',')[0].Trim();
                    if (LIBS.Common.ConvertInt(savelocation.CommandArgument) > 0)
                    {
                        int projectid = LIBS.Common.ConvertInt(savelocation.CommandArgument);
                        using (TransactionScope Trans = new TransactionScope())
                        {


                            OtherSqlConn.ExequteQuey("update [SalesOutstatingRemark] set  [UserName]='" + SiteSession.LoginUser.User_Name + "',[Ledg_Ac]='" + Ledg_Ac + "',[PendingAmt]="+ PendingAmt + ",[Remark]='"+Remark.Text+"',[Date]='"+Common.DateTimeNow().ToString("dd-MMM-yyyy hh:mm tt")+"',[UserId]="+SiteSession.LoginUser.User_Code+",[Ip]='"+ clientIp + "' where SalesOutstatingRemarkID="+ projectid + "");
                                FillTable();
                                Trans.Complete();
                           
                        }
                        Response.Redirect("salesoutstadingupdateRemark.aspx?Ledg_Ac=" + Ledg_Ac + "&&PendingAmt=" + PendingAmt + "", false);
                    }
                    else
                    {
                        using (TransactionScope Trans = new TransactionScope())
                        {
                            OtherSqlConn.ExequteQuey("insert into [SalesOutstatingRemark] ([UserName],[Ledg_Ac],[PendingAmt],[Remark],[Date],[UserId],[Ip]) values ('" + SiteSession.LoginUser.User_Name + "','" + Ledg_Ac + "'," + PendingAmt + ",'" + Remark.Text + "','" + Common.DateTimeNow().ToString("dd-MMM-yyyy hh:mm tt") + "'," + SiteSession.LoginUser.User_Code + ",'" + clientIp + "')");
                            FillTable();
                            Trans.Complete();
                        }

                        Remark.Text = "";
                       
                        MessageBox.ShowMessage("Success", "successfully data Saved", SiteKey.MessageType.success);
                    }

                }

            }
            catch (Exception ex)
            {
                String Message = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                if (Message.Contains("UNIQUE KEY")) { Message = "Record/Username already exists. Please choose another."; }
                MessageBox.ShowMessage("Error", Message, SiteKey.MessageType.danger);
            }
        }
        #endregion
       
    }
}