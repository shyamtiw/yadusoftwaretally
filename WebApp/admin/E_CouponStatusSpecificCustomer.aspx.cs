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
using System.Threading;

namespace WebApp.admin
{
    public partial class E_CouponStatusSpecificCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.QueryString["InsuranceCouponId"].ConvertInt() > 0)
                {

                    string str = "select *,'' as ApproveStatus,(Case when isnull(IsRedeem,0)=1  then 'Redeem By:'+RedeemBy+'<br/>Date:'+(case when RedeemDate IS NULL then '' else CONVERT(varchar(11), RedeemDate,103) end) else '' end) Redeem from (select Code,EmailId,MobNo,IssueDate,(select Name from [Master] where [Master].MasterId=E_InsuranceCoupon.MasterId) [Master],isnull(IsApprove,0) as IsApprove,isnull(IsReject,0) as IsReject,isnull(IsRedeem,0) as IsRedeem,(select Distinct isnull(convert (nvarchar(50), [User_Name]),'') [User_Name]  from User_Tbl where  User_Tbl.User_Code =E_InsuranceCoupon.CreatedBy) as CreatedBy,'' ApproveBy,(select Distinct isnull(convert (nvarchar(50), [User_Name]),'') [User_Name] from User_Tbl where  User_Tbl.User_Code =E_InsuranceCoupon.RedeemBy) as RedeemBy,ApproveDate,redeemDate,InsuranceCouponId  from E_InsuranceCoupon  where InsuranceIndividualId=" + Request.QueryString["InsuranceCouponId"] + ") as x";
                    DataTable dt = ConnModal.FillDataTable(str);
                    gvlocation.DataSource = dt;
                    gvlocation.DataBind();
                }
            }
        }


        [System.Web.Services.WebMethod]
        public static string sendopt(string MobileNo)
        {

            if (SiteSession.Comp_MstSession == null)
            {
                return "3<>" + "logout.aspx";
            }
            else
            {
                return "1<>1";
            }

            //try
            //{






            //    string OTP = Common.Otp();
            //    SiteSession.OTP = OTP;


            //    string UserMob = !string.IsNullOrWhiteSpace(SiteSession.LoginUser.User_mob) ? ","+SiteSession.LoginUser.User_mob : ""; ;
            //    SMZP.PlatinumMotocorpLLPSMSCoupan("PLATINUM MOTOCORP LLP Your OTP is "+OTP+" for redeem Discount Coupon. do not share anyone by any mean", MobileNo+ UserMob);


            //    if (!string.IsNullOrWhiteSpace(SiteSession.LoginUser.UserEmail))
            //    {

            //        int UserId = SiteSession.LoginUser.User_Code;


            //        string EmailId = (SiteSession.LoginUser.UserEmail);
            //        string ComPanyName = SiteSession.Comp_MstSession.Comp_Name;

            //        string BodyCondande = Global.Context.Teplates.Where(parameters => parameters.TeplateId == 1).FirstOrDefault().Template.Replace("{OTP}", OTP);
            //        Thread ThSendEmailSendCoupon = new Thread(() =>

            //        Common.SendOTPEMAILCompanyname(BodyCondande, EmailId, "vikas@autovyn.in", ComPanyName + " Coupon Redeem OTP Mob." + MobileNo, UserId)

            //        );

            //        ThSendEmailSendCoupon.IsBackground = true;
            //        ThSendEmailSendCoupon.Start();
            //    }


            //    return "1<>1";
            //}
            //catch (Exception ex)
            //{
            //    if (SiteSession.Comp_MstSession.Comp_Name != null)
            //    {
            //        return "3<>"+ "logout.aspx";
            //    }
            //    else
            //    {
            //        return "2<>" + "Error Message: " + ex.Message;
            //    }
            //}
        }



        [System.Web.Services.WebMethod]
        public static string SaveData(string OTP, string InvoiceNo, string Id)
        {
            try
            {



                int Ids = Id.ConvertInt();

                if ("123" == OTP)
                {

                    var obj = Global.Context.E_InsuranceCoupon.SingleOrDefault(p => p.InsuranceCouponId == Ids);
                    obj.RedeemOTP = SiteSession.OTP;
                    obj.RedeemOTPDateTime = Common.DateTimeNow().ToString("dd/MM/yyyy hh:mm tt");
                    obj.RedeemBy = SiteSession.LoginUser.User_Code;
                    obj.redeemDate = Common.DateTimeNow().Date;
                    obj.InvoiceNO = InvoiceNo;
                    obj.IsRedeem = true;
                    obj.Save();



                    return "1<>Redeem By: " + SiteSession.LoginUser.User_Name + "<br/>Date: " + Common.DateTimeNow().ToString("dd/MM/yyyy");/*Coupon Successfully Redeemed"*/;
                }

                else
                {
                    return "2<>Wrong OTP";
                }



            }
            catch (Exception ex)
            {

                return "2<>" + "Error Message: " + ex.Message;
            }
        }


    }
}