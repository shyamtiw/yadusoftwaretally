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
    public partial class CouponBalanceReport :BasePageClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string[] Array = Global.Context.Masters.AsEnumerable().Where(print => print.MasterParentId == 2).Select(p => p.Name.Replace(" ", "")).ToArray();
                var ArrayItem = string.Join(",", Array);

                var TotalArray = Array.Select(p => string.Concat("isnull(", p, ",0)")).ToArray();

                var TotalConvert = ",(" + string.Join("+", TotalArray) + ") as Total ";
                var TotalConvertRedeem = ",(" + string.Join("+", TotalArray) + ") as RedeemTotal ";

                var ArrayItemCaptionRedeem = string.Join(",", Array.Select(p => p + " as Redeem" + p));

                var TotalArrayBalance = Array.Select(p => string.Concat("(isnull(", p, ",0)-", "isnull(Redeem", p, ",0)) as Bal", p)).ToArray();
                string str = "select *," + string.Join(",", TotalArrayBalance) + ",(isnull(Total,0)-isnull(RedeemTotal,0)) as Balance from  (select x.InsuranceIndividualId,InsuranceCouponId,isnull( ApproveBy,'') as ApproveBy,isnull( CreateBy,'') as CreateBy,CustomerName,VehicleRegnNo,isnull(EmailId,'') as EmailId ," + ArrayItem + " " + TotalConvert + "  from   (select InsuranceIndividualId,InsuranceCouponId,ApproveBy,CreateBy,EmailId, " + ArrayItem + " from( select x.InsuranceIndividualId, (select top 1 ISNULL(EmailId,'') from InsuranceCoupon where InsuranceCoupon.InsuranceIndividualId = (x.InsuranceIndividualId)  and Comp_Code=" + SiteSession.Comp_MstSession.Comp_Code + " and LEN( ISNULL(EmailId,''))>0) as EmailId ,(select top 1 stuff(( select ',' + u.InsuranceCouponId from  (select convert (nvarchar(50), InsuranceCouponId)+'_'+convert (nvarchar(50), MasterId) InsuranceCouponId from InsuranceCoupon where InsuranceCoupon.InsuranceIndividualId in (x.InsuranceIndividualId) and    isnull(IsApprove,0)=1 and Comp_Code=" + SiteSession.Comp_MstSession.Comp_Code + ") u for xml path('') ),1,1,'')) as  InsuranceCouponId,(select top 1 stuff(( select ',' + u.[User_Name] from  (select Distinct isnull(convert (nvarchar(50), [User_Name]),'') [User_Name] from User_Tbl where User_Tbl.User_Code in (select CreatedBy from  InsuranceCoupon where InsuranceCoupon.InsuranceIndividualId=x.InsuranceIndividualId and isnull(IsApprove,0)=1 and Comp_Code=" + SiteSession.Comp_MstSession.Comp_Code + ")) u for xml path('') ),1,1,'') ) as  CreateBy,(select top 1 stuff(( select ',' + u.[User_Name] from  (select Distinct isnull(convert (nvarchar(50), [User_Name]),'') [User_Name] from User_Tbl where User_Tbl.User_Code in (select CreatedBy from  InsuranceCoupon where InsuranceCoupon.InsuranceIndividualId=x.InsuranceIndividualId and isnull(IsApprove,0)=1 and Comp_Code=" + SiteSession.Comp_MstSession.Comp_Code + ")) u for xml path('') ),1,1,'') ) as  ApproveBy ,replace( Name,' ','') as Name,TotalCoupon from (select InsuranceIndividualId,MasterId,COUNT(*) as TotalCoupon from  (select   InsuranceCouponId,MasterId,MobNo,InsuranceIndividualId from InsuranceCoupon  where   isnull(IsApprove,0)=1 and Comp_Code=" + SiteSession.Comp_MstSession.Comp_Code + ") as x group by InsuranceIndividualId,MasterId ) as x  left join [Master] on x.MasterId=[Master].MasterId  ) d pivot ( sum(TotalCoupon) for Name in (" + ArrayItem + ") ) piv) as x left join  InsuranceIndividual on  x.InsuranceIndividualId=InsuranceIndividual.InsuranceIndividualId) as x left join (select x.InsuranceIndividualId,isnull(RedeemBy,'') as RedeemBy,VehicleRegnNo," + ArrayItemCaptionRedeem + " " + TotalConvertRedeem + "  from   (select InsuranceIndividualId,RedeemBy," + ArrayItem + " from( select x.InsuranceIndividualId,(select top 1 stuff(( select ',' + u.[User_Name] from  (select Distinct isnull(convert (nvarchar(50), [User_Name]),'') [User_Name] from User_Tbl where User_Tbl.User_Code in (select RedeemBy from  InsuranceCoupon where InsuranceCoupon.InsuranceIndividualId=x.InsuranceIndividualId and isnull(IsRedeem,0)=1 and Comp_Code=" + SiteSession.Comp_MstSession.Comp_Code + ")) u for xml path('') ),1,1,'') ) as  RedeemBy ,replace( Name,' ','') as Name,TotalCoupon from (select InsuranceIndividualId,MasterId,COUNT(*) as TotalCoupon from  (select   InsuranceCouponId,MasterId,MobNo,InsuranceIndividualId from InsuranceCoupon  where   isnull(IsRedeem,0)=1 and Comp_Code=" + SiteSession.Comp_MstSession.Comp_Code + ") as x group by InsuranceIndividualId,MasterId ) as x  left join [Master] on x.MasterId=[Master].MasterId  ) d pivot ( sum(TotalCoupon) for Name in (" + ArrayItem + ") ) piv) as x left join  InsuranceIndividual on  x.InsuranceIndividualId=InsuranceIndividual.InsuranceIndividualId) as y  on x.InsuranceIndividualId=y.InsuranceIndividualId";
                DataTable dt = ConnModal.FillDataTable(str);

                foreach (DataColumn dr in dt.Columns)
                {
                    if (!"InsuranceCouponId,InsuranceIndividualId,InsuranceIndividualId1,CustomerName,EmailId,CreateBy,RedeemBy,ApproveBy,VehicleRegnNo1".Split(',').Contains(dr.ColumnName))
                    {
                        BoundField newColumnName = new BoundField();
                        newColumnName.DataField = dr.ColumnName;
                        newColumnName.HeaderText = Common.AddSpacesToSentence(dr.ColumnName);
                        gvlocation.Columns.Add(newColumnName);
                    }


                }


                gvlocation.DataSource = dt;

                gvlocation.DataBind();

            }
        }
    }
}