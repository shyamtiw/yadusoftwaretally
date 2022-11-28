using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.LIBS;
using Business;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using WebApp.admin.ReportModal;
using System.IO;
using SelectPdf;
using Emailer;
using System.Threading;
namespace WebApp.admin
{
    public partial class NotReadeemCoupon : BasePageClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string[] Array = Global.Context.Masters.AsEnumerable().Where(print => print.MasterParentId == 2).Select(p => p.Name.Replace(" ", "")).ToArray();
                var ArrayItem = string.Join(",", Array);

                var TotalArray = Array.Select(p => string.Concat("isnull(", p, ",0)")).ToArray();

                var TotalConvert = ",(" + string.Join("+", TotalArray) + ") as Total ";





                string str = "select x.InsuranceIndividualId,InsuranceCouponId,isnull( CreateBy,'') as CreateBy,ApproveBy,CustomerName,VehicleRegnNo,isnull(EmailId,'') as EmailId , " + ArrayItem + " " + TotalConvert + " from  (select InsuranceIndividualId,InsuranceCouponId,CreateBy,ApproveBy,EmailId," + ArrayItem + " from( select x.InsuranceIndividualId, (select top 1 ISNULL(EmailId,'') from InsuranceCoupon where InsuranceCoupon.InsuranceIndividualId = (x.InsuranceIndividualId)  and Comp_Code= " + SiteSession.Comp_MstSession.Comp_Code + " and LEN( ISNULL(EmailId,''))>0) as EmailId , (select top 1 stuff(( select ',' + u.InsuranceCouponId from   (select convert (nvarchar(50), InsuranceCouponId)+'_'+convert (nvarchar(50), MasterId) InsuranceCouponId from InsuranceCoupon where InsuranceCoupon.InsuranceIndividualId in (x.InsuranceIndividualId) and    isnull( IsApprove,0)=1 and isnull(IsRedeem,0)=0 and Comp_Code= " + SiteSession.Comp_MstSession.Comp_Code + ") u for xml path('') ),1,1,'')) as  InsuranceCouponId, (select top 1 stuff(( select ',' + u.[User_Name] from   (select Distinct isnull(convert (nvarchar(50), [User_Name]),'') [User_Name] from User_Tbl where  User_Tbl.User_Code in (select CreatedBy from  InsuranceCoupon where InsuranceCoupon.InsuranceIndividualId=x.InsuranceIndividualId and isnull( IsApprove,0)=1 and isnull(IsRedeem,0)=0 and Comp_Code= " + SiteSession.Comp_MstSession.Comp_Code + ")) u for xml path('') ),1,1,'') ) as  CreateBy, (select top 1 stuff(( select ',' + u.[User_Name] from   (select Distinct isnull(convert (nvarchar(50), [User_Name]),'') [User_Name] from User_Tbl where  User_Tbl.User_Code in (select ApproveBy from  InsuranceCoupon where InsuranceCoupon.InsuranceIndividualId=x.InsuranceIndividualId and isnull( IsApprove,0)=1 and isnull(IsRedeem,0)=0 and Comp_Code= " + SiteSession.Comp_MstSession.Comp_Code + ")) u for xml path('') ),1,1,'') ) as  ApproveBy  ,replace( Name,' ','') as Name,TotalCoupon from (select InsuranceIndividualId,MasterId,COUNT(*) as TotalCoupon from  (select   InsuranceCouponId,MasterId,MobNo,InsuranceIndividualId from InsuranceCoupon  where   isnull( IsApprove,0)=1 and isnull(IsRedeem,0)=0 and Comp_Code= " + SiteSession.Comp_MstSession.Comp_Code + ") as x group by InsuranceIndividualId,MasterId ) as x  left join [Master] on x.MasterId=[Master].MasterId  ) d pivot  ( sum(TotalCoupon) for Name in (" + ArrayItem + ") ) piv) as x left join InsuranceIndividual on  x.InsuranceIndividualId=InsuranceIndividual.InsuranceIndividualId";
                DataTable dt = ConnModal.FillDataTable(str);
                
                foreach (DataColumn dr in dt.Columns)
                {
                    if (!"InsuranceCouponId,InsuranceIndividualId,CustomerName,EmailId,CreateBy".Split(',').Contains(dr.ColumnName))
                    {
                        BoundField newColumnName = new BoundField();

                        newColumnName.DataField = dr.ColumnName;
                        newColumnName.HeaderText = Common.AddSpacesToSentence(dr.ColumnName);

                        gvlocation.Columns.Add(newColumnName);
                    }


                }

                //HiddenField lnkView = new HiddenField();
                //lnkView.ID = "lnkView";
                //lnkView.Text = "View";
                //lnkView.Click += ViewDetails;
                //lnkView.CommandArgument = (e.Row.DataItem as DataRowView).Row["Id"].ToString();
                //e.Row.Cells[2].Controls.Add(lnkView);



                gvlocation.DataSource = dt;

                gvlocation.DataBind();
            }


        }


        protected void StuclsIds_TextChanged(object sender, EventArgs e)
        {

            string[] Array = Global.Context.Masters.AsEnumerable().Where(print => print.MasterParentId == 2).Select(p => p.Name.Replace(" ", "")).ToArray();
            var ArrayItem = string.Join(",", Array);

            var TotalArray = Array.Select(p => string.Concat("isnull(", p, ",0)")).ToArray();

            var TotalConvert = ",(" + string.Join("+", TotalArray) + ") as Total ";


            string str = "select x.InsuranceIndividualId,InsuranceCouponId,isnull( CreateBy,'') as CreateBy,ApproveBy,CustomerName,VehicleRegnNo,isnull(EmailId,'') as EmailId , " + ArrayItem + " " + TotalConvert + " from  (select InsuranceIndividualId,InsuranceCouponId,CreateBy,ApproveBy,EmailId," + ArrayItem + " from( select x.InsuranceIndividualId, (select top 1 ISNULL(EmailId,'') from InsuranceCoupon where InsuranceCoupon.InsuranceIndividualId = (x.InsuranceIndividualId)  and Comp_Code= " + SiteSession.Comp_MstSession.Comp_Code + " and LEN( ISNULL(EmailId,''))>0) as EmailId , (select top 1 stuff(( select ',' + u.InsuranceCouponId from   (select convert (nvarchar(50), InsuranceCouponId)+'_'+convert (nvarchar(50), MasterId) InsuranceCouponId from InsuranceCoupon where InsuranceCoupon.InsuranceIndividualId in (x.InsuranceIndividualId) and    isnull( IsApprove,0)=1 and isnull(IsRedeem,0)=0 and Comp_Code= " + SiteSession.Comp_MstSession.Comp_Code + ") u for xml path('') ),1,1,'')) as  InsuranceCouponId, (select top 1 stuff(( select ',' + u.[User_Name] from   (select Distinct isnull(convert (nvarchar(50), [User_Name]),'') [User_Name] from User_Tbl where  User_Tbl.User_Code in (select CreatedBy from  InsuranceCoupon where InsuranceCoupon.InsuranceIndividualId=x.InsuranceIndividualId and isnull( IsApprove,0)=1 and isnull(IsRedeem,0)=0 and Comp_Code= " + SiteSession.Comp_MstSession.Comp_Code + ")) u for xml path('') ),1,1,'') ) as  CreateBy, (select top 1 stuff(( select ',' + u.[User_Name] from   (select Distinct isnull(convert (nvarchar(50), [User_Name]),'') [User_Name] from User_Tbl where  User_Tbl.User_Code in (select ApproveBy from  InsuranceCoupon where InsuranceCoupon.InsuranceIndividualId=x.InsuranceIndividualId and isnull( IsApprove,0)=1 and isnull(IsRedeem,0)=0 and Comp_Code= " + SiteSession.Comp_MstSession.Comp_Code + ")) u for xml path('') ),1,1,'') ) as  ApproveBy  ,replace( Name,' ','') as Name,TotalCoupon from (select InsuranceIndividualId,MasterId,COUNT(*) as TotalCoupon from  (select   InsuranceCouponId,MasterId,MobNo,InsuranceIndividualId from InsuranceCoupon  where   isnull( IsApprove,0)=1 and isnull(IsRedeem,0)=0 and Comp_Code= " + SiteSession.Comp_MstSession.Comp_Code + ") as x group by InsuranceIndividualId,MasterId ) as x  left join [Master] on x.MasterId=[Master].MasterId  ) d pivot  ( sum(TotalCoupon) for Name in (" + ArrayItem + ") ) piv) as x left join InsuranceIndividual on  x.InsuranceIndividualId=InsuranceIndividual.InsuranceIndividualId";
            DataTable dt = ConnModal.FillDataTable(str);

            //foreach (DataColumn dr in dt.Columns)
            //{
            //    if (!"InsuranceCouponId,InsuranceIndividualId,CustomerName,EmailId,CreateBy".Split(',').Contains(dr.ColumnName))
            //    {
            //        BoundField newColumnName = new BoundField();

            //        newColumnName.DataField = dr.ColumnName;
            //        newColumnName.HeaderText = Common.AddSpacesToSentence(dr.ColumnName);

            //        gvlocation.Columns.Add(newColumnName);
            //    }


            //}

            //HiddenField lnkView = new HiddenField();
            //lnkView.ID = "lnkView";
            //lnkView.Text = "View";
            //lnkView.Click += ViewDetails;
            //lnkView.CommandArgument = (e.Row.DataItem as DataRowView).Row["Id"].ToString();
            //e.Row.Cells[2].Controls.Add(lnkView);



            gvlocation.DataSource = dt;

            gvlocation.DataBind();
        }
        }
}